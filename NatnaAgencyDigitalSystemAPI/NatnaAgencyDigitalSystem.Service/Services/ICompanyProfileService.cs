using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Auth;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Core.Models;
using NatnaAgencyDigitalSystem.Core.Models.Common;
using NatnaAgencyDigitalSystem.Core.Models.ReadOnlyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatnaAgencyDigitalSystem.Service.Services
{
    public interface ICompanyProfileService
    {
        Task<IEnumerable<CompanyProfile>> GetAllCompanyProfiles();
        Task<CompanyProfile> GetCompanyProfileById(int id);
        Task<CompanyProfile> CreateCompanyProfile(CompanyProfile newCompanyProfile);
        Task UpdateCompanyProfile(CompanyProfile CompanyProfileToBeUpdated, CompanyProfile CompanyProfile);
        Task DeleteCompanyProfile(CompanyProfile CompanyProfile);
    }

}
