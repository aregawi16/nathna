using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Auth;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatnaAgencyDigitalSystem.Api.Repositories
{
    
    public interface IApplicantProfileRepository : IRepository<ApplicantProfile>
    {
        Task<Core.Models.Common.Page<ApplicantProfile>> GetAllWithStatusAsync(Pageable pageabl, User user,int id);
        Task<ApplicantProfile> GetWithWorkExperienceByIdAsync(int id);
    }
    public interface IWorkExperienceRepository : IRepository<WorkExperience>
    {
        //Task<IEnumerable<WorkExperience>> GetAllWithMusicsAsync();
        //Task<WorkExperience> GetWithMusicsByIdAsync(int id);
    }
    public interface ICommonJobRepository : IRepository<CommonJob>
    {

    }
    public interface ICountryRepository : IRepository<Country>
    {
    }
    public interface IAgentRepository : IRepository<Agent>
    {
    }
    public interface IOfficeRepository : IRepository<Office>
    {
    }
}
