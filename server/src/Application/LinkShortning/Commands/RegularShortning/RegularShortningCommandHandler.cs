using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Domain.Entites;
using MediatR;

namespace Application.LinkShortning.Commands.RegularShortning
{
    public class RegularShortningCommandHandler : IRequestHandler<RegularShortningCommand, RegularShortningResult>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IUniqueIdProvider _uniqueIdProvider;
        public RegularShortningCommandHandler(IAppDbContext dbContext, IUniqueIdProvider uniqueIdProvider)
        {
            _uniqueIdProvider = uniqueIdProvider;
            _dbContext = dbContext;
        }
        public async Task<RegularShortningResult> Handle(RegularShortningCommand command, CancellationToken cancellationToken)
        {
            string generatedUniqueId;

            do
            {
                generatedUniqueId = _uniqueIdProvider.GetUniqueString();
            }
            while(_dbContext.Links.Any(x => x.Uri == generatedUniqueId));

            var link = new Link
            {
                OriginalUrl = command.Url,
                Uri = generatedUniqueId  
            };

            _dbContext.Links.Add(link);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new() { Id = link.Id, URI = link.Uri };
        }
    }
}