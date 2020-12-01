//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.IO;
using Ncr.Core.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Models;
using Sscat.Core.Net;
using Sscat.Tests.Config;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class SscatClientWorkerTests
	{
		SscatClientWorker worker;
		SscatClientStub client;
		
		[SetUp]
		public void Setup()
		{
			MessageService.Attach(new ConsoleMessageProvider());
			DnsHelper.Attach(new DnsManagerStub());
			
			client = new SscatClientStub(new XmlResponseParser(), new EasyClientEngine());
			client.Configuration = ClientConfiguration.Deserialize(new StringReader(@"<Configuration>
	<ScriptGenerator>
		<Files/>
	</ScriptGenerator>
	<Player PlaybackRepetition='1'/>
</Configuration>"));
			worker = new SscatClientWorker(client);
			
			client.DataSent += new EventHandler<NetworkEventArgs>(ClientDataSent);
		}
		
		[TearDown]
		public void Teardown()
		{
			client.DataSent -= new EventHandler<NetworkEventArgs>(ClientDataSent);
		}
		
		[Test]
        //TODO: FIX CRASHING UNIT TEST
		[Ignore("Skip, Causes Unit Tests to Crash")] 
		public void TestGenerate()
		{
			worker.GeneratorConfiguration = new GeneratorConfigurationRepositoryStub().Read("");
			worker.Generate();
		}
		
		[Test]
        //TODO: FIX CRASHING UNIT TEST
        [Ignore("Skip, Causes Unit Tests to Crash")] 
		public void TestPlay()
		{
			worker.ScriptFiles = new List<ScriptFile>(new ScriptFile[] { new ScriptFile(@"C:\Projects\finger\trunk\tests\test.xml") });
			worker.Play();
		}

		void ClientDataSent(object sender, NetworkEventArgs e)
		{
			client.Stop();
		}
	}
}
