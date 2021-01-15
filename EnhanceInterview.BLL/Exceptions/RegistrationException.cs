using System;
using System.Runtime.Serialization;

namespace EnhanceInterview.BLL.Exceptions
{
	public class RegistrationException : Exception
	{
		public const ExceptionSeverity DEFAULT_EXCEPTION_SEVERITY = ExceptionSeverity.Critical;

		public RegistrationException() : this(null)
		{
		}

		public RegistrationException(
			string message,
			Exception innerException = null,
			ExceptionSeverity severity = DEFAULT_EXCEPTION_SEVERITY)
			: base(message, innerException)
		{
			Severity = severity;
		}

		protected RegistrationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public ExceptionSeverity Severity { get; protected set; }
	}
}