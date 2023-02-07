using MediatR;

namespace Application.LinkShortning.Commands.StandardShortening
{
    public class StandardShorteningCommand : IRequest<StandardShorteningResult>
    {
        public string Url { get; set; }
    }
}