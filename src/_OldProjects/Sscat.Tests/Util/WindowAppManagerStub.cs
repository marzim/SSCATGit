//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Util;
using Sscat.Tests.Config;

namespace Sscat.Tests.Util
{
	public class WindowAppManagerStub : WindowAppManager
	{
		string str;
		
		public WindowAppManagerStub() : this("")
		{
		}
		
		public WindowAppManagerStub(string str) : base(new LaunchPadConfigRepositoryStub())
		{
			this.str = str;
		}
		
		public override string GetText(string filename)
		{
			return str;
		}
		
		public override string CheckDiagnosticFile(int time, int timeout)
		{
			return str;
		}
		
		public override void AutoPushDiagFiles()
		{
			OnProcess("...");
		}
		
		public override void GetDiagnosticFilesResults()
		{
			OnProcess("...");
		}
		
		public override void WriteFile(string writeFile, string readFile, string message)
		{
			OnProcess("...");
		}
		
		public override void WindowAppExit(string windowTitle)
		{
		}
	}
}
