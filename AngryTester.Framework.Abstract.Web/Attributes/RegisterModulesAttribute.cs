using AngryTester.Framework.Abstract.NUnit3;
using Autofac.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System;

namespace AngryTester.Framework.Abstract.Web.Attributes
{
	[AttributeUsage(AttributeTargets.Assembly)]
	public class RegisterModulesAttribute : NUnitAttribute, IApplyToContext
	{
		private readonly Type[] types;

		public RegisterModulesAttribute(params Type[] types)
		{
			this.types = types;
		}

		public void ApplyToContext(TestExecutionContext context)
		{
			foreach (var type in types)
			{
				if (Activator.CreateInstance(type) is IModule module)
				{
					DependencyResolver.ApplyModule(module);
				}
			}
		}
	}
}
