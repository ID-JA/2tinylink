using MediatR;

namespace Application.UseCases.Auth.Commands.EmailConfirmation
{
    public class EmailConfirmationCommand : IRequest
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}