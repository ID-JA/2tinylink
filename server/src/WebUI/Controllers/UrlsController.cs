using Application.CorrespondedUrl.Queries.UrlByAddress;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contracts.CorrespondedUrl;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    public class UrlsController : ApiController
    {
        private readonly ISender _sender;
        public UrlsController(ISender sender)
        {
            _sender = sender;
        }
        
        [HttpGet("{address}")]
        public async Task<IActionResult> GetUrlByAddress([FromRoute] UrlByAddressRequest request)
        {
            var query = new UrlByAddressQuery() { Address = request.Address };

            var result = await _sender.Send(query);

            var response = new UrlByAddressResponse() { Url = result.Url };

            return Ok(response);
        }
    }
}