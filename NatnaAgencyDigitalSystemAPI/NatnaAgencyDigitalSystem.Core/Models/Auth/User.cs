using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace NatnaAgencyDigitalSystem.Api.Models.Auth
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
      

        public string? MiddleName { get; set; }

        public string LastName { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {MiddleName} {LastName}";

        public int OfficeId { get; set; }
    }
}