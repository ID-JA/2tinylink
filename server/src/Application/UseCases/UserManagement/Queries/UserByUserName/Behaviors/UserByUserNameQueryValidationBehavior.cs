using System.Net;
using Application.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.UseCases.UserManagement.Queries.UserByUserName.Behaviors
{
    public class UserByUserNameQueryValidationBehavior : IPipelineBehavior<UserByUserNameQuery, UserByUserNameQueryResult>
    {
        private readonly IValidator<UserByUserNameQuery> _validator;

        public UserByUserNameQueryValidationBehavior(IValidator<UserByUserNameQuery> validator)
        {
            _validator = validator;
        }

        public async Task<UserByUserNameQueryResult> Handle(UserByUserNameQuery query, RequestHandlerDelegate<UserByUserNameQueryResult> next, CancellationToken cancellationToken)
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