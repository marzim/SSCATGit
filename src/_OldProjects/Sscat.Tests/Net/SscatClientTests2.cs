//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.IO;
using Ncr.Core.Net;
using Ncr.Core.Tests.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Models;
using Sscat.Core.Net;
using Sscat.Tests.Config;
using Sscat.Tests.Models;
using Sscat.Tests.Repositories;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class SscatClientTests2
	{
		SscatClient client;
		GeneratorConfiguration generatorConfig;
		
		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			DnsHelper.Attach(new DnsManagerStub());
//			MessageService.Attach(new ConsoleMessageProvider());
			MessageService.Attach(new NoMessageProvider());
//			ThreadHelper.Attach(new ThreadManagerStub());
			ThreadHelper.Attach(new T());
			
//			generatorConfig = new GeneratorConfiguration("test", "", "", true, @"C:\sscat\scripts", @"C:\sscat\scotconfig");
			generatorConfig = new GeneratorConfiguration();
			generatorConfig.ScriptName = "test";
			generatorConfig.SegmentedScripts = true;
			generatorConfig.ScriptOutputDirectory = @"C:\sscat\scripts";
			generatorConfig.ScotConfigOutputDirectory = @"C:\sscat\scotconfig";
		}

        [SetUp]
        public void SetUp()
        {
            client = new SscatClient(new XmlResponseParser(), new ClientEngineStub());
            client.AddDispatcher(new G());
            client.AddDispatcher(new P());
            client.AddDispatcher(new E());

            client.ConnectionTimeOut += new EventHandler<NetworkEventArgs>(ClientConnectionTimeOut);
            client.CacheInitiate += new EventHandler<ScriptEventArgs>(ClientCacheInitiate);
            client.ConfigLoadedDispatched += new EventHandler(ClientConfigLoadedDispatched);
            client.ConfigurationChanged += new EventHandler(ClientConfigurationChanged);
            client.LoggerStart += new EventHandler(ClientLoggerStart);
            client.LoggerStop += new EventHandler(ClientLoggerStop);
            client.Playing += new EventHandler(ClientPlaying);
            client.ReportDispatched += new EventHandler<ReportEventArgs>(ClientReportDispatched);
            client.ScriptEventResultDispatched += new EventHandler<ScriptEventEventArgs>(ClientScriptEventResultDispatched);
            client.ScriptResultDispatched += new EventHandler<ScriptEventArgs>(ClientScriptResultDispatched);
            client.ScriptsDispatched += new EventHandler(ClientScriptsDispatched);
            client.Stopped += new EventHandler(ClientStopped);
            client.Stopping += new EventHandler(ClientStopping);
            client.PlayerConfigurationPrepare += new EventHandler<PlayerConfigurationEventArgs>(ClientPlayerConfigurationPrepare);
            client.ScriptFileNameCheck += new EventHandler<GeneratorConfigurationEventArgs>(ClientScriptFileNameCheck);
            client.ConfigCheckedDispatched += new EventHandler<ConfigFileEventArgs>(ClientConfigCheckedDispatched);
            client.ConfigDispatched += new EventHandler<ConfigFileEventArgs>(ClientConfigDispatched);

            client.Configuration = new ClientConfigurationRepositoryStub().Read("");
        }
		
		[OneTimeTearDown]
		public void Teardown()
		{
			client.ConnectionTimeOut -= new EventHandler<NetworkEventArgs>(ClientConnectionTimeOut);
			client.CacheInitiate -= new EventHandler<ScriptEventArgs>(ClientCacheInitiate);
			client.ConfigLoadedDispatched -= new EventHandler(ClientConfigLoadedDispatched);
			client.ConfigurationChanged -= new EventHandler(ClientConfigurationChanged);
			client.LoggerStart -= new EventHandler(ClientLoggerStart);
			client.LoggerStop -= new EventHandler(ClientLoggerStop);
			client.Playing -= new EventHandler(ClientPlaying);
			client.ReportDispatched -= new EventHandler<ReportEventArgs>(ClientReportDispatched);
			client.ScriptEventResultDispatched -= new EventHandler<ScriptEventEventArgs>(ClientScriptEventResultDispatched);
			client.ScriptResultDispatched -= new EventHandler<ScriptEventArgs>(ClientScriptResultDispatched);
			client.ScriptsDispatched -= new EventHandler(ClientScriptsDispatched);
			client.Stopped -= new EventHandler(ClientStopped);
			client.Stopping -= new EventHandler(ClientStopping);
			client.PlayerConfigurationPrepare -= new EventHandler<PlayerConfigurationEventArgs>(ClientPlayerConfigurationPrepare);
			client.ScriptFileNameCheck -= new EventHandler<GeneratorConfigurationEventArgs>(ClientScriptFileNameCheck);
			client.ConfigCheckedDispatched -= new EventHandler<ConfigFileEventArgs>(ClientConfigCheckedDispatched);
			client.ConfigDispatched -= new EventHandler<ConfigFileEventArgs>(ClientConfigDispatched);
			
			client.Disconnect();
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("ClientConfiguration..xml", client.ConfigurationName);
			Assert.AreEqual("ClientConfiguration.default.xml", client.DefaultConfigurationName);
		}
		
		[Test]
		public void TestStop()
		{
			client.Stop();
		}
		
		[Test]
		public void TestReceiveResponseWithError()
		{
//			client.ReceiveResponse(new Response("E", ""));
			client.ReceiveResponse(new Response("E", new MessageContent("")));
		}
		
		[Test]
		public void TestReceiveNotSupportedResponse()
		{
//			client.ReceiveResponse(new Response("Qwerty", ""));
			client.ReceiveResponse(new Response("Qwerty", new MessageContent("")));
		}
		
		[Test]
		public void TestGenerate()
		{
			client.DataSent += delegate(object sender, NetworkEventArgs e) { 
				client.ReceiveResponse(Response.Deserialize(new StringReader(@"<Response Type='G'/>")));
			};
//			client.Generate(new GeneratorConfiguration("test", "", "", true, @"C:\sscat\scripts", @"C:\sscat\scotconfig"));
			client.Generate(generatorConfig);
		}
		
		[Test]
		public void TestGenerateWithError()
		{
//			client.Generate(new GeneratorConfiguration("", "", "",  true, @"C:\sscat\scripts", @"C:\sscat\scotconfig"));
			generatorConfig.ScriptName = "";
			client.Generate(generatorConfig);
		}
		
		[Test]
		public void TestGenerateWithInvalidFileName()
		{
			client.ScriptFileNameCheck += delegate(object sender, GeneratorConfigurationEventArgs e) { 
				e.Config.Errors.Add("Chuck Norris!");
			};
//			client.Generate(new GeneratorConfiguration("test", "", "", true, @"C:\sscat\scripts", @"C:\sscat\scotconfig"));
			client.Generate(generatorConfig);
		}
		
		[Test]
		public void TestPlay()
		{
			DnsHelper.Attach(new DA());
			client.DataSent += delegate(object sender, NetworkEventArgs e) { 
				client.ReceiveResponse(Response.Deserialize(new StringReader(@"<Response Type='P'/>")));
			};
			ScriptFile[] scripts = new ScriptFile[] { new ScriptFile(@"C:\Projects\finger\trunk\tests\test.xml"), new ScriptFile(@"C:\Projects\finger\trunk\tests\test2.xml") };
			client.Play(new List<ScriptFile>(scripts));
		}
		
		[Test]
		public void TestPlayWithError()
		{
			DnsHelper.Attach(new DA());
			client.Configuration.PlayerConfiguration.RapName = "";
			ScriptFile[] scripts = new ScriptFile[] { new ScriptFile(@"C:\Projects\finger\trunk\tests\test.xml"), new ScriptFile(@"C:\Projects\finger\trunk\tests\test2.xml") };
			client.Play(new List<ScriptFile>(scripts));
		}
		
		[Test]
		public void TestConnect()
		{
			client.Connect();
		}

		void ClientConfigDispatched(object sender, ConfigFileEventArgs e)
		{
		}

		void ClientConfigCheckedDispatched(object sender, ConfigFileEventArgs e)
		{
		}

		void ClientScriptFileNameCheck(object sender, GeneratorConfigurationEventArgs e)
		{
		}

		void ClientPlayerConfigurationPrepare(object sender, PlayerConfigurationEventArgs e)
		{
		}

		void ClientConnectionTimeOut(object sender, NetworkEventArgs e)
		{
		}

		void ClientStopping(object sender, EventArgs e)
		{
		}

		void ClientStopped(object sender, EventArgs e)
		{
		}

		void ClientScriptsDispatched(object sender, EventArgs e)
		{
		}

		void ClientScriptResultDispatched(object sender, ScriptEventArgs e)
		{
		}

		void ClientScriptEventResultDispatched(object sender, ScriptEventEventArgs e)
		{
		}

		void ClientReportDispatched(object sender, ReportEventArgs e)
		{
		}

		void ClientPlaying(object sender, EventArgs e)
		{
		}

		void ClientLoggerStop(object sender, EventArgs e)
		{
		}

		void ClientLoggerStart(object sender, EventArgs e)
		{
		}

		void ClientConfigurationChanged(object sender, EventArgs e)
		{
		}

		void ClientConfigLoadedDispatched(object sender, EventArgs e)
		{
		}

		void ClientCacheInitiate(object sender, ScriptEventArgs e)
		{
		}
		
		class E : SscatResponseDispatcher
		{
			public E() : base("E")
			{
			}
			
			public override void Dispatch(Response response)
			{
				OnErrorDispatched(null);
				throw new NotImplementedException();
			}
		}
		
		class G : SscatResponseDispatcher
		{
			public G() : base("G")
			{
			}
			
			public override void Dispatch(Response response)
			{
				OnDispatching("...");
				OnScriptsDispatched(null);
			}
		}
		
		class P : SscatResponseDispatcher
		{
			public P() : base("P")
			{
			}
			
			public override void Dispatch(Response response)
			{
				OnDispatching("...");
				OnConfigCheckedDispatched(new ConfigFileEventArgs(new ConfigFile()));
				OnConfigDispatched(new ConfigFileEventArgs(new ConfigFile()));
				OnConfigLoadedDispatched(null);
				OnScriptEventResultDispatched(new ScriptEventEventArgs(new ScriptEvent()));
				OnScriptResultDispatched(new ScriptEventArgs(new Script()));
				OnReportDispatched(new ReportEventArgs(new Report()));
			}
		}
		
		class DA : DnsManagerStub
		{
			public override bool ValidHostName(string host)
			{
				return true;
			}
		}
	}
	
	public class SscatClientStub : SscatClient
	{
		public SscatClientStub(IResponseParser responseParser, IClientEngine engine) : base(responseParser, engine)
		{
		}
		
		public override void Stop()
		{
			/// hasStopped = true;
			base.Stop();
		}
		
//		public override void SendRequest(string request)
		public override void SendRequest(Request request)
		{
			OnDataSent(new NetworkEventArgs(request));
		}
		
		public override void Disconnect()
		{
			OnDisconnected(new NetworkEventArgs(string.Format("Successfully disconnected from {0}:{1}", Server, Port)));
		}
		
		public override void Connect()
		{
			OnConnected(new NetworkEventArgs(string.Format("Successfully connected to {0}:{1}", Server, Port)));
		}
		
		public void PerformRejected()
		{
			OnConnectionRejecting(null);
			OnConnectionRejected(null);
		}
		
		public void PerformTimeout()
		{
			OnConnectionTimeOut();
		}
	}
	
	class T : ThreadManagerStub
		{
			public override void Start(System.Threading.ThreadStart d)
			{
			}
		}
}
