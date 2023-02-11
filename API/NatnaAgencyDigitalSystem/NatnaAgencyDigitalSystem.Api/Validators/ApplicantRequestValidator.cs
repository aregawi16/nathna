using FluentValidation;
using NatnaAgencyDigitalSystem.Api.Resources;
using NatnaAgencyDigitalSystem.Api.Models;

namespace NatnaAgencyDigitalSystem.Api.Validators
{
    public class ApplicantProfileValidator : AbstractValidator<ApplicantProfileResource>
    {
        public ApplicantProfileValidator()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
