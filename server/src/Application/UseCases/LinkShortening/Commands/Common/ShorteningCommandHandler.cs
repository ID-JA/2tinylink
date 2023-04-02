using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using MediatR;

namespace Application.UseCases.LinkShortening.Commands.Common
{
    public abstract class ShorteningCommandHandler<TCommand>: IRequestHandler<TCommand, ShorteningResult> where TCommand : ShorteningCommand
    {
        protected readonly IAppDbContext _dbContext;
        protected readonly IUniqueIdProvider _uniqueIdProvider;
        public ShorteningCommandHandler(IAppDbContext dbContext, IUniqueIdProvider uniqueIdProvider)
        {
            _uniqueIdProvider = uniqueIdProvider;
            _dbContext = dbContext;
        }
        public abstract Task<ShorteningResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
}