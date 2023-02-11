using NatnaAgencyDigitalSystem.Api.Models.Common;
using NatnaAgencyDigitalSystem.Api.Models.Setting;

namespace NatnaAgencyDigitalSystem.Api.Resources
{
    public class CountryResource : BaseModelRes
    {
        public string Name { get; set; }
        public string? PolticalName { get; set; }
        public Continent Continent { get; set; }
        public string? TelephoneCode { get; set; }
        public string? Nationality { get; set; }

        public string Code { get; set; }

        public decimal PassportActivePeriod { get; set; }

        public string? Remark { get; set; }
    }
    public class AgentResource
    {
        public string Code { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Description { get; set; }
    }
    public class BaseModelRes
    {
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
    public class CommonJobResource : BaseModelResource
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }


    public class BaseModelResource
    {
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
