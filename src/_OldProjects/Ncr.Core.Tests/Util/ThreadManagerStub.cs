//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Threading;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	public class ThreadManagerStub : IThreadManager
	{
		public virtual void Sleep(int time)
		{
		}
		
		public virtual void Start(ThreadStart d)
		{
			d();
		}
	}
}
