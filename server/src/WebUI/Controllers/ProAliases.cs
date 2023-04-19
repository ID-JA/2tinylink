using Application.UseCases.LinkShortening.Commands.ProShortening;
using Application.UseCases.ProAliasManagement.Queries.ProAliasById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contracts.ProAliasManagement.ProAliasById;
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

        [HttpGet("{id:guid}", Name = "GetProAliasById")]
        [Authorize(Policy = "ActiveSuperuserOnly")]
        public async Task<ActionResult<ProAliasByIdResponse>> GetProAliasById([FromRoute] ProAliasByIdRequest request)
        {
            var query = new ProAliasByIdQuery { Id = request.Id };

            var queryResult = await _sender.Send(query);

            var response = new ProAliasByIdResponse() 
            { 
                Id = queryResult.Id, 
                Alias = queryResult.Alias, 
                CreatedAt = queryResult.CreatedAt 
            };

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = "ActiveSuperuserOnly")]
        public async Task<ActionResult<ProShorteningResponse>> CreateProAlias([FromBody] ProShorteningRequest request)
        {
            var command = new ProShorteningCommand { Url = request.Url, ExpiredAt = request.ExpiredAt, CustomAlias = request.CustomAlias };
            
            var result = await _sender.Send(command);

            var response = new ProShorteningResponse { Id = result.Id, Alias = result.Alias ,Url = result.Url };

            return CreatedAtAction(nameof(GetProAliasById), new { Id = response.Id }, response );

        }
    }
}