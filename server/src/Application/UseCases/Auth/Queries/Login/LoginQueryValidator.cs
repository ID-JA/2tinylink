using Application.Common.Helpers.Consts;
using FluentValidation;

namespace Application.UseCases.Auth.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            // Rules for UserNameOrEmail property
            When(x => x.UserNameOrEmail is not null && x.UserNameOrEmail.Contains("@"), () => {
                RuleFor(x => x.UserNameOrEmail)
                    .EmailAddress()
                    .WithName("Email");
            })
            .Otherwise(() => {
                RuleFor(x => x.UserNameOrEmail)
                    .NotEmpty().WithMessage("'UserNameOrEmail' must not be empty.")
                    .MinimumLength(3)
                    .MaximumLength(30)
                    .Matches(AppRegEx.USER_NAME).WithMessage($"{{PropertyName}} must match the pattern '{AppRegEx.USER_NAME}'")
                    .WithName("UserName");
            });

            RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .Matches(AppRegEx.PASSWORD)
            .WithMessage("'{PropertyName}' must contain at least one number and have a mixture of uppercase and lowercase letters and at least one special character like $.");


        }
    }
}