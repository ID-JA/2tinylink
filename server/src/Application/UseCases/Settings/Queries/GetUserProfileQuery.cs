using System.Net;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Persistence;
using Application.Specifications;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Settings.Queries;

public class GetUserProfileQuery : IRequest<UserProfileDto>;

public class UserProfileDto
{
    public string Email { get; set; }
    public string UserName { get; set; }
}

public class GetUserProfileQueryHandler(ICurrentUser _currentUser, IAppDbContext _appDbContext, IReadRepository<AppUser> useRepository)
    : IRequestHandler<GetUserProfileQuery, UserProfileDto>
{

    private readonly IReadRepository<AppUser> _useRepository = useRepository;


    public async Task<UserProfileDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var userId = Guid.Parse(_currentUser.GetUserId());
        var userSpec = new UserProfileSpecification(userId);
        var user = await _useRepository.FirstOrDefaultAsync(userSpec, cancellationToken);

        if (user == null)
        {
            throw new AppException((int)HttpStatusCode.NoContent, "User not found");
        }

        return user.Adapt<UserProfileDto>();

    }
}


