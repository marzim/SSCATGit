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

using Sscat.Core.Config;
using Sscat.Core.Views;

namespace Sscat.Wpf.Gui
{
	public partial class ClientConfigurationPane : BaseUserControl, IClientConfigurationView
	{
		ClientConfiguration config;
		
		public ClientConfigurationPane()
		{
			InitializeComponent();
		}
		
		public event EventHandler<ClientConfigurationEventArgs> ConfigurationSave;
		
		public event EventHandler ConfigurationDefaultRestore;
		
		public event EventHandler<ClientConfigurationEventArgs> ConfigurationChanged;
		
		public ClientConfiguration Configuration {
			get {
				config.GeneratorConfiguration.ScriptOutputDirectory = textBoxOutputDirectory.Text;
				return config;
			}
			
			set {
				config = value;
				textBoxOutputDirectory.Text = config.GeneratorConfiguration.ScriptOutputDirectory;
			}
		}
		
		public void Save(ClientConfiguration config)
		{
			OnConfigurationSave(new ClientConfigurationEventArgs(config));
		}
		
		public void Restore()
		{
			OnConfigurationDefaultRestore(null);
		}
		
		public void Save()
		{
			throw new NotImplementedException();
		}
		
		protected virtual void OnConfigurationChanged(ClientConfigurationEventArgs e)
		{
			if (ConfigurationChanged != null) {
				ConfigurationChanged(this, e);
			}
		}
		
		protected virtual void OnConfigurationSave(ClientConfigurationEventArgs e)
		{
			if (ConfigurationSave != null) {
				ConfigurationSave(this, e);
			}
		}
		
		protected virtual void OnConfigurationDefaultRestore(EventArgs e)
		{
			if (ConfigurationDefaultRestore != null) {
				ConfigurationDefaultRestore(this, e);
			}
		}
		
		void ButtonOkClick(object sender, RoutedEventArgs e)
		{
			Save(Configuration);
		}
		
		void ButtonRestoreDefaultsClick(object sender, RoutedEventArgs e)
		{
			Restore();
		}
	}
}