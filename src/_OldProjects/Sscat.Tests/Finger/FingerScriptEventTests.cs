//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;

namespace Sscat.Tests.Finger
{
	[TestFixture]
	public class FingerScriptEventTests
	{
		FingerScriptEvent e;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = FingerScriptEvent.Deserialize(new StringReader(@"<FingerEventData ScreenshotLink='' ScriptIndex='0' Index='0'>
              <enable>true</enable>
              <eventTimeMS>942962708</eventTimeMS>
              <eventType>PsxEventData</eventType>
              <PsxEventData>
                <contextName>Attract</contextName>
                <controlName>Display</controlName>
                <eventName>ChangeContext</eventName>
                <param />
                <psxId>1</psxId>
                <remoteConnectionName />
                <seqId>1</seqId>
              </PsxEventData>
            </FingerEventData>"));
            e.ResultChanged += new EventHandler<ResultEventArgs>(EventResultChanged);
		}

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            e.ResultChanged -= new EventHandler<ResultEventArgs>(EventResultChanged);
        }
		
		[Test]
		public void TestOtherConstructor()
		{
			FingerScriptEvent x = new FingerScriptEvent(0, true);
			Assert.IsTrue(x.Enabled);
		}
		
		[Test]
        public void TestEnabledValue()
		{
			Assert.IsTrue(e.Enabled);
		}

        [Test]
        public void TestTimeValue()
        {
            Assert.AreEqual(942962708, e.Time);
        }

        [Test]
        public void TestTypeValue()
        {
            Assert.AreEqual("PsxEventData", e.Type);
        }

        [Test]
        public void TestScreenshotLinkValue()
        {
            Assert.IsEmpty(e.ScreenshotLink);
        }

        [Test]
        public void TestIndexValue()
        {
            Assert.AreEqual(0, e.Index);
        }

        [Test]
        public void TestScriptIndexValue()
        {
            Assert.AreEqual(0, e.ScriptIndex);
        }

        [Test]
        public void TestItemValue()
        {
            Assert.IsNotNull(e.Item);
        }

        [Test]
        public void TestFingerPsxEventItemValue()
        {
            Assert.IsInstanceOf(typeof(FingerPsxEvent), e.Item);
        }

        [Test]
        public void TestResultNotNullValue()
        {
            Assert.IsNotNull(e.Result);
        }

        [Test]
        public void TestResultNullValue()
        {
            e.Result = null;
            Assert.IsNull(e.Result);
        }

        [Test]
        public void TestHasRapConnectionValue()
        {
            Assert.IsFalse(e.HasRapConnection);
        }

        [Test]
        public void TestToEventValue()
        {
            Assert.IsNotNull(e.ToEvent());
        }

		void EventResultChanged(object sender, ResultEventArgs e)
		{
		}
	}
}
