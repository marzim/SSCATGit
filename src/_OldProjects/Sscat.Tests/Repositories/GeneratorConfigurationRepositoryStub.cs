//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Config;
using Sscat.Core.Repositories;

namespace Sscat.Tests.Config
{
	public class GeneratorConfigurationRepositoryStub : IGeneratorConfigurationRepository
	{
		public GeneratorConfiguration Read(string filename)
		{
			return GeneratorConfiguration.Deserialize(new StringReader(@"<Configuration
	ScriptName=''
	ScriptDescription=''
	ScriptOutputDirectory='C:\SSCAT\Scripts'
	SegmentedScripts='true'
	DontShowMSCardEditor='false'
	DefaultMSCard=''
	LogsOutputDirectory='C:\SSCAT\logs'
	RootDirectory='C:\SSCAT'>
	<Files
		Name='ConfigFiles'
		Destination='C:\SSCAT\Scot\ScotConfig'
		Source='C:\sscat'>
		<File Name='AssistMenuConfig.xml'/>
		<File Name='RCMConfig.000'/>
		<File Name='RCMConfig.xml'/>
		<File Name='Scotopts.000'/>
		<File Name='Scotopts.001'/>
		<File Name='Scotopts.002'/>
		<File Name='Scotopts.dat'/>
		<File Name='ScotTare.dat'/>
		<File Name='Scottend.000'/>
		<File Name='Scottend.dat'/>
		<File Name='SecurityConfig.000'/>
		<File Name='SecurityConfig.xml'/>
		<File Name='ConfigEntity-AllLanesCommon.xml' Host='g2lane-ian'/>
		<File Name='ConfigEntity-AllStoresCommon.xml'/>
		<File Name='ConfigEntity-DistributionController.xml'/>
		<File Name='ConfigEntity-EntityAssociation.xml'/>
		<File Name='ConfigEntity-ItemSecurityController.xml'/>
		<File Name='ConfigEntity-PersonalizationController.xml'/>
		<File Name='ConfigEntity-SystemCommon.xml'/>
	</Files>
	<Scripts/>
	</Configuration>"));
		}
	}
}
