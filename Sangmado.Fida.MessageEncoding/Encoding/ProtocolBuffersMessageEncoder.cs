using Sangmado.Inka.Serialization;
using Sangmado.Inka.Serialization.ProtocolBuffers;

namespace Sangmado.Fida.MessageEncoding
{
    public class ProtocolBuffersMessageEncoder : IMessageEncoder
    {
        public ProtocolBuffersMessageEncoder()
        {
            this.CompressionEnabled = false;
        }

        public bool CompressionEnabled { get; set; }

        public byte[] EncodeMessage(object message)
        {
            if (message == null)
                throw new CannotSerializeMessageException("The message which is to be serialized cannot be null.");

            var raw = ProtocolBuffersConvert.SerializeObject(message);
            if (CompressionEnabled)
            {
                return GZipCompression.Compress(raw);
            }
            else
            {
                return raw;
            }
        }

        public byte[] EncodeMessage<T>(T message)
        {
            if (message == null)
                throw new CannotSerializeMessageException("The message which is to be serialized cannot be null.");

            var raw = ProtocolBuffersConvert.SerializeObject<T>(message);
            if (CompressionEnabled)
            {
                return GZipCompression.Compress(raw);
            }
            else
            {
                return raw;
            }
        }
    }
}
