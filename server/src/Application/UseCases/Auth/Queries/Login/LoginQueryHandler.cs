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
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryResult>
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtProvider _jwtProvider;

        public LoginQueryHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IJwtProvider jwtProvider)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginQueryResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var isEmail = query.UserNameOrEmail.Contains("@");

            AppUser user;

            if (isEmail)
            {
                user = await _userManager.FindByEmailAsync(query.UserNameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(query.UserNameOrEmail);
            }

            if (user is not null)
            {
                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, query.Password, false);

                if (result.Succeeded)
                {
                    var token = _jwtProvider.Create(user);
                    var loginResult = user.Adapt<LoginQueryResult>();
                    loginResult.Token = token;
                    return loginResult;
                }
                else if (result.IsNotAllowed)
                {
                    throw new AppException((int)StatusCodes.Status409Conflict, "The email address is not confirmed.");
                }
            }

            throw new AppException((int)StatusCodes.Status422UnprocessableEntity, "The username or password you entered is incorrect.");

        }
    }
}