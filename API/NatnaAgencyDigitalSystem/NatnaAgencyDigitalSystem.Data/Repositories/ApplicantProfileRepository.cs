using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Repositories;

namespace NatnaAgencyDigitalSystem.Data.Repositories
{
    public class ApplicantProfileRepository : Repository<ApplicantProfile>, IApplicantProfileRepository
    {
        public ApplicantProfileRepository(NatnaAgencyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<ApplicantProfile>> GetAllWithStatusAsync()
        {
            return await NatnaAgencyDbContext.ApplicantProfiles
                   .Include(m => m.ApplicantDocument)
                   .Include(m => m.ApplicantStatuses.OrderByDescending(q => q.ApplicantStatusId))
               .ToListAsync();
        }

        public async Task<ApplicantProfile> GetWithWorkExperienceByIdAsync(int id)
        {
            return await NatnaAgencyDbContext.ApplicantProfiles
                   .Include(m => m.WorkExperiences)
                   .Include(m => m.ExperiencedJobs)
                   .Include(m => m.ApplicantDocument)
                   .Include(m => m.ContactPerson)
                   .Include(m => m.EducationHistorys)
                   .Include(m => m.BenificiaryDeclarations.OrderByDescending(q => q.BenificiaryDeclarationId))
                   .Include(m => m.ApplicantPlacements.OrderByDescending(q => q.ApplicantPlacementId))
                   .Include(m => m.ApplicantPlacements.OrderByDescending(q => q.ApplicantPlacementId))
                   .Include(m => m.ApplicantContractAgreements.OrderByDescending(q => q.ApplicantContractAgreementId))
                   .Include(m => m.ApplicantInsurances.OrderByDescending(q => q.ApplicantInsuranceId))
                   .Include(m => m.ApplicantLabourOffices.OrderByDescending(q => q.ApplicantLabourOfficeId))
                   .Include(m => m.ApplicantFlightTickets.OrderByDescending(q => q.ApplicantFlightTicketId))
                   .Include(m => m.ApplicantStatuses.OrderByDescending(q => q.ApplicantStatusId))
                .SingleOrDefaultAsync(m => m.ApplicantProfileId == id);

       
        }

      

        private NatnaAgencyDbContext NatnaAgencyDbContext
        {
            get { return Context as NatnaAgencyDbContext; }
        }
    }
}