using System.Net;
using Application.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.UseCases.CorrespondedUrl.Queries.UrlByAlias.Behaviors
{
    public class UrlByAliasQueryValidationBehavior : IPipelineBehavior<UrlByAliasQuery, UrlByAliasQueryResult>
    {
        private readonly IValidator<UrlByAliasQuery> _validator;
        public UrlByAliasQueryValidationBehavior(IValidator<UrlByAliasQuery> validator)
        {
            _validator = validator;
        }
        public async Task<UrlByAliasQueryResult> Handle(UrlByAliasQuery query, RequestHandlerDelegate<UrlByAliasQueryResult> next, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(query, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var firstError = validationResult.Errors.First();

            throw new AppException((int)HttpStatusCode.UnprocessableEntity, firstError.ErrorMessage);
        }
    }
}