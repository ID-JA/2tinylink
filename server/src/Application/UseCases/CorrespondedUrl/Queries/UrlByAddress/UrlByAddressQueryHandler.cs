using System.Net;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.CorrespondedUrl.Queries.UrlByAlias
{
    public class UrlByAliasQueryHandler : IRequestHandler<UrlByAliasQuery, UrlByAliasQueryResult>
    {
        private readonly IAppDbContext _context;
        public UrlByAliasQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<UrlByAliasQueryResult> Handle(UrlByAliasQuery query, CancellationToken cancellationToken)
        {
            var result = await _context.TinyLinks.AsNoTracking()
                                                 .Where(x => x.IsActive && x.Alias == query.Alias)
                                                 .Select(x => new {
                                                    Url = x.Url
                                                 })
                                                 .SingleOrDefaultAsync(cancellationToken);
            if(result is null)
            {
                throw new AppException((int)HttpStatusCode.NotFound, $"Cannot find url with alias : '{query.Alias}'");
            }

            return new() { Url = result.Url };
        }
    }
}