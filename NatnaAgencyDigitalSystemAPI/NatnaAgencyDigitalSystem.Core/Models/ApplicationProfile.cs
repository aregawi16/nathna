using NatnaAgencyDigitalSystem.Api.Models.Common;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace NatnaAgencyDigitalSystem.Api.Models
{
    public class ApplicantProfile : BaseModel
    {

        //public ApplicantProfile()
        //{
        //    ApplicantPlacement = new ApplicantPlacement();
        //    ExperiencedJobs = new Collection<ExperiencedJob>();
        //}


        public int ApplicantProfileId { get; set; }
        public int AgentId { get; set; }
        
        [NotMapped]
        public Boolean IsDeleted => false;
        [NotMapped]
        public string Image => "assets/images/profile/ashley.jpg";
        public string FirstName { get; set; }
        [NotMapped]
        public string FullName => $"{char.ToUpper(FirstName[0]) + FirstName.Substring(1).ToLower()} {char.ToUpper(MiddleName[0]) + MiddleName.Substring(1).ToLower()} {char.ToUpper(LastName[0]) + LastName.Substring(1).ToLower()}";
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstNameAm { get; set; }
        [NotMapped]
        public string FullNameAm => $"{FirstNameAm} {MiddleNameAm} {LastNameAm}";
        public string MiddleNameAm { get; set; }
        public string LastNameAm { get; set; }
        public string Nationality { get; set; }
        public int CountryId { get; set; }
        public string ReferenceNo { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Gender Gender { get; set; }
        public string PassportNo { get; set; }
        [NotMapped]
        public int Age => (DateTime.Now.Year - DoB.Year);
        public DateTime DoB { get; set; }
        public DateTime PassportIssueDate { get; set; }
        public DateTime PassportExpiryDate { get; set; }
        [NotMapped]
        public int AvailableYear => PassportExpiryDate.Year - PassportIssueDate.Year;
        public Religion Religion { get; set; }
        public int? NoOfChildren { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string City { get; set; }
        public string Wereda { get; set; }
        public string Kebelle { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        [NotMapped]
        public string Address => $"{Kebelle} {Wereda} {City}";
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }
        //public  ICollection<ExperiencedJob> ExperiencedJobs { get; set; }
        public virtual  ICollection<BenificiaryDeclaration> BenificiaryDeclarations { get; set; }
        public   ContactPerson ContactPerson { get; set; }
        public  ApplicantDocument ApplicantDocument { get; set; }
        public virtual ICollection<ApplicantPlacement> ApplicantPlacements { get; set; } 
        public virtual ICollection<ApplicantContractAgreement> ApplicantContractAgreements { get; set; } 
        public virtual ICollection<ApplicantInsurance> ApplicantInsurances { get; set; } 
        public virtual ICollection<ApplicantLabourOffice> ApplicantLabourOffices { get; set; } 
        public virtual ICollection<ApplicantFlightTicket> ApplicantFlightTickets { get; set; } 
        public virtual ICollection<ApplicantStatus> ApplicantStatuses { get; set; } 
        public virtual ICollection<EducationHistory> EducationHistorys { get; set; } 
        public string GetFullName(string format)
        {
            return string.Format(format, FirstName, LastName);
        }


        
    }
    public class WorkExperience 
    {
        public int WorkExperienceId { get; set; }
        public int ApplicantProfileId { get; set; }

        public DateTime? StartDate { get; set; }
        public int Duration { get; set; }
        public DateTime? EndDate { get; set; }
        public string Country { get; set; }
        public string JobDescription { get; set; }



    }
    public class ContactPerson 
    {
        public int ContactPersonId { get; set; }
        public int ApplicantProfileId { get; set; }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string City { get; set; }
        public string Wereda { get; set; }
        public string Kebelle { get; set; }
        public string ContactPersonDocumentPath { get; set; }



    }  
    public class BenificiaryDeclaration 
    {
        public int BenificiaryDeclarationId { get; set; }
        public int ApplicantProfileId { get; set; }

        public string FullName { get; set; }
        public Relationship Relationship { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? Wereda { get; set; }
        public string? Kebelle { get; set; }
        public string? Address { get; set; }
        public decimal Percent { get; set; }
        public string BenificiaryDeclarationDocumentPath { get; set; }



    }   
    public class EducationHistory 
    {
        public int EducationHistoryId { get; set; }
        public int ApplicantProfileId { get; set; }

        public string? QualificationType { get; set; }
        public string? LevelOfQualification { get; set; }
        public int? YearCompleted { get; set; }
        public string? Award { get; set; }
        public string? ProfessionalSkill { get; set; }
    }
    public class ExperiencedJob 
    {
        public int ExperiencedJobId { get; set; }
        public int ApplicantProfileId { get; set; }
        public bool HaveExperience { get; set; }
        public int CommonJobId { get; set; }
        [ForeignKey("CommonJobId")]
        public virtual CommonJob CommonJob { get; set; }
        [NotMapped]
        public string CommonJobName  => CommonJob?.Name;

    }  
    public class ApplicantDocument 
    {
        public int ApplicantDocumentId { get; set; }
        public int ApplicantProfileId { get; set; }
        public string? ApplicantIdFilePath { get; set; }
        public string ApplicantPassportFilePath { get; set; }
        public string? ApplicantSmallPhotoPath { get; set; }
        public string? ApplicantFullPhotoPath { get; set; }
        public string? ApplicantContractAgreementPath { get; set; }
        public string? ApplicantMedicalDocumentPath { get; set; }
        public string? ApplicantCrimeCheckfreeDocumentPath { get; set; }
        public string? ApplicantVideoPath { get; set; }

    }

    public class ApplicantStatus : BaseModel
    {
         public int ApplicantStatusId { get; set; }
        public int ApplicantProfileId { get; set; }
        public string OfficeLevel { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }


    }
    public class ApplicantPlacement : BaseModel
    {
     
        public int ApplicantPlacementId { get; set; }
        public int ApplicantProfileId { get; set; }
        public int OfficeId { get; set; }
        public string? Description { get; set; }

    }
    public class ApplicantContractAgreement : BaseModel
    {
     
        public int ApplicantContractAgreementId { get; set; }
        public int ApplicantProfileId { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ContractFilePath { get; set; }

    }
    public class ApplicantInsurance : BaseModel
    {
        public int ApplicantInsuranceId { get; set; }
        public int ApplicantProfileId { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? InsuranceFilePath { get; set; }

    } 
    
    public class ApplicantLabourOffice : BaseModel
    {
     
        public int ApplicantLabourOfficeId { get; set; }
        public int ApplicantProfileId { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? LabourOfficeDocumentFilePath { get; set; }
        public string? LetterFilePath { get; set; }
        public string? YellowCardFilePath { get; set; }
        public string? PreFlightTrainingCertficatePath { get; set; }

    }
    public class ApplicantFlightTicket : BaseModel
    {
     
        public int ApplicantFlightTicketId { get; set; }
        public int ApplicantProfileId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? TicketFilePath { get; set; }

    }
}
