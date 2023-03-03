namespace Application.UseCases.UserManagement.Queries.UserByUserName
{
    public class UserByUserNameQueryResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}