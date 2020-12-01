//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class MemoryUsageTests
	{
		MemoryUsage u;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			u = new MemoryUsage(0, new DateTime(2011, 11, 22, 10, 58, 12), 0, 0, 0, 0, 0);
			u.ResultChanged += new EventHandler<ResultEventArgs>(EventResultChanged);
			u.Result = new Result(ResultType.None, "");
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			u.ResultChanged -= new EventHandler<ResultEventArgs>(EventResultChanged);
		}
		
		[Test]
		public void TestEmptyConstructor()
		{
			u = new MemoryUsage();

            reset();
		}
		
		[Test]
        public void TestResultValue()
		{
			Assert.IsNotNull(u.Result);
		}
		
		[Test]
		public void TestToEvent()
		{
			Assert.That(() => u.ToEvent(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestToString()
		{
			Assert.AreEqual("0,10:58:12,0,0,0,0,0,0", u.ToString());
		}
		
		[Test]
		public void TestType()
		{
			//Assert.IsEmpty(u.Type);
            Assert.That(() => u.Type,
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestGetScreenshotLink()
		{
			//Assert.IsEmpty(u.ScreenshotLink);
            Assert.That(() => u.ScreenshotLink,
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestSetScreenshotLink()
		{
			Assert.That(() => u.ScreenshotLink = "",
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestGetItem()
		{
			//Assert.IsNotNull(u.Item);
            Assert.That(() => u.Item,
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestSetItem()
		{
			Assert.That(() => u.Item = new DeviceEvent(), 
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestGetScriptIndex()
		{
			//Assert.AreEqual(0, u.ScriptIndex);
            Assert.That(() => u.ScriptIndex,
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestSetScriptIndex()
		{
			Assert.That(() => u.ScriptIndex = 0, 
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestGetIndex()
		{
			//Assert.AreEqual(0, u.Index);
            Assert.That(() => u.Index,
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestSetIndex()
		{
            Assert.That(() => u.Index = 0,
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestGetTime()
		{
			//Assert.AreEqual(0, u.Time);
            Assert.That(() => u.Time,
                Throws.TypeOf<NotImplementedException>());

		}
		
		[Test]
		public void TestSetTime()
		{
			Assert.That(() => u.Time = 0,
                Throws.TypeOf<NotImplementedException>());
		}

        private void reset()
        {
            u = new MemoryUsage(0, new DateTime(2011, 11, 22, 10, 58, 12), 0, 0, 0, 0, 0);
            u.ResultChanged += new EventHandler<ResultEventArgs>(EventResultChanged);
            u.Result = new Result(ResultType.None, "");
        }

		void EventResultChanged(object sender, ResultEventArgs e)
		{
		}
	}
}
