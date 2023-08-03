using NatnaAgencyDigitalSystem.Api;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Service.Services;

namespace NatnaAgencyDigitalSystem.Service
{

    public class AgentService : IAgentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AgentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<Agent> CreateAgent(Agent newAgent)
        {
            await _unitOfWork.Agents
                .AddAsync(newAgent);
            await _unitOfWork.CommitAsync();
            return newAgent;
        }

        public async Task DeleteAgent(Agent Agent)
        {
            _unitOfWork.Agents.Remove(Agent);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Agent>> GetAllAgents()
        {
            return await _unitOfWork.Agents.GetAllAsync();
        }

        public async Task<Agent> GetAgentById(int id)
        {
            return await _unitOfWork.Agents.GetByIdAsync(id);
        }

        public async Task UpdateAgent(Agent AgentToBeUpdated, Agent Agent)
        {
            //  AgentToBeUpdated. = Agent.Name;

            await _unitOfWork.CommitAsync();
        }
    }


}
