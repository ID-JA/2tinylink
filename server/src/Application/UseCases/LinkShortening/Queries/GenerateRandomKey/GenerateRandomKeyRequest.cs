using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using MediatR;

namespace Application.UseCases.LinkShortening.Queries.GenerateRandomKey;

public class GenerateRandomKeyRequest : IRequest<string>
{
}

internal class GenerateRadnomKeyRequestHandler(IAppDbContext _dbContext, IUniqueIdProvider _uniqueIdProvider) : IRequestHandler<GenerateRandomKeyRequest, string> 
{
    public Task<string> Handle(GenerateRandomKeyRequest request, CancellationToken cancellationToken)
    {
        string generatedRandomKey = null;
        do
        {
            generatedRandomKey = _uniqueIdProvider.GetUniqueString();

        } while (_dbContext.Links.Any(l => l.Address.Equals(generatedRandomKey)));

        return Task.FromResult(generatedRandomKey);
    }
}


