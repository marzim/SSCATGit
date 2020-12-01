//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Net;
using Ncr.Core.Net;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	public class DnsManagerStub : IDnsManager
	{
		public bool HasHost(string host)
		{
			return host != null && host != "" && !host.Equals("localhost");
		}
		
		public string GetIPAddress(string host)
		{
			return host.Equals("localhost") ? "127.0.0.1" : "192.168.0.1";
		}
		
		public string GetLocalIPAddress()
		{
			return GetIPAddress("localhost");
		}
		
		public virtual bool ValidHostName(string host)
		{
			return host.Equals("localhost");
		}
		
		public IPHostEntry GetHostByName(string hostName)
		{
			return Dns.GetHostEntry(hostName);
		}
		
		public string GetHostName()
		{
//			return Dns.GetHostName();
			return "holy-cow";
		}
	}
}
