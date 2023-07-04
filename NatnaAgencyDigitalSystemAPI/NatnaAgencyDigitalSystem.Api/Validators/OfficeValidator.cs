using FluentValidation;
using NatnaAgencyDigitalSystem.Api.Resources;
using NatnaAgencyDigitalSystem.Api.Models.Setting;

namespace NatnaAgencyDigitalSystem.Api.Validators
{
    public class OfficeValidator : AbstractValidator<OfficeResource>
    {
        public OfficeValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
