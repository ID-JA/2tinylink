namespace Application.UseCases.StandardTinyLinkManagment.Queries.TinyLinkById
{
    public class StandardTinyLinkByIdQueryResult
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}