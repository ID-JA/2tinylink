using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Application.UseCases.LinkShortening.Commands.Common;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.LinkShortening.Commands.StandardShortening
{
    public class StandardShorteningCommandHandler : ShorteningCommandHandler<StandardShorteningCommand>
    {
        public StandardShorteningCommandHandler(IAppDbContext dbContext, IAliasProvider aliasProvider) : base(dbContext, aliasProvider)
        {
        }
        public override async Task<ShorteningResult> Handle(StandardShorteningCommand command, CancellationToken cancellationToken)
        {
            var alias = await _aliasProvider.GetAliasAsync();

            var tinyLink = new TinyLink
            {
                Alias = alias,
                Url  = command.Url
            };

            _dbContext.TinyLinks.Add(tinyLink);
            
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new() { Id = tinyLink.Id, Alias = tinyLink.Alias , Url = tinyLink.Url };
        }
    }
}