//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Net
{
	public class ClientEngineStub : AbstractClientEngine
	{
		public ClientEngineStub()
		{
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
		
		public void PerformConnectionRejected()
		{
			OnConnectionRejecting(null);
			OnConnectionRejected(null);
		}
		
		public void PerformConnectionTimeout()
		{
			OnConnectionTimeOut();
		}
	}
}
