using MediatR;

namespace Application.UseCases.Auth.Command.Register
{
    public class RegisterCommand : IRequest<RegisterCommandResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}