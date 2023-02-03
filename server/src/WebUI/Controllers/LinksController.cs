using Application.LinkManagment.Queries.LinkById;
using Application.LinkShortning.Commands.RegularShortning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contracts.LinkManagment.LinkById;
using WebUI.Contracts.LinkShortning;

namespace WebUI.Controllers
{
    public class LinksController : ApiController
    {
        private readonly ISender _sender;

        public LinksController(ISender sender)
        {
           _sender = sender;    
        }


        [HttpGet("{id:guid}", Name = "GetById")]
        public async Task<ActionResult<LinkByIdResponse>> GetById([FromRoute] LinkByIdRequest request)
        {
            var query = new LinkByIdQuery { Id = request.Id };

            var queryResult = await _sender.Send(query);

            var response = new LinkByIdResponse() { 
                Id = queryResult.Id, 
                URI = queryResult.URI, 
                CreatedAt = queryResult.CreatedAt 
            };

            return Ok(response);
        }
        
        [HttpPost("regular")]
        public async Task<ActionResult<RegularShortningResponse>> RegularCreate(RegularShortningRequest request)
        {
            var command = new RegularShortningCommand { Url = request.Url };
            
            var result = await _sender.Send(command);

            var response = new RegularShortningResponse { Id = result.Id, URI = result.URI };

            return CreatedAtAction(nameof(GetById), new { Id = response.Id }, response );
        }



    }
}