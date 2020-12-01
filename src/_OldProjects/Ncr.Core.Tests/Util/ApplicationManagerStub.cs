//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Threading;
using System.Windows.Forms;
using Ncr.Core.Commands;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	public class ApplicationManagerStub : AbstractApplicationManager
	{
		ICommand cmd;
		
		public ApplicationManagerStub()
		{
		}
		
		public ApplicationManagerStub(ICommand cmd)
		{
			this.cmd = cmd;
		}
		
		public override string ProductVersion {
			get { return "3.0"; }
		}
		
		public override string ProductName {
			get { return "SSCAT"; }
		}
		
		public override string ProcessName {
			get { return "SSCAT"; }
		}
		
		public override string Location {
			get {
				return @"C:\Projects\finger\trunk\bin";
			}
		}
		
		public override void Run(Form form)
		{
			if (cmd != null) {
				cmd.Run();
			}
		}
		
		public override string ClientConfigurationFileName(string serverIP) 
		{	
			return @"C:\SSCAT\config\ClientConfiguration.192.168.131.67.xml";
		}		                                                   
	}
}
