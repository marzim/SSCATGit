//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	public class ApplicationStub : AbstractApplication
	{
		public ApplicationStub() : this("Qwerty")
		{
		}
		
		public ApplicationStub(string caption) : base(caption)
		{
		}
		
		public override string ProcessName {
			get { return "Qwerty"; }
		}
		
		public override string FileName {
			get { return @"C:\Projects\finger\trunk\tests\Qwerty.exe"; }
		}
	}
}
