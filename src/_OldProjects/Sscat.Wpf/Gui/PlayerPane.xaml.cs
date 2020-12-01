//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Sscat.Core;
using Sscat.Core.Emulators;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Views;

namespace Sscat.Wpf.Gui
{
	public partial class PlayerPane : BaseUserControl, IPlayerView
	{
		List<IScript> scripts;
		
		public PlayerPane()
		{
			InitializeComponent();
		}
		
		public event EventHandler<SscatLaneEventArgs> Playing;
		
		public event EventHandler Stopping;
		
		public event EventHandler Stop;
		
		public event EventHandler<SscatLaneEventArgs> Play;
		
		public List<IScript> Scripts {
			get { return scripts; }
			set { scripts = value; }
		}
		
		public FingerScript SelectedScript {
			get {
				throw new NotImplementedException();
			}
		}
		
		public List<ScriptFile> ScriptFiles {
			get {
				throw new NotImplementedException();
			}
		}
		
		public void PerformPlaying()
		{
			throw new NotImplementedException();
		}
		
		public void PerformDisable()
		{
			throw new NotImplementedException();
		}
		
		public void AddScript(IScript script)
		{
			throw new NotImplementedException();
		}
		
		public void UpdateEventResult(IScriptEvent e)
		{
			throw new NotImplementedException();
		}
		
		public void UpdateScriptResult(IScript s)
		{
			throw new NotImplementedException();
		}
		
		public void InitiateCache(ScriptEventArgs e)
		{
			throw new NotImplementedException();
		}
		
		public void ClearResults()
		{
			foreach (IScript s in scripts) {
				s.ClearResults();
			}
		}
		
		
		public void ClearView()
		{
			throw new NotImplementedException();
		}		
		
		public void Run()
		{
			throw new NotImplementedException();
		}
		
		public void PerformStopping()
		{
			throw new NotImplementedException();
		}
		
		public void ClearScripts()
		{
			throw new NotImplementedException();
		}
		
		public void PlaySelectedScripts()
		{
			throw new NotImplementedException();
		}
		
		public void AddScript(List<IScript> scripts)
		{
			throw new NotImplementedException();
		}
		
		public void Write(string text)
		{
			throw new NotImplementedException();
		}
		
		public void WriteLine(string text)
		{
			throw new NotImplementedException();
		}
		
		public void AddScript(List<string> scripts)
		{
			throw new NotImplementedException();
		}
		
		public void PerformPlay()
		{
			throw new NotImplementedException();
		}
		
		public void PerformStop()
		{
			throw new NotImplementedException();
		}
		
		public void SelectScript(ScriptFile script)
		{
			throw new NotImplementedException();
		}
		
		protected virtual void OnPlaying(SscatLaneEventArgs e)
		{
			if (Playing != null) {
				Playing(this, e);
			}
		}
		
		protected virtual void OnStopping(EventArgs e)
		{
			if (Stopping != null) {
				Stopping(this, e);
			}
		}
		
		protected virtual void OnStop(EventArgs e)
		{
			if (Stop != null) {
				Stop(this, e);
			}
		}
		
		protected virtual void OnPlay(SscatLaneEventArgs e)
		{
			if (Play != null) {
				Play(this, e);
			}
		}
	}
}