using System.Net;
using Application.Common.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.UseCases.Auth.Commands.EmailConfirmation
{
    public class EmailConfirmationCommandHandler : IRequestHandler<EmailConfirmationCommand>
    {
        private readonly UserManager<AppUser> _userManager;

        public EmailConfirmationCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(EmailConfirmationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if( user is null )
            {
                throw new AppException((int)HttpStatusCode.NotFound, $"User with '{request.UserName}' not found.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, request.Token);

            if(result.Succeeded)
            {
                return Unit.Value;
            }

            
            var firstError = result.Errors.First().Description;

            throw new AppException((int)HttpStatusCode.Conflict, firstError);



        }
    }
}