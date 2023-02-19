using NatnaAgencyDigitalSystem.Api.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatnaAgencyDigitalSystem.Core.Models
{
    public class CoC : BaseModel
    {

        public int CoCId { get; set; }
        public string TrainedPlaceName { get; set; }
        public string  TrainedPlaceAddress { get; set; }
        public string TrainedSkill { get; set; }
        public string CertificateTakenPlaceName { get; set; }
        public string CertificateTakenAddress { get; set; }
        public string? Description { get; set; }
    }
}
