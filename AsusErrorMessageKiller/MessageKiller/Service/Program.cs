using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AsusErrorMessageKiller.MessageKiller.Service
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			ShutdownMonitor.Start();
			CreateHostBuilder(args).Build().Run();
		}

		private static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureServices((hostContext, services) => { services.AddHostedService<MessageKiller>(); });
	}
}