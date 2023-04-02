namespace Application.UseCases.LinkShortening.Commands.Common
{
    public class ShorteningResult
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public string Url { get; set; }
    }
}