using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Auth;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Core.Models.Common;
using NatnaAgencyDigitalSystem.Core.Models.ReadOnlyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatnaAgencyDigitalSystem.Api.Services
{
    public interface IApplicantProfileService
    {
        Task<Page<ApplicantProfileViewModel>> GetAllWithStatusAsync(Pageable pageable, User user,int id, int? officeId, string? search);
        Task<IEnumerable<ApplicantProfile>> GetAllApplicantProfiles();
        Task<ApplicantProfile> GetApplicantProfileById(int id);
        Task<ApplicantProfile> GetWithWorkExperienceByIdAsync(int id);
        Task<ApplicantProfile> CreateApplicantProfile(ApplicantProfile newApplicantProfile);
        Task UpdateApplicantProfile(ApplicantProfile ApplicantProfileToBeUpdated, ApplicantProfile ApplicantProfile);
        Task DeleteApplicantProfile(ApplicantProfile ApplicantProfile);
    }

    public interface ICommonJobService
    {
        Task<IEnumerable<CommonJob>> GetAllCommonJobs();
        Task<CommonJob> GetCommonJobById(int id);
        Task<CommonJob> CreateCommonJob(CommonJob newCommonJob);
        Task UpdateCommonJob(CommonJob CommonJobToBeUpdated, CommonJob CommonJob);
        Task DeleteCommonJob(CommonJob CommonJob);
    }
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountrys();
        Task<Country> GetCountryById(int id);
        Task<Country> CreateCountry(Country newCountry);
        Task UpdateCountry(Country CountryToBeUpdated, Country Country);
        Task DeleteCountry(Country Country);
    }
    public interface IAgentService
    {
        Task<IEnumerable<Agent>> GetAllAgents();
        Task<Agent> GetAgentById(int id);
        Task<Agent> CreateAgent(Agent newAgent);
        Task UpdateAgent(Agent AgentToBeUpdated, Agent Agent);
        Task DeleteAgent(Agent Agent);
    }
    public interface IOfficeService
    {
        Task<IEnumerable<Office>> GetAllOffices();
        Task<Office> GetOfficeById(int id);
        Task<Office> CreateOffice(Office newOffice);
        Task UpdateOffice(Office OfficeToBeUpdated, Office Office);
        Task DeleteOffice(Office Office);
    }
}
