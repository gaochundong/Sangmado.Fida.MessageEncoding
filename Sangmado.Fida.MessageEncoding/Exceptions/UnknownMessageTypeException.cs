using System;

namespace Sangmado.Fida.MessageEncoding
{
    [Serializable]
    public class UnknownMessageTypeException : Exception
    {
        public UnknownMessageTypeException()
            : base()
        {
        }

        public UnknownMessageTypeException(string message)
            : base(message)
        {
        }

        public UnknownMessageTypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
