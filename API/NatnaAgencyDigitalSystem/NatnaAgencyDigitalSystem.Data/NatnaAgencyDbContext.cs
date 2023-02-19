using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Auth;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Core.Models;
using NatnaAgencyDigitalSystem.Data.Configurations;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NatnaAgencyDigitalSystem.Data
{
    public class NatnaAgencyDbContext :  IdentityDbContext<User, Role, Guid>
    {


        public DbSet<ApplicantProfile> ApplicantProfiles { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<EducationHistory> EducationHistorys { get; set; }
        public DbSet<ContactPerson> ContactPeople { get; set; }
        public DbSet<ExperiencedJob> ExperiencedJobs { get; set; }
        public DbSet<BenificiaryDeclaration> BenificiaryDeclarations { get; set; }
        public DbSet<ApplicantDocument> ApplicantDocuments { get; set; }
        public DbSet<ApplicantPlacement> ApplicantPlacements { get; set; }
        public DbSet<FingerPrintInvestigation> FingerPrintInvestigations { get; set; }
        public DbSet<FingerPrintInvestigationPerson> FingerPrintInvestigationPeople { get; set; }
        public DbSet<ApplicantContractAgreement> ApplicantContractAgreements { get; set; }
        public DbSet<ApplicantInsurance> ApplicantInsurances { get; set; }
        public DbSet<CoC> CoCs { get; set; }
        public DbSet<PreFlightTraining> PreFlightTrainings { get; set; }
        public DbSet<PreFlightTrainingPerson> PreFlightTrainingPeople { get; set; }
        public DbSet<ApplicantLabourOffice> ApplicantLabourOffices { get; set; }
        public DbSet<ApplicantFlightTicket> ApplicantFlightTickets { get; set; }
        public DbSet<ApplicantStatus> ApplicantStatuses { get; set; }
        public DbSet<CommonJob> CommonJobs { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Office> Offices { get; set; }

        public NatnaAgencyDbContext(DbContextOptions<NatnaAgencyDbContext> options)
           : base(options)
        {
        }

        public NatnaAgencyDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicantProfile>().HasMany(s => s.WorkExperiences);

            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new ApplicantProfileConfiguration()); 
            builder
                .ApplyConfiguration(new CompanyProfileConfiguration());
            builder
                .ApplyConfiguration(new WorkExperienceConfiguration());
            builder
                .ApplyConfiguration(new ContactPersonConfiguration());
            builder
                .ApplyConfiguration(new ExperiencedJobConfiguration());
            builder
                .ApplyConfiguration(new EducationHistoryConfiguration());
            builder
                .ApplyConfiguration(new ApplicantDocumentConfiguration());  
            builder
                .ApplyConfiguration(new ApplicantPlacementConfiguration());  
            builder
                .ApplyConfiguration(new FingerPrintInvestigationConfiguration());  
            builder
                .ApplyConfiguration(new FingerPrintInvestigationPersonConfiguration()); 
            builder
                .ApplyConfiguration(new ApplicantContractConfiguration()); 
            builder
                .ApplyConfiguration(new ApplicantInsuranceConfiguration()); 
            builder
                .ApplyConfiguration(new CoCConfiguration());  
            builder
                .ApplyConfiguration(new PreFlightTrainingConfiguration());
            builder
                .ApplyConfiguration(new PreFlightTrainingPersonConfiguration()); 
            builder
                .ApplyConfiguration(new ApplicantLabourOfficeConfiguration());
            builder
                .ApplyConfiguration(new ApplicantTicketConfiguration());
            builder
                .ApplyConfiguration(new CommonJobConfiguration());
            builder
                .ApplyConfiguration(new CountryConfiguration()); 
            builder
                .ApplyConfiguration(new AgentConfiguration()); 
            builder
                .ApplyConfiguration(new OfficeConfiguration());
            builder
                .ApplyConfiguration(new ApplicantStatusConfiguration());


        }
    }
}