using NatnaAgencyDigitalSystem.Api.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace NatnaAgencyDigitalSystem.Api.Resources
{

    public class ApplicantProfileResource : BaseModelResource
    {
        public int? ApplicantProfileId { get; set; }
        public string FirstName { get; set; }
        public string FirstNameAm { get; set; }
        public string MiddleName { get; set; }
        public string MiddleNameAm { get; set; }
        public string LastName { get; set; }
        public string LastNameAm { get; set; }
        public string? Email { get; set; }
        public string Nationality { get; set; }
        public int? CountryId { get; set; }
        public string ReferenceNo { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Gender Gender { get; set; }
        public string PassportNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
        "{0:MM-dd-yyyy}",
         ApplyFormatInEditMode = true)]
        public DateTime DoB { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
        "{0:MM-dd-yyyy}",
         ApplyFormatInEditMode = true)]
        public DateTime PassportIssueDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
         "{0:MM-dd-yyyy}",
          ApplyFormatInEditMode = true)]
        public DateTime PassportExpiryDate { get; set; }
        public Religion Religion { get; set; }
        public int? NoOfChildren { get; set; }
        public string City { get; set; }
        public Priority Priority { get; set; }
        public int AgentId { get; set; }
        public string Wereda { get; set; }
        public string Kebelle { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public IFormFile? applicantPassport { get; set; } = null;
        public IFormFile? applicantId { get; set; } = null;
        public IFormFile? contactDocument { get; set; } = null;
        public IFormFile? applicantVideo { get; set; } = null;
        public IFormFile? applicantShortPhoto { get; set; } = null;
        public IFormFile? applicantFullPhoto { get; set; } = null;
        public virtual List<WorkExperienceResource>? WorkExperiences { get; set; }
        public virtual ContactPersonResource? ContactPerson { get; set; }
        //public virtual List<ExperiencedJobResource> ExperiencedJobs { get; set; }
    //    public virtual ApplicantDocument ApplicantDocuments { get; set; }




    }
    public class WorkExperienceResource 
    {
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public int? Duration { get; set; }
            public string? Country { get; set; }
            public string? JobDescription { get; set; }

        }
        public class ContactPersonResource
    { 

            public string? FullName { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Email { get; set; }
            public string? City { get; set; }
            public string? Wereda { get; set; }
            public string? Kebelle { get; set; }
        public string ContactPersonDocumentPath  => "aaaaaa";


    }
    public class ExperiencedJobResource
    {
            public int CommonJobId { get; set; }
            public bool HaveExperience { get; set; }

      }
    public class ApplicantDocumentResource
    {
        public int ApplicantProfileId { get; set; }
        public IFormFile? applicantPassport { get; set; } = null;
        public IFormFile? applicantId { get; set; } = null;
        public  IFormFile? contactDocument { get; set; } = null;
        public IFormFile? applicantVideo { get; set; } = null;
        public IFormFile? applicantShortPhoto { get; set; } = null;
        public IFormFile? applicantFullPhoto { get; set; } = null;


    }
    public class ApplicantPlacementResource
    {
        public int officeId { get; set; }

        public IEnumerable<int> applicantIds { get; set; }
     


    }
}
