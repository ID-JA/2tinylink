using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.LinkShortening.Commands.StandardShortening
{
    public class RegularShorteningCommandHandler : IRequestHandler<StandardShorteningCommand, StandardShorteningResult>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IUniqueIdProvider _uniqueIdProvider;
        public RegularShorteningCommandHandler(IAppDbContext dbContext, IUniqueIdProvider uniqueIdProvider)
        {
            _uniqueIdProvider = uniqueIdProvider;
            _dbContext = dbContext;
        }
        public async Task<StandardShorteningResult> Handle(StandardShorteningCommand command, CancellationToken cancellationToken)
        {
            string generatedUniqueId;

            do
            {
                generatedUniqueId = _uniqueIdProvider.GetUniqueString();
            }
            while(_dbContext.Links.Any(x => x.Address == generatedUniqueId));

            var tinyLink = new Link
            {
                Address = generatedUniqueId,
                Url  = command.Url
            };

            _dbContext.Links.Add(tinyLink);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new() { Id = tinyLink.Id, Address = tinyLink.Address , Url = tinyLink.Url };
        }
    }
}