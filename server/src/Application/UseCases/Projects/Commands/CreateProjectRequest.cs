using Application.Common.Interfaces;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Projects.Commands;

public class CreateProjectRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;

}

public class CreateProjectCommandHandler(IRepository<Project> _repository, ICurrentUser _currentUser) : IRequestHandler<CreateProjectRequest, Guid>
{
    public async Task<Guid> Handle(CreateProjectRequest request, CancellationToken cancellationToken)
    {
        var userId = Guid.Parse(_currentUser.GetUserId());
        var project = Project.Create(request.Name, request.Description, userId);
        await _repository.AddAsync(project, cancellationToken);
        return project.Id;
    }
}
