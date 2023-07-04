using NatnaAgencyDigitalSystem.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatnaAgencyDigitalSystem.Api
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicantProfileRepository ApplicantProfiles { get; }
        ICommonJobRepository CommonJobs { get; }
        ICountryRepository Countrys { get; }
        IAgentRepository Agents { get; }
        IOfficeRepository Offices { get; }
        Task<int> CommitAsync();
    }
}
