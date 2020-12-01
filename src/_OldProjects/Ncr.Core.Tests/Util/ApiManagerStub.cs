//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	public class ApiManagerStub : IApiManager
	{
		int visible;
		IntPtr dialogItem;
		IntPtr findWindow;
		IntPtr findWindowEx;
		string str;
		
		public ApiManagerStub() : this(666, new IntPtr(666), new IntPtr(666), new IntPtr(666))
		{
		}
		
		public ApiManagerStub(int visible, IntPtr dialogItem, IntPtr findWindow, IntPtr findWindowEx) : this(visible, dialogItem, findWindow, findWindowEx, "")
		{
		}
		
		public ApiManagerStub(int visible, IntPtr dialogItem, IntPtr findWindow, IntPtr findWindowEx, string str)
		{
			this.visible = visible;
			this.dialogItem = dialogItem;
			this.findWindow = findWindow;
			this.findWindowEx = findWindowEx;
			this.str = str;
		}
		
		public IntPtr SendMessage(IntPtr handle, uint message, int wparam, int lparam)
		{
			return new IntPtr(666);
		}
		
		public IntPtr FindWindow(string className, string windowName)
		{
			return findWindow;
		}
		
		public IntPtr GetDlgItem(IntPtr handle, int item)
		{
			return dialogItem;
		}
		
		public int SendMessage(IntPtr handle, uint message, int wparam, string lparam)
		{
			return 666;
		}
		
		public bool ShowWindow(IntPtr handle, int show)
		{
			return true;
		}
		
		public IntPtr FindWindowEx(IntPtr parentHandle, int childAfter, string className, string windowTitle)
		{
			return findWindowEx;
		}
		
		public int IsWindowVisible(IntPtr handle)
		{
			return visible;
		}
		
		public int IsWindowEnabled(IntPtr handle)
		{
			return 666;
		}
		
		public bool SetForegroundWindow(IntPtr handle)
		{
			return true;
		}
		
		public IntPtr SendMessage(IntPtr handle, uint message, int wparam, System.Text.StringBuilder lparam)
		{
			lparam.Append(str);
			return new IntPtr(666);
		}
		
		public IntPtr SendMessage(IntPtr handle, uint message, IntPtr wparam, IntPtr lparam)
		{
			return new IntPtr(666);
		}
		
		public void KeyboardEvent(int vk, byte scan, int flags, int extrainfo)
		{
		}
		
		public Image CaptureImageWindow(IntPtr handle)
		{
			return new PictureBox().Image;
		}
		
		public Image CaptureImageDesktop()
		{
			return new PictureBox().Image;
		}		
		
		public void SendWait(string command)
		{
		}
		
		public IntPtr ChiledWindowFromPoint(IntPtr handle, Point point)
		{
			return new IntPtr(666);
		}
		
		public int GetWindowText(IntPtr handle, StringBuilder text, int maxCount)
		{
			return 1;
		}
		
		public void SendDlgItemMessage(IntPtr handle, int id, uint message, int index, StringBuilder buffer)
		{
		}
		
        public void SetCursorPosition(Point pt)
        {

        }
	}
}
