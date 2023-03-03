namespace Application.UseCases.Auth.Command.Register
{
    public class RegisterCommandResult
    {
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}