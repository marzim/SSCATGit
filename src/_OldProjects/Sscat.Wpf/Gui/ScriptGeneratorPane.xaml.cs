//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Sscat.Core;
using Sscat.Core.Config;
using Sscat.Core.Models;
using Sscat.Core.Views;

namespace Sscat.Wpf.Gui
{
	public partial class ScriptGeneratorPane : BaseUserControl, IGeneratorView
	{
		string title;
		IOutputView outputView;
		GeneratorConfiguration config;
		
		public ScriptGeneratorPane()
		{
			InitializeComponent();
		}
		
		public event EventHandler Stopping;
		
		public event EventHandler<GeneratorConfigurationEventArgs> Generate;
		
		public event EventHandler Stop;
		
		public GeneratorConfiguration Configuration {
			get {
				config.ScriptOutputDirectory = textBoxOutputDirectory.Text;
				config.LogsOutputDirectory = textBoxLogsDirectory.Text;
				return config;
			}
			
			set {
				config = value;
				textBoxOutputDirectory.Text = config.ScriptOutputDirectory;
				textBoxLogsDirectory.Text = config.LogsOutputDirectory;
			}
		}
		
		public IOutputView OutputView {
			get { return outputView; }
			set { outputView = value; }
		}
		
		public string Title {
			get { return title; }
			set { title = value; OnTitleChanged(null); }
		}
		
		public void PerformStop()
		{
//			OnStopping(null);
			OnStop(null);
		}
		
		public void PerformStopping()
		{
			OnStopping(null);
		}
		
		public void PerformGenerating()
		{
			OnGenerating(new GeneratorConfigurationEventArgs(this.config));
		}
		
		public void WriteLine(string text)
		{
			outputView.WriteLine(text);
		}
		
		public void Write(string text)
		{
			outputView.Write(text);
		}
		
		public void PerformGenerate(GeneratorConfiguration config)
		{
			OnGenerating(new GeneratorConfigurationEventArgs(config));
		}
		
		public void PerformGenerate()
		{
			throw new NotImplementedException();
		}
		
		public void PerformDisable()
		{
			throw new NotImplementedException();
		}				
		
		protected virtual void OnStop(EventArgs e)
		{
			if (Stop != null) {
				Stop(this, e);
			}
		}
		
		protected virtual void OnStopping(EventArgs e)
		{
			if (Stopping != null) {
				Stopping(this, e);
			}
		}
		
		protected virtual void OnGenerating(GeneratorConfigurationEventArgs e)
		{
			if (Generate != null) {
				Generate(this, e);
			}
		}
		
		void ButtonGenerateScriptsClick(object sender, RoutedEventArgs e)
		{
			PerformGenerate(Configuration);
		}
	}
}