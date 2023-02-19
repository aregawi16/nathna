using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatnaAgencyDigitalSystem.Api.Models.Common
{
    public class BaseModel
    {
        public string CreatedBy { get; set; } 
        public string ModifiedBy { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; } 

    }
    public enum Religion
    {
        Christian=1,
        Muslim=2,
        Other=3
    }
    public enum Gender
    {
        Male=1,
        Female=2

    }
    public enum Relationship
    {
        Parent,
        Father,
        Mother,
        Husband,
        Wife,
        Son,
        Doughter,
        Sibling,
        Brother,
        Sister,
        Grandfather,
        Grandmother,
        Grandson,
        Granddaughter,
        Uncle,
        Aunt,
        Nephew,
        Niece,
        Cousins



    }
    public enum MaritalStatus
    {
        Single = 1,
        Married = 2,
        Divorced =3,
        widowed =4,

    }
    public enum DocumentType
    {
        ID,
        Passport,
        ShortPhoto,
        FullPhoto,
        ContactDocument,
        Video,

    } 
    public enum Priority
    {
        High=1,
        Medium,
        Low,
    }
    public enum Status
    {
        UnAssigned,
        Placement = 1,
        ContractAgreement,
        Insurance,
        CoC,
        PreFlightTraining,
        MinistryOfLabor,
        Ticket
    }
    
public enum ApplicantPlacementStatus
    {
        Assigned = 1,
        Selected,
        DocumentVerified,
        Accepted,
        Rejected,
       
    }
    public enum ApplicantContractStatus
    {
        Ready = 1,
        Received,
        Verified,
        Rejected,

    }
    public enum ApplicantInsuranceStatus  
    {
        Requested = 1,
        Completed,
        Rejected,

    }
    public enum ApplicantLabourStatus
    {
        Requested = 1,
        YellowCardReceived,
        Rejected,

    }
    public enum ApplicantFlightTicketStatus
    {
        Requested = 1,
        Verified,
        Flighted,
        Arrived

    }   
    public enum CoCAndTrainingStatus
    {
        Progress = 1,
        Taken
    }
  


    //public enum DocumentUserType
    //{
    //    Applicant,
    //    ContactPerson
    //}
}
