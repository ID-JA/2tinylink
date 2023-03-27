namespace Application.UseCases.StandardTinyLinkManagement.Queries.TinyLinkById
{
    public class StandardTinyLinkByIdQueryResult
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}