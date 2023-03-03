using System.Net;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.CorrespondedUrl.Queries.UrlByAddress
{
    public class UrlByAddressQueryHandler : IRequestHandler<UrlByAddressQuery, UrlByAddressQueryResult>
    {
        private readonly IAppDbContext _context;
        public UrlByAddressQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<UrlByAddressQueryResult> Handle(UrlByAddressQuery query, CancellationToken cancellationToken)
        {
            var result = await _context.TinyLinks.AsNoTracking()
                                                 .Where(x => x.IsActive && x.Address == query.Address)
                                                 .Select(x => new {
                                                    Url = x.Url
                                                 })
                                                 .SingleOrDefaultAsync(cancellationToken);
            if(result is null)
            {
                throw new AppException((int)HttpStatusCode.NotFound, $"Cannot find url with address : '{query.Address}'");
            }

            return new() { Url = result.Url };
        }
    }
}