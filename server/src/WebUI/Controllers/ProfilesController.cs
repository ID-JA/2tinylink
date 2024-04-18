using Application.UseCases.Settings.Queries;
using Application.UseCases.UserManagement.Queries.UserByUserName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("me", Name = "GetCurrentUser")]
        [Authorize]
        public async Task<ActionResult<UserByUserNameResponse>> GetCurrentUser()
        {
            return Ok(await _sender.Send(new GetUserProfileQuery()));
        }
    }
}