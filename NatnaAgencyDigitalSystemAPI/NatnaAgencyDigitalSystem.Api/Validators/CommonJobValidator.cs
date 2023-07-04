using FluentValidation;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Api.Resources;

namespace NatnaAgencyDigitalSystem.Api.Validators
{
    public class CommonJobValidator : AbstractValidator<CommonJobResource>
    {
        public CommonJobValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
