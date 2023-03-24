using System.Net;
using Application.Common.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.UseCases.Auth.Commands.Register
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
            var user = new AppUser()
            {
                FirstName = command.FirstName,
                LastName  = command.LastName,
                UserName  = command.UserName,
                Email     = command.Email
            };

            var result = await _userManager.CreateAsync(user, command.Password);

            if(result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                return new() { EmailConfirmationToken = token };
            }

            var firstError = result.Errors.First().Description;

            throw new AppException((int)HttpStatusCode.Conflict, firstError);

        }
    }
}