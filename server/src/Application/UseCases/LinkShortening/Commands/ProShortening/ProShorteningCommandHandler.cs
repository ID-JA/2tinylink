using System.Net;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Application.UseCases.LinkShortening.Commands.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebUI.Application.Common.Interfaces.Services;

namespace Application.UseCases.LinkShortening.Commands.ProShortening
{
    public class ProShorteningCommandHandler : ShorteningCommandHandler<ProShorteningCommand>
    {
        private readonly IUserService _userService;

        public ProShorteningCommandHandler(IAppDbContext dbContext, IAliasProvider aliasProvider, IUserService userService) : base(dbContext, aliasProvider)
        {
            _userService = userService;
        }
        public override async Task<ShorteningResult> Handle(ProShorteningCommand command, CancellationToken cancellationToken)
        {
            string alias = await GetAliasAsync(command.CustomAlias);

            var tinyLink = new TinyLink
            {
                Alias = alias,
                Url = command.Url,
                AppUserId = new Guid(_userService.GetUserId()),
                ExpiredAt = command.ExpiredAt is null ? null : DateTime.Parse(command.ExpiredAt).ToUniversalTime()
            };

            _dbContext.TinyLinks.Add(tinyLink);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new() { Id = tinyLink.Id, Alias = tinyLink.Alias, Url = tinyLink.Url };
        }


        private async Task<string> GetAliasAsync(string customAlias)
        {
            var isWithCustomAlias = customAlias is not null;
            string alias;

            if (isWithCustomAlias)
            {
                if(await _dbContext.TinyLinks.AnyAsync(x => x.Alias == customAlias))
                {
                    throw new AppException((int)HttpStatusCode.Conflict, "Alias already exists, please choose a different alias.");
                }

                alias = customAlias;
            }
            else
            {
               alias = await _aliasProvider.GetAliasAsync();
            }

            return alias;
        }
    }
}