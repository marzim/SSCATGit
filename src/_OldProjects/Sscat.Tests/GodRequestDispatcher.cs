//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Commands;
using Ncr.Core.Emulators;
using Ncr.Core.Models;
using Ncr.Core.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Net;
using Sscat.Server;
using Sscat.Tests.Net;

namespace Sscat.Tests
{
	public class GodRequestDispatcher : SscatRequestDispatcher
	{
		public GodRequestDispatcher() : base("GOD")
		{
		}
		
		public override void Dispatch(Request request)
		{
			OnParserInitialize(null);
			OnLogHookInitialize(null);
			OnClientInitialize(null);
		}
	}
}
