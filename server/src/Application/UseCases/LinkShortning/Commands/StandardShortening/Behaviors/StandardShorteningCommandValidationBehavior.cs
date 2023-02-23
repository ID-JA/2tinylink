using System.Net;
using Application.Common.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.UseCases.LinkShortning.Commands.StandardShortening.Behaviors
{
    public class StandardShorteningCommandValidationBehavior : IPipelineBehavior<StandardShorteningCommand, StandardShorteningResult>
    {
        private readonly IValidator<StandardShorteningCommand> _validator;
        public StandardShorteningCommandValidationBehavior(IValidator<StandardShorteningCommand> validator)
        {
            _validator = validator;
        }
        public async Task<StandardShorteningResult> Handle(StandardShorteningCommand request, RequestHandlerDelegate<StandardShorteningResult> next, CancellationToken cancellationToken)
        {

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var firstError = validationResult.Errors.First();

            throw new AppException((int)HttpStatusCode.UnprocessableEntity, firstError.ErrorMessage);
        }
    }
}