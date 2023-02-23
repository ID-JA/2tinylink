using MediatR;

namespace Application.UseCases.LinkShortning.Commands.StandardShortening
{
    public class StandardShorteningCommand : IRequest<StandardShorteningResult>
    {
        public string Url { get; set; }
    }
}