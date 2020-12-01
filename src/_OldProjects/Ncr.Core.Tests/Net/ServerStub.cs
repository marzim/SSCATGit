//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Net;
using NUnit.Framework;

namespace Ncr.Core.Tests.Net
{
	public class ServerEngineStub : AbstractServerEngine
	{
		public ServerEngineStub(IRequestParser requestParser) : base(requestParser)
		{
		}
		
		public override void Stop()
		{
			OnStopping(null);
		}
		
		public override void SendResponse(Response response)
		{
			OnDataSent(new NetworkEventArgs(response));
		}
		
		public override void Listen()
		{
		}
		
		public override void Dispose()
		{
		}
		
		protected override int GetClientIndex(string client)
		{
			throw new NotImplementedException();
		}
	}
}
