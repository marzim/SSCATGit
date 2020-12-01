//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Commands;
using Ncr.Core.Views;
using Sscat.Core.Controllers;
using Sscat.Core.Util;
using Sscat.Core.Views;
using Sscat.Gui;

namespace Sscat.Commands
{
	public class ManageWldb : AbstractCommand
	{
		public override void Run()
		{
			IWldbController controller = new WldbController(new SscatSecurityManager(), new WldbManagerPane());
			IWldbManagerView wldbManagerView = controller.Manage() as IWldbManagerView;
			WorkbenchSingleton.ShowView(wldbManagerView);
		}
	}
}
