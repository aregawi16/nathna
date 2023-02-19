using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatnaAgencyDigitalSystem.Core.Models
{
    public class FingerPrintInvestigation : BaseModel
    {

        public int FingerPrintInvestigationId { get; set; }
        public string? Description { get; set; }
        public IList<FingerPrintInvestigationPerson> FingerPrintInvestigationPeople { get; set; }

    }
    public class FingerPrintInvestigationPerson : BaseModel
    {
        public int FingerPrintInvestigationPersonId { get; set; }
        public int FingerPrintInvestigationId { get; set; }
        public int ApplicantProfileId { get; set; }
        public ApplicantProfile ApplicantProfile { get; set; }
        public string? Description { get; set; }
    }
}
