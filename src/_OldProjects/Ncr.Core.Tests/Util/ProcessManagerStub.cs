//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Diagnostics;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	public class ProcessManagerStub : IProcessManager
	{
		bool started;
		bool throwException;
		string output;
		
		public ProcessManagerStub() : this(false)
		{
		}
		
		public ProcessManagerStub(bool started) : this(started, false)
		{
		}
		
		public ProcessManagerStub(bool started, bool throwException) : this(started, throwException, "")
		{
		}
		
		public ProcessManagerStub(bool started, bool throwException, string output)
		{
			this.started = started;
			this.throwException = throwException;
			this.output = output;
		}
		
		public string GetStandardOutput(string filename, string arguments)
		{
			return output;
		}
		
		public bool CanPing(string hostname)
		{
			return hostname.Equals("localhost");
		}
		
		public int Start(string filename, string arguments, bool waitForExit)
		{
			return 0;
		}
		
		public void Start(ProcessStartInfo startInfo, bool waitForExit)
		{
			if (throwException) {
				throw new Exception();
			}
		}
		
		public void Start(string filename)
		{
			if (throwException) {
				throw new Exception();
			}
		}
		
		public void Start(string filename, bool waitForExit, int sleep)
		{
		}
		
		public bool HasStarted(string processName)
		{
			return started;
		}
		
		public bool HasStarted(string processName, bool includeMe)
		{
			return started;
		}
		
		public void Kill(string name, bool waitForExit)
		{
		}
		
		public void Start(string filename, string arguments, ProcessWindowStyle windowstyle, bool creatNoWindow)
		{
			if (throwException) {
				throw new Exception();
			}			
		}
		
		public Process GetCurrentProcess()
		{
			return Process.GetCurrentProcess();
		}
		
		public Process[] GetProcessesByName(string name)
		{
//			throw new NotImplementedException();
			return Process.GetProcessesByName(name);
		}
	}
}
