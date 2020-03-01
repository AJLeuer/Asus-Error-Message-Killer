using System;
using System.Threading;
using AsusErrorMessageKiller.MessageKiller.SystemIO;

namespace AsusErrorMessageKiller.MessageKiller.Service
{
	public static class AsusErrorDialog
	{
		private const string AsusErrorMessageClassName = "#32770";
		private const string AsusErrorMessageWindowName = "Message";
		
		public static bool ConfirmedDialogClosedOrNotPresent { get; private set; } = false;

		public static void Kill()
		{
			// ReSharper disable once SuggestVarOrType_SimpleTypes
			var dialog = WindowService.FindWindow(AsusErrorMessageClassName, AsusErrorMessageWindowName);

			while (WindowService.IsOpen(dialog))
			{
				WindowService.CloseWindow(dialog);
				Thread.Sleep(TimeSpan.FromMilliseconds(20));
			}

			ConfirmedDialogClosedOrNotPresent = true;
		}
	}
}