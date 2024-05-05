using Domain.Entities.Common;

namespace Domain.Entities;

public class ProjectUser : IAggregateRoot
{
    public string Role { get; set; } = "member";
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime LastModified { get; set;} = DateTime.UtcNow;
}