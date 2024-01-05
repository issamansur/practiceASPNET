using System;
using System.Runtime.Serialization;

/* DEPRECATED */

namespace PracticeASPNET.Domain.Exceptions
{
    [Serializable]
    public class GuidEmptyException : Exception
    {
        public GuidEmptyException() :
            base("Guid cannot be empty")
        { }

        public GuidEmptyException(string message)
            : base(message) { }

        public GuidEmptyException(string message, Exception inner)
            : base(message, inner) { }

        protected GuidEmptyException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
