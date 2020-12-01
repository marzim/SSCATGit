//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Net.Sockets;
using Ncr.Core.Net;
using NUnit.Framework;

namespace Ncr.Core.Tests.Net
{
	[TestFixture]
	public class NcrSocketListTests
	{
		NcrSocketList l;
		
		[SetUp]
		public void Setup()
		{
			l = new NcrSocketList();
		}
		
		[Test]
		public void TestAdd()
		{
		}
	}
}
