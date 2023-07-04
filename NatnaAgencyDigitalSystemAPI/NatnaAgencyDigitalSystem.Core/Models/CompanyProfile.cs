using NatnaAgencyDigitalSystem.Api.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatnaAgencyDigitalSystem.Core.Models
{
    public class CompanyProfile : BaseModel
    {
        public int CompanyProfileId { get; set; }
        public int AgencyId { get; set; }
        public string Name { get; set; }
        public string NameAm { get; set; }
        public string AddressRegion { get; set; }
        public string City { get; set; }
        public string Zone { get; set; }
        public string Wereda { get; set; }
        public string Kebelle { get; set; }
        public string LicenseNumber { get; set; }
        public string Email { get; set; }
        public string GeneralManager { get; set; }
        public string Telephone { get; set; }
        public string? Fax { get; set; }
        public string? POBox { get; set; }
        public string LogoName { get; set; }
    }
}
