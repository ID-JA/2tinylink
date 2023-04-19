namespace WebUI.Contracts.ProAliasManagement.ProAliasById
{
    public class ProAliasByIdResponse
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}