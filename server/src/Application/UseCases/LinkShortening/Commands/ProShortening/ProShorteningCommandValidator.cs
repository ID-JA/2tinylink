using Application.UseCases.LinkShortening.Commands.Common;
using FluentValidation;

namespace Application.UseCases.LinkShortening.Commands.ProShortening
{
    public class ProShorteningCommandValidator : ShorteningCommandValidator<ProShorteningCommand>
    {
        public ProShorteningCommandValidator()
        {
            When(x => !string.IsNullOrWhiteSpace(x.ExpiredAt.ToString()) && x.ExpiredAt == default(DateTime), () => {

                RuleFor(x => x.ExpiredAt)
                .Cascade(CascadeMode.Stop)
                .Must(x => x > DateTime.Now.AddMinutes(3)).WithMessage("'{PropertyName}' must be in the future.");

            });
           
        }
    }
}