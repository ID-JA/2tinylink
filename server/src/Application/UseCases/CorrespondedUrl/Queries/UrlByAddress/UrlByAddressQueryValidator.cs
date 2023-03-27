using FluentValidation;

namespace Application.UseCases.CorrespondedUrl.Queries.UrlByAlias
{
    public class UrlByAliasQueryValidator : AbstractValidator<UrlByAliasQuery>
    {
        public UrlByAliasQueryValidator()
        {
            RuleFor(x => x.Alias)
            .NotEmpty().WithMessage("'{PropertyName}' cannot be empty");
        }
    }
}