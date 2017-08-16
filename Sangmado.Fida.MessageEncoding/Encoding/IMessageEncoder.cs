
namespace Sangmado.Fida.MessageEncoding
{
    public interface IMessageEncoder
    {
        byte[] EncodeMessage(object message);
        byte[] EncodeMessage<T>(T message);
    }
}
