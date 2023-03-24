using Application.Common.Helpers.Consts;
using FluentValidation;

namespace Application.UseCases.UserManagement.Queries.UserByUserName
{
    public class UserByUserNameQueryValidator : AbstractValidator<UserByUserNameQuery>
    {
        public UserByUserNameQueryValidator()
        {
            RuleFor(x => x.UserName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(30)
            .Matches(AppRegEx.USER_NAME);
        }
    }
}