﻿using NatnaAgencyDigitalSystem.Api.Models.Common;

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
        public ApplicantInsuranceStatus status { get; set; }

    }
    public class ApplicantCocStstusResource
    {
        public int applicantId { get; set; }
        public ApplicantCocStatus status { get; set; }

    }
    public class ApplicantLabourResource
    {
        public int applicantId { get; set; }
        public decimal? price { get; set; }

        public IFormFile? labourDocument { get; set; }
        public IFormFile? preFlightTrainingCertficate { get; set; }
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
    public class ApplicantCoCResource
    {
        public int applicantId { get; set; }
        public string trainedPlaceName { get; set; }
        public string trainedPlaceAddress { get; set; }
        public string trainedSkill { get; set; }
        public string certificateTakenPlaceName { get; set; }
        public string certificateTakenAddress { get; set; }
        public string? description { get; set; }
        public IFormFile? cocCertificateFile { get; set; }
    }
    public class ApplicantPreflightTrainingResource
    {
        public List<int> applicantIds { get; set; }
        public DateTime scheduledDate { get; set; }
        public int? preFlightTrainingId { get; set; }
        public string place { get; set; }
        public string? description { get; set; }
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
