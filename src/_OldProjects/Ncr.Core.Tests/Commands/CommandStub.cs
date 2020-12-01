//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using System.Windows.Forms;
using Ncr.Core.Commands;
using Ncr.Core.Plugins;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Plugins
{
	public class CommandStub : AbstractCommand
	{
		public override void Run()
		{
			OnRunning("hello world");
		}
	}
}
