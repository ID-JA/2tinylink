using MediatR;

namespace Application.UseCases.CorrespondedUrl.Queries.UrlByAlias
{
    public class UrlByAliasQuery : IRequest<UrlByAliasQueryResult>
    {
        public string Alias { get; set; }
    }
}