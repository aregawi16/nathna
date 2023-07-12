using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatnaAgencyDigitalSystem.Core.Models.ReadOnlyModel
{
    public class ApplicantProfileViewModel
    {
        public int ApplicantProfileId { get; set; }
        public string FullName { get; set; }
        public string FullNameAm { get; set; }
        public string? PhoneNumber { get; set; }
        public string PassportNo { get; set; }
        public int AgentId { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public ApplicantDocument ApplicantDocument { get; set; }
        public virtual ICollection<ApplicantStatus> ApplicantStatuses { get; set; }
        public virtual ICollection<ApplicantPlacement> ApplicantPlacements { get; set; }


    }
}
