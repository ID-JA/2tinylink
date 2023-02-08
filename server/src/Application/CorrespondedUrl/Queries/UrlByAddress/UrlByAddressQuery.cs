using MediatR;

namespace Application.CorrespondedUrl.Queries.UrlByAddress
{
    public class UrlByAddressQuery : IRequest<UrlByAddressQueryResult>
    {
        public string Address { get; set; }
    }
}