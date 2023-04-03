using MediatR;

namespace Application.UseCases.ProAliasManagement.Queries.ProAliasById
{
    public class ProAliasByIdQuery : IRequest<ProAliasByIdQueryResult>
    {
        public Guid Id { get; set; }
    }
}