using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

// TODO: remove this in future / if isn't unnecessary
/// <summary>
/// This Entity is used to track invitation that been sent to users
/// </summary>
public class ProjectInvitation : IAggregateRoot
{
    public string Email { get; set; }
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
