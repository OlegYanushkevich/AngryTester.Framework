using AngryTester.Framework.Abstract.NUnit3.Exceptions;
using Autofac;
using Autofac.Core;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AngryTester.Framework.Abstract.NUnit3
{
	public class DependencyResolver
	{
		private static IContainer container;

		private static readonly ContainerBuilder builder = new ContainerBuilder();

		public static void RegisterAssemblyModules(Assembly[] assemblies)
		{
			if (container != null)
			{
				throw new ContainerAlreadyInitializedException("Container is already initialized. Applying module after container initialization is impossible.");
			}

			builder.RegisterAssemblyModules(assemblies);
		}

		public static void ApplyModule(IModule module)
		{
			if (container != null)
			{
				throw new ContainerAlreadyInitializedException("Container is already initialized. Applying module after container initialization is impossible.");
			}

			builder.RegisterModule(module);
		}

		public static void ApplyModule<TModule>() where TModule : class, IModule, new()
		{
			ApplyModule(Activator.CreateInstance<TModule>());
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static IContainer GetResolver()
		{
			return container ?? (container = builder.Build());
		}
	}
}
