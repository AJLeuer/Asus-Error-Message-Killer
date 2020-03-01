using System;
using System.Threading;

namespace AsusErrorMessageKiller.MessageKiller.Service
{
	public static class ShutdownMonitor
	{
		public static void Start()
		{
			var monitorThread = new Thread(run);
			monitorThread.Start();
		}

		private static void run()
		{
			while (AsusErrorDialog.ConfirmedDialogClosedOrNotPresent == false)
			{
				Thread.Sleep(TimeSpan.FromMilliseconds(20));
			}
			
			Environment.Exit(0);
		}
	}
}