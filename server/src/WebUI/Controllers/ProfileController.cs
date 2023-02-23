using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contracts.Auth.Common;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ISender _sender;

        public ProfileController(ISender sender)
        {
            _sender = sender;
        }

        [Route("{userName}", Name = "GetUserProfileByUserName")]
        public async Task<ActionResult<AuthenticatedUserResponse>> GetUserProfileByUserName([FromRoute] string userName)
        {
            return Ok();
        }
    }
}