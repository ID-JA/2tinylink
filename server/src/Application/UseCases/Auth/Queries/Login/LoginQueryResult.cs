namespace Application.UseCases.Auth.Queries.Login
{
    public class LoginQueryResult
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}