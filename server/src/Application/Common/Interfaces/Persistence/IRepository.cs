using Ardalis.Specification;
using Domain.Entities.Common;

namespace Application.Common.Interfaces.Persistence;

public interface IRepository<T> : IRepositoryBase<T>
    where T : class, IAggregateRoot
{
}

public interface IReadRepository<T> : IReadRepositoryBase<T>
    where T : class, IAggregateRoot
{
}

public interface IRepositoryWithEvents<T> : IRepositoryBase<T>
    where T : class, IAggregateRoot
{
}
