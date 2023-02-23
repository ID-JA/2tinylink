using MediatR;

namespace Application.UseCases.Auth.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResult>
    {
        public RegisterCommandHandler()
        {
            
        }
        public Task<RegisterCommandResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}