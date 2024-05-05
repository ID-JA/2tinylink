using Domain.Entities.Common;

namespace Domain.Entities;

public class Project : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; set; }
    public string? InviteCode { get; set; }

    public List<AppUser> AppUsers { get; } = [];
    public List<Link> Links { get;  } = [];
    public List<ProjectInvitation> Invitations { get; } = [];
    public List<ProjectUser> ProjectUsers { get; } = [];


    public static Project Create(string name, string description, string inviteCode)
    {
        return new Project
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            InviteCode = inviteCode,
            CreatedAt = DateTime.Now,
            LastModified = DateTime.Now,
            IsActive = true
        };
    }

}