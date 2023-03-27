namespace Application.UseCases.LinkShortening.Commands.StandardShortening
{
    public class StandardShorteningResult
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public string Url { get; set; }
    }
}