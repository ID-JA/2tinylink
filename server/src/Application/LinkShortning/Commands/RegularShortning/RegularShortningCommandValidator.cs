using FluentValidation;

namespace Application.LinkShortning.Commands.RegularShortning
{
    public class RegularShortningCommandValidator : AbstractValidator<RegularShortningCommand>
    {
        public RegularShortningCommandValidator()
        {
            RuleFor(x => x.Url ).NotEmpty();
        }
    }
}