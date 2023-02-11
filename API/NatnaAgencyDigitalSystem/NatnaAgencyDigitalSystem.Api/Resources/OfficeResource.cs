namespace NatnaAgencyDigitalSystem.Api.Resources
{

   public class OfficeResource : BaseModelRes
    { 
        public int CountryId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public Boolean IsHeadOffice { get; set; }

        public string? Remark { get; set; }
    }
    }

  