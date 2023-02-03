using MediatR;

namespace Application.LinkShortning.Commands.RegularShortning
{
    public class RegularShortningCommand : IRequest<RegularShortningResult>
    {
        public string Url { get; set; }
    }
}