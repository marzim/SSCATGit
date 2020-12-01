//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Microsoft.Win32;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NMock;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	public class EmulatorStub : Emulator
	{
		public EmulatorStub() : base("")
		{
			Controls.Add(1, 0);
			Controls.Add("&Button", 0);
			Controls.Add("1", 0);
		}
		
		public string Text {
			get { return GetText(1, 10); }
			set { SetText(1, value, 10); }
		}
		
		public string Title {
			set { SetText("textBoxWeigh", value, 10); }
		}
		
		public void Click(int id)
		{
			OnEmulating("Clicking...");
			ClickButton(id, 10);
		}
		
		public void Click(string text)
		{
			ClickButton(text, 10);
		}
		
		public void Select()
		{
			SelectIndex(1, 0, 10);
		}
		
		public void Select(string str)
		{
			SelectIndex(1, str, 10);
		}
		
		public void Check()
		{
			CheckBox("1", 10);
		}
		
		public void Compare()
		{
			CompareIndex(1, "test", 10);
		}
	}
}
