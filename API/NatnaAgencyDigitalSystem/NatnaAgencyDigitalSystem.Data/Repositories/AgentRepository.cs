
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Api.Repositories;

namespace NatnaAgencyDigitalSystem.Data.Repositories
{
    public class AgentRepository : Repository<Agent>, IAgentRepository
    {
        public AgentRepository(NatnaAgencyDbContext context)
            : base(context)
        { }

        

        private NatnaAgencyDbContext NatnaAgencyDbContext
        {
            get { return Context as NatnaAgencyDbContext; }
        }
    }
}