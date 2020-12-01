//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core;
using Ncr.Core.Emulators;
using Ncr.Core.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Core.Net;
using Sscat.Tests.Config;
using Sscat.Tests.Repositories;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class LoadConfigRequestDispatcherTests
	{
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
//			LoggingService.Attach(new ConsoleLogger(new DateLogFormatter()));
//			LoggingService.Attach(new Log4NetLogger());
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
		}
		
		[Test]
		public void TestDispatch()
		{
            //Request r = Request.Deserialize(new StringReader(@"<Request Type='LOAD_CONFIG'>
            //	<Content>
            //<![CDATA[
            //<File Name='test.xml' Destination='C:\scot\config'>hello world</File>
            //]]>
            //	</Content>
            //</Request>
            //"));
            ConfigFile c = new ConfigFile("test.xml", "");
            c.Destination = @"C:\scot\config";
            c.Content = "hello world";
            Request r = new Request("LOAD_CONFIG", c);
			LoadConfigRequestDispatcher dispatcher = new LoadConfigRequestDispatcher(new ConfigFileRepositoryStub(), new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()));
			dispatcher.Dispatch(r);
		}
		
		[Test]
		public void TestDispatchNonExistentConfigFile()
		{
            //Request r = Request.Deserialize(new StringReader(@"<Request Type='LOAD_CONFIG'>
            //	<Content>
            //<![CDATA[
            //<File Name='notexists.xml' Destination='C:\scot\config'>hello world</File>
            //]]>
            //	</Content>
            //</Request>
            //"));
            ConfigFile c = new ConfigFile("notexists.xml");
            c.Destination = @"C:\scot\config";
            c.Content = "hello world";
            Request r = new Request("LOAD_CONFIG", c);
			            LoadConfigRequestDispatcher dispatcher = new LoadConfigRequestDispatcher(new ConfigFileRepositoryStub(), new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()));
			            dispatcher.Dispatch(r);
		}
		
		[Test]
		public void TestDispatchOnException()
		{
			LoadConfigRequestDispatcher dispatcher = new LoadConfigRequestDispatcher(new ConfigFileRepositoryStub(), new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()));
//			Request r = Request.Deserialize(new StringReader(@"<Request/>"));
			Request r = new Request();
			dispatcher.Dispatch(r);
		}
	}
}
