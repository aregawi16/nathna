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
    public class SchedulePreflightTrainingController :  ControllerBase
    {
        private NatnaAgencyDbContext _db;
    private readonly UserManager<User> _userManager;
    private IHostingEnvironment Environment;

       
        public SchedulePreflightTrainingController(IHostingEnvironment _environment, NatnaAgencyDbContext db, UserManager<User> userManager)
    {
        this._db = db;
        this._userManager = userManager;
        Environment = _environment;

    }

        [HttpPost("schedulePreflightTraining")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> schedulePreflightTraining([FromBody] ApplicantPreflightTrainingResource applicantPreflightTrainingResource)

        {

            var preFlightTraining = new PreFlightTraining();
            preFlightTraining.ScheduledDate = applicantPreflightTrainingResource.scheduledDate;
            preFlightTraining.Place = applicantPreflightTrainingResource.place;
            preFlightTraining.Status = TrainingStatus.Comleted;
            preFlightTraining.Description = applicantPreflightTrainingResource.description;
            preFlightTraining.CreatedBy = User.Identity.Name;
            preFlightTraining.ModifiedBy = User.Identity.Name;
            preFlightTraining.CreatedDate = DateTime.Now;
            preFlightTraining.ModifiedDate = DateTime.Now;



            _db.PreFlightTrainings.Add(preFlightTraining);
            _db.SaveChanges();
            var aplicantTraings = new List<PreFlightTrainingPerson>();
            foreach (var applicantId in applicantPreflightTrainingResource.applicantIds)
            {
                if (applicantId != 0)
                {


                    UpdateStatus(applicantId, Status.PreFlightTraining, ApplicantPreFlightTrainingStatus.Requested.ToString());
                    var aplicantTraing = new PreFlightTrainingPerson();
                    aplicantTraing.PreFlightTrainingId = preFlightTraining.PreFlightTrainingId;
                    aplicantTraing.ApplicantProfileId = applicantId;
                    aplicantTraing.Status = TrainingPeopleStatus.Completed;
                    aplicantTraing.CreatedBy = User.Identity.Name;
                    aplicantTraing.CreatedBy = User.Identity.Name;
                    aplicantTraing.ModifiedBy = User.Identity.Name;
                    aplicantTraing.CreatedDate = DateTime.Now;
                    aplicantTraing.ModifiedDate = DateTime.Now;
                    _db.PreFlightTrainingPeople.Add(aplicantTraing);
                }

            }

            _db.SaveChanges();
            return Ok("Updated");


            return Ok(404);

        }

        [HttpGet("getPreflightTrainingScheduless")]
        //[Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> GetPreflightTrainingScheduless()
        {

            var trainingSchedules = _db.PreFlightTrainings.Include(inc => inc.PreFlightTrainingPeople).ToList();
            return Ok(trainingSchedules);
        }

        [HttpPost("completeSchedulePreflightTraining")]
        [Authorize(Roles = "OnlyTest")]
        public async Task<ActionResult> completeSchedulePreflightTraining([FromBody] ApplicantPreflightTrainingResource applicantPreflightTrainingResource)

        {

            var preFlightTraining = _db.PreFlightTrainings.Find(applicantPreflightTrainingResource.preFlightTrainingId);
            if (preFlightTraining != null) {
                preFlightTraining.Status = TrainingStatus.Comleted;
                preFlightTraining.ModifiedBy = User.Identity.Name;
       



                _db.PreFlightTrainings.Attach(preFlightTraining);
                _db.Entry(preFlightTraining).State =  EntityState.Modified;
                _db.SaveChanges();
                foreach (var applicantId in applicantPreflightTrainingResource.applicantIds)
                {
                    if (applicantId != 0)
                    {


                        UpdateStatus(applicantId, Status.PreFlightTraining, ApplicantPreFlightTrainingStatus.Completed.ToString());
                        var aplicantTraing = _db.PreFlightTrainingPeople.Where(q=>q.ApplicantProfileId==applicantId &&
                                                                                       q.PreFlightTrainingId== preFlightTraining.PreFlightTrainingId).FirstOrDefault();
                        if(aplicantTraing!=null)
                        {

                            aplicantTraing.PreFlightTrainingId = preFlightTraining.PreFlightTrainingId;
                            aplicantTraing.ApplicantProfileId = applicantId;
                            aplicantTraing.Status = TrainingPeopleStatus.Completed;
                            aplicantTraing.ModifiedBy = User.Identity.Name;
                            _db.PreFlightTrainingPeople.Attach(aplicantTraing);
                            _db.Entry(aplicantTraing).State = EntityState.Modified;
                        }
                        
                        
                    }

                }

                _db.SaveChanges();
                return Ok("Updated");

            }



            return Ok(404);

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

    }
}
