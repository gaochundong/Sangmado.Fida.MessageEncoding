using System.Text;
using Sangmado.Inka.Serialization;

namespace Sangmado.Fida.MessageEncoding
{
    public class JsonMessageEncoder : IMessageEncoder
    {
        public JsonMessageEncoder()
        {
            this.Formatting = Formatting.None;
            this.CompressionEnabled = false;
        }

        public JsonMessageEncoder(Formatting formatting)
            : this()
        {
            this.Formatting = formatting;
        }

        public Formatting Formatting { get; set; }
        public bool CompressionEnabled { get; set; }

        public byte[] EncodeMessage(object message)
        {
            if (message == null)
                throw new CannotSerializeMessageException("The message which is to be serialized cannot be null.");

            var json = JsonConvert.SerializeObject(message, this.Formatting);
            if (CompressionEnabled)
            {
                return GZipCompression.Compress(Encoding.UTF8.GetBytes(json));
            }
            else
            {
                return Encoding.UTF8.GetBytes(json);
            }
        }

        public byte[] EncodeMessage<T>(T message)
        {
            if (message == null)
                throw new CannotSerializeMessageException("The message which is to be serialized cannot be null.");

            var json = JsonConvert.SerializeObject(message, this.Formatting);
            if (CompressionEnabled)
            {
                return GZipCompression.Compress(Encoding.UTF8.GetBytes(json));
            }
            else
            {
                return Encoding.UTF8.GetBytes(json);
            }
        }
    }
}
