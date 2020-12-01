//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Core.Util;

namespace Sscat.Tests.Util
{
	public class ApplicationLauncherStub : ISscatApplicationLauncher
	{
		public event EventHandler<ApplicationLauncherEventArgs> ApplicationLauncherManage;
		
		public void LaunchApplication(IApplicationLauncherEvent item)
		{
			LaunchApplication(item.Host, item.ApplicationPath);
		}
		
		public void LaunchApplication(string host, string path)
		{
			OnApplicationLauncherManage(new ApplicationLauncherEventArgs("Success running the application."));
		}
		
		public void CreateLaunchApplication(IApplicationLauncherEvent item)
		{
			OnApplicationLauncherManage(new ApplicationLauncherEventArgs(@"Successfully created application launcher script C:\SSCAT\Scripts\" + item.ScriptFileName.ToString() + ".xml"));
		}
		
		protected virtual void OnApplicationLauncherManage(ApplicationLauncherEventArgs e)
		{
			if (ApplicationLauncherManage != null) {
				ApplicationLauncherManage(this, e);
			}
		}
	}
}
