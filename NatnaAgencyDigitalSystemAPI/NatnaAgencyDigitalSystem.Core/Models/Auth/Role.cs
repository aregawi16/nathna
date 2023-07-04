using System;
using Microsoft.AspNetCore.Identity;

namespace NatnaAgencyDigitalSystem.Api.Models.Auth
{
    public class Role : IdentityRole<Guid>
    { 
    public string? Description { get; set; }
    }
}