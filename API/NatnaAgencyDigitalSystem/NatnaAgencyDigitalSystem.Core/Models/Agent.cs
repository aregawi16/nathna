using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatnaAgencyDigitalSystem.Api.Models
{
    public class Agent
    {
        public int AgentId { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Description { get; set; }
    }
}
