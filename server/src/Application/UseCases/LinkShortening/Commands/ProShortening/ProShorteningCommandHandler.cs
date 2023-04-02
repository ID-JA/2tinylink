using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Application.UseCases.LinkShortening.Commands.Common;
using Domain.Entities;

namespace Application.UseCases.LinkShortening.Commands.ProShortening
{
    public class ProShorteningCommandHandler : ShorteningCommandHandler<ProShorteningCommand>
    {
        public ProShorteningCommandHandler(IAppDbContext dbContext, IUniqueIdProvider uniqueIdProvider) : base(dbContext, uniqueIdProvider)
        {
        }
        public override async Task<ShorteningResult> Handle(ProShorteningCommand command, CancellationToken cancellationToken)
        {
            string generatedUniqueId;

            do
            {
                generatedUniqueId = _uniqueIdProvider.GetUniqueString();
            }
            while (_dbContext.TinyLinks.Any(x => x.Alias == generatedUniqueId));

            var tinyLink = new TinyLink
            {
                Alias = generatedUniqueId,
                Url = command.Url
            };

            _dbContext.TinyLinks.Add(tinyLink);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new() { Id = tinyLink.Id, Alias = tinyLink.Alias, Url = tinyLink.Url };
        }
    }
}