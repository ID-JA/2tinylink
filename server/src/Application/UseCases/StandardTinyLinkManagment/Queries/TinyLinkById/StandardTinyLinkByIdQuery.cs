using MediatR;

namespace Application.UseCases.StandardTinyLinkManagment.Queries.TinyLinkById
{
    public class StandardTinyLinkByIdQuery : IRequest<StandardTinyLinkByIdQueryResult>
    {
        public Guid Id { get; set; }
    }
}