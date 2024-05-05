using Application.Common.Exceptions;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Text;

namespace Application.UseCases.Auth.Commands.Register
{
    public class RegisterCommandHandler(UserManager<AppUser> _userManager, IMailService _mailSerivce) : IRequestHandler<RegisterCommand, string>
    {
        public async Task<string> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var user = new AppUser()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                UserName = command.UserName,
                Email = command.Email
            };

            var result = await _userManager.CreateAsync(user, command.Password);

            if (result.Succeeded)
            {
                var confirmationEmail = await GetEmailVerificationUriAsync(user, command.Origin);
                await _mailSerivce.SendAccountConfirmation(user, confirmationEmail);
                return "User account created successfully";
            }

            throw new AppException((int)HttpStatusCode.Conflict, result.Errors.First().Description);

        }

        private async Task<string> GetEmailVerificationUriAsync(AppUser user, string origin)
        {

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var endpointUri = new Uri(string.Concat($"{origin}/", "api/auth/email-confirmation/"));
            var verificationUri = QueryHelpers.AddQueryString(endpointUri.ToString(), "username", user.UserName.ToString());
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "token", token);
            return verificationUri;
        }
    }
}