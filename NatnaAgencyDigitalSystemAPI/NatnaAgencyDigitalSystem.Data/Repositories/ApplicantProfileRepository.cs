using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Microsoft.EntityFrameworkCore;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Auth;
using NatnaAgencyDigitalSystem.Api.Repositories;
using NatnaAgencyDigitalSystem.Core.Models.Common;
using NatnaAgencyDigitalSystem.Core.Models.ReadOnlyModel;
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

        public async Task<Core.Models.Common.Page<ApplicantProfileViewModel>> GetAllWithStatusAsync(Pageable pageable, User user, int id, int? officeId,string? search)
        {
            var office = await _context.Offices.FindAsync(user.OfficeId);
            var appPlacmentIds = _context.ApplicantPlacements.Where(q => q.OfficeId == user.OfficeId).Select(s => s.ApplicantProfileId);

            var applcantProfiles = new List<ApplicantProfileViewModel>();
            IEnumerable<int> appIds = null;
            Boolean isUpdate = false;
            IEnumerable<int> officeAssignedAppIds = new List<int>();
            if (officeId!=0)
            {
                officeAssignedAppIds = _context.ApplicantPlacements.Where(q => q.OfficeId==officeId).Select(s=>s.ApplicantProfileId);
            }
            if (id == 2)
            {
                isUpdate = true;
                    appIds = _context.ApplicantStatuses.Where(q => q.OfficeLevel == "Placement" && q.Status == "Assigned").Select(q => q.ApplicantProfileId);
            }
            else if (id == 3)
            {
                isUpdate = true;

                appIds = _context.ApplicantStatuses.Where(q => q.OfficeLevel == "Placement" && q.OfficeLevel != "ContractAgreement" && q.Status == "Selected").Select(q => q.ApplicantProfileId);

            }
            else if (id == 4)
            {
                isUpdate = true;

                appIds = _context.ApplicantStatuses.Where(q => q.OfficeLevel == "ContractAgreement").Select(q => q.ApplicantProfileId);
            }
            applcantProfiles = _context.ApplicantProfiles
                .Where(q => isUpdate? appIds.Contains(q.ApplicantProfileId): q.ApplicantStatuses.Count() == 0)
                .Where(q => officeId!=0? officeAssignedAppIds.Contains(q.ApplicantProfileId):true)
                .Where(q => search!="null"? q.FirstName.Contains(search):true)
            .Select(s => new ApplicantProfileViewModel
            {
                ApplicantProfileId = s.ApplicantProfileId,
                FullName = s.FullName,
                FullNameAm = s.FullNameAm,
                PhoneNumber = s.PhoneNumber,
                PassportNo = s.PassportNo,
                Gender = s.Gender,
                MaritalStatus = s.MaritalStatus,
                Status = s.Status,
                ApplicantStatuses = s.ApplicantStatuses.OrderByDescending(q => q.ApplicantStatusId).Take(1).ToList(),
                ApplicantPlacements = s.ApplicantPlacements,
                ApplicantDocument = s.ApplicantDocument

            })
       .ToList();
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
                   .Include(m => m.ApplicantStatuses.OrderByDescending(q => q.ApplicantStatusId).Take(1))
                   .Where(q => q.ApplicantProfileId == id).FirstOrDefaultAsync();




        }



        private NatnaAgencyDbContext NatnaAgencyDbContext
        {
            get { return Context as NatnaAgencyDbContext; }
        }
    }
}