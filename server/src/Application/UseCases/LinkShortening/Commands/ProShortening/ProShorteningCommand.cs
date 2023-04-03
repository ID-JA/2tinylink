using Application.UseCases.LinkShortening.Commands.Common;

namespace Application.UseCases.LinkShortening.Commands.ProShortening
{
    public class ProShorteningCommand : ShorteningCommand
    {
        public string ExpiredAt { get; set; }
    }
}