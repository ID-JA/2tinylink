using Application.UseCases.Auth.Command.Register;
using Application.UseCases.Auth.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contracts.Auth.Common;
using WebUI.Contracts.Auth.Login;
using WebUI.Contracts.Auth.Register;

namespace WebUI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("register")]
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

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            var query = new LoginQuery()
            {
                UserNameOrEmail = loginRequest.UserNameOrEmail,
                Password = loginRequest.Password
            };

            var result = await _sender.Send(query);

            var response = new LoginResponse() { Token = result.Token };
            
            return Ok(response);
        }
    }
}