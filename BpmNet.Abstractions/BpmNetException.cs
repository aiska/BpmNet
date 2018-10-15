using System;

namespace BpmNet
{
    public class BpmNetException : Exception
    {
        public string Reason { get; }

        /// <summary>
        /// Creates a new <see cref="BpmNetException"/>.
        /// </summary>
        /// <param name="reason">The reason of the exception.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public BpmNetException(string reason, string message, Exception innerException)
            : base(message, innerException)
        {
            Reason = reason;
        }
    }
}
