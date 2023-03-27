using Application.UseCases.CorrespondedUrl.Queries.UrlByAlias;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contracts.CorrespondedUrl;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UrlsController : ApiController
    {
        private readonly ISender _sender;
        public UrlsController(ISender sender)
        {
            _sender = sender;
        }
        
        [HttpGet("{alias}")]
        public async Task<IActionResult> GetUrlByAlias([FromRoute] UrlByAliasRequest request)
        {
            var query = new UrlByAliasQuery() { Alias = request.Alias };

            var result = await _sender.Send(query);

            var response = new UrlByAliasResponse() { Url = result.Url };

            return Ok(response);
        }
    }
}