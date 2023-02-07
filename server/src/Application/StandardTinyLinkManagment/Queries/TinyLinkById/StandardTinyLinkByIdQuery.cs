using MediatR;

namespace Application.StandardTinyLinkManagment.Queries.TinyLinkById
{
    public class StandardTinyLinkByIdQuery : IRequest<StandardTinyLinkByIdQueryResult>
    {
        public Guid Id { get; set; }
    }
}