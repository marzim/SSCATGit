//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using Ncr.Core.Views;
using NUnit.Framework;
using Sscat.Core.Commands.Gui;
using Sscat.Core.Gui;
using Sscat.Core.Views;
using Sscat.Views;

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class ShowAboutTests
	{
		ShowAbout command;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApplicationUtility.Attach(new ApplicationManagerStub());
			WorkbenchSingleton.Attach(new ConsoleWorkbench(), new ConsoleWorkbenchLayout());
			
			command = new ShowAbout(new V());
		}
		
		[Test]
		public void TestEmptyConstructor()
		{
            try
            {
                command = new ShowAbout();
            }
            catch (Exception)
            {
                Assert.That(() => command = new ShowAbout(),
                    Throws.TypeOf<System.IO.DirectoryNotFoundException>());
            }
			
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
		
		class V : IAboutView
		{
			public IntPtr Handle {
				get {
					throw new NotImplementedException();
				}
			}
		}
	}
}
