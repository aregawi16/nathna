using System.Threading.Tasks;
using NatnaAgencyDigitalSystem.Api;
using NatnaAgencyDigitalSystem.Api.Repositories;
using NatnaAgencyDigitalSystem.Core.Repositories;
using NatnaAgencyDigitalSystem.Data.Repositories;

namespace NatnaAgencyDigitalSystem.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NatnaAgencyDbContext _context;
        private ApplicantProfileRepository _applicantProfileRepository;
        private CommonJobRepository _commonJobRepository;
        private CountryRepository _countryRepository;
        private AgentRepository _agentRepository;
        private OfficeRepository _officeRepository;
        private CompanyProfileRepository _companyProfileRepository;
        private NotificationRepository _notificationRepository;

        public UnitOfWork(NatnaAgencyDbContext context)
        {
            this._context = context;
        }

        public INotificationRepository NotificationRepository => _notificationRepository ??= new NotificationRepository(_context);
        public IApplicantProfileRepository ApplicantProfiles => _applicantProfileRepository ??= new ApplicantProfileRepository(_context);
        public ICommonJobRepository CommonJobs => _commonJobRepository ??= new CommonJobRepository(_context);
        public ICountryRepository Countrys => _countryRepository ??= new CountryRepository(_context);
        public IAgentRepository Agents => _agentRepository ??= new AgentRepository(_context);
        public IOfficeRepository Offices => _officeRepository ??= new OfficeRepository(_context);
        public ICompanyProfileRepository CompanyProfiles => _companyProfileRepository ??= new CompanyProfileRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}