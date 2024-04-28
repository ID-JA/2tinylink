using Application.Common.Interfaces;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Projects.Commands;

public class CreateProjectRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

}

public class CreateProjectCommandHandler(IRepository<Project> _repositoryProject, IRepository<ProjectUser> _repositoryProjectUser, ICurrentUser _currentUser, IUniqueIdProvider _uniqueIdProvider, IAppDbContext _dbContext) : IRequestHandler<CreateProjectRequest, Guid>
{
    public async Task<Guid> Handle(CreateProjectRequest request, CancellationToken cancellationToken)
    {
        string generatedRandomKey = null;
        do
        {
            generatedRandomKey = _uniqueIdProvider.GetUniqueString();

        } while (await _dbContext.Projects.AnyAsync(x=>x.InviteCode.Equals(generatedRandomKey), cancellationToken: cancellationToken));
        
       

        var project = Project.Create(request.Name, request.Description, generatedRandomKey);
        await _repositoryProject.AddAsync(project, cancellationToken);
       
        var userId = Guid.Parse(_currentUser.GetUserId());

        var projectUser = new ProjectUser()
        {
            ProjectId = project.Id,
            AppUserId = userId,
            Role = "admin"
        };
        await _repositoryProjectUser.AddAsync(projectUser, cancellationToken);

        return project.Id;
    }
}
