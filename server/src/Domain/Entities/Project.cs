using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;

namespace Domain.Entities;

public class Project : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; set; }
    public Guid AppUserId { get; private set; }
    public AppUser AppUser { get; private set; }

    public List<Link> Links { get; private set; } = [];

    public static Project Create(string name, string description, Guid userId)
    {
        return new Project
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            AppUserId = userId,
            CreatedAt = DateTime.Now,
            LastModified = DateTime.Now,
            IsActive = true
        };
    }
}