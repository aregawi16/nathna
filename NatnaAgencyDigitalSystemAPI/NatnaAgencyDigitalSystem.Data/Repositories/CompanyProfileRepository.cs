
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Api.Repositories;
using NatnaAgencyDigitalSystem.Core.Models;
using NatnaAgencyDigitalSystem.Core.Repositories;

namespace NatnaAgencyDigitalSystem.Data.Repositories
{
    public class CompanyProfileRepository : Repository<CompanyProfile>, ICompanyProfileRepository
    {
        public CompanyProfileRepository(NatnaAgencyDbContext context)
            : base(context)
        { }



        private NatnaAgencyDbContext NatnaAgencyDbContext
        {
            get { return Context as NatnaAgencyDbContext; }
        }
    }
}