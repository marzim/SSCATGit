//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Gui;
using Sscat.Core.Models;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class ScriptTreeNodeTests
	{
		IScript script;
		ScriptTreeNode scriptNode;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			script = FingerScript.Deserialize(new StringReader(@"<FingerScript>
	            <FileName>C:\sscat\scripts\test.xml</FileName>
	            <FingerEventData>
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
	            </FingerEventData>
            </FingerScript>"));
			scriptNode = new ScriptTreeNode(script);
		}
		
		[Test]
		public void TestScriptNodeTextValue()
		{
			Assert.AreEqual(script.FileName, scriptNode.Text);
		}

        [Test]
        public void TestScriptNodesCountValue()
        {
            Assert.AreEqual(script.Events.Events.Length, scriptNode.Nodes.Count);
        }
	}
}
