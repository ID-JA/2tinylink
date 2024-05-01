using System.Text.RegularExpressions;
using Application.Common.Exceptions;
using Application.Common.Helpers.Consts;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.UseCases.Auth.Queries.Login
{
    public class LoginQueryHandler(
        SignInManager<AppUser> signInManager,
        UserManager<AppUser> userManager,
        IJwtProvider jwtProvider)
        : IRequestHandler<LoginQuery, LoginQueryResult>
    {
        public async Task<LoginQueryResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var isEmail = query.UserNameOrEmail.Contains("@");

            AppUser user;

            if (isEmail)
            {
                user = await userManager.FindByEmailAsync(query.UserNameOrEmail);
            }
            else
            {
                user = await userManager.FindByNameAsync(query.UserNameOrEmail);
            }

            if (user is null)
                throw new AppException((int)StatusCodes.Status422UnprocessableEntity,
                    "The username or password you entered is incorrect.");
            var result = await signInManager.CheckPasswordSignInAsync(user, query.Password, false);

            if (result.Succeeded)
            {
                var token = jwtProvider.Create(user);
                var loginResult = user.Adapt<LoginQueryResult>();
                loginResult.Token = token;
                return loginResult;
            }

            if (result.IsNotAllowed)
            {
                throw new AppException((int)StatusCodes.Status409Conflict, "The email address is not confirmed.");
            }

            throw new AppException((int)StatusCodes.Status422UnprocessableEntity, "The username or password you entered is incorrect.");

        }
    }
}