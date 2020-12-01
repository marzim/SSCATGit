//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kd185032@ncr.com"/>
//	</file>

using System;
using Ncr.Core;
using Ncr.Core.Controllers;
using Ncr.Core.Emulators;
using Ncr.Core.Models;
using Ncr.Core.Util;
using Ncr.Core.Views;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Core.Views;

namespace Sscat.Core.Controllers
{
	public interface ICustomGeneratorController : IController
	{
		IView Create();
	}
	
	public class CustomGeneratorController : ICustomGeneratorController
	{
		ICustomGeneratorView customGeneratorView;
		SscatLane lane;
		LaneService service;
		
		public CustomGeneratorController(ICustomGeneratorView customGeneratorView, SscatLane lane, LaneService service)
		{
			this.customGeneratorView = customGeneratorView;
			this.lane = lane;
			this.service = service;

			service.Servicing += new EventHandler<NcrEventArgs>(ServiceServicing);			
			customGeneratorView.CustomGenerate += new EventHandler<GeneratorConfigurationEventArgs>(CustomerGeneratorViewGenerating);
		}
		
		~CustomGeneratorController()
		{
			customGeneratorView.CustomGenerate -= new EventHandler<GeneratorConfigurationEventArgs>(CustomerGeneratorViewGenerating);			
		}
		
		public IView Create()
		{
			return customGeneratorView;
		}

		public void CustomerGeneratorViewGenerating(object sender, GeneratorConfigurationEventArgs e)
		{
//			Generate(e.Config.ScriptName, e.Config.ScriptDescription, e.Config.DiagPath, lane.ProductVersion, ApplicationUtility.ProductVersion, e.Config.SegmentedScripts, e.Config.ScriptOutputDirectory);
			Generate(e.Config.ScriptName, e.Config.ScriptDescription, e.Config.DiagPath, lane.ProductVersion, ApplicationUtility.ProductVersion, e.Config.SegmentedScripts, e.Config.ScriptOutputDirectory, e.Config.GenerateLast, e.Config.LastScriptsNumber);
		}
		
		public void Generate(string name, string description, string diagpath, string sscoBuild, string build, bool segmented, string scriptsOutputDirectory, bool generateLast, int lastScriptsNumber)
		{
			try {
				// FIXME: Why should we assign it here. There also a code like this in client woker's generate. Please check!
				lane.Configuration.Files.SourceDirectory = @"C:\scot\config";
				lane.Configuration.Files.DestinationDirectory = lane.Configuration.GeneratorConfiguration.ScotConfigOutputDirectory;
				lane.Configuration.GeneratorConfiguration.DiagPath = diagpath;
				
				lane.ConfigurationGet += new EventHandler<ConfigFilesEventArgs>(LaneConfigurationGet);
				lane.ParserInitialize += new EventHandler(LaneParserInitialize);
				lane.Parse += new EventHandler<ProgressEventArgs>(LaneParse);
				lane.Generating += new EventHandler<ProgressEventArgs>(LaneGenerating);
				lane.ValidateScriptname(name,scriptsOutputDirectory);
//				IScript[] scripts = lane.Generate(name, description, sscoBuild, build, segmented, scriptsOutputDirectory);
				IScript[] scripts = lane.Generate(name, description, sscoBuild, build, segmented, scriptsOutputDirectory, generateLast, lastScriptsNumber);
				service.SaveScripts(scripts);
				service.SaveConfigFiles(lane.Configuration.Files.Files);
			} catch (Exception ex){
				LoggingService.Info(ex.ToString());
				throw;
			} finally {
				lane.ConfigurationGet -= new EventHandler<ConfigFilesEventArgs>(LaneConfigurationGet);
				lane.ParserInitialize -= new EventHandler(LaneParserInitialize);
				lane.Parse -= new EventHandler<ProgressEventArgs>(LaneParse);
				lane.Generating -= new EventHandler<ProgressEventArgs>(LaneGenerating);
			}
		}

		void LaneConfigurationGet(object sender, ConfigFilesEventArgs e)
		{
			service.GetConfiguration(e.Files, e.ConfigName);
		}

		void LaneParse(object sender, ProgressEventArgs e)
		{
            customGeneratorView.WriteLine(string.Format("{0}: {1}", DateTimeUtility.Now(), e.Message));
            LoggingService.Info(string.Format("{0}: {1}", DateTimeUtility.Now(), e.Message));
		}

		void LaneGenerating(object sender, ProgressEventArgs e)
		{
            customGeneratorView.WriteLine(string.Format("{0}: {1}", DateTimeUtility.Now(), e.Message));
            LoggingService.Info(string.Format("{0}: {1}", DateTimeUtility.Now(), e.Message));
		}

		void LaneParserInitialize(object sender, EventArgs e)
		{
			lane.Parsers = service.CreateParsers();
		}
		
		void ServiceServicing(object sender, NcrEventArgs e)
		{
            customGeneratorView.WriteLine(string.Format("{0}: {1}", DateTimeUtility.Now(), e.Message));
            LoggingService.Info(string.Format("{0}: {1}", DateTimeUtility.Now(), e.Message));
		}		
	}
}
