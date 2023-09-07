using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Auth;
using NatnaAgencyDigitalSystem.Api.Models.Common;
using NatnaAgencyDigitalSystem.Api.Resources;
using NatnaAgencyDigitalSystem.Core.Models;
using NatnaAgencyDigitalSystem.Data;
using System.Data;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace NatnaAgencyDigitalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessManagementController : ControllerBase
    {
        private NatnaAgencyDbContext _db;
        private readonly UserManager<User> _userManager;
        private IHostingEnvironment Environment;

        public ProcessManagementController(IHostingEnvironment _environment, NatnaAgencyDbContext db, UserManager<User> userManager)
        {
            this._db = db;
            this._userManager = userManager;
            Environment = _environment;



        }

        [HttpPost("placement")]
        public async Task<ActionResult<ApplicantProfile>> placeApplicant(ApplicantPlacementResource ApplicantPlacmentRes)
        {

            var placements = new List<ApplicantPlacement>();
            IQueryable<ApplicantProfile> applicants = _db.ApplicantProfiles.Where(q=> ApplicantPlacmentRes.applicantIds.Contains(q.ApplicantProfileId));

            foreach (var applicantId in ApplicantPlacmentRes.applicantIds)
            {
                var applicant = applicants.FirstOrDefault(q=>q.ApplicantProfileId== applicantId);
                if (applicant != null)
                {
                    applicant.Status = Status.Placement;
                    _db.ApplicantProfiles.Attach(applicant);
                    _db.Entry(applicant).State = EntityState.Modified;
                }
                var placement = new ApplicantPlacement();
                placement.ApplicantProfileId = applicantId;
                placement.OfficeId = ApplicantPlacmentRes.officeId;
                placement.CreatedBy = User.Identity.Name;
                placement.ModifiedBy = User.Identity.Name;
                placement.CreatedDate = DateTime.Now;
                placement.ModifiedDate = DateTime.Now;
                _db.ApplicantPlacements.Add(placement);

                UpdateStatus(applicantId, applicant.Status, ApplicantPlacementStatus.Assigned.ToString());

            }
            _db.SaveChanges();


            return Ok(ApplicantPlacmentRes);
        }

        private void UpdateStatus(int applicantId, Status status, string levelStatus)
        {
            var applicantStatus = new ApplicantStatus();
            applicantStatus.ApplicantProfileId = applicantId;
            applicantStatus.OfficeLevel = status.ToString();
            applicantStatus.OfficeLevel = status.ToString();
            applicantStatus.Status = levelStatus;
            applicantStatus.CreatedBy = User.Identity.Name;
            applicantStatus.ModifiedBy = User.Identity.Name;
            applicantStatus.CreatedDate = DateTime.Now;
            applicantStatus.ModifiedDate = DateTime.Now;
            _db.ApplicantStatuses.Add(applicantStatus);


        }

        [HttpPost("selectApplicant")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> updateApplicantProfileStatus([FromBody] ApplicantPLacementResource selectRes)
        {
            var applicantPlacementStatus = _db.ApplicantPlacements.Where(q => q.ApplicantProfileId == selectRes.applicantId).FirstOrDefault();
            if (applicantPlacementStatus != null)
            {
                UpdateStatus(selectRes.applicantId, Status.Placement, ApplicantPlacementStatus.Selected.ToString());

                _db.SaveChanges();
            }
            return Ok();
        }
        [HttpPost("approveApplicant")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> approveApplicantProfileStatus([FromBody] List<int> ids)
        {
            foreach(int id in ids)
            {
                UpdateStatus(id, Status.Placement, ApplicantPlacementStatus.Approved.ToString());

                _db.SaveChanges();
            }
            return Ok();
        }

        [HttpPost("receiveContractAgreement")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> updateApplicantContractStatus([FromBody] ApplicantContractResource selectRes)
        {
            var applicantContractStatus = _db.ApplicantStatuses.Where(q => q.ApplicantProfileId == selectRes.applicantId).FirstOrDefault();
            if (applicantContractStatus != null)
            {
                UpdateStatus(selectRes.applicantId, Status.ContractAgreement, ApplicantContractStatus.Received.ToString());

                _db.SaveChanges();
                return Ok("Updated");

            }
            return Ok(404);
        }
        [HttpPost("verifyContractAgreement")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> verifyContractAgreement([FromForm] ApplicantContractVerificationResource applicantContractVerification)
        {
            var applicantContractStatus = _db.ApplicantStatuses.Where(q => q.ApplicantProfileId == applicantContractVerification.applicantId).FirstOrDefault();

            if (applicantContractStatus != null)
            {
                var applicantContract = new ApplicantContractAgreement();
                applicantContract.ApplicantProfileId = applicantContractVerification.applicantId;
                applicantContract.Price = applicantContractVerification.price;
                applicantContract.CreatedBy = User.Identity.Name;
                applicantContract.ModifiedBy = User.Identity.Name;
                applicantContract.CreatedDate = DateTime.Now;
                applicantContract.ModifiedDate = DateTime.Now;
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                string path = Path.Combine("", "NathnaDocuments");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var NibConstantFileName = "NIB" + applicantContractVerification.applicantId.ToString();
                string extention = Path.GetExtension(applicantContractVerification.verifiedContractDocument.FileName);

                string fileName = NibConstantFileName + "VerifiedContractAgreement" + extention;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    applicantContractVerification.verifiedContractDocument.CopyTo(stream);
                    applicantContract.ContractFilePath = Path.Combine(path, fileName);
                    //applicantContract.ContractFilePath = Path.Combine(path, fileName);
                }

                _db.ApplicantContractAgreements.Add(applicantContract);
                UpdateStatus(applicantContractVerification.applicantId, Status.ContractAgreement, ApplicantContractStatus.Verified.ToString());

                _db.SaveChanges();
                return Ok("Updated");

            }
            return Ok(404);
        }
        [HttpPost("uploadVerifiedDocument")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> uploadVerifiedDocument([FromForm] VerifiedDocumentResource verifiedDocumentRes)
        {
            var applicantDocument = _db.ApplicantDocuments.Where(q => q.ApplicantProfileId == verifiedDocumentRes.applicantId).FirstOrDefault();
            if (applicantDocument != null)
            {

                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                string path = Path.Combine("", "NathnaDocuments");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var NibConstantFileName = "NIB" + verifiedDocumentRes.applicantId.ToString();
                string extention = Path.GetExtension(verifiedDocumentRes.medicalDocument.FileName);

                string fileName = NibConstantFileName + "MEDICAL" + extention;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    verifiedDocumentRes.medicalDocument.CopyTo(stream);
                    applicantDocument.ApplicantMedicalDocumentPath = Path.Combine(path, fileName);

                }
                extention = Path.GetExtension(verifiedDocumentRes.crimeFreeDocument.FileName);
                fileName = NibConstantFileName + "CRIME" + extention;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    verifiedDocumentRes.crimeFreeDocument.CopyTo(stream);
                    applicantDocument.ApplicantCrimeCheckfreeDocumentPath = Path.Combine(path, fileName);

                }

                UpdateStatus(verifiedDocumentRes.applicantId, Status.Placement, ApplicantPlacementStatus.DocumentVerified.ToString());
                _db.ApplicantDocuments.Attach(applicantDocument);
                _db.Entry(applicantDocument).State = EntityState.Modified;
                _db.SaveChanges();
                return Ok(200);

            }

            return Ok("Not Found");
        }


        [HttpPost("completeInsurance")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> completeInsurance([FromForm] InsuranceResource applicantInsurance)
        {
            var applicantInsuranceStatus = _db.ApplicantStatuses.Where(q => q.ApplicantProfileId == applicantInsurance.applicantId).FirstOrDefault();

            if (applicantInsuranceStatus != null)
            {
                var applicantInsuranceObj = new ApplicantInsurance();
                applicantInsuranceObj.ApplicantProfileId = applicantInsurance.applicantId;
                applicantInsuranceObj.Price = applicantInsurance.price;
                applicantInsuranceObj.CreatedBy = User.Identity.Name;
                applicantInsuranceObj.ModifiedBy = User.Identity.Name;
                applicantInsuranceObj.CreatedDate = DateTime.Now;
                applicantInsuranceObj.ModifiedDate = DateTime.Now;
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                string path = Path.Combine("", "NathnaDocuments");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var NibConstantFileName = "NIB" + applicantInsurance.applicantId.ToString();
                string extention = Path.GetExtension(applicantInsurance.insuranceDocument.FileName);

                string fileName = NibConstantFileName + "CompletedInsurance" + extention;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    applicantInsurance.insuranceDocument.CopyTo(stream);
                    applicantInsuranceObj.InsuranceFilePath = Path.Combine(path, fileName);
                    //applicantContract.ContractFilePath = Path.Combine(path, fileName);
                }

                _db.ApplicantInsurances.Add(applicantInsuranceObj);
                UpdateStatus(applicantInsurance.applicantId, Status.Insurance, ApplicantInsuranceStatus.Completed.ToString());

                _db.SaveChanges();
                return Ok("Updated");

            }
            return Ok(404);
        }

        [HttpPost("requestInsurance")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> requestInsurance([FromBody] ApplicantInsuranceResource applicantInsuranceResource)
        {
            var applicantPlacementStatus = _db.ApplicantPlacements.Where(q => q.ApplicantProfileId == applicantInsuranceResource.applicantId).FirstOrDefault();
            if (applicantPlacementStatus != null)
            {
                UpdateStatus(applicantInsuranceResource.applicantId, Status.Insurance, ApplicantInsuranceStatus.Requested.ToString());

                _db.SaveChanges();
                return Ok("200");

            }
            return Ok("404");
        }

        [HttpPost("completeCoC")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> completeCoC([FromForm] ApplicantCoCResource applicantCocResource)
        {
            var applicantInsuranceStatus = _db.ApplicantStatuses.Where(q => q.ApplicantProfileId == applicantCocResource.applicantId).FirstOrDefault();

            if (applicantInsuranceStatus != null)
            {
                var applicantCoCObj = new CoC();
                applicantCoCObj.ApplicantProfileId = applicantCocResource.applicantId;
                applicantCoCObj.TrainedPlaceName = applicantCocResource.trainedPlaceName;
                applicantCoCObj.TrainedPlaceAddress = applicantCocResource.trainedPlaceAddress;
                applicantCoCObj.TrainedSkill = applicantCocResource.trainedSkill;
                applicantCoCObj.CertificateTakenPlaceName = applicantCocResource.certificateTakenPlaceName;
                applicantCoCObj.CertificateTakenAddress = applicantCocResource.certificateTakenAddress;
                applicantCoCObj.Description = applicantCocResource.description;
                applicantCoCObj.CreatedBy = User.Identity.Name;
                applicantCoCObj.ModifiedBy = User.Identity.Name;
                applicantCoCObj.CreatedDate = DateTime.Now;
                applicantCoCObj.ModifiedDate = DateTime.Now;
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                if (applicantCocResource.cocCertificateFile != null)
                {

                    string path = Path.Combine("", "NathnaDocuments");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var NibConstantFileName = "NIB" + applicantCocResource.applicantId.ToString();
                    string extention = Path.GetExtension(applicantCocResource.cocCertificateFile.FileName);

                    string fileName = NibConstantFileName + "CoCCertificate" + extention;
                    using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        applicantCocResource.cocCertificateFile.CopyTo(stream);
                        applicantCoCObj.CertificateFilePath = Path.Combine(path, fileName);
                    }
                }


                _db.CoCs.Add(applicantCoCObj);
                UpdateStatus(applicantCocResource.applicantId, Status.CoC, ApplicantCocStatus.Completed.ToString());

                _db.SaveChanges();
                return Ok("Updated");

            }
            return Ok(404);

        }

    

        [HttpPost("requestCoc")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> requestCoc([FromBody] ApplicantCocStstusResource applicantcocResource)
        {
            var applicantPlacementStatus = _db.ApplicantPlacements.Where(q => q.ApplicantProfileId == applicantcocResource.applicantId).FirstOrDefault();
            if (applicantPlacementStatus != null)
            {
                UpdateStatus(applicantcocResource.applicantId, Status.CoC, ApplicantCocStatus.Requested.ToString());

                _db.SaveChanges();
            }
            return Ok();
        }

        [HttpPost("uploadContractDocument")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> uploadContractDocument([FromForm] ContractDocumentResource contractDocumentRes)
        {
            var applicantDocument = _db.ApplicantDocuments.Where(q => q.ApplicantProfileId == contractDocumentRes.applicantId).FirstOrDefault();
            if (applicantDocument != null)
            {
                //var applicantContract = new ApplicantContractAgreement();
                //applicantContract.ApplicantProfileId = contractDocumentRes.applicantId;
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                string path = Path.Combine("", "NathnaDocuments");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var NibConstantFileName = "NIB" + contractDocumentRes.applicantId.ToString();
                string extention = Path.GetExtension(contractDocumentRes.contractDocument.FileName);

                string fileName = NibConstantFileName + "ContractAgreement" + extention;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    contractDocumentRes.contractDocument.CopyTo(stream);
                    applicantDocument.ApplicantContractAgreementPath = Path.Combine(path, fileName);
                    //applicantContract.ContractFilePath = Path.Combine(path, fileName);
                }

                var applicantPlacement = _db.ApplicantPlacements.Where(q => q.ApplicantProfileId == contractDocumentRes.applicantId).FirstOrDefault();
                UpdateStatus(contractDocumentRes.applicantId, Status.Placement, ApplicantPlacementStatus.Accepted.ToString());
                UpdateStatus(contractDocumentRes.applicantId, Status.ContractAgreement, ApplicantContractStatus.Ready.ToString());

                _db.ApplicantDocuments.Attach(applicantDocument);
                _db.Entry(applicantDocument).State = EntityState.Modified;
                _db.SaveChanges();
                return Ok(200);

            }

            return Ok(404);
        }



        [HttpPost("requestYellowRecord")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> requestYellowRecord([FromForm] ApplicantLabourResource applicantLabourResource)
        {
            var applicantStatus = _db.ApplicantStatuses.Where(q => q.ApplicantProfileId == applicantLabourResource.applicantId).FirstOrDefault();
            if (applicantStatus != null)
            {
                var applicantLabourObj = new ApplicantLabourOffice();

                applicantLabourObj.ApplicantProfileId = applicantLabourResource.applicantId;
                applicantLabourObj.CreatedBy = User.Identity.Name;
                applicantLabourObj.ModifiedBy = User.Identity.Name;
                applicantLabourObj.CreatedDate = DateTime.Now;
                applicantLabourObj.ModifiedDate = DateTime.Now;
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;
                string path = Path.Combine("", "NathnaDocuments");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var NibConstantFileName = "NIB" + applicantLabourResource.applicantId.ToString();
                string extention = Path.GetExtension(applicantLabourResource.labourDocument.FileName);

                string fileName = NibConstantFileName + "LabourOfficeDocument" + extention;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    applicantLabourResource.labourDocument.CopyTo(stream);
                    applicantLabourObj.LabourOfficeDocumentFilePath = Path.Combine(path, fileName);
                    //applicantContract.ContractFilePath = Path.Combine(path, fileName);
                }

                 extention = Path.GetExtension(applicantLabourResource.preFlightTrainingCertficate.FileName);

                 fileName = NibConstantFileName + "PreFlightTrainingCertificate" + extention;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    applicantLabourResource.preFlightTrainingCertficate.CopyTo(stream);
                    applicantLabourObj.PreFlightTrainingCertficatePath = Path.Combine(path, fileName);
                    //applicantContract.ContractFilePath = Path.Combine(path, fileName);
                }


                UpdateStatus(applicantLabourResource.applicantId, Status.MinistryOfLabor, ApplicantLabourStatus.Requested.ToString());

                _db.ApplicantLabourOffices.Add(applicantLabourObj);
                _db.SaveChanges();
                return Ok(200);
            }
            return Ok(404);

        }
        [HttpPost("receiveYellowRecord")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> receiveYellowRecord([FromForm] ApplicantLabourResource applicantLabourResource)
        {
            var applicantStatus = _db.ApplicantStatuses.Where(q => q.ApplicantProfileId == applicantLabourResource.applicantId).FirstOrDefault();
            var applicantLabourObj = _db.ApplicantLabourOffices.Where(q => q.ApplicantProfileId == applicantLabourResource.applicantId).FirstOrDefault();
            if (applicantStatus != null && applicantLabourObj != null)
            {

                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;
                string path = Path.Combine("", "NathnaDocuments");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                applicantLabourObj.Price = (decimal)applicantLabourResource.price;
                var NibConstantFileName = "NIB" + applicantLabourResource.applicantId.ToString();
                string extention = Path.GetExtension(applicantLabourResource.yellowCardDocument.FileName);

                string fileName = NibConstantFileName + "YellowCardDocument" + extention;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    applicantLabourResource.yellowCardDocument.CopyTo(stream);
                    applicantLabourObj.YellowCardFilePath = Path.Combine(path, fileName);
                }

                UpdateStatus(applicantLabourResource.applicantId, Status.MinistryOfLabor, ApplicantLabourStatus.YellowCardReceived.ToString());
                UpdateStatus(applicantLabourResource.applicantId, Status.Ticket, ApplicantFlightTicketStatus.Requested.ToString());

                _db.ApplicantLabourOffices.Attach(applicantLabourObj);
                _db.Entry(applicantLabourObj).State = EntityState.Modified;
                _db.SaveChanges();
                return Ok(200);
            }
            return Ok(404);

        }

        [HttpPost("verifyFlightTcket")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> verifyFlightTcket([FromForm] ApplicantFlightTicketResource applicantFlightTicketResource)
        {
            var applicantStatus = _db.ApplicantStatuses.Where(q => q.ApplicantProfileId == applicantFlightTicketResource.applicantId).FirstOrDefault(); if (applicantStatus != null)
            {
                var applicantFlightTicketObj = new ApplicantFlightTicket();
                applicantFlightTicketObj.ApplicantProfileId = applicantFlightTicketResource.applicantId;
                applicantFlightTicketObj.CreatedBy = User.Identity.Name;
                applicantFlightTicketObj.ModifiedBy = User.Identity.Name;
                applicantFlightTicketObj.CreatedDate = DateTime.Now;
                applicantFlightTicketObj.ModifiedDate = DateTime.Now;
                applicantFlightTicketObj.Price = (decimal)applicantFlightTicketResource.price;

                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;
                string path = Path.Combine("", "NathnaDocuments");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var NibConstantFileName = "NIB" + applicantFlightTicketResource.applicantId.ToString();
                string extention = Path.GetExtension(applicantFlightTicketResource.flightTicketDocument.FileName);

                string fileName = NibConstantFileName + "FlightTicket" + extention;
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    applicantFlightTicketResource.flightTicketDocument.CopyTo(stream);
                    applicantFlightTicketObj.TicketFilePath = Path.Combine(path, fileName);
                }

                UpdateStatus(applicantFlightTicketResource.applicantId, Status.Ticket, ApplicantFlightTicketStatus.Verified.ToString());

                _db.ApplicantFlightTickets.Add(applicantFlightTicketObj);
                _db.SaveChanges();
                return Ok(200);
            }
            return Ok(404);

        }

        [HttpPost("followFlight")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> followFlight([FromBody] ApplicantFlightResource flightRes)
        {
            var applicantPlacementStatus = _db.ApplicantPlacements.Where(q => q.ApplicantProfileId == flightRes.applicantId).FirstOrDefault();
            if (applicantPlacementStatus != null)
            {
                UpdateStatus(flightRes.applicantId, Status.Ticket, flightRes.status.ToString());

                _db.SaveChanges();
            }
            return Ok();
        }
    }



}
