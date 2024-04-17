using System.Net;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.StandardTinyLinkManagement.Queries.TinyLinkById
{
    public class StandardTinyLinkByIdQueryHandler : IRequestHandler<StandardTinyLinkByIdQuery, StandardTinyLinkByIdQueryResult>
    {
        private readonly IAppDbContext _dbContext;
        private readonly ICurrentUser _currentUser;
        public StandardTinyLinkByIdQueryHandler(IAppDbContext dbContext, ICurrentUser currentUser)
        {
            _dbContext = dbContext;
            _currentUser = currentUser;
        }
        public async Task<StandardTinyLinkByIdQueryResult> Handle(StandardTinyLinkByIdQuery query, CancellationToken cancellationToken)
        {
            var userId = _currentUser.GetUserId();
            var link = await _dbContext.Links.AsNoTracking()
                                       .Where(x => query.Id == x.Id && x.IsActive && x.AppUserId.ToString() == _currentUser.GetUserId())
                                       .Select(x => new
                                       {
                                           x.Id,
                                           x.Address,
                                           x.CreatedAt,
                                       })
                                       .FirstOrDefaultAsync();
            if(link is null)
            {
                throw new AppException(statusCode: (int)HttpStatusCode.NotFound, errorMessage: $"Link with Id: {query.Id} not found.");
            }

            return new() { Id = link.Id, Address = link.Address, CreatedAt = link.CreatedAt };
        }
    }
}