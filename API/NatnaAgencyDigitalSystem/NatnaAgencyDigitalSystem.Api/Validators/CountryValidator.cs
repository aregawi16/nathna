using FluentValidation;
using NatnaAgencyDigitalSystem.Api.Resources;
using NatnaAgencyDigitalSystem.Api.Models.Setting;

namespace NatnaAgencyDigitalSystem.Api.Validators
{
    public class AgentValidator : AbstractValidator<AgentResource>
    {
        public AgentValidator()
        {
            RuleFor(a => a.FullName)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
