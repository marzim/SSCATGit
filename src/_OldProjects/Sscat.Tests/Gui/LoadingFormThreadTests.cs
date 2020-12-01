//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using System.Threading;
using NUnit.Framework;
using Sscat.Core.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class LoadingFormThreadTests
	{
		LoadingFormThread thread;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			thread = new LoadingFormThread("Test Title", "Test Message");
		}
		
		//[Test]
        //TODO: Either remove or fix empty test
		public void TestStartAndKill()
		{
//			thread.Start();
//			thread.Kill();
		}
	}
}