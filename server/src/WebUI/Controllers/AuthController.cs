using Application.UseCases.Auth.Commands.EmailConfirmation;
using Application.UseCases.Auth.Commands.Register;
using Application.UseCases.Auth.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contracts.Auth.Common;
using WebUI.Contracts.Auth.EmailConfirmation;
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
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest registerRequest)
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

            string endpointUrl = Url.Action(nameof(EmailConfirmation), 
                                        ControllerContext.ActionDescriptor.ControllerName, 
                                        new { UserName = command.UserName, Token = result.EmailConfirmationToken}, 
                                        Request.Scheme);

            var response = new RegisterResponse()
            {
                EmailConfirmationUrl = endpointUrl
            };

            return CreatedAtAction("GetUserProfileByUserName","Profiles", new { UserName = registerRequest.UserName }, response);
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

        [HttpGet("email-confirmation", Name = "EmailConfirmation")]
        public async Task<ActionResult<DefaultResponse>> EmailConfirmation([FromQuery] EmailConfirmationRequest emailConfirmationRequest)
        {
            var command = new EmailConfirmationCommand()
            {
                UserName = emailConfirmationRequest.UserName,
                Token    = emailConfirmationRequest.Token
            };

            var result = await _sender.Send(command);

            var response = new DefaultResponse()
            {
                Message = "Email verification complete! You're all set to use our services."
            };

            return Ok(response);
        }



    }
}