using MediatR;

namespace Application.UseCases.StandardTinyLinkManagement.Queries.TinyLinkById
{
    public class StandardTinyLinkByIdQuery : IRequest<StandardTinyLinkByIdQueryResult>
    {
        public Guid Id { get; set; }
    }
}