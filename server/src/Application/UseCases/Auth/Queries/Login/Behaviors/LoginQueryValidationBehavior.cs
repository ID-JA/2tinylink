using System.Net;
using Application.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.UseCases.Auth.Queries.Login.Behaviors
{
    public class LoginQueryValidationBehavior : IPipelineBehavior<LoginQuery, LoginQueryResult>
    {
        private readonly IValidator<LoginQuery> _validator;

        public LoginQueryValidationBehavior(IValidator<LoginQuery> validator)
        {
            _validator = validator;
        }

        public async Task<LoginQueryResult> Handle(LoginQuery query, RequestHandlerDelegate<LoginQueryResult> next, CancellationToken cancellationToken)
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