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
using Ncr.Core.Net;
using Ncr.Core.Views;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Net;
using Sscat.Core.Views;

namespace Sscat.Wpf.Gui
{
	public partial class ClientPane : BaseUserControl, IClientView
	{
		SscatClient client;
		List<IScript> scripts;
		
		public ClientPane()
		{
			InitializeComponent();
		}
		
		public event EventHandler ScriptsGenerate;
		
		public event EventHandler ScriptsPlay;
		
		public event EventHandler ReportsView;
		
		public event EventHandler ToolsView;
		
		public event EventHandler<SscatLaneEventArgs> Play;
		
		public event EventHandler<GeneratorConfigurationEventArgs> Generate;
		
		public event EventHandler<ClientConfigurationEventArgs> ConfigurationSave;
		
		public event EventHandler ConfigurationRestore;
		
		public event EventHandler Stopping;
		
		public event EventHandler Stop;
		
		public List<IScript> Scripts {
			get { return scripts; }
			set { scripts = value; }
		}
		
		public SscatClient Client {
			get { return client; }
			set { client = value; }
		}	
		
		public IOutputView OutputView {
			get {
				throw new NotImplementedException();
			}
		}
		
		public void PerformPlaying()
		{
		}
		
		public void PerformGenerating()
		{
		}		
		
		public void ClearResults()
		{
		}
		
		public void ClearView()
		{
		}
		
		public void AddToPanel(IView view)
		{
		}
		
		public void WriteLine(string text)
		{
		}
		
		public void SetText(string text)
		{
		}	
		
		public void PerformGenerate(GeneratorConfiguration config)
		{
			OnGenerating(new GeneratorConfigurationEventArgs(config));
		}
		
		public void StopPlaying()
		{
			throw new NotImplementedException();
		}
		
		public void StopGenerating()
		{
			throw new NotImplementedException();
		}
		
		public void PerformGenerate()
		{
			throw new NotImplementedException();
		}
		
		public void PerformStopping()
		{
			throw new NotImplementedException();
		}

		public void PerformDisable()
		{
			throw new NotImplementedException();
		}		
		
		public void GeneratingOrPlaying()
		{
			throw new NotImplementedException();
		}
		
		public void UpdateResult(IScriptEvent e)
		{
			throw new NotImplementedException();
		}
		
		public void UpdateResult(IScript s)
		{
			throw new NotImplementedException();
		}
		
		public void InitiateCache(ScriptEventArgs e)
		{
			throw new NotImplementedException();
		}
		
		public void SelectScript(ScriptFile script)
		{
			throw new NotImplementedException();
		}
		
//		protected virtual void OnGeneratorStop(EventArgs e)
//		{
//			if (GeneratorStop != null) {
//				GeneratorStop(this, e);
//			}
//		}
//		
		protected virtual void OnStop(EventArgs e)
		{
			if (Stop != null) {
				Stop(this, e);
			}
		}
		
		protected virtual void OnToolsView(EventArgs e)
		{
			if (ToolsView != null) {
				ToolsView(this, e);
			}
		}
		
		protected virtual void OnConfigurationSave(ClientConfigurationEventArgs e)
		{
			if (ConfigurationSave != null) {
				ConfigurationSave(this, e);
			}
		}
		
		protected virtual void OnConfigurationRestore(EventArgs e)
		{
			if (ConfigurationRestore != null) {
				ConfigurationRestore(this, e);
			}
		}
		
		protected virtual void OnReportsView(EventArgs e)
		{
			if (ReportsView != null) {
				ReportsView(this, e);
			}
		}
		
		protected virtual void OnScriptsPlay(EventArgs e)
		{
			if (ScriptsPlay != null) {
				ScriptsPlay(this, e);
			}
		}
		
		protected virtual void OnScriptsGenerate(EventArgs e)
		{
			if (ScriptsGenerate != null) {
				ScriptsGenerate(this, e);
			}
		}
		
		protected virtual void OnPlay(SscatLaneEventArgs e)
		{
			if (Play != null) {
				Play(this, e);
			}
		}
		
		protected virtual void OnGenerating(GeneratorConfigurationEventArgs e)
		{
			if (Generate != null) {
				Generate(this, e);
			}
		}
		
		protected virtual void OnStopping(EventArgs e)
		{
			if (Stopping != null) {
				Stopping(this, e);
			}
		}
		
		void ButtonGenerateScriptsClick(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}
		
		void ButtonPlayScriptsClick(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}
		
		void ButtonUpdateConfigurationClick(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}