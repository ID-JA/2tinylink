using Application.UseCases.Auth.Command.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contracts.Auth.Common;
using WebUI.Contracts.Auth.Register;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [Route("register")]
        public async Task<ActionResult<AuthenticatedUserResponse>> Register([FromBody] RegisterRequest registerRequest)
        {
            var command = new RegisterCommand() 
            { 
                UserName  = registerRequest.UserName,
                FirstName = registerRequest.FirstName,
                LastName  = registerRequest.LastName,
                Email     = registerRequest.Email,
                Password  = registerRequest.Password
            };

            var result = await _sender.Send(command);

            return CreatedAtAction("GetUserProfileByUserName","Profiles", new { UserName = result.UserName }, result);
        }
    }
}