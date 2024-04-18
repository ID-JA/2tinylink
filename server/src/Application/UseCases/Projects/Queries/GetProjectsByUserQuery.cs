using Application.Common.Interfaces;
using Application.Common.Interfaces.Persistence;
using Ardalis.Specification;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Projects.Queries;

public class ProjectDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

/// <summary>
/// Retrieve authenticted user's projects
/// </summary>
public class GetProjectsByUserQuery : IRequest<List<ProjectDTO>>;

public class GetPrjectsByUserQueryHandler(IReadRepository<Project> _readRepository, ICurrentUser _currentUser) : IRequestHandler<GetProjectsByUserQuery, List<ProjectDTO>>
{
    public async Task<List<ProjectDTO>> Handle(GetProjectsByUserQuery request, CancellationToken cancellationToken)
    {
        var userId = Guid.Parse(_currentUser.GetUserId());
        var spec = new ProjectsByUserSpec(userId);
        var result = await _readRepository.ListAsync(spec, cancellationToken);
        return result;
    }
}


public class ProjectsByUserSpec : Specification<Project, ProjectDTO>
{
    public ProjectsByUserSpec(Guid userId)
    {
        Query.Where(x => x.AppUserId.Equals(userId));
    }
}
