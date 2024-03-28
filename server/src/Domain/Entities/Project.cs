using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Common;

namespace Domain.Entities;

public class Project : BaseEntity
{
    public string Name { get; private set; }

    public AppUser AppUser { get; private set; }

    [Column("UserId")]
    public Guid AppUserId { get; private set; }

    public ICollection<TinyLink> links { get; private set; } = [];

}