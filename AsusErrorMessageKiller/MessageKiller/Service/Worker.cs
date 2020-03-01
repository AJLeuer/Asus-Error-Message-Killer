using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// ReSharper disable ClassNeverInstantiated.Global
namespace AsusErrorMessageKiller.MessageKiller.Service
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> logger;

		public Worker(ILogger<Worker> logger)
		{
			this.logger = logger;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			await Task.Run(AsusErrorDialog.Kill, stoppingToken);
		}
	}
}