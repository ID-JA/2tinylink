

using MediatR;

namespace Application.UseCases.Auth.Queries.Login
{
    public class LoginQuery : IRequest<LoginQueryResult>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}