//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Models;
using Sscat.Core.Util;

namespace Sscat.Tests.Util
{
	public class SecurityManagerStub : ISscatSecurityManager
	{
		public event EventHandler<WldbEventArgs> WldbManage;
		
		public void UpdateWldb(IWldbEvent item)
		{
			UpdateWldb(item.Host, item.WldbFile, item.SAConfigFile, item.User, item.Password);
		}
		
		public void UpdateWldb(string server, string wldbFile, string saConfigFile, string user, string password)
		{
			OnWldbManage(new WldbEventArgs("Success in updating WLDB/SAConfig."));
		}
		
		public void BackupWldb(IWldbEvent item)
		{
			BackupWldb(item.Host, item.WldbFile, item.SAConfigFile, item.User, item.Password);
		}
		
		public void BackupWldb(string server, string wldbFile, string saConfigFile, string user, string password)
		{
			OnWldbManage(new WldbEventArgs("Success in backing up WLDB/SAConfig."));
		}
		
		public void CreateBackupScript(IWldbEvent item)
		{
	//			throw new NotImplementedException();
		}
			
		public void CreateUpdateScript(IWldbEvent item)
		{
	//			throw new NotImplementedException();
		}
		
		public bool IsSuccessfulLogin(string server)
		{
			return true;
		}
		
		protected virtual void OnWldbManage(WldbEventArgs e)
		{
			if (WldbManage != null) {
				WldbManage(this, e);
			}
		}
	}
}
