using FluentValidation;

namespace Application.UseCases.LinkShortening.Commands.Common
{
    public class ShorteningCommandValidator<TCommand> : AbstractValidator<TCommand> where TCommand : ShorteningCommand
    {
        private readonly string urlRegex = "^https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$";

        public ShorteningCommandValidator()
        {
            RuleFor(x => x.Url )
            .NotEmpty()
            .Matches(urlRegex).WithMessage("'{PropertyName}' is not a valid URL");
        }
    }
}