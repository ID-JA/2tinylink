namespace Application.UseCases.ProAliasManagement.Queries.ProAliasById
{
    public class ProAliasByIdQueryResult
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}