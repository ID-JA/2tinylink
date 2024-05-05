using Application.Common.Interfaces.Services;
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
    public class AuthController(ISender _sender, IMailService _mailService) : ControllerBase
    {
        

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest registerRequest)
        {
            var command = new RegisterCommand()
            {
                UserName = registerRequest.UserName,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Origin = $"{Request.Scheme}://{Request.Host.Value}{Request.PathBase.Value}"
            };

            return Ok(await _sender.Send(command));
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            var query = new LoginQuery()
            {
                UserNameOrEmail = loginRequest.UserNameOrEmail,
                Password = loginRequest.Password
            };

            return Ok(await _sender.Send(query));
        }

        [HttpGet("email-confirmation", Name = "EmailConfirmation")]
        public async Task<ActionResult<DefaultResponse>> EmailConfirmation([FromQuery] EmailConfirmationRequest emailConfirmationRequest)
        {
            var command = new EmailConfirmationCommand()
            {
                UserName = emailConfirmationRequest.UserName,
                Token = emailConfirmationRequest.Token
            };

            await _sender.Send(command);

            var response = new DefaultResponse()
            {
                Message = "Email verification complete! You're all set to use our services."
            };

            return Ok(response);
        }



    }
}