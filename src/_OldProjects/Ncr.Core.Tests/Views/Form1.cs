//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using Ncr.Core.Gui;
using Ncr.Core.Views;
using NUnit.Framework;

namespace Ncr.Core.Tests.Views
{
	public class Form1 : Form, IView
	{
		public event EventHandler TitleChanged;
		
		public event EventHandler ViewClose;
		
		public event EventHandler ViewShow;
		
		public void ShowView()
		{
			throw new NotImplementedException();
		}
		
		public void CloseView()
		{
			throw new NotImplementedException();
		}
		
		public void SetTitle(string title)
		{
			this.Text = title;
		}
		
		public string GetTitle()
		{
			return this.Text;
		}
		
		protected virtual void OnTitleChanged(EventArgs e)
		{
			if (TitleChanged != null) {
				TitleChanged(this, e);
			}
		}
		
		protected virtual void OnViewClose(EventArgs e)
		{
			if (ViewClose != null) {
				ViewClose(this, e);
			}
		}
		
		protected virtual void OnViewShow(EventArgs e)
		{
			if (ViewShow != null) {
				ViewShow(this, e);
			}
		}
		
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			Close();
		}
	}
}
