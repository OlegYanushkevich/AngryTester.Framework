using AngryTester.Framework.Abstract.NUnit3.Exceptions;
using Autofac;
using Autofac.Core;
using System.Runtime.CompilerServices;

namespace AngryTester.Framework.Abstract.NUnit3
{
	public class DependencyResolver
	{
		private static IContainer container;

		private static readonly ContainerBuilder builder = new ContainerBuilder();

		public static void ApplyModule<TModule>() where TModule : class, IModule, new()
		{
			if (container != null)
			{
				throw new ContainerAlreadyInitializedException("Container is already initialized. Applying module after container initialization is impossible.");
			}

			builder.RegisterModule<TModule>();
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static IContainer GetResolver()
		{
			return container ?? (container = builder.Build());
		}
	}
}
