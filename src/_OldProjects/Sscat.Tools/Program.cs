//	<file>
//		<license></license>
//		<owner name="Marvin Casagnap" email="marvin.casagnap@ncr.com"/>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using Sscat.Core.Gui;

namespace Sscat.Tools
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
//			Application.Run(new MainForm());
			Application.Run(new OptionsForm());
		}
	}
}
