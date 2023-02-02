using Application.LinkShortning.Commands.RegularShortning;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviors
{
    public class RegularShortningCommandValidationBehavior : IPipelineBehavior<RegularShortningCommand, RegularShortningResult>
    {
        private readonly IValidator<RegularShortningCommand> _validator;
        public RegularShortningCommandValidationBehavior(IValidator<RegularShortningCommand> validator)
        {
            _validator = validator;
        }
        public async Task<RegularShortningResult> Handle(RegularShortningCommand request, RequestHandlerDelegate<RegularShortningResult> next, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var firstError = validationResult.Errors.First();

            throw new Exception(firstError.ErrorMessage);
        }
    }
}