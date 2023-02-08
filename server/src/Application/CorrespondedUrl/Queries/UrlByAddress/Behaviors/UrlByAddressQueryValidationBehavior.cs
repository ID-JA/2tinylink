using System.Net;
using Application.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.CorrespondedUrl.Queries.UrlByAddress.Behaviors
{
    public class UrlByAddressQueryValidationBehavior : IPipelineBehavior<UrlByAddressQuery, UrlByAddressQueryResult>
    {
        private readonly IValidator<UrlByAddressQuery> _validator;
        public UrlByAddressQueryValidationBehavior(IValidator<UrlByAddressQuery> validator)
        {
            _validator = validator;
        }
        public async Task<UrlByAddressQueryResult> Handle(UrlByAddressQuery query, RequestHandlerDelegate<UrlByAddressQueryResult> next, CancellationToken cancellationToken)
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