
namespace Sangmado.Inka.MessageEncoding
{
    public interface IMessageEncoder
    {
        byte[] EncodeMessage(object message);
        byte[] EncodeMessage<T>(T message);
    }
}
