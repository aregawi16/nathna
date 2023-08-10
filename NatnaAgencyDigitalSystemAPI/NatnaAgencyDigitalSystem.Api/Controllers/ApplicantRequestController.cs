using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NatnaAgencyDigitalSystem.Api.Resources;
using NatnaAgencyDigitalSystem.Api.Validators;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Service.Services;
using NatnaAgencyDigitalSystem.Data;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using NatnaAgencyDigitalSystem.Api.Models.Auth;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using NatnaAgencyDigitalSystem.Api.Models.Common;
using Microsoft.EntityFrameworkCore;
using NatnaAgencyDigitalSystem.Core.Models.Common;
using NatnaAgencyDigitalSystem.Data.Pagination.Extensions;
using DocumentFormat.OpenXml.Bibliography;
using System.Text.Json;
using NatnaAgencyDigitalSystem.Service;

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

        [HttpPost("list")]
        public async Task<ActionResult<Page<ApplicantProfile>>> GetAllApplicantProfiles(Pageable pageable, int id, int? officeId,string? search)
        {
            pageable.PageNumber = pageable.PageNumber-1;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var applicantProfiles = await _ApplicantProfileService.GetAllWithStatusAsync(pageable, user, id, officeId, search);



                //var ApplicantProfileResource = _mapper.Map<IEnumerable<ApplicantProfile>, IEnumerable<ApplicantProfile>>(ApplicantProfiles);


                return Ok(applicantProfiles);
            }
            return Ok();


        }






        private void UploadDocuments([FromForm] ApplicantDocumentResource ApplicantDocRes)

        {
            var appDoc = new ApplicantDocumentResource();
            var appDocument = new ApplicantDocument();
            var applicantDetail = _db.ApplicantProfiles.Find(ApplicantDocRes.ApplicantProfileId);
            string fullName = applicantDetail?.FirstName + "_" + applicantDetail?.MiddleName + "_" + applicantDetail?.MiddleName;
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine("", "NathnaDocuments/" + fullName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var NibConstantFileName = "NIB" + ApplicantDocRes.ApplicantProfileId.ToString();

            if (ApplicantDocRes.applicantId != null)
            {
                string extention = Path.GetExtension(ApplicantDocRes.applicantId.FileName);
                string fileName = NibConstantFileName + "ID" + extention;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    ApplicantDocRes.applicantId.CopyTo(stream);
                    appDocument.ApplicantIdFilePath = Path.Combine(path, fileName);

                }
            }

            if (ApplicantDocRes.applicantPassport != null)
            {
                string extention = Path.GetExtension(ApplicantDocRes.applicantPassport.FileName);
                string fileName = NibConstantFileName + "Passport" + extention;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    ApplicantDocRes.applicantPassport.CopyTo(stream);
                    appDocument.ApplicantPassportFilePath = Path.Combine(path, fileName);

                }
            }
            if (ApplicantDocRes.applicantShortPhoto != null)
            {
                var extention = Path.GetExtension(ApplicantDocRes.applicantShortPhoto.FileName);
                var fileName = NibConstantFileName + "SmallPhoto" + extention;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    ApplicantDocRes.applicantShortPhoto.CopyTo(stream);
                    appDocument.ApplicantSmallPhotoPath = Path.Combine(path, fileName);

                }
            }
            if (ApplicantDocRes.applicantFullPhoto != null)
            {
                var extention = Path.GetExtension(ApplicantDocRes.applicantFullPhoto.FileName);
                var fileName = NibConstantFileName + "FullPhoto" + extention;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    ApplicantDocRes.applicantFullPhoto.CopyTo(stream);
                    appDocument.ApplicantFullPhotoPath = Path.Combine(path, fileName);

                }
            }
            if (ApplicantDocRes.applicantVideo != null)
            {
                var extention = Path.GetExtension(ApplicantDocRes.applicantVideo.FileName);
                var fileName = NibConstantFileName + "Video" + extention;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    ApplicantDocRes.applicantVideo.CopyTo(stream);
                    appDocument.ApplicantVideoPath = Path.Combine(path, fileName);

                }
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

            // return Ok(appDocument);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult<ApplicantProfile>> GetApplicantProfileById(int id)
        {
            var ApplicantProfile = await _ApplicantProfileService.GetWithWorkExperienceByIdAsync(id);
            var ApplicantProfileResource = _mapper.Map<ApplicantProfile, ApplicantProfile>(ApplicantProfile);

            return Ok(ApplicantProfileResource);
        }

        [HttpPost("")]
        [RequestSizeLimit(20 * 1024 * 1024)]
        //  [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult<ApplicantProfile>> CreateApplicantProfile([FromForm] ApplicantProfileResource ApplicantProfileRes)
        {


            var validator = new ApplicantProfileValidator();
            // ApplicantProfile appRes = JsonSerializer.Deserialize<ApplicantProfile>(ApplicantProfileRes.ToString());
            ApplicantProfileRes.CreatedBy = "1111";
            ApplicantProfileRes.ModifiedBy = "1111";
            ApplicantProfileRes.CreatedDate = DateTime.Now;
            ApplicantProfileRes.ModifiedDate = DateTime.Now;
            ApplicantProfileRes.DoB = ApplicantProfileRes.DoB.AddDays(1);
            ApplicantProfileRes.PassportIssueDate = ApplicantProfileRes.PassportIssueDate.AddDays(1);
            ApplicantProfileRes.PassportExpiryDate = ApplicantProfileRes.PassportExpiryDate.AddDays(1);

            //var validationResult = await validator.ValidateAsync(ApplicantProfileRes);

            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var ApplicantProfileToCreate = _mapper.Map<ApplicantProfileResource, ApplicantProfile>(ApplicantProfileRes);

            var newApplicantProfile = await _ApplicantProfileService.CreateApplicantProfile(ApplicantProfileToCreate);

            var ApplicantProfile = await _ApplicantProfileService.GetApplicantProfileById(newApplicantProfile.ApplicantProfileId);

            var ApplicantProfileResource = _mapper.Map<ApplicantProfile, ApplicantProfile>(ApplicantProfile);

            var apppResource = new ApplicantDocumentResource();
            apppResource.ApplicantProfileId = newApplicantProfile.ApplicantProfileId;
            apppResource.applicantPassport = ApplicantProfileRes.applicantPassport;
            apppResource.applicantFullPhoto = ApplicantProfileRes.applicantFullPhoto;
            apppResource.applicantShortPhoto = ApplicantProfileRes.applicantShortPhoto;
            apppResource.applicantId = ApplicantProfileRes.applicantId;
            apppResource.contactDocument = ApplicantProfileRes.contactDocument;
            apppResource.applicantVideo = ApplicantProfileRes.applicantVideo;
            UploadDocuments(apppResource);
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

        [HttpGet("getApplicantsForTraining")]
        public async Task<ActionResult<ApplicantProfile>> getApplicantsForTraining()
        {
            var appIds = _db.ApplicantStatuses.Where(q => q.OfficeLevel == Status.CoC.ToString()
            && q.Status == ApplicantCocStatus.Completed.ToString()
            ).Select(s => s.ApplicantProfileId).ToList();

            var applicants = _db.ApplicantProfiles.Where(q => appIds.Contains(q.ApplicantProfileId))
                                                   .Select(s => new
                                                   {
                                                       id = s.ApplicantProfileId,
                                                       name = $"{s.FirstNameAm} {s.MiddleName} {s.LastNameAm} "
                                                   })
                                                  .ToList();


            return Ok(applicants);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "OnlyTest")]
        public async Task<IActionResult> DeleteApplicantProfile(int id)
        {
            var ApplicantProfile = await _ApplicantProfileService.GetApplicantProfileById(id);

            await _ApplicantProfileService.DeleteApplicantProfile(ApplicantProfile);

            return Ok("Deleted");
        }



        [HttpDelete("reject/{id}")]
        public async Task<IActionResult> RejectApplicantProfile(int id)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var statuses = _db.ApplicantStatuses.Where(q => q.ApplicantProfileId == id).ToList();
            var offices = _db.ApplicantPlacements.Where(q => q.ApplicantProfileId == id).ToList();
            _db.ApplicantStatuses.RemoveRange(statuses);
            _db.ApplicantPlacements.RemoveRange(offices);
            _db.SaveChanges();

            return Ok("Rejected");
        }
    }

}
