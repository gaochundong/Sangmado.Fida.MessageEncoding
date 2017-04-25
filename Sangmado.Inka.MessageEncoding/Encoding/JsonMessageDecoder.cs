using System.Text;
using Sangmado.Inka.Serialization;

namespace Sangmado.Inka.MessageEncoding
{
    public class JsonMessageDecoder : IMessageDecoder
    {
        public JsonMessageDecoder()
        {
            this.CompressionEnabled = false;
        }

        public bool CompressionEnabled { get; set; }

        public T DecodeMessage<T>(byte[] data)
        {
            return DecodeMessage<T>(data, data.Length);
        }

        public T DecodeMessage<T>(byte[] data, int dataLength)
        {
            return DecodeMessage<T>(data, 0, dataLength);
        }

        public T DecodeMessage<T>(byte[] data, int dataOffset, int dataLength)
        {
            if (data == null)
                throw new CannotDeserializeMessageException("The data which is to be deserialized cannot be null.");

            if (CompressionEnabled)
            {
                string json = Encoding.UTF8.GetString(GZipCompression.Decompress(data, dataOffset, dataLength));
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                string json = Encoding.UTF8.GetString(data, dataOffset, dataLength);
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}
