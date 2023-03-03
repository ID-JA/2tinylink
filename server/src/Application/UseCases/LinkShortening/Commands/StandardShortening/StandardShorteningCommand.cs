using MediatR;

namespace Application.UseCases.LinkShortening.Commands.StandardShortening
{
    public class StandardShorteningCommand : IRequest<StandardShorteningResult>
    {
        public string Url { get; set; }
    }
}