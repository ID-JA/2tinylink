using WebUI.Contracts.Shortening.Common;

namespace WebUI.Contracts.Shortening.ProShortening
{
    public class ProShorteningRequest : ShorteningRequest
    {
        public string ExpiredAt { get; set; }

    }
}