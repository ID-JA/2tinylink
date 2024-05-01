using System.Net;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Projects.Queries;

public class VerifyProjectInvitationRequest : IRequest<bool>
{
    public string Code { get; set; }
}

public class VerifyProjectInvitationRequestHandler(
    ICurrentUser _currentUser,
    IRepository<ProjectUser> _repository,
    IAppDbContext _dbContext) : IRequestHandler<VerifyProjectInvitationRequest, bool>
{
    public async Task<bool> Handle(VerifyProjectInvitationRequest request, CancellationToken cancellationToken)
    {

        var userId = Guid.Parse(_currentUser.GetUserId());

        var project = await _dbContext.Projects
            .Include(p => p.ProjectUsers)
            .ThenInclude(pu => pu.AppUser)
            .Where(x => x.InviteCode == request.Code)
            .AsSplitQuery()
            .FirstOrDefaultAsync(cancellationToken) ?? throw new AppException((int)HttpStatusCode.NotFound, $"Project with this code '{request.Code}' dosen't exists, please verify again.");
        
        var userAlreadyInvited = project.ProjectUsers.Any(x => x.AppUser.Id.Equals(userId));

        if (userAlreadyInvited)
        {
            // todo: redirect user to project because he's already a member in the project
            return false;
        }

        // Add user to project as member
        var projectUser = new ProjectUser()
        {
            AppUserId = userId,
            ProjectId = project.Id,
        };
        await _repository.AddAsync(projectUser, cancellationToken);

        return true;
    }
}