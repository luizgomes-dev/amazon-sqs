using Consumer.Messages;

namespace Consumer.Handlers;

public interface IMessageHandler
{
    Task HandleAsync(IMessage message);

    Type MessageType { get; }
}