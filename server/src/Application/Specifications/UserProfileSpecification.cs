using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications;

public sealed class UserProfileSpecification : Specification<AppUser>
{
    public UserProfileSpecification(Guid id)
    {
        Query.Where(o => o.Id == id);
    }
}