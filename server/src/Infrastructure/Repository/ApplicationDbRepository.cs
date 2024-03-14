using Application.Common.Interfaces.Persistence;
using Ardalis.Specification.EntityFrameworkCore;
using Ardalis.Specification;
using Domain.Entities.Common;
using Infrastructure.Persistence;
using Mapster;

namespace Infrastructure.Repository;

public class ApplicationDbRepository<T>(AppDbContext dbContext)
    : RepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
    // We override the default behavior when mapping to a dto.
    // We're using Mapster's ProjectToType here to immediately map the result from the database.
    protected override IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification) =>
        ApplySpecification(specification, false)
            .ProjectToType<TResult>();
}
