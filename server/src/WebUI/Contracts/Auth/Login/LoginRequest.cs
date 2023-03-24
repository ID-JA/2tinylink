namespace WebUI.Contracts.Auth.Login
{
    public class LoginRequest
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}