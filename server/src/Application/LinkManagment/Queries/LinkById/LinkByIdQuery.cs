using MediatR;

namespace Application.LinkManagment.Queries.LinkById
{
    public class LinkByIdQuery : IRequest<LinkByIdQueryResult>
    {
        public Guid Id { get; set; }
    }
}