//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Repositories;

namespace Sscat.Tests.Config
{
	public class PlayerConfigurationRepositoryStub : IPlayerConfigurationRepository
	{
		public PlayerConfiguration Read(string filename)
		{
			return PlayerConfiguration.Deserialize(new StringReader(@"<Configuration
	PlaybackRepetition='1'
	SecurityServer='g2lane-ian'
	SimulateUserTime='true'
	LoadConfiguration='true'
	LogHookTimeout='60000'
	ReportFilePath=''
	ScreenshotPath=''
	DiagnosticPath=''
	LogFilesPath=''
	ScotConfigPath=''
	GetDiagsOnError='true'
	DisplayResultsAfterPlayback='true'
	CaptureScreenShot='true'
	RapName='g2rap-ian'
	OverrideRapName='true'>
	<Files
		Name='ConfigFiles'
		Destination='C:\SSCAT\ScotConfig'
		Source='C:\scot\config'>
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
		<File Name='ConfigEntity-AllLanesCommon.xml'/>
		<File Name='ConfigEntity-AllStoresCommon.xml'/>
		<File Name='ConfigEntity-DistributionController.xml'/>
		<File Name='ConfigEntity-EntityAssociation.xml'/>
		<File Name='ConfigEntity-ItemSecurityController.xml'/>
		<File Name='ConfigEntity-PersonalizationController.xml'/>
		<File Name='ConfigEntity-SystemCommon.xml'/>
	</Files>
	<MSRCards>
		<Card Name='Default' Track1='4921190001020103' Track2='0812101171750000000000767000000' Track3='12345678901234=06051010000087524397'/>
		<Card Name='WalmartMCXShoppingCard' Track1='B6010566912936155^WALMARTSHOPCARD^25010004000060013419' Track2='6010566912936155=25010004000060013419' Track3=''/>
		<Card Name='WalmartMCXMoneyCenterCard' Track1='B6032201000795248^REISSUE/TEST3^201270110000000001000169154107' Track2='6032201000795248=201270110000079' Track3=''/>
		<Card Name='WalmartMCXMoneyCenterCCPayment' Track1='B6011310002782537^PUBLIC/JOHN Q^1006101CBA812372459100234000009' Track2='6011310002782537=10061010000087524397' Track3='a960009686601131000278253700000000000001006101000000000000000000'/>
	</MSRCards>
	</Configuration>"));
		}
	}
}
