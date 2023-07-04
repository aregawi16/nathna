using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NatnaAgencyDigitalSystem.Api.Resources;
using NatnaAgencyDigitalSystem.Api.Validators;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Api.Services;

namespace NatnaAgencyDigitalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class AgentController : ControllerBase
    {
       
            private readonly IAgentService _AgentService;
            private readonly IMapper _mapper;

            public AgentController(IAgentService AgentService, IMapper mapper)
            {
                this._mapper = mapper;
                this._AgentService = AgentService;
            }

            [HttpGet("")]   
            public async Task<ActionResult<IEnumerable<Agent>>> GetAllAgents()
            {

            var Agents = await _AgentService.GetAllAgents();
                var AgentResource = _mapper.Map<IEnumerable<Agent>, IEnumerable<Agent>>(Agents).OrderByDescending(o=>o.AgentId);

                return Ok(AgentResource);
            }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Agent>>> GetAgentLists()
        {
            var Agents = await _AgentService.GetAllAgents();
            var AgentResource = _mapper.Map<IEnumerable<DropDownPObject>, IEnumerable<DropDownPObject>>(Agents.ToList().Select(s => new DropDownPObject
            {
                id=s.AgentId,
                name = s.FullName
            }));

            return Ok(AgentResource);
        }

        [HttpGet("{id}")]
            [Authorize(Roles = "Test")]
            public async Task<ActionResult<Agent>> GetAgentById(int id)
            {
                var Agent = await _AgentService.GetAgentById(id);
                var AgentResource = _mapper.Map<Agent, Agent>(Agent);

                return Ok(AgentResource);
            }

            [HttpPost("")]
            [Authorize(Roles ="OnlyTest")]
            public async Task<ActionResult<Agent>> CreateAgent([FromBody] AgentResource AgentRes)
            {
            //AgentRes.CreatedBy = "1111";
            //AgentRes.ModifiedBy = "1111";
            //AgentRes.CreatedDate = DateTime.Now;
            //AgentRes.ModifiedDate = DateTime.Now;
            var validator = new AgentValidator();
                var validationResult = await validator.ValidateAsync(AgentRes);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

                var AgentToCreate = _mapper.Map<AgentResource, Agent>(AgentRes);

                var newAgent = await _AgentService.CreateAgent(AgentToCreate);

                var Agent = await _AgentService.GetAgentById(newAgent.AgentId);

                var AgentResource = _mapper.Map<Agent, Agent>(Agent);

                return Ok(AgentResource);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<Agent>> UpdateAgent(int id, [FromBody] AgentResource AgentRes)
            {
                var validator = new AgentValidator();
                var validationResult = await validator.ValidateAsync(AgentRes);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

                var AgentToBeUpdated = await _AgentService.GetAgentById(id);

                if (AgentToBeUpdated == null)
                    return NotFound();

                var Agent = _mapper.Map<AgentResource, Agent>(AgentRes);

                await _AgentService.UpdateAgent(AgentToBeUpdated, Agent);

                var updatedAgent = await _AgentService.GetAgentById(id);

                var updatedAgentResource = _mapper.Map<Agent, Agent>(updatedAgent);

                return Ok(updatedAgentResource);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAgent(int id)
            {
                var Agent = await _AgentService.GetAgentById(id);

                await _AgentService.DeleteAgent(Agent);

                return Ok("Deleted");
            }
        }

    }
