using MediatR;

namespace Application.UseCases.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Origin { get; set; }

    }
}