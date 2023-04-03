using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Application.UseCases.LinkShortening.Commands.Common;
using Domain.Entities;
using WebUI.Application.Common.Interfaces.Services;

namespace Application.UseCases.LinkShortening.Commands.ProShortening
{
    public class ProShorteningCommandHandler : ShorteningCommandHandler<ProShorteningCommand>
    {
        private readonly IUserService _userService;

        public ProShorteningCommandHandler(IAppDbContext dbContext, IUniqueIdProvider uniqueIdProvider, IUserService userService) : base(dbContext, uniqueIdProvider)
        {
            _userService = userService;
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
                Url = command.Url,
                AppUserId = new Guid(_userService.GetUserId()),
                ExpiredAt = command.ExpiredAt is null ? null : DateTime.Parse(command.ExpiredAt).ToUniversalTime()
            };

            _dbContext.TinyLinks.Add(tinyLink);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new() { Id = tinyLink.Id, Alias = tinyLink.Alias, Url = tinyLink.Url };
        }
    }
}