//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//		<owner name="Ian Escarro" email="ian.escrro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Util;

namespace Sscat.Tests.Util
{
	[TestFixture]
	public class GenerateDiagsTest
	{
		DiagnosticsUtility gd;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			LoggingService.DetachAll();
			DirectoryHelper.Attach(new DirectoryManagerStub());
			FileHelper.Attach(new FileManagerStub());
			gd = new DiagnosticsUtility();
			gd.DiagnosticsInProcess += new EventHandler<SscatEventArgs>(GenerateDiagsDoingSomething);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			gd.DiagnosticsInProcess -= new EventHandler<SscatEventArgs>(GenerateDiagsDoingSomething);
		}
		
		[Test]
		public void TestGenerateDiagWithException()
		{
			FileHelper.Attach(new FileManagerStub());
			WindowAppHelper.Attach(new W());
			//Assert.IsNotEmpty(gd.GetDiag(@"c:\SSCAT\Diags\", @"c:\SSCAT\"));
            Assert.That(() => gd.GetDiag(@"c:\SSCAT\Diags\", @"c:\SSCAT\"), 
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestGenerateDiagWithException2()
		{
			FileHelper.Attach(new FileManagerStub());
			WindowAppHelper.Attach(new X());
            //Assert.IsNotEmpty(gd.GetDiag(@"c:\SSCAT\Diags\", @"c:\SSCAT\"));
            Assert.That(() => gd.GetDiag(@"c:\SSCAT\Diags\", @"c:\SSCAT\"), 
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestGenerateDiagWithException3()
		{
			FileHelper.Attach(new FileManagerStub());
			WindowAppHelper.Attach(new W());
            //Assert.IsNotEmpty(gd.GetDiag(@"c:\SSCAT\Diags\", @"c:\SSCAT\", @"c:\temp]"));
            Assert.That(() => gd.GetDiag(@"c:\SSCAT\Diags\", @"c:\SSCAT\", @"c:\temp]"),
                Throws.TypeOf<NotImplementedException>());
		}		
		
		[Test]
		public void TestGenerateDiag()
		{
			WindowAppHelper.Attach(new WindowAppManagerStub("c:\temp.txt"));
			Assert.IsNotEmpty(gd.GetDiag(@"c:\SSCAT\Diags\", @"c:\SSCAT\"));
			WindowAppHelper.Attach(new WindowAppManagerStub(null));
			Assert.IsNotEmpty(gd.GetDiag(@"c:\SSCAT\Diags\", @"c:\SSCAT\Screenshots\"));
		}
		
		[Test]
		public void TestGenerateDiag2()
		{
			WindowAppHelper.Attach(new WindowAppManagerStub("c:\temp.txt"));
			Assert.IsNotEmpty(gd.GetDiag(@"c:\SSCAT\Diags\", @"c:\SSCAT\", @"c:\temp"));
			WindowAppHelper.Attach(new WindowAppManagerStub(null));
			Assert.IsNotEmpty(gd.GetDiag(@"c:\SSCAT\Diags\", @"c:\SSCAT\Screenshots\", @"c:\temp"));
		}		

		void GenerateDiagsDoingSomething(object sender, SscatEventArgs e)
		{
		}
		
		class X : WindowAppManagerStub
		{
			public override string GetLastWrittenFile(string path, string pattern)
			{
				throw new NotImplementedException();
			}
		}
		
		class W : WindowAppManagerStub
		{
			public override void WriteFile(string writeFile, string readFile, string message)
			{
				throw new NotImplementedException();
			}
		}
	}
}
