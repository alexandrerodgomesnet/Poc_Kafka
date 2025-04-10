using MediatR;

namespace Poc_Kafka.Application.Abstractions.Messaging.Command
{
    public interface ICommand : IRequest { }
    public interface ICommand<TResponse> : IRequest<TResponse> { }
}
