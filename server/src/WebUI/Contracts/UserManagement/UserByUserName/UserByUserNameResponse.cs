namespace WebUI.Contracts.UserManagement.UserByUserName
{
    public class UserByUserNameResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}