using FluentValidation;
using NatnaAgencyDigitalSystem.Api.Resources;
using NatnaAgencyDigitalSystem.Api.Models.Setting;

namespace NatnaAgencyDigitalSystem.Api.Validators
{
    public class CountryValidator : AbstractValidator<CountryResource>
    {
        public CountryValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
