//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Threading;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Emulators;
using Sscat.Core.Gui;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class MessageFormTests
	{
		MessageForm form;
		SscatLane lane;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			RegistryHelper.Attach(new RegistryManagerStub());
			ApiHelper.Attach(new ApiManagerStub());
			
			lane = new SscatLane();
			
			form = new MessageForm();
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			form.Close();
		}
		
		[Test]
		public void TestProgress()
		{
			form.Show();
			form.SetProgress("Starting lane...", 50);
		}
	}
}
