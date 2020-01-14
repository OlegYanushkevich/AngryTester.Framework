namespace AngryTester.Framework.Abstract.Web.Configuration
{
	public class WebDriverConfiguration
	{
		private const string Remote = "(remote)";

		private const string LatestVersion = "latest";

		public string Browser { get; set; }

		public string Version { get; set; }

		public bool IsRemote { get; set; }

		public string Alias => string.Concat(Browser, IsRemote ? Remote : null);

		public WebDriverConfiguration(string browser, bool remote = true, string version = LatestVersion)
		{
			Browser = browser;
			IsRemote = remote;
			Version = version;
		}

		private bool IsLatestVersion()
		{
			return LatestVersion.Equals(Version);
		}

		public override string ToString()
		{
			return string.Concat(Browser, IsLatestVersion() ? null : $"[{Version}]");
		}
	}
}
