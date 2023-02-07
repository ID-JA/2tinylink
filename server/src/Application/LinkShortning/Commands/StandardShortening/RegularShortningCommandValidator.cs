using FluentValidation;

namespace Application.LinkShortning.Commands.StandardShortening
{
    public class RegularShortningCommandValidator : AbstractValidator<StandardShorteningCommand>
    {
        private readonly string urlRegex = "^https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$";

        public RegularShortningCommandValidator()
        {
            RuleFor(x => x.Url )
            .NotEmpty()
            .Matches(urlRegex).WithMessage("'{PropertyName}' is not a valid URL");
        }
    }
}