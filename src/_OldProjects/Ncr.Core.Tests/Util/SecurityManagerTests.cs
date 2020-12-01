//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class SecurityManagerTests
	{
		TestSecurityManager ts;
		SecurityManager s;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ProcessUtility.Attach(new ProcessManagerStub());
			DirectoryHelper.Attach(new DirectoryManagerStub());
			FileHelper.Attach(new FileManagerStub());
			ts = new TestSecurityManager();
			s = new SecurityManager();
		}
		
		[Test]
		public void TestUpdate1Wldb()
		{
            try
            {
                ts.UpdateWldb("localhost", "some.mdb", "some.mdb", "scot", "Q+1MwHiTNa4RB04/+wirFg==");
            }catch(Exception){
                Assert.That(() => ts.UpdateWldb("localhost", "some.mdb", "some.mdb", "scot", "Q+1MwHiTNa4RB04/+wirFg=="),
                Throws.TypeOf<System.ComponentModel.Win32Exception>());
            }
		}
		
		[Test]
		public void TestUpdate2Wldb()
		{
            try
            {
                ts.SetValidateLogin(true);
                ts.SetValidateServer(true);
                ts.SetValidateSAServer(true);
                ts.UpdateWldb("localhost", "some.mdb", "some.mdb", "scot", "Q+1MwHiTNa4RB04/+wirFg==");
            }catch(Exception){
                Assert.That(() => ts.UpdateWldb("localhost", "some.mdb", "some.mdb", "scot", "Q+1MwHiTNa4RB04/+wirFg=="),
                    Throws.TypeOf<System.ComponentModel.Win32Exception>());
            }
		}
		
		[Test]
		public void TestValidateServer()
		{
			s.ValidateServer("localhost");
		}
		
		[Test]
		public void TestValidateInvalidServer()
		{
            Assert.That(() => s.ValidateServer("invalidserver"),
                Throws.TypeOf<SecurityManagerException>());
		}		
		
		[Test]
		public void TestValidateLogin()
		{
            Assert.That(() => s.ValidateLogin("localhost", "scot", "Q+1MwHiTNa4RB04/+wirFg=="),
                Throws.TypeOf<SecurityManagerException>());
		}
		
		[Test]
		public void TestValidateInvalidLogin()
		{
            Assert.That(() => s.ValidateLogin("localhost", "scot", "scot"),
                Throws.TypeOf<SecurityManagerException>());
		}		

		[Test]
		public void TestValidateSAServer()
		{
            Assert.That(() => s.ValidateSAServer("localhost"),
                Throws.TypeOf<SecurityManagerException>());
		}

		[Test]
		public void TestEditFile()
		{
            try
            {
                s.EditFile("update.bat", "localhost", "some.mdb", "some.mdb");
            }catch(Exception){
                Assert.That(() => s.EditFile("update.bat", "localhost", "some.mdb", "some.mdb"),
                    Throws.TypeOf<ArgumentNullException>());
            }
		}
		
		[Test]
		public void TestWriteAll()
		{
			ArrayList list = new ArrayList(500);
			list.Insert(0, "test");
			s.WriteAllText("test.txt", list);
		}
	}
	
	public class TestSecurityManager : SecurityManager
	{
		bool isValidServer;
		bool isValidLogin;
		bool isValidSAServer;
		bool isSuccessfulLogin;
		
		public TestSecurityManager()
		{
			isValidServer = true;
			isValidLogin = true;
			isValidSAServer = true;
			isSuccessfulLogin = true;
		}
				
		public void SetValidateServer(bool b)
		{
			isValidServer = b;
		}
		
		public void SetValidateLogin(bool b)
		{
			isValidLogin = b;
		}

		public void SetValidateSAServer(bool b)
		{
			isValidSAServer = b;
		}
		
		public override bool IsSuccessfulLogin(string server, string user, string password)
		{
			if (!isSuccessfulLogin) {
				throw new SecurityManagerException(string.Format("Unable to sign on at {0}.", server));
			}
			return true;
		}
		
		public override void ValidateServer(string server)
		{
			if (!isValidServer) {
				throw new SecurityManagerException(string.Format("Unable to ping server {0}", server));
			}
		}
		
		public override void ValidateLogin(string server, string user, string password)
		{
			if (!isValidLogin) {
				throw new SecurityManagerException(string.Format("Unable to sign on at {0}", server));
			}
		}
		
		public override void ValidateSAServer(string server)
		{
			if (!isValidSAServer) {
				throw new SecurityManagerException(string.Format(@"Unable to locate in {0} C:\scot\SecurityAgent\SAServer.exe", server));
			}
		}
		
		public override void EditFile(string file, string server, string wldbFile, string saConfigFile)
		{
		}
	}
}