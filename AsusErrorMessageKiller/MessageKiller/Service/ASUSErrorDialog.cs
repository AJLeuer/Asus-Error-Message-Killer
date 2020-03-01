using System;
using System.Threading;
using AsusErrorMessageKiller.MessageKiller.SystemIO;
using NodaTime;

namespace AsusErrorMessageKiller.MessageKiller.Service
{
	public static class AsusErrorDialog
	{
		private const string AsusErrorMessageClassName = "#32770";
		private const string AsusErrorMessageWindowName = "Message";
		
		public static bool ConfirmedDialogClosedOrNotPresent { get; private set; } = false;

		public static void Kill()
		{
			Instant startTime = SystemClock.Instance.GetCurrentInstant();
			Duration elapsedTime ;
			// ReSharper disable once SuggestVarOrType_SimpleTypes
			IntPtr dialog;

			do
			{
				dialog = WindowService.FindWindow(AsusErrorMessageClassName, AsusErrorMessageWindowName);
				elapsedTime = SystemClock.Instance.GetCurrentInstant() - startTime;
				Thread.Sleep(TimeSpan.FromMilliseconds(25));
			} while ((elapsedTime < Duration.FromSeconds(30)) && (WindowService.WindowIsPresent(dialog) == false));


			while (WindowService.IsOpen(dialog))
			{
				WindowService.CloseWindow(dialog);
				Thread.Sleep(TimeSpan.FromMilliseconds(25));
			}

			ConfirmedDialogClosedOrNotPresent = true;
		}
	}
}