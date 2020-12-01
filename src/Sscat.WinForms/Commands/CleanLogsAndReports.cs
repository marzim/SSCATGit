//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Commands;
using Ncr.Core.Emulators;
using Ncr.Core.Views;
using Sscat.Core.Views;
using Sscat.Gui;

namespace Sscat.Commands
{
	public class CleanLogsAndReports : AbstractCommand
	{
		ICleanFilesView view;
		
		public CleanLogsAndReports() : this(new CleanFilesForm(new Lane()))
		{
		}
		
		public CleanLogsAndReports(ICleanFilesView view)
		{
			this.view = view;
		}
		
		public override void Run()
		{
			WorkbenchSingleton.ShowDialog(view);
		}
	}
}
