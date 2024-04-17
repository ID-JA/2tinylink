using Application.UseCases.LinkShortening.Commands.StandardShortening;
using Application.UseCases.StandardTinyLinkManagement.Queries.TinyLinkById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contracts.StandardShortening;
using WebUI.Contracts.StandardTinyLinkManagement.TinyLinkById;

namespace WebUI.Controllers
{
    [Route("api/standard/tiny-links")]
    [AllowAnonymous]
    public class StandardLinksController : ApiController
    {
        private readonly ISender _sender;

        public StandardLinksController(ISender sender)
        {
           _sender = sender;    
        }

        [HttpGet("{id:guid}", Name = "GetStandardTinyLinkById")]
        public async Task<ActionResult<StandardTinyLinkByIdResponse>> GetStandardTinyLinkById([FromRoute] StandardTinyLinkByIdRequest request)
        {
            var query = new StandardTinyLinkByIdQuery { Id = request.Id };

            var queryResult = await _sender.Send(query);

            var response = new StandardTinyLinkByIdResponse() { 
                Id = queryResult.Id, 
                Address = queryResult.Address, 
                CreatedAt = queryResult.CreatedAt 
            };

            return Ok(response);
        }
        
        [HttpPost]
        public async Task<ActionResult<StandardShorteningResponse>> CreateStandardTinyLink([FromBody] StandardShorteningRequest request)
        {
            var command = new StandardShorteningCommand { Url = request.Url };
            
            var result = await _sender.Send(command);

            var response = new StandardShorteningResponse { Id = result.Id, Address = result.Address ,Url = result.Url };

            return CreatedAtAction(nameof(GetStandardTinyLinkById), new { Id = response.Id }, response );

        }



    }
}