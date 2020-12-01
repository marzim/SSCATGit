//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Input;
using Sscat.Wpf.Commands;

namespace Sscat.Wpf
{
	public static class AppCommands
	{
		public static ICommand TestCommand {
			get { return new TestCommand(); }
		}
	}
}
