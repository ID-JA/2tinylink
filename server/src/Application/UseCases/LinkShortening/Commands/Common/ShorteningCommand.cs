using MediatR;

namespace Application.UseCases.LinkShortening.Commands.Common
{
    public class ShorteningCommand : IRequest<ShorteningResult>
    {
        public string Url { get; set; }
    }
}