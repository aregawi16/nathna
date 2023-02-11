using NatnaAgencyDigitalSystem.Api.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NatnaAgencyDigitalSystem.Api.Models.Setting
{
    public class Country : BaseModel
    {

        public int CountryId { get; set; }
        public string Name { get; set; }
        public string? PolticalName { get; set; }
        public Continent Continent { get; set; }
        public string? TelephoneCode { get; set; }
        public string? Nationality { get; set; }

        public string Code { get; set; }

        public decimal PassportActivePeriod { get; set; }

        public string? Remark { get; set; }
        public ICollection<Office> Offices { get; set; }

    }
    public class Office : BaseModel
    {

        public int OfficeId { get; set; }
        public int CountryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Boolean IsHeadOffice { get; set; }
        public string? Remark { get; set; }
    }

    public enum Continent
    { 
        Europe=1,
        NorthAmerica,
        SouthAmerica,
        Asia,
        Australia,
        Africa,


    }

}
