using MediatR;

namespace Application.UseCases.CorrespondedUrl.Queries.UrlByAddress
{
    public class UrlByAddressQuery : IRequest<UrlByAddressQueryResult>
    {
        public string Address { get; set; }
    }
}