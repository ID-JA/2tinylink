namespace Application.UseCases.LinkShortening.Commands.StandardShortening
{
    public class StandardShorteningResult
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }
        public Guid ProjectId { get; set; }
    }
}