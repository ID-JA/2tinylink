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
        //var project = await _dbContext.Projects
        //    .Where(x => x.InviteCode == request.Code && x.AppUsers.Any(pu => pu.Id.Equals(userId)))
        //    .FirstOrDefaultAsync(cancellationToken);

        //var project = await _dbContext.Projects.Include(p => p.ProjectUsers).ThenInclude(pu => pu.AppUser)
        //    .ToArrayAsync();

        //if (project.AppUsers.Count > 0)
        //{
        //    // redirect user to project because he's already a member in the project
        //    return false;
        //}

        //var projectUser = new ProjectUser()
        //{
        //    AppUserId = userId,
        //    ProjectId = project.Id,
        //};
        //await _repository.AddAsync(projectUser, cancellationToken);

        return true;
    }
}