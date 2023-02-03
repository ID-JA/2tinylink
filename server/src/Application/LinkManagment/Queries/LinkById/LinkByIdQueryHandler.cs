using System.Net;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.LinkManagment.Queries.LinkById
{
    public class LinkByIdQueryHandler : IRequestHandler<LinkByIdQuery, LinkByIdQueryResult>
    {
        private readonly IAppDbContext _dbContext;
        public LinkByIdQueryHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LinkByIdQueryResult> Handle(LinkByIdQuery query, CancellationToken cancellationToken)
        {
            var link = await _dbContext.Links.AsNoTracking()
                                       .Where(x => query.Id == x.Id && x.IsActive)
                                       .Select(x => new {
                                        Id          = x.Id,
                                        URI         = x.URI,
                                        CreatedAt   = x.CreatedAt
                                       })
                                       .FirstOrDefaultAsync();
            if(link is null)
            {
                throw new AppException(statusCode: (int)HttpStatusCode.NotFound, errorMessage: $"Link with Id: {query.Id} not found.");
            }

            return new() { Id = link.Id, URI = link.URI, CreatedAt = link.CreatedAt };
        }
    }
}