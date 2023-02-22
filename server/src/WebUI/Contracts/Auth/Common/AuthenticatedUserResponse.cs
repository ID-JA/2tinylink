namespace WebUI.Contracts.Auth.Common
{
    public class AuthenticatedUserResponse
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}