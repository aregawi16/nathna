using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NatnaAgencyDigitalSystem.Api.Resources;
using NatnaAgencyDigitalSystem.Api.Validators;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Services;
using NatnaAgencyDigitalSystem.Data;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using NatnaAgencyDigitalSystem.Api.Models.Auth;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NatnaAgencyDigitalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class ApplicantProfileController : ControllerBase
    {
        private IHostingEnvironment Environment;
        private readonly IApplicantProfileService _ApplicantProfileService;
        private readonly IMapper _mapper;
        private NatnaAgencyDbContext _db;
        private readonly UserManager<User> _userManager;

        public ApplicantProfileController(IApplicantProfileService ApplicantProfileService, IMapper mapper, IHostingEnvironment _environment, NatnaAgencyDbContext db, UserManager<User> userManager)
        {
            this._mapper = mapper;
            this._ApplicantProfileService = ApplicantProfileService;
            Environment = _environment;
            this._db = db;
            this._userManager = userManager;

        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ApplicantProfile>>> GetAllApplicantProfiles()
        {
         
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var appPlacmentIds = _db.ApplicantPlacements.Where(q => q.OfficeId == user.OfficeId).Select(s => s.ApplicantProfileId);
                var ApplicantProfiles = await _ApplicantProfileService.GetAllWithStatusAsync();

                var office = await _db.Offices.FindAsync(user.OfficeId);
                if(office != null)
                {
                  if(office.IsHeadOffice)
                    {
                        if(!User.IsInRole("admin"))
                            {
                            ApplicantProfiles = ApplicantProfiles.Where(q =>q.CreatedBy == User.Identity.Name);
                        }
                    }
                    else
                    {
                        ApplicantProfiles = ApplicantProfiles.Where(q => appPlacmentIds.Contains(q.ApplicantProfileId));

                    }
                }

                var ApplicantProfileResource = _mapper.Map<IEnumerable<ApplicantProfile>, IEnumerable<ApplicantProfile>>(ApplicantProfiles);


                return Ok(ApplicantProfileResource);
            }
            return Ok();


        }


      



        [HttpPost("upload")]
        public async Task<ActionResult<ApplicantDocumentResource>> UploadDocuments([FromForm] ApplicantDocumentResource ApplicantDocRes)

        {
            var appDoc = new ApplicantDocumentResource();
            var appDocument = new ApplicantDocument();

            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine("", "NathnaDocuments");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            var NibConstantFileName = "NIB" + ApplicantDocRes.ApplicantProfileId.ToString();
            string extention = Path.GetExtension(ApplicantDocRes.applicantId.FileName);

            string fileName = NibConstantFileName + "ID"+ extention;
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {    
                ApplicantDocRes.applicantId.CopyTo(stream);
                appDocument.ApplicantIdFilePath= Path.Combine(path, fileName); 

            }
             extention = Path.GetExtension(ApplicantDocRes.applicantPassport.FileName);
            fileName = NibConstantFileName + "Passport"+extention;
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                ApplicantDocRes.applicantPassport.CopyTo(stream);
                appDocument.ApplicantPassportFilePath= Path.Combine(path, fileName); 

            }
            extention = Path.GetExtension(ApplicantDocRes.applicantShortPhoto.FileName);
            fileName = NibConstantFileName + "SmallPhoto"+extention;
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                ApplicantDocRes.applicantShortPhoto.CopyTo(stream);
                appDocument.ApplicantSmallPhotoPath= Path.Combine(path, fileName);

            }
            extention = Path.GetExtension(ApplicantDocRes.applicantFullPhoto.FileName);
            fileName = NibConstantFileName + "FullPhoto"+ extention;
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                ApplicantDocRes.applicantFullPhoto.CopyTo(stream);
                appDocument.ApplicantFullPhotoPath= Path.Combine(path, fileName);

            }
            extention = Path.GetExtension(ApplicantDocRes.applicantVideo.FileName);
            fileName = NibConstantFileName + "Video"+extention;
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                ApplicantDocRes.applicantVideo.CopyTo(stream);
                appDocument.ApplicantVideoPath= Path.Combine(path, fileName);

            }
            appDocument.ApplicantProfileId = ApplicantDocRes.ApplicantProfileId;

            _db.ApplicantDocuments.Add(appDocument);
            _db.SaveChanges();
            //fileName = Path.GetFileName(ApplicantDocRes.contactDocument.FileName);
            //using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            //{
            //    ApplicantDocRes.contactDocument.CopyTo(stream);
            //    appDocument. = fileName;

            //}

            return Ok(appDocument);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Test")]
        public async Task<ActionResult<ApplicantProfile>> GetApplicantProfileById(int id)
        {
            var ApplicantProfile = await _ApplicantProfileService.GetWithWorkExperienceByIdAsync(id);
            var ApplicantProfileResource = _mapper.Map<ApplicantProfile, ApplicantProfile>(ApplicantProfile);

            return Ok(ApplicantProfileResource);
        }

        [HttpPost("")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult<ApplicantProfile>> CreateApplicantProfile([FromBody] ApplicantProfileResource ApplicantProfileRes)
        {
            ApplicantProfileRes.CreatedBy = "1111";
            ApplicantProfileRes.ModifiedBy = "1111";
            ApplicantProfileRes.CreatedDate = DateTime.Now;
            ApplicantProfileRes.ModifiedDate = DateTime.Now;

            var validator = new ApplicantProfileValidator();

            var validationResult = await validator.ValidateAsync(ApplicantProfileRes);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var ApplicantProfileToCreate = _mapper.Map<ApplicantProfileResource, ApplicantProfile>(ApplicantProfileRes);

            var newApplicantProfile = await _ApplicantProfileService.CreateApplicantProfile(ApplicantProfileToCreate);

            var ApplicantProfile = await _ApplicantProfileService.GetApplicantProfileById(newApplicantProfile.ApplicantProfileId);

            var ApplicantProfileResource = _mapper.Map<ApplicantProfile, ApplicantProfile>(ApplicantProfile);

            return Ok(ApplicantProfileResource);
        }


            [HttpPut("{id}")]
            public async Task<ActionResult<ApplicantProfile>> UpdateApplicantProfile(int id, [FromBody] ApplicantProfileResource applicantProfile)
            {
                var validator = new ApplicantProfileValidator();
                var validationResult = await validator.ValidateAsync(applicantProfile);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

                var ApplicantProfileToBeUpdated = await _ApplicantProfileService.GetApplicantProfileById(id);

                if (ApplicantProfileToBeUpdated == null)
                    return NotFound();

                var ApplicantProfile = _mapper.Map<ApplicantProfileResource, ApplicantProfile>(applicantProfile);

                await _ApplicantProfileService.UpdateApplicantProfile(ApplicantProfileToBeUpdated, ApplicantProfile);

                var updatedApplicantProfile = await _ApplicantProfileService.GetApplicantProfileById(id);

                var updatedApplicantProfileResource = _mapper.Map<ApplicantProfile, ApplicantProfile>(updatedApplicantProfile);

                return Ok(updatedApplicantProfileResource);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteApplicantProfile(int id)
            {
                var ApplicantProfile = await _ApplicantProfileService.GetApplicantProfileById(id);

                await _ApplicantProfileService.DeleteApplicantProfile(ApplicantProfile);

                return NoContent();
            }
        }

}
