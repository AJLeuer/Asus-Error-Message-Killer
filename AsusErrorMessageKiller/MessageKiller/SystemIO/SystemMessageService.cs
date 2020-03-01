using System;
using System.Runtime.InteropServices;

namespace AsusErrorMessageKiller.MessageKiller.SystemIO
{
	public static class SystemMessageService
	{
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr window, uint message, int firstParameter, int secondParameter);
	}
}