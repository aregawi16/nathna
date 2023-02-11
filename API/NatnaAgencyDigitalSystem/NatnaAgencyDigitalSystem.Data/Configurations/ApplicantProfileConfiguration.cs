using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using System.Reflection.Emit;

namespace NatnaAgencyDigitalSystem.Data.Configurations
{
    public class ApplicantProfileConfiguration : IEntityTypeConfiguration<ApplicantProfile>
    {
        public void Configure(EntityTypeBuilder<ApplicantProfile> builder)
        {
            builder
                .HasKey(a => a.ApplicantProfileId);

            builder
                .Property(m => m.ApplicantProfileId)
                .UseIdentityColumn();

            builder
                .Property(m => m.FirstName)
                .IsRequired()
            .HasMaxLength(50);

        

            builder
                .ToTable("ApplicantProfiles","NatnaAgency");
        }
    }
    public class ApplicantPlacementConfiguration : IEntityTypeConfiguration<ApplicantPlacement>
    {
        public void Configure(EntityTypeBuilder<ApplicantPlacement> builder)
        {
            builder
                .HasKey(a => a.ApplicantPlacementId);

            builder
                .Property(m => m.ApplicantPlacementId)
                .UseIdentityColumn();

         

        

            builder
                .ToTable("ApplicantPlacements","NatnaAgency");
        }
    }

    public class WorkExperienceConfiguration : IEntityTypeConfiguration<WorkExperience>
    {
        public void Configure(EntityTypeBuilder<WorkExperience> builder)
        {
            builder
                .HasKey(a => a.WorkExperienceId);

            builder
                .Property(m => m.WorkExperienceId)
                .UseIdentityColumn();


            builder
                .ToTable("WorkExperiences","NatnaAgency");

        }
    }

    public class ContactPersonConfiguration : IEntityTypeConfiguration<ContactPerson>
    {
        public void Configure(EntityTypeBuilder<ContactPerson> builder)
        {
            builder
                .HasKey(a => a.ContactPersonId);

            builder
                .Property(m => m.ContactPersonId)
                .UseIdentityColumn();


            builder
                .ToTable("ContactPersons","NatnaAgency");

        }
    }
    public class ApplicantContractConfiguration : IEntityTypeConfiguration<ApplicantContractAgreement>
    {
        public void Configure(EntityTypeBuilder<ApplicantContractAgreement> builder)
        {
            builder
                .HasKey(a => a.ApplicantContractAgreementId);

            builder
                .Property(m => m.ApplicantContractAgreementId)
                .UseIdentityColumn();


            builder
                .ToTable("ApplicantContractAgreements", "NatnaAgency");

        }
    }
    public class ApplicantInsuranceConfiguration : IEntityTypeConfiguration<ApplicantInsurance>
    {
        public void Configure(EntityTypeBuilder<ApplicantInsurance> builder)
        {
            builder
                .HasKey(a => a.ApplicantInsuranceId);

            builder
                .Property(m => m.ApplicantInsuranceId)
                .UseIdentityColumn();


            builder
                .ToTable("ApplicantInsurances", "NatnaAgency");

        }
    }
    public class ApplicantLabourOfficeConfiguration : IEntityTypeConfiguration<ApplicantLabourOffice>
    {
        public void Configure(EntityTypeBuilder<ApplicantLabourOffice> builder)
        {
            builder
                .HasKey(a => a.ApplicantLabourOfficeId);

            builder
                .Property(m => m.ApplicantLabourOfficeId)
                .UseIdentityColumn();


            builder
                .ToTable("ApplicantLabourOffices", "NatnaAgency");

        }
    }
    public class ApplicantTicketConfiguration : IEntityTypeConfiguration<ApplicantFlightTicket>
    {
        public void Configure(EntityTypeBuilder<ApplicantFlightTicket> builder)
        {
            builder
                .HasKey(a => a.ApplicantFlightTicketId);

            builder
                .Property(m => m.ApplicantFlightTicketId)
                .UseIdentityColumn();


            builder
                .ToTable("ApplicantFlightTickets", "NatnaAgency");

        }
    }

    public class ApplicantDocumentConfiguration : IEntityTypeConfiguration<ApplicantDocument>
    {
        public void Configure(EntityTypeBuilder<ApplicantDocument> builder)
        {
            builder
                .HasKey(a => a.ApplicantDocumentId);

            builder
                .Property(m => m.ApplicantDocumentId)
                .UseIdentityColumn();


            builder
                .ToTable("ApplicantDocuments","NatnaAgency");

        }
    }
    public class ExperiencedJobConfiguration : IEntityTypeConfiguration<ExperiencedJob>
    {
        public void Configure(EntityTypeBuilder<ExperiencedJob> builder)
        {
            builder
                .HasKey(a => a.ExperiencedJobId);

            builder
                .Property(m => m.ExperiencedJobId)
                .UseIdentityColumn();


            builder
                .ToTable("ExperiencedJobs","NatnaAgency");

        }
    }

    //setting
    public class CommonJobConfiguration : IEntityTypeConfiguration<CommonJob>
    {
        public void Configure(EntityTypeBuilder<CommonJob> builder)
        {
            builder
                .HasKey(a => a.CommonJobId);

            builder
                .Property(m => m.CommonJobId)
                .UseIdentityColumn();


            builder
                .ToTable("CommonJobs","NatnaAgency");

        }
    }
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .HasKey(a => a.CountryId);

            builder
                .Property(m => m.CountryId)
                .UseIdentityColumn();


            builder
                .ToTable("Countrys", "NatnaAgency");

        }
    }

    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder
                .HasKey(a => a.OfficeId);

            builder
                .Property(m => m.OfficeId)
                .UseIdentityColumn();


            builder
                .ToTable("Offices", "NatnaAgency");

        }
    }

    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder
                .HasKey(a => a.AgentId);

            builder
                .Property(m => m.AgentId)
                .UseIdentityColumn();


            builder
                .ToTable("Agents", "NatnaAgency");

        }
    }

    public class ApplicantStatusConfiguration : IEntityTypeConfiguration<ApplicantStatus>
    {
        public void Configure(EntityTypeBuilder<ApplicantStatus> builder)
        {
            builder
                .HasKey(a => a.ApplicantStatusId);

            builder
                .Property(m => m.ApplicantStatusId)
                .UseIdentityColumn();


            builder
                .ToTable("ApplicantStatuses", "NatnaAgency");

        }
    }


}