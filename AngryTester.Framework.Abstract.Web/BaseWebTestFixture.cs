using AngryTester.Framework.Abstract.Web.Configuration;
using Atata;
using Autofac;

namespace AngryTester.Framework.Abstract.Web
{
	public class BaseWebTestFixture : NUnit3.BaseTestFixture
	{
		protected readonly WebDriverConfiguration configuration;

		public BaseWebTestFixture(WebDriverConfiguration config)
		{
			configuration = config;
		}

		protected override void BeforeTest()
		{
			base.BeforeTest();
			Resolver.Resolve<AtataContextBuilder>().Build();
		}

		protected override void AfterTest()
		{
			try
			{
				AtataContext.Current?.CleanUp();
			}
			finally
			{
				base.AfterTest();
			}
		}

		protected override void InitializeResolver(ContainerBuilder builder)
		{
			base.InitializeResolver(builder);

			var context = AtataContext.Configure()
				.UseDriver(alias: configuration.Alias);

			builder.RegisterInstance(context);
		}
	}
}
