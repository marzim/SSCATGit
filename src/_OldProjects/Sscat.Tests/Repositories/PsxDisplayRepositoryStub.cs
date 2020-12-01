//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Emulators;
using Ncr.Core.Plugins;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands.LaunchPadPsx;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Repositories;
using Sscat.Core.Services;

namespace Sscat.Tests.Commands.Psx
{
	public class PsxDisplayRepositoryStub : BaseRepository, IPsxDisplayRepository
	{
		public PsxDisplay Load(string context)
		{
			return PsxDisplay.Deserialize(new StringReader(@"<Display Version=""1.0"" Position=""0,0,1024,768"" Language=""0409"">
	<Controls>
		<Control Name='Display'>
			<Properties>
				<Property Name='Position'>531,490,440,57</Property>
			</Properties>
		</Control>
		<Control Name='KeyBoardP1'>
			<Properties>
				<Property Name='Position'>531,490,440,57</Property>
			</Properties>
		</Control>
	</Controls>
	</Display>"));
		}
		
		public PsxDisplay Read(string file)
		{
			return PsxDisplay.Deserialize(new StringReader(@"<Display Version=""1.0"" Position=""0,0,1024,768"" Language=""0409"">
	<Controls>
    <Control Name='NumericP1' Type='ButtonList' Synchronize='False'>
      <Properties>
        <Property Name='Position'>274,190,286,283</Property>
        <Property Name='ButtonHorizontalSpacing'>11</Property>
        <Property Name='ButtonVerticalSpacing'>8</Property>
        <Property Name='ButtonHeight'>89</Property>
        <Property Name='ButtonWidth'>88</Property>
        <Property Name='Audio'>%AudioPath%\BttnValid.wav</Property>
        <Property Name='Font'>CMButtonFont</Property>
        <Property Name='TextColor'>CMButtonTextColor</Property>
        <Property Name='Picture'>%MediaPath%\10x7_Btn_AlphaNumKey.png</Property>
        <Property Name='Z-Order'>1</Property>
        <Property Name='ClickMove'>2</Property>
      </Properties>
      <List>
        <Button>1,-,97</Button>
        <Button>2,-,98</Button>
        <Button>3,-,99</Button>
        <Button>4,-,100</Button>
        <Button>5,-,101</Button>
        <Button>6,-,102</Button>
        <Button>7,-,103</Button>
        <Button>8,-,104</Button>
        <Button>9,-,105</Button>
      </List>
    </Control>
	</Controls>
	</Display>"));
		}
	}
	
	public class PluginRepositoryStub : BaseRepository, IPluginRepository
	{
		public Plugin Load(string file)
		{
			return Plugin.Deserialize(new StringReader(@"<Plugin Name='Server Workbench Plugin' Description=''>
	<MainMenu>
		<Menu Text='File'>
			<Menu Text='Exit' Command='Ncr.Core.Commands.ExitCommand, Ncr.Core' />
		</Menu>
	</MainMenu>
	<StatusBar>
		<StatusBarLabel Text='Ready' />
	</StatusBar>
</Plugin>"));
		}
	}
}
