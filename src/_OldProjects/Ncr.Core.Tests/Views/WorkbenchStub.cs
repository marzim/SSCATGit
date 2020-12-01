//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using Ncr.Core.Views;
using NUnit.Framework;

namespace Ncr.Core.Tests.Views
{
	public class WorkbenchStub : Form, IWorkbench
	{
		IWorkbenchLayout layout;
		
		public WorkbenchStub()
		{
		}
		
		public event EventHandler<WorkbenchSettingsEventArgs> SettingsSave;
		
		public IWorkbenchLayout WorkbenchLayout {
			get { return layout; }
			set { layout = value; layout.Workbench = this; }
		}
		
		public WorkbenchSettings Settings {
			get {
				throw new NotImplementedException();
			}
			
			set {
				throw new NotImplementedException();
			}
		}
		
		public System.Windows.Forms.MenuStrip MainMenu {
			set {
			}
		}
		
		public System.Windows.Forms.Control ToolBar {
			set {
			}
		}
		
		public System.Windows.Forms.Control StatusBar {
			set {
			}
		}
		
		public virtual void ShowView(IView view)
		{
			layout.ShowView(view);
		}
		
		public virtual void SaveSettings(WorkbenchSettings setings)
		{
			throw new NotImplementedException();
		}
		
		protected virtual void OnSettingsSave(WorkbenchSettingsEventArgs e)
		{
			if (SettingsSave != null) {
				SettingsSave(this, e);
			}
		}
	}
}
