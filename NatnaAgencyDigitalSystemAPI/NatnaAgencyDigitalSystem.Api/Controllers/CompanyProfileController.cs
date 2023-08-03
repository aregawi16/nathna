using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NatnaAgencyDigitalSystem.Api.Resources;
using NatnaAgencyDigitalSystem.Api.Validators;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Service.Services;
using NatnaAgencyDigitalSystem.Core.Models;

namespace NatnaAgencyDigitalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class CompanyProfileController : ControllerBase
    {
       
            private readonly ICompanyProfileService _CompanyProfileService;
            private readonly IMapper _mapper;

            public CompanyProfileController(ICompanyProfileService CompanyProfileService, IMapper mapper)
            {
                this._mapper = mapper;
                this._CompanyProfileService = CompanyProfileService;
            }

            [HttpGet("")]
            public async Task<ActionResult<IEnumerable<CompanyProfile>>> GetAllCompanyProfiles()
            {
                var CompanyProfiles = await _CompanyProfileService.GetAllCompanyProfiles();
                var CompanyProfileResource = _mapper.Map<IEnumerable<CompanyProfile>, IEnumerable<CompanyProfile>>(CompanyProfiles).ToList().OrderByDescending(o=>o.CompanyProfileId);

                return Ok(CompanyProfileResource);
            }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<CompanyProfile>>> GetCompanyProfileLists()
        {
            var CompanyProfiles = await _CompanyProfileService.GetAllCompanyProfiles();
            var CompanyProfileResource = _mapper.Map<IEnumerable<DropDownPObject>, IEnumerable<DropDownPObject>>(CompanyProfiles.ToList().Select(s => new DropDownPObject
            {
                id=s.CompanyProfileId,
                name = s.Name
            }));

            return Ok(CompanyProfileResource);
        }

        [HttpGet("{id}")]
            [Authorize(Roles = "Test")]
            public async Task<ActionResult<CompanyProfile>> GetCompanyProfileById(int id)
            {
                var CompanyProfile = await _CompanyProfileService.GetCompanyProfileById(id);
                var CompanyProfileResource = _mapper.Map<CompanyProfile, CompanyProfile>(CompanyProfile);

                return Ok(CompanyProfileResource);
            }

            [HttpPost("")]
            [Authorize(Roles ="OnlyTest")]
            public async Task<ActionResult<CompanyProfile>> CreateCompanyProfile([FromBody] CompanyProfile CompanyProfileRes)
            {
            CompanyProfileRes.CreatedBy = "1111";
            CompanyProfileRes.ModifiedBy = "1111";
            CompanyProfileRes.CreatedDate = DateTime.Now;
            CompanyProfileRes.ModifiedDate = DateTime.Now;
            var validator = new CompanyProfileValidator();
                var validationResult = await validator.ValidateAsync(CompanyProfileRes);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

                var CompanyProfileToCreate = _mapper.Map<CompanyProfile, CompanyProfile>(CompanyProfileRes);

                var newCompanyProfile = await _CompanyProfileService.CreateCompanyProfile(CompanyProfileToCreate);

                var CompanyProfile = await _CompanyProfileService.GetCompanyProfileById(newCompanyProfile.CompanyProfileId);

                var CompanyProfileResource = _mapper.Map<CompanyProfile, CompanyProfile>(CompanyProfile);

                return Ok(CompanyProfileResource);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<CompanyProfile>> UpdateCompanyProfile(int id, [FromBody] CompanyProfile CompanyProfileRes)
            {
                var validator = new CompanyProfileValidator();
                var validationResult = await validator.ValidateAsync(CompanyProfileRes);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

                var CompanyProfileToBeUpdated = await _CompanyProfileService.GetCompanyProfileById(id);

                if (CompanyProfileToBeUpdated == null)
                    return NotFound();

                var CompanyProfile = _mapper.Map<CompanyProfile, CompanyProfile>(CompanyProfileRes);

                await _CompanyProfileService.UpdateCompanyProfile(CompanyProfileToBeUpdated, CompanyProfile);

                var updatedCompanyProfile = await _CompanyProfileService.GetCompanyProfileById(id);

                var updatedCompanyProfileResource = _mapper.Map<CompanyProfile, CompanyProfile>(updatedCompanyProfile);

                return Ok(updatedCompanyProfileResource);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCompanyProfile(int id)
            {
                var CompanyProfile = await _CompanyProfileService.GetCompanyProfileById(id);

                await _CompanyProfileService.DeleteCompanyProfile(CompanyProfile);

                return Ok("Deleted");
            }
        }

    }
