using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Domain.Entites;
using MediatR;

namespace Application.LinkShortning.Commands.StandardShortening
{
    public class RegularShortningCommandHandler : IRequestHandler<StandardShorteningCommand, StandardShorteningResult>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IUniqueIdProvider _uniqueIdProvider;
        public RegularShortningCommandHandler(IAppDbContext dbContext, IUniqueIdProvider uniqueIdProvider)
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
            while(_dbContext.TinyLinks.Any(x => x.Address == generatedUniqueId));

            var tinyLink = new TinyLink
            {
                Address = generatedUniqueId,
                Url  = command.Url
            };

            _dbContext.TinyLinks.Add(tinyLink);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new() { Id = tinyLink.Id, Address = tinyLink.Address , Url = tinyLink.Url };
        }
    }
}