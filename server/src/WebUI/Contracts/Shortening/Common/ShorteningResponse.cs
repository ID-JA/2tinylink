namespace WebUI.Contracts.Shortening.Common
{
    public class ShorteningResponse
    {
        public Guid Id { get; set; }
        public string Alias { get; set; }
        public string Url { get; set; }
    }
}