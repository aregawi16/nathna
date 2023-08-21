using NatnaAgencyDigitalSystem.Api.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatnaAgencyDigitalSystem.Core.Models
{
    public class Notification:BaseModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
    }
}
