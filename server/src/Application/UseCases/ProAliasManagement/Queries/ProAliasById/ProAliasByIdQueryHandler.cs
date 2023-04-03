using System.Net;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.ProAliasManagement.Queries.ProAliasById
{
    public class ProAliasByIdQueryHandler : IRequestHandler<ProAliasByIdQuery, ProAliasByIdQueryResult>
    {
        private readonly IAppDbContext _dbContext;
        public ProAliasByIdQueryHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProAliasByIdQueryResult> Handle(ProAliasByIdQuery query, CancellationToken cancellationToken)
        {
            var link = await _dbContext.TinyLinks.AsNoTracking()
                                       .Where(x => query.Id == x.Id && x.IsActive)
                                       .Select(x => new {
                                        Id          = x.Id,
                                        Alias         = x.Alias,
                                        CreatedAt   = x.CreatedAt
                                       })
                                       .FirstOrDefaultAsync();
            if(link is null)
            {
                throw new AppException(statusCode: (int)HttpStatusCode.NotFound, errorMessage: $"Link with Id: {query.Id} not found.");
            }

            return new() { Id = link.Id, Alias = link.Alias, CreatedAt = link.CreatedAt };
        }
    }
}