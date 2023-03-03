using System.Net;
using Application.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.UseCases.Auth.Command.Register.Behaviors
{
    public class RegisterCommandValidationBehavior : IPipelineBehavior<RegisterCommand, RegisterCommandResult>
    {
        private readonly IValidator<RegisterCommand> _validator;

        public RegisterCommandValidationBehavior(IValidator<RegisterCommand> validator)
        {
            _validator = validator;
        }

        public async Task<RegisterCommandResult> Handle(RegisterCommand command, RequestHandlerDelegate<RegisterCommandResult> next, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var firstError = validationResult.Errors.First();

            throw new AppException((int)HttpStatusCode.UnprocessableEntity, firstError.ErrorMessage);
        }
    }
}