using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Microsoft.EntityFrameworkCore;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Auth;
using NatnaAgencyDigitalSystem.Api.Repositories;
using NatnaAgencyDigitalSystem.Core.Models.Common;
using NatnaAgencyDigitalSystem.Data.Pagination.Extensions;

namespace NatnaAgencyDigitalSystem.Data.Repositories
{
    public class ApplicantProfileRepository : Repository<ApplicantProfile>, IApplicantProfileRepository
    {
        private NatnaAgencyDbContext _context;
        public ApplicantProfileRepository(NatnaAgencyDbContext context)
            : base(context)
        {
            _context = context;
                }

        public async Task<Core.Models.Common.Page<ApplicantProfile>> GetAllWithStatusAsync(Pageable pageable, User user, int id)
        {
            var office = await _context.Offices.FindAsync(user.OfficeId);
            var appPlacmentIds = _context.ApplicantPlacements.Where(q => q.OfficeId == user.OfficeId).Select(s => s.ApplicantProfileId);

            var applcantProfiles = new List<ApplicantProfile>();
            applcantProfiles = _context.ApplicantProfiles
                   .Include(m => m.ApplicantDocument)
                   .Include(m => m.ApplicantStatuses.OrderByDescending(q => q.ApplicantStatusId).Take(1)).ToList();
            if (office != null)
            {
                if (office.IsHeadOffice)
                {
                    //if(!User.IsInRole("admin"))
                    //    {
                    //    ApplicantProfiles = ApplicantProfiles.Where(q =>q.CreatedBy == User.Identity.Name);
                    //}
                }
                else
                {
                    applcantProfiles = applcantProfiles.Where(q => appPlacmentIds.Contains(q.ApplicantProfileId)).ToList();

                }
            }
            if(id==1)
            {
                applcantProfiles = applcantProfiles.Where(q=>q.ApplicantStatuses.Count()==0).ToList();
            }
            else if(id==2)
            {
                var appIds = _context.ApplicantStatuses.Where(q => q.OfficeLevel == "Placement" && q.Status == "Assigned").Select(q => q.ApplicantProfileId);
                applcantProfiles = applcantProfiles.Where(q => appIds.Contains(q.ApplicantProfileId)).ToList();
            }
            else if (id == 3)
            {
                var appIds = _context.ApplicantStatuses.Where(q => q.OfficeLevel == "Placement" && q.Status == "Selected").Select(q => q.ApplicantProfileId);

                applcantProfiles = applcantProfiles.Where(q => appIds.Contains(q.ApplicantProfileId)).ToList();
            }
            else if (id == 4)
            {
                var appIds = _context.ApplicantStatuses.Where(q => q.OfficeLevel == "Placement" && q.Status == "Selected").Select(q => q.ApplicantProfileId);
                applcantProfiles = applcantProfiles.Where(q => appIds.Contains(q.ApplicantProfileId)).ToList();
            }
            return applcantProfiles
                   .OrderByDescending(c => c.ApplicantProfileId)

                   .UsePageable(pageable);
               
        }

        public async Task<ApplicantProfile> GetWithWorkExperienceByIdAsync(int id)
        {
            return await _context.ApplicantProfiles
                   .Include(m => m.WorkExperiences)
                   //.Include(m => m.ExperiencedJobs)
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
                   .Where(q => q.ApplicantProfileId == id).FirstOrDefaultAsync();




        }



        private NatnaAgencyDbContext NatnaAgencyDbContext
        {
            get { return Context as NatnaAgencyDbContext; }
        }
    }
}