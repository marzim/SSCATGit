//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class AboutFormTests
	{
        string[] trunkDir;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Get the working directory so that it will work running in local machine or in build machine
            string debugDir = AppDomain.CurrentDomain.BaseDirectory;
            trunkDir = debugDir.Split(new[] { "src" }, StringSplitOptions.None);

            // Createing bin folder in trunk dir for the test
            DirectoryHelper.CreateDirectory(System.IO.Path.Combine(trunkDir[0], "bin"));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DirectoryHelper.DeleteDirectory(System.IO.Path.Combine(trunkDir[0], "bin"));
        }

		[Test]
		public void TestAbout()
		{
            ApplicationUtility.Attach(new ApplicationManagerStub());
			AboutForm f = new AboutForm();
		}
	}
}
