using System;
using System.Runtime.Serialization;

namespace SendGridSharp
{
    [Serializable]
    public class SendGridException : Exception
    {
        public SendGridException()
        {
        }

        public SendGridException(string message)
            : base(message)
        {
        }

        public SendGridException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected SendGridException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
