//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Net;
using Sscat.Tests.Config;
using Sscat.Tests.Models;
using Sscat.Tests.Repositories;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class ScriptsResponseDispatcherTests
	{
		ScriptsResponseDispatcher dispatcher;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
//			MessageService.Attach(new ConsoleMessageProvider());
			MessageService.Attach(new NoMessageProvider());
			dispatcher = new ScriptsResponseDispatcher(new ConfigFileRepositoryStub(), new ScriptRepositoryStub(), "localhost");
		}

		[Test]
//		[Ignore()]
		public void TestDispatch()
		{
			Response r = new Response(
				"",
				GeneratorConfiguration.Deserialize(new StringReader(@"<Configuration>
	            <Files>
		            <File Name='test.xml' Destination='C:\SSCAT\Scripts'/>
	            </Files>
	            <Scripts>
		            <Script/>
	            </Scripts>
            </Configuration>")));
			dispatcher.Dispatch(r);
		}

		[Test]
		public void TestDispatchOnException()
		{
			dispatcher = new ScriptsResponseDispatcher(new R(), new ScriptRepositoryStub(), "localhost");
			Response r = new Response(
				"",
				GeneratorConfiguration.Deserialize(new StringReader(@"<Configuration>
	                <Files>
		                <File Name='test.xml' Destination='C:\SSCAT\Scripts'/>
	                </Files>
	                <Scripts>
		                <Script/>
	                </Scripts>
                </Configuration>")));
			Assert.That(() => dispatcher.Dispatch(r),
                Throws.TypeOf<NotImplementedException>());
		}
		
		class R : ConfigFileRepositoryStub
		{
			public override void Create(Sscat.Core.Config.ConfigFile file)
			{
				throw new NotImplementedException();
			}
		}
	}
}
