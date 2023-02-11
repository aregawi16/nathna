using NatnaAgencyDigitalSystem.Api.Models.Common;

namespace NatnaAgencyDigitalSystem.Api.Resources
{
    public class ApplicantPLacementResource
    {
        public int applicantId { get; set; }
        public ApplicantPlacementStatus status { get; set; }
    }
    public class ApplicantFlightResource
    {
        public int applicantId { get; set; }
        public ApplicantFlightTicketStatus status { get; set; }
    }
    
    public class ApplicantInsuranceResource
    {
        public int applicantId { get; set; }
        public decimal price { get; set; }

        public IFormFile insuranceDocument { get; set; }
    }
    public class ApplicantLabourResource
    {
        public int applicantId { get; set; }
        public decimal? price { get; set; }

        public IFormFile? labourDocument { get; set; }
        public IFormFile? yellowCardDocument { get; set; }
    } 
    public class ApplicantFlightTicketResource
    {
        public int applicantId { get; set; }
        public decimal? price { get; set; }
        public DateTime departureDate { get; set; }
        public DateTime arrivalDate { get; set; }
        public IFormFile? flightTicketDocument { get; set; }
    }
        public class ApplicantYellowCardResource
    {
        public int applicantId { get; set; }
        public decimal price { get; set; }

        public IFormFile yellowCardDocument { get; set; }
    }
    
    public class VerifiedDocumentResource
    {
        public int applicantId { get; set; }
        public IFormFile medicalDocument { get; set; }
        public IFormFile crimeFreeDocument { get; set; }
    } 
    public class ApplicantContractResource
    {
        public int applicantId { get; set; }
        public ApplicantContractStatus status { get; set; }
    }
    public class ApplicantContractVerificationResource
    {
        public int applicantId { get; set; }
        public decimal price { get; set; }
        public IFormFile verifiedContractDocument { get; set; }

    }
    public class ContractDocumentResource
    {
        public int applicantId { get; set; }
        public IFormFile contractDocument { get; set; }
    } 
    public class InsuranceResource
    {
        public int applicantId { get; set; }
        public decimal price { get; set; }

        public IFormFile insuranceDocument { get; set; }
    }
}
