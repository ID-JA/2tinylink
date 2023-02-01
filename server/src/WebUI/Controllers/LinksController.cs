using Application.LinkShortning.Commands.RegularShortning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("regular")]
        public async Task<ActionResult<RegularShortningResponse>> RegularCreate(RegularShortningRequest request)
        {
            var command = new RegularShortningCommand { Url = request.Url };
            
            var result = await _sender.Send(command);

            var response = new RegularShortningResponse { URI = result.URI };

            return Ok(response);
        }



    }
}