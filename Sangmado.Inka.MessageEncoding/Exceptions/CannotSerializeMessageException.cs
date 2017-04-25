using System;

namespace Sangmado.Inka.MessageEncoding
{
    [Serializable]
    public class CannotSerializeMessageException : Exception
    {
        public CannotSerializeMessageException()
            : base()
        {
        }

        public CannotSerializeMessageException(string message)
            : base(message)
        {
        }

        public CannotSerializeMessageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
