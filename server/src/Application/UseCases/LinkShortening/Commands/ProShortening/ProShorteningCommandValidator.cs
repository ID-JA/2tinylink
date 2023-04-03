using System.Globalization;
using Application.UseCases.LinkShortening.Commands.Common;
using FluentValidation;

namespace Application.UseCases.LinkShortening.Commands.ProShortening
{
    public class ProShorteningCommandValidator : ShorteningCommandValidator<ProShorteningCommand>
    {
        public ProShorteningCommandValidator()
        {
            When(x => x.ExpiredAt is not null, () =>
            {

                RuleFor(x => x.ExpiredAt)
                .Cascade(CascadeMode.Stop)
                .Must(x => BeAValidDate(x.ToString())).WithMessage("'{PropertyName}' must be a valid format date")
                .Must(x => DateTime.Parse(x).ToUniversalTime() > DateTime.Now.AddMinutes(3)).WithMessage("'{PropertyName}' must be in the future.");

            });

        }

        private bool BeAValidDate(string value)
        {
            DateTime date;
            return DateTime.TryParse(value,CultureInfo.InvariantCulture, out date);
        }
    }
}