using System.Net;
using Application.Common.Exceptions;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.UseCases.Auth.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResult>
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<RegisterCommandResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var appUser = new AppUser()
            {
                FirstName = command.FirstName,
                LastName  = command.LastName,
                UserName  = command.UserName,
                Email     = command.Email
            };

            var result = await _userManager.CreateAsync(appUser, command.Password);

            if(result.Succeeded)
            {
                 return new() { UserName = appUser.UserName };
            }

            var firstError = result.Errors.First().Description;

            throw new AppException((int)HttpStatusCode.Conflict, firstError);

        }
    }
}