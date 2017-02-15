using System;
using System.Runtime.Serialization;

namespace RememBeer.Common.Exceptions
{
    public class InvalidConfigurationOptionException : FormatException
    {
        private const string MessageFormat =
            "The configuration options setting \"{0}\" is invalid. Fix it in the application configuration file.";

        /// <summary>Initializes a new instance of the <see cref="T:RememBeer.Common.Exceptions.InvalidConfigurationOptionException" /> class.</summary>
        public InvalidConfigurationOptionException()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:RememBeer.Common.Exceptions.InvalidConfigurationOptionException" /> class with a specified error message.</summary>
        /// <param name="message">The name of the invalid configuration option.</param>
        public InvalidConfigurationOptionException(string message)
            : base(string.Format(MessageFormat, message))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:RememBeer.Common.Exceptions.InvalidConfigurationOptionException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="message">The name of the invalid configuration option.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified. </param>
        public InvalidConfigurationOptionException(string message, Exception innerException)
            : base(string.Format(MessageFormat, message), innerException)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:RememBeer.Common.Exceptions.InvalidConfigurationOptionException" /> class with serialized data.</summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown. </param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination. </param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info" /> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult" /> is zero (0). </exception>
        protected InvalidConfigurationOptionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
