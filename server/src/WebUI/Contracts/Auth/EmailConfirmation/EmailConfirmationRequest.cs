namespace WebUI.Contracts.Auth.EmailConfirmation
{
    public class EmailConfirmationRequest
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}