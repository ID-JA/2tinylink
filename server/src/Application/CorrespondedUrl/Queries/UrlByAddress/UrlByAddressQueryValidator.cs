using FluentValidation;

namespace Application.CorrespondedUrl.Queries.UrlByAddress
{
    public class UrlByAddressQueryValidator : AbstractValidator<UrlByAddressQuery>
    {
        public UrlByAddressQueryValidator()
        {
            RuleFor(x => x.Address)
            .NotEmpty().WithMessage("'{PropertyName}' cannot be empty");
        }
    }
}