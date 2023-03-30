using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatnaAgencyDigitalSystem.Core.Models
{

    public enum TrainingStatus
    {
        Scheduled,
        Comleted,
        Rejected
    };
    public enum TrainingPeopleStatus
    {
        Assigned,
        Completed,
        Rejected
    };

    public class PreFlightTraining:BaseModel
    {
      public int PreFlightTrainingId { get; set; }
      public DateTime ScheduledDate { get; set; }
      public string Place { get; set; }
      public TrainingStatus Status { get; set; }
      public string? Description { get; set; }
      public IList<PreFlightTrainingPerson> PreFlightTrainingPeople { get; set; }

    }
    public class PreFlightTrainingPerson : BaseModel
    {
        public int PreFlightTrainingPersonId { get; set; }
        public int PreFlightTrainingId { get; set; }
        public int ApplicantProfileId { get; set; }
        public ApplicantProfile ApplicantProfile { get; set; }
        public TrainingPeopleStatus Status { get; set; }
        public string? Description { get; set; }
    }
}
