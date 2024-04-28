using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public class ProjectInvitation : IAggregateRoot
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
