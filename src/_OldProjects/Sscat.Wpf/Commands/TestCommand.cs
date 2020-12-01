//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows;
using System.Windows.Input;

namespace Sscat.Wpf.Commands
{
	public class TestCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;
		
		public void Execute(object parameter)
		{
			MessageBox.Show("lalala");
		}
		
		public bool CanExecute(object parameter)
		{
			OnCanExecuteChanged(null);
			return true;
		}
		
		protected virtual void OnCanExecuteChanged(EventArgs e)
		{
			if (CanExecuteChanged != null) {
				CanExecuteChanged(this, e);
			}
		}
	}
}
