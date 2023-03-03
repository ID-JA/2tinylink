using System.Net;
using Application.Common.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.UseCases.UserManagement.Queries.UserByUserName
{
    public class UserByUserNameQueryHandler : IRequestHandler<UserByUserNameQuery, UserByUserNameQueryResult>
    {
        private readonly UserManager<AppUser> _userManager;

        public UserByUserNameQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserByUserNameQueryResult> Handle(UserByUserNameQuery query, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(query.UserName);

            if(user is null)
            {
                throw new AppException((int)HttpStatusCode.NotFound, $"User with username '{query.UserName}' not found.");
            }

            return new() 
            { 
                FirstName = user.FirstName,
                LastName = user.LastName, 
                UserName = user.UserName, 
                CreatedAt = user.CreatedAt 
            };
        }
    }
}