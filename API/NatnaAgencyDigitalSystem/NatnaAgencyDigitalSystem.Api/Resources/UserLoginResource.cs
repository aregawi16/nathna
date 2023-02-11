namespace NatnaAgencyDigitalSystem.Api.Resources
{

        public class UserLoginResource
        {
            public string UserName { get; set; }

            public string Password { get; set; }
            public Boolean RememberMe { get; set; }
        }
    public class RoleResource
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}

  