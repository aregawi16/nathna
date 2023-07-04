
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Api.Repositories;

namespace NatnaAgencyDigitalSystem.Data.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(NatnaAgencyDbContext context)
            : base(context)
        { }

        

        private NatnaAgencyDbContext NatnaAgencyDbContext
        {
            get { return Context as NatnaAgencyDbContext; }
        }
    }
}