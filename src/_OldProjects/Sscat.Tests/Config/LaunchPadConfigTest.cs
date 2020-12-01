//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;

namespace Sscat.Tests.Config
{
	[TestFixture]
	public class LaunchPadConfigTest
	{
		LaunchPadConfig config;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManagerStub());						
			config = new LaunchPadConfigRepositoryStub().Read("");
		}

		[Test]
		public void TestGetDiagLocation()
		{	
			GetDiagLocation g = new GetDiagLocation("", new LaunchPadConfigRepositoryStub());
			Assert.AreEqual(@"C:\scot\bin\autopushdiagfiles.bat", g.GetFilename());
		}
		
		[Test]
		public void TestGetDiagLocationWithException()
		{	
			GetDiagLocation g;
            Assert.That(() => g = new GetDiagLocation(@"C:\Not.Found", new LaunchPadConfigRepositoryStub()),
                Throws.TypeOf<Exception>());
		}

		[Test]
		public void TestXmlLaunchPadConfigRepository()
		{
			XmlLaunchPadConfigRepository xm = new XmlLaunchPadConfigRepository();
			Assert.That(() => xm.Read("test.txt"), Throws.TypeOf<System.IO.FileNotFoundException>());
		}
	}
}
