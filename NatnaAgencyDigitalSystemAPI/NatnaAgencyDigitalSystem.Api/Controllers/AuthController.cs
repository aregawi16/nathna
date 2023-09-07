using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NatnaAgencyDigitalSystem.Api.Resources;
using NatnaAgencyDigitalSystem.Api.Settings;
using NatnaAgencyDigitalSystem.Api.Models.Auth;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using Microsoft.EntityFrameworkCore;
using NatnaAgencyDigitalSystem.Data;
using Microsoft.AspNetCore.Authorization;

namespace NatnaAgencyDigitalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private NatnaAgencyDbContext _db;

        private readonly IConfiguration _configuration;

        private readonly JwtSettings _jwtSettings;

        public AuthController(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            NatnaAgencyDbContext db,
            IOptionsSnapshot<JwtSettings> jwtSettings,
             IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
            _jwtSettings = jwtSettings.Value;
            _configuration = configuration;

        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserLists()
        {
            var users = _userManager.Users.ToList();
             
            return Ok(users);
        }
        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult<User>> DeleteUser(Guid id)
        {
            var user =  _userManager.Users.FirstOrDefault(q=>q.Id==id);
            // Delete the user
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                // User deleted successfully
                return Ok();
            }
            else
            {
                // Failed to delete the user
                return BadRequest(result.Errors);
            }

        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserSignUpResource userSignUpResource)
        {
            var userExists = await _userManager.FindByNameAsync(userSignUpResource.UserName);
            if (userExists != null)
                return StatusCode(
                    StatusCodes.Status500InternalServerError, 
                    new NatnaAgencyDigitalSystem.Api.Settings.Response { Status = "Error", Message = "User already exists!" 
                    });

            User user = new()
            {
                Email = userSignUpResource.Email,
                MiddleName = userSignUpResource.MiddleName,
                LastName = userSignUpResource.LastName,
                OfficeId = userSignUpResource.OfficeId,
                FirstName = userSignUpResource.FirstName,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userSignUpResource.UserName
            };
            var result = await _userManager.CreateAsync(user, userSignUpResource.Password);

            if (!result.Succeeded)

                return StatusCode(StatusCodes.Status500InternalServerError, new NatnaAgencyDigitalSystem.Api.Settings.Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new NatnaAgencyDigitalSystem.Api.Settings.Response { Status = "Success", Message = "User created successfully!" });
        }

    

         [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(UserLoginResource userLoginResource)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userLoginResource.UserName);
            if (user is null)
            {
                return NotFound("User not found");
            }

            var userSigninResult = await _userManager.CheckPasswordAsync(user, userLoginResource.Password);

            if (userSigninResult)
            {
                var offce = _db.Offices.Find(user.OfficeId);
                var roles = await _userManager.GetRolesAsync(user);
                return Ok(new { 
                    AccessToken=GenerateJwt(user, roles),
                    IsHeadOffice=offce?.IsHeadOffice,
                    Roles = roles,
                    fullName = user.FullName
                });
            }

            return BadRequest("Email or password incorrect.");
        }

        [HttpPost("Roles")]
        public async Task<IActionResult> CreateRole(RoleResource role)
        {
            if (string.IsNullOrWhiteSpace(role.Name))
            {
                return BadRequest("Role name should be provided.");
            }

            var newRole = new Role
            {
                Name = role.Name
            };

            var roleResult = await _roleManager.CreateAsync(newRole);

            if (roleResult.Succeeded)
            {
                return Ok(roleResult);
            }

            return Problem(roleResult.Errors.First().Description, null, 500);
        } 
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {

            var roleResult = await _roleManager.Roles.ToListAsync();
                return Ok(roleResult);
            
        }

        [HttpPost("User/{userEmail}/Role")]
        public async Task<IActionResult> AddUserToRole(string userEmail, [FromBody] string roleName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userEmail);

            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                return Ok();
            }

            return Problem(result.Errors.First().Description, null, 500);
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddSeconds(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }


        private string GenerateJwt(User user, IList<string> roles)
        {

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                     issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24),
                         claims: claims,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}