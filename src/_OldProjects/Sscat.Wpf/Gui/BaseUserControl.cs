//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Controls;
using Ncr.Core.Views;
using Sscat.Core.Views;

namespace Sscat.Wpf.Gui
{
	public class BaseUserControl : UserControl, IView
	{
		public BaseUserControl()
		{
		}
		
		public event EventHandler ViewClose;
		
		public event EventHandler TitleChanged;
		
		public event EventHandler ViewShow;
		
		public void SetTitle(string title)
		{
			this.Content = title;
		}
		
		public string GetTitle()
		{
			return this.Content.ToString();
		}
		
		public void CloseView()
		{
			OnViewClose(null);
		}
		
		public void ShowView()
		{
			OnViewShow(null);
		}
		
		protected virtual void OnViewClose(EventArgs e)
		{
			if (ViewClose != null) {
				ViewClose(this, e);
			}
		}
		
		protected virtual void OnTitleChanged(EventArgs e)
		{
			if (TitleChanged != null) {
				TitleChanged(this, e);
			}
		}
		
		protected virtual void OnViewShow(EventArgs e)
		{
			if (ViewShow != null) {
				ViewShow(this, e);
			}
		}
	}
}
