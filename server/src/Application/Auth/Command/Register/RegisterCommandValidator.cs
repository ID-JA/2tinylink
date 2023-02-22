using Application.Common.Helpers.Consts;
using FluentValidation;

namespace Application.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {

        public RegisterCommandValidator()
        {
            RuleFor(x => x.UserName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(30)
            .Matches(AppRegEx.USER_NAME);

            RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(30)
            .Matches(AppRegEx.FIRST_NAME).WithMessage("'{PropertyName}' must contains letters between A-Z.");

            RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(30)
            .Matches(AppRegEx.FIRST_NAME).WithMessage("'{PropertyName}' must contains letters between A-Z.");

            RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

            RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .Matches(AppRegEx.PASSWORD)
            .WithMessage("'{PropertyName}' must contain at least one number and have a mixture of uppercase and lowercase letters and at least one special character like $.");

            
        }
    }
}