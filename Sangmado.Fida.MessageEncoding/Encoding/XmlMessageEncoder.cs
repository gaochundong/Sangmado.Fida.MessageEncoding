using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Sangmado.Inka.Serialization;

namespace Sangmado.Fida.MessageEncoding
{
    public class XmlMessageEncoder : IMessageEncoder
    {
        public XmlMessageEncoder()
        {
            this.CompressionEnabled = true;

            this.Settings = new XmlWriterSettings()
            {
                Indent = false,
                OmitXmlDeclaration = true,
                NewLineHandling = NewLineHandling.None,
            };
            this.Namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        }

        public bool CompressionEnabled { get; set; }

        public XmlWriterSettings Settings { get; set; }
        public XmlSerializerNamespaces Namespaces { get; set; }

        public byte[] EncodeMessage(object message)
        {
            if (message == null)
                throw new CannotSerializeMessageException("The message which is to be serialized cannot be null.");

            if (CompressionEnabled)
            {
                var xml = Sangmado.Inka.Serialization.XmlConvert.SerializeObject(message, this.Settings, this.Namespaces);
                return GZipCompression.Compress(Encoding.UTF8.GetBytes(xml));
            }
            else
            {
                var xml = Sangmado.Inka.Serialization.XmlConvert.SerializeObject(message, this.Settings, this.Namespaces);
                return Encoding.UTF8.GetBytes(xml);
            }
        }

        public byte[] EncodeMessage<T>(T message)
        {
            if (message == null)
                throw new CannotSerializeMessageException("The message which is to be serialized cannot be null.");

            if (CompressionEnabled)
            {
                var xml = Sangmado.Inka.Serialization.XmlConvert.SerializeObject(message, this.Settings, this.Namespaces);
                return GZipCompression.Compress(Encoding.UTF8.GetBytes(xml));
            }
            else
            {
                var xml = Sangmado.Inka.Serialization.XmlConvert.SerializeObject(message, this.Settings, this.Namespaces);
                return Encoding.UTF8.GetBytes(xml);
            }
        }
    }
}
