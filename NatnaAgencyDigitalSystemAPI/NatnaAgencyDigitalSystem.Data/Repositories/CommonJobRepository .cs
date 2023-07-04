
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Api.Repositories;

namespace NatnaAgencyDigitalSystem.Data.Repositories
{
    public class CommonJobRepository : Repository<CommonJob>, ICommonJobRepository
    {
        public CommonJobRepository(NatnaAgencyDbContext context)
            : base(context)
        { }

        

        private NatnaAgencyDbContext NatnaAgencyDbContext
        {
            get { return Context as NatnaAgencyDbContext; }
        }
    }
}