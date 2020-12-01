//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Repositories;
using Sscat.Core.Repositories.Xml;

namespace Sscat.Tests.Repositories
{
	[TestFixture]
	public class XmlClientConfigurationRepositoryTests
	{
		XmlClientConfigurationRepository d;
		ClientConfiguration c;
		string f = @"C:\Projects\finger\trunk\tests\test.xml";
		string f1 = @"C:\Projects\finger\trunk\tests\test2.xml";
		
		[SetUp]
		public void Setup()
		{
			FileHelper.Attach(new FileManager());
			
			c = new ClientConfiguration();
			c.FileName = f;
			
			FileHelper.Create(f, c.Serialize());
			d = new XmlClientConfigurationRepository();
		}
		
		[TearDown]
		public void Teardown()
		{
			FileHelper.Delete(f);
		}
		
		[Test]
		public void TestRead()
		{
			ClientConfiguration c = d.Read(f);
			Assert.AreEqual(f, c.FileName);
		}		
		
		[Test]
		public void TestReadWithOverwrite()
		{
			ClientConfiguration c = d.Read(f, f1);
			Assert.AreEqual(f1, c.FileName);
		}
		
		[Test]
		public void TestSave()
		{
			d.Save(c);
		}
	}
	
	public class ClientConfigurationRepositoryStub : BaseRepository, IClientConfigurationRepository
	{
		public void Save(ClientConfiguration config)
		{
			OnAccessing(new NcrEventArgs("Saving config file..."));
		}
		
		public ClientConfiguration Read(string file)
		{
			return Read(file, "");
		}
		
		public ClientConfiguration Read(string file, string fileNameToOVerwrite)
		{
			return ClientConfiguration.Deserialize(new StringReader(@"<Configuration>
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
	<ScriptGenerator
		ScriptOutputDirectory='C:\SSCAT\Scripts'
		SegmentedScripts='true'
		LogsOutputDirectory='C:\SSCAT\Logs'
		RootDirectory='C:\SSCAT'
		ScotConfigOutputDirectory='C:\SSCAT\ScotConfig'>
	</ScriptGenerator>
	<Player
		LogHookTimeout='60000'
		OverrideRapName='true'
		RapName='localhost'
		CaptureScreenShot='false'
		DisplayResultsAfterPlayback='false'
		GetDiagsOnError='false'
		AutoGetDiagsAfterPlayback='false'
		UserInterventionOnErro='false'
		PlayerConfigFile='C:\SSCAT\Config'
		ScotConfigPath='C:\SSCAT\ScotConfig'
		LogFilesPath='C:\SSCAT\Logs'
		ReportFilePath='C:\SSCAT\Reports'
		LoadConfiguration='true'
		PlaybackRepetition='1'
		StartContext='Attract'
		LoginId='97'
		Password='97'>
		<MSRCards>
			<Card Name='Default' Track1='4921190001020103' Track2='0812101171750000000000767000000' Track3='12345678901234=06051010000087524397'/>
			<Card Name='93' Track1='4921190001020103' Track2='0812101171750000000000767000000' Track3='12345678901234=06051010000087524397'/>
			<Card Name='198' Track1='4921190001020103' Track2='0812101171750000000000767000000' Track3='12345678901234=06051010000087524397'/>
			<Card Name='102' Track1='4921190001020103' Track2='0812101171750000000000767000000' Track3='12345678901234=06051010000087524397'/>
			<Card Name='WalmartMCXShoppingCard' Track1='B6010566912936627^WALMARTSHOPCARD^25010004000060014670' Track2='6010566912936627=25010004000060014670' Track3=''/>
			<Card Name='WalmartMCXMoneyCenterCard' Track1='B5448560000001224^GORDON JAMES^1106101000000000000000419000000' Track2='5448560000001224=11061010000000419000' Track3='' />
			<Card Name='WalmartMCXMoneyCenterCCPayment' Track1='B6011310002782537^PUBLIC/JOHN Q^1006101CBA812372459100234000009' Track2='6011310002782537=10061010000087524397' Track3='a960009686601131000278253700000000000001006101000000000000000000' />
			<Card Name='WalmartMCXPhoneCard' Track1='AT20300030000004870467' Track2='' Track3='' />
			<Card Name='WalmartMCXOtherPrepaid' Track1='IC3^00000020^000000000000001716589381^' Track2='' Track3='' />
			<Card Name='WalmartMCXMoneyTranser' Track1='B7600000400009006^PRUEBA BENTONVILLE DUMMY^101218700000' Track2='7600000400009006=10121870000000000' Track3='' />
			<Card Name='WalmartMCXDebitCard' Track1='' Track2='7600000400009006=10121870000000000' Track3='' />
			<Card Name='WalmartMCXBluebirdBuy' Track1='IC3^00000000^000000000000003147978348^0840' Track2='' Track3='' />
			<Card Name='WalmartMCXBluebirdAddMoney' Track1='B379019083478852^MATHI/INDHU^1702122120210240' Track2='379019083478852=170212212021024000000' Track3='' />
			<Card Name='TescoDebitCard' Track1='B4539785000002517^PUBLIC/JOHN Q^1312101CBA812372459100234000009' Track2='4539785000002517=13121010000087524397' Track3='a960009686453978500000251700000000000001312101000000000000000000' />
			<Card Name='TescoCreditCard' Track1='B4627851909738776^PUBLIC/JOHN Q^1312101CBA812372459100234000009' Track2='4627851909738776=13121010000087524397' Track3='a960009686462785190973877600000000000001312101000000000000000000' />
			<Card Name='TescoStaffDiscountCard' Track1='B634002400016244127^PUBLIC/JOHN Q^1311101CBA812372459100234000009' Track2='634002400016244127=13111010000087524397' Track3='a96000968663400240001624412700000000000001311101000000000000000000' />
			<Card Name='TescoClubCard' Track1='B634004000039308673^PUBLIC/JOHN Q^1312101CBA812372459100234000009' Track2='634004000039308673=13121010000087524397' Track3='a96000968663400400003930867300000000000001312101000000000000000000' />
			<Card Name='TescoInvalidCard' Track1='' Track2='63400320805084387=1412===20010======' Track3='' />
			<Card Name='BootsUKAdvantageCard' Track1='' Track2='6330356000000042601=99121220008260000' Track3=''/>
			<Card Name='BootsUKStaffDiscountCard' Track1='63303000109328619=1309000000000000000' Track2='' Track3=''/>
			<Card Name='BootsUKGiftCard' Track1='' Track2='63303057807000817=0000' Track3=''/>
			<Card Name='BootsUKMasterCard' Track1='B5111370000000002^FDMS*TEST*CARD^150410123456789' Track2='5111370000000002=150410123456789' Track3='12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234'/>
			<Card Name='BootsUKTMobileTopUpCard' Track1='B8944304300243405048^X^1208' Track2='8944304300243405048=1208' Track3=''/>
		</MSRCards>
	</Player>
	</Configuration>"));
		}
	}
}
