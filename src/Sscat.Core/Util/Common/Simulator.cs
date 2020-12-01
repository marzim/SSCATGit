//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Sscat.Core
{
	public class Simulator
	{
		public Simulator()
		{
		}
		
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string className, string windowName);

//		[DllImport("user32.dll", EntryPoint = "keybd_event", CharSet = CharSet.Auto, ExactSpelling = true)]
//		public static extern void keybd_event(int vk, byte scan, int flags, int extrainfo);
//
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr handle, uint message, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr handle, int show);

		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr handle);

		[DllImport("user32.dll")]
		public static extern bool BringWindowToTop(IntPtr hwnd);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool IsWindowVisible(IntPtr handle);
	}
}
