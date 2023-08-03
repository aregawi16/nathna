using FluentValidation;
using NatnaAgencyDigitalSystem.Api.Resources;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Core.Models;

namespace NatnaAgencyDigitalSystem.Api.Validators
{
    public class CompanyProfileValidator : AbstractValidator<CompanyProfile>
    {
        public CompanyProfileValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
