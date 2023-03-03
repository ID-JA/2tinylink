using MediatR;

namespace Application.UseCases.UserManagement.Queries.UserByUserName
{
    public class UserByUserNameQuery : IRequest<UserByUserNameQueryResult>
    {
        public string UserName { get; set; }
    }
}