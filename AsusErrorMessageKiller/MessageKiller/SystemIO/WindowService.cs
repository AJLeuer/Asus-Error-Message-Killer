using System;
using System.Runtime.InteropServices;

#pragma warning disable 8123

namespace AsusErrorMessageKiller.MessageKiller.SystemIO
{
	public static class WindowService
	{

		private static readonly (uint, int) CloseWindowCommand = (WM_SYSCOMMAND: 0x0112, SC_CLOSE: 0xF060);

		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(string className, string windowName);
		
		[DllImport("user32.dll")]
		private static extern bool IsWindowVisible(IntPtr window);

		public static void CloseWindow(IntPtr window)
		{
			SystemMessageService.SendMessage(window, CloseWindowCommand.Item1, CloseWindowCommand.Item2, 0);
		}

		public static bool IsOpen(IntPtr window)
		{
			bool windowExists = (window.ToInt64() > 0);
			
			return windowExists && IsWindowVisible(window);
		}
		
	}
}