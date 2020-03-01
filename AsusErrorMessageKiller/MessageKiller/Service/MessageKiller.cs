using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
#pragma warning disable 4014

// ReSharper disable ClassNeverInstantiated.Global
namespace AsusErrorMessageKiller.MessageKiller.Service
{
	public class MessageKiller : BackgroundService
	{
		private readonly ILogger<MessageKiller> logger;

		public MessageKiller(ILogger<MessageKiller> logger)
		{
			this.logger = logger;
		}

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			CloseErrorDialog();
			StopAsync(stoppingToken);
			return Task.CompletedTask;
		}
		
		private void CloseErrorDialog()
		{
			AsusErrorDialog.Kill();
		}
	}
}