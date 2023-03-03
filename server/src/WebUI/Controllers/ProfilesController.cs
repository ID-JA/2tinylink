using Application.UseCases.UserManagement.Queries.UserByUserName;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contracts.UserManagement.UserByUserName;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ISender _sender;

        public ProfilesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{userName}", Name = "GetUserProfileByUserName")]
        public async Task<ActionResult<UserByUserNameResponse>> GetUserProfileByUserName([FromRoute] UserByUserNameResponse request)
        {
            var query = new UserByUserNameQuery { UserName = request.UserName };

            var result = await _sender.Send(query);

            var response = new UserByUserNameResponse()
            {
                FirstName = result.FirstName,
                LastName  = result.LastName,
                UserName  = result.UserName,
                CreatedAt = result.CreatedAt
            };

            return Ok(response);
        }
    }
}