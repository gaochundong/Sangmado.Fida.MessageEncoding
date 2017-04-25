using Sangmado.Inka.Serialization;

namespace Sangmado.Inka.MessageEncoding
{
    public class BinaryMessageEncoder : IMessageEncoder
    {
        public BinaryMessageEncoder()
        {
            this.CompressionEnabled = true;
        }

        public bool CompressionEnabled { get; set; }

        public byte[] EncodeMessage(object message)
        {
            if (message == null)
                throw new CannotSerializeMessageException("The message which is to be serialized cannot be null.");

            if (CompressionEnabled)
            {
                return GZipCompression.Compress(BinaryConvert.SerializeObject(message));
            }
            else
            {
                return BinaryConvert.SerializeObject(message);
            }
        }

        public byte[] EncodeMessage<T>(T message)
        {
            if (message == null)
                throw new CannotSerializeMessageException("The message which is to be serialized cannot be null.");

            if (CompressionEnabled)
            {
                return GZipCompression.Compress(BinaryConvert.SerializeObject(message));
            }
            else
            {
                return BinaryConvert.SerializeObject(message);
            }
        }
    }
}
