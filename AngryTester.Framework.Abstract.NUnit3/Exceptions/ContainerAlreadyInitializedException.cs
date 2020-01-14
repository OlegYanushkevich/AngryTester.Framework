using System;
using System.Runtime.Serialization;

namespace AngryTester.Framework.Abstract.NUnit3.Exceptions
{
	public class ContainerAlreadyInitializedException : Exception
	{
		public ContainerAlreadyInitializedException()
		{
		}

		public ContainerAlreadyInitializedException(string message)
			: base(message)
		{
		}

		public ContainerAlreadyInitializedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected ContainerAlreadyInitializedException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
