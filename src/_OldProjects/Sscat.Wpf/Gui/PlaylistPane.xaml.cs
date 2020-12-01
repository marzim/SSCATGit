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
using Sscat.Core.Models;
using Sscat.Core.Views;

namespace Sscat.Wpf.Gui
{
	public partial class PlaylistPane : BaseUserControl, IPlaylistView
	{
		Playlist playlist;
		
		public PlaylistPane()
		{
			InitializeComponent();
		}
		
		public event EventHandler<PlaylistEventArgs> PlaylistSave;
		
		public event EventHandler PlaylistLoad;
		
		public event EventHandler ScriptsLoad;
		
		public event EventHandler<PlaylistEventArgs> Playing;
		
		public event EventHandler<PlaylistEventArgs> PlayingOnServer;
		
		public event EventHandler Generating;
		
		public event EventHandler GeneratingOnServer;
		
		public event EventHandler Connecting;
		
		public Playlist Playlist {
			get { return playlist; }
			set { playlist = value; }
		}
		
		public string Title {
			get {
				throw new NotImplementedException();
			}
			
			set {
				throw new NotImplementedException();
			}
		}
		
		public void Connect()
		{
			throw new NotImplementedException();
		}
		
		public void Save()
		{
			throw new NotImplementedException();
		}
		
		public void Play()
		{
			throw new NotImplementedException();
		}
		
		public void Generate()
		{
			throw new NotImplementedException();
		}
		
		public void PlayOnServer()
		{
			throw new NotImplementedException();
		}
		
		public void GenerateOnServer()
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
		
		protected virtual void OnPlaylistSave(PlaylistEventArgs e)
		{
			if (PlaylistSave != null) {
				PlaylistSave(this, e);
			}
		}
		
		protected virtual void OnPlaylistLoad(EventArgs e)
		{
			if (PlaylistLoad != null) {
				PlaylistLoad(this, e);
			}
		}
		
		protected virtual void OnScriptsLoad(EventArgs e)
		{
			if (ScriptsLoad != null) {
				ScriptsLoad(this, e);
			}
		}
		
		protected virtual void OnPlaying(PlaylistEventArgs e)
		{
			if (Playing != null) {
				Playing(this, e);
			}
		}
		
		protected virtual void OnPlayingOnServer(PlaylistEventArgs e)
		{
			if (PlayingOnServer != null) {
				PlayingOnServer(this, e);
			}
		}
		
		protected virtual void OnGenerating(EventArgs e)
		{
			if (Generating != null) {
				Generating(this, e);
			}
		}
		
		protected virtual void OnGeneratingOnServer(EventArgs e)
		{
			if (GeneratingOnServer != null) {
				GeneratingOnServer(this, e);
			}
		}
		
		protected virtual void OnConnecting(EventArgs e)
		{
			if (Connecting != null) {
				Connecting(this, e);
			}
		}
	}
}