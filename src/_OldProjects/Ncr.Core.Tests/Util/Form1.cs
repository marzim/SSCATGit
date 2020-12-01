//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ncr.Core.Tests.Util
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		
		public Button ClickMeButton {
			get { return button1; }
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			button1.Text = "You clicked!";
		}
	}
}
