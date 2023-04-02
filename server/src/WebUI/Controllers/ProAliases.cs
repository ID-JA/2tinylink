using Application.UseCases.LinkShortening.Commands.ProShortening;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contracts.Shortening.ProShortening;

namespace WebUI.Controllers
{
    [Route("api/pro/aliases")]
    public class ProAliasesController : ApiController
    {
        private readonly ISender _sender;

        public ProAliasesController(ISender sender)
        {
           _sender = sender;    
        }

        [HttpPost]
        public async Task<ActionResult<ProShorteningResponse>> CreateStandardTinyLink([FromBody] ProShorteningRequest request)
        {
            var command = new ProShorteningCommand { Url = request.Url, ExpiredAt = request.ExpiredAt };
            
            var result = await _sender.Send(command);

            var response = new ProShorteningResponse { Id = result.Id, Alias = result.Alias ,Url = result.Url };

            return Ok(response);

        }
    }
}