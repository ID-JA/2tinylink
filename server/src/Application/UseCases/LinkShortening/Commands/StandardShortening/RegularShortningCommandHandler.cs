using Application.Common.Interfaces;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.LinkShortening.Commands.StandardShortening
{
    public class RegularShorteningCommandHandler(IAppDbContext _dbContext, IUniqueIdProvider _uniqueIdProvider, ICurrentUser _currentUser) : IRequestHandler<StandardShorteningCommand, StandardShorteningResult>
    {
       
        public async Task<StandardShorteningResult> Handle(StandardShorteningCommand command, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(_currentUser.GetUserId());

            string generatedUniqueId;

            do
            {
                generatedUniqueId = _uniqueIdProvider.GetUniqueString();
            }
            while(_dbContext.Links.Any(x => x.Address == generatedUniqueId));

            var tinyLink = Link.Create(generatedUniqueId, command.Url, DateTime.Now.AddDays(7), userId, command.ProjectId);

            _dbContext.Links.Add(tinyLink);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new() { Id = tinyLink.Id, Address = tinyLink.Address , Url = tinyLink.Url,ProjectId = tinyLink.ProjectId };
        }
    }
}