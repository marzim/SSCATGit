//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.PsxNet
{
	[TestFixture]
	public class PsxDisplayTests
	{
		PsxDisplay display;
		
		[SetUp]
		public void Setup()
		{
			display = PsxDisplay.Deserialize(new StringReader(@"<Display Version=""1.0"" Position=""0,0,1024,768"" Language=""0409"">
	<Includes>
		<!-- INCLUDE XML HERE -->
		<Include File='%ConfigPath%\SharedFontsAndControls.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg0409.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg0809.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg080a.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg0c0c.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg0407.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg0413.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg040c.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg0410.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg0c0a.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg0c09.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg1409.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg0411.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg0412.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg0415.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg041d.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg041f.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg040b.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg0406.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg0427.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg1809.xml'/>
		<Include File='%ConfigPath%\LaunchPadMsg0452.xml'/>
	</Includes>
	<Fonts>
		<Font Name='LaunchPadFont'>
			<Face>Arial</Face>
			<Size>14</Size>
			<Bold>True</Bold>
			<Italic>False</Italic>
		</Font>
	</Fonts>
	<Controls>
		<Control Name='MinMaxFastLaneButton' Type='Button'>
			<Properties>
				<Property Name='Position'>531,490,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>MinMaxFastLaneBtnPrimaryTxt</Data>
				<Data Name='SecondaryText'>MinMaxFastLaneBtnSecondaryTxt</Data>
				<Data Name='PrimaryShowConfirmation'>false</Data>
				<Data Name='SecondaryShowConfirmation'>false</Data>
				<Data Name='PrimaryFunction'>Minimize</Data>
				<Data Name='SecondaryFunction'>Maximize</Data>
				<Data Name='PrimaryRequiredSecurity'>false</Data>
				<Data Name='SecondaryRequiredSecurity'>false</Data>
				<Data Name='ToggleStateOnDeadMainExecutable'>Primary</Data>
				<Data Name='DisabledOnDeadEnabledOnAliveMainExecutable'>true</Data>
				<Data Name='ToggleEnabled'>True</Data>
				<Data Name='ExecutableName'>FastLane</Data>
			</CustomData>
		</Control>
		<Control Name='StopStartFastLaneButton' Type='Button'>
			<Properties>
				<Property Name='Position'>531,490,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>StopStartFastLaneBtnPrimaryTxt</Data>
				<Data Name='SecondaryText'>StopStartFastLaneBtnSecondaryTxt</Data>
				<Data Name='PrimaryAllowToggleOnButton'>ExitFastLaneAndRunProfileButton</Data>
				<Data Name='SecondaryAllowToggleOnButton'>ExitFastLaneAndRunProfileButton</Data>
				<Data Name='PrimaryAllowToggleOnButtonState'>0</Data>
				<Data Name='SecondaryAllowToggleOnButtonState'>1</Data>
				<Data Name='PrimaryFunction'>Stop</Data>
				<Data Name='SecondaryFunction'>Start</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>StopFastLaneConfirm</Data>
				<Data Name='SecondaryShowConfirmation'>true</Data>
				<Data Name='SecondaryShowConfirmationMessage'>StartFastLaneConfirm</Data>
				<Data Name='ToggleStateOnAliveMainExecutable'>Primary</Data>
				<Data Name='ToggleStateOnDeadMainExecutable'>Secondary</Data>
				<Data Name='ToggleEnabled'>True</Data>
				<Data Name='ExecutableName'>FastLane</Data>
			</CustomData>
		</Control>
		<Control Name='CommandPromptButton' Type='Button'>
			<Properties>
				<Property Name='Position'>531,420,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='WindowsSignOn'>true</Data>
				<Data Name='PrimaryText'>CommandPromptPrimaryTxt</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='ExecutableName'>CommandPrompt</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>CommandPromptConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='SwitchToRAPButton' Type='Button'>
			<Properties>
				<Property Name='Position'>50,270,440,57</Property>
				<Property Name='TextPosition'>10,10,300,80</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>SwitchToRAPBtnPrimaryTxt</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='PrimaryFunction'>SwitchTo</Data>
			</CustomData>
		</Control>
		<Control Name='ShutdownSystemButton' Type='Button'>
			<Properties>
				<Property Name='Position'>41,490,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>ShutdownSystemBtnPrimaryTxt</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='ExecutableName'>Shutdown</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>ShutdownConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='RebootSystemButton' Type='Button'>
			<Properties>
				<Property Name='Position'>41,560,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='State'>0</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>RebootSystemBtnPrimaryTxt</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='ExecutableName'>Reboot</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>RebootConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='VolumeButton' Type='Button'>
			<Properties>
				<Property Name='Position'>531,140,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>VolumeBtnPrimaryTxt</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='ExecutableName'>Volume</Data>
			</CustomData>
		</Control>
		<Control Name='EventViewerButton' Type='Button'>
			<Properties>
				<Property Name='Position'>41,280,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>EventViewerBtnPrimaryTxt</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='ExecutableName'>EventViewer</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>EventViewerConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='TouchWareButton' Type='Button'>
			<Properties>
				<Property Name='Position'>41,350,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>TouchWareTxt</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='ExecutableName'>TouchWare</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>CalibrateConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='GenerateLogButton' Type='Button'>
			<Properties>
				<Property Name='Position'>41,140,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>GenerateLogBtnPrimaryTxt</Data>
				<Data Name='ExecutableName'>GenerateLog</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>DiagConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='ExitFastLaneAndRunProfileButton' Type='Button'>
			<Properties>
				<Property Name='Position'>41,210,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>ExitFastLaneAndRunProfileBtnPrimaryTxt</Data>
				<Data Name='SecondaryText'>ExitFastLaneAndRunProfileBtnSecondaryTxt</Data>
				<Data Name='PrimaryAllowToggleOnButton'>StopStartFastLaneButton</Data>
				<Data Name='SecondaryAllowToggleOnButton'>StopStartFastLaneButton</Data>
				<Data Name='PrimaryAllowToggleOnButtonState'>0</Data>
				<Data Name='SecondaryAllowToggleOnButtonState'>1</Data>
				<Data Name='ToggleStateOnAliveMainExecutable'>Primary</Data>
				<Data Name='ToggleStateOnDeadMainExecutable'>Secondary</Data>
				<Data Name='ToggleEnabled'>true</Data>
				<Data Name='ExecutableName'>ExitFastLaneAndRunProfile</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>ProfileManagerFLConfirm</Data>
				<Data Name='SecondaryShowConfirmation'>true</Data>
				<Data Name='SecondaryShowConfirmationMessage'>ProfileManagerConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='TerminalInfoButton' Type='Button'>
			<Properties>
				<Property Name='Position'>531,210,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>TerminalInfoBtnPrimaryTxt</Data>
				<Data Name='ExecutableName'>TerminalInfo</Data>
			</CustomData>
		</Control>
		<Control Name='MinMaxRAPButton' Type='Button'>
			<Properties>
				<Property Name='Position'>531,490,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>MinMaxRAPBtnPrimaryTxt</Data>
				<Data Name='SecondaryText'>MinMaxRAPBtnSecondaryTxt</Data>
				<Data Name='PrimaryShowConfirmation'>false</Data>
				<Data Name='SecondaryShowConfirmation'>false</Data>
				<Data Name='PrimaryFunction'>Minimize</Data>
				<Data Name='SecondaryFunction'>Maximize</Data>
				<Data Name='ToggleStateOnDeadMainExecutable'>Primary</Data>
				<Data Name='DisabledOnDeadEnabledOnAliveMainExecutable'>true</Data>
				<Data Name='ToggleEnabled'>True</Data>
				<Data Name='ExecutableName'>RAP</Data>
			</CustomData>
		</Control>
		<Control Name='WindowsLogOnButton' Type='Button'>
			<Properties>
				<Property Name='Position'>41,420,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='WindowsSignOn'>true</Data>
				<Data Name='PrimaryText'>WindowsLogOnTxt</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='PrimaryFunction'>WindowsLogOn</Data>
				<Data Name='ExecutableName'>FastLane</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>WindowsLogOnConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='ExitAllRAPButton' Type='Button'>
			<Properties>
				<Property Name='Position'>531,560,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='MaintenanceSignOn'>false</Data>
				<Data Name='PrimaryText'>Exit</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='PrimaryFunction'>StopAll</Data>
				<Data Name='ExecutableName'>RAP</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>CloseAllConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='ExitAllFastLaneButton' Type='Button'>
			<Properties>
				<Property Name='Position'>531,560,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='MaintenanceSignOn'>false</Data>
				<Data Name='PrimaryText'>Exit</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='PrimaryFunction'>StopAll</Data>
				<Data Name='ExecutableName'>FastLane</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>CloseAllConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='RSMLEButton' Type='Button'>
			<Properties>
				<Property Name='Position'>531,560,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>RSMLEPrimaryTxt</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='ExecutableName'>RSMLE</Data>
				<Data Name='PrimaryShowConfirmation'>false</Data>
				<Data Name='PrimaryShowConfirmationMessage'>RSMLEConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='StopStartRAPButton' Type='Button'>
			<Properties>
				<Property Name='Position'>531,490,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>StopStartRAPButtonPrimaryTxt</Data>
				<Data Name='SecondaryText'>StopStartRAPButtonSecondaryTxt</Data>
				<Data Name='PrimaryFunction'>Stop</Data>
				<Data Name='SecondaryFunction'>Start</Data>
				<Data Name='ToggleStateOnAliveMainExecutable'>Primary</Data>
				<Data Name='ToggleStateOnDeadMainExecutable'>Secondary</Data>
				<Data Name='ToggleEnabled'>True</Data>
				<Data Name='ExecutableName'>RAP</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>StopRAPConfirm</Data>
				<Data Name='SecondaryShowConfirmation'>true</Data>
				<Data Name='SecondaryShowConfirmationMessage'>StartRAPConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='SwitchToFastLaneButton' Type='Button'>
			<Properties>
				<Property Name='Position'>50,270,440,57</Property>
				<Property Name='TextPosition'>10,10,300,80</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>SwitchToFastLaneBtnPrimaryTxt</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='PrimaryFunction'>SwitchTo</Data>
			</CustomData>
		</Control>
		<Control Name='ExitRAPAndRunProfileButton' Type='Button'>
			<Properties>
				<Property Name='Position'>41,210,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,7,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>ExitRAPAndRunProfileBtnPrimaryTxt</Data>
				<Data Name='SecondaryText'>ExitRAPAndRunProfileBtnSecondaryTxt</Data>
				<Data Name='PrimaryAllowToggleOnButton'>StopStartRAPButton</Data>
				<Data Name='SecondaryAllowToggleOnButton'>StopStartRAPButton</Data>
				<Data Name='PrimaryAllowToggleOnButtonState'>0</Data>
				<Data Name='SecondaryAllowToggleOnButtonState'>1</Data>
				<Data Name='ToggleStateOnAliveMainExecutable'>Primary</Data>
				<Data Name='ToggleStateOnDeadMainExecutable'>Secondary</Data>
				<Data Name='ToggleEnabled'>true</Data>
				<Data Name='ExecutableName'>ExitRAPAndRunProfile</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>ProfileManagerRAPConfirm</Data>
				<Data Name='SecondaryShowConfirmation'>true</Data>
				<Data Name='SecondaryShowConfirmationMessage'>ProfileManagerConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='TrainingProgramButton' Type='Button'>
			<Properties>
				<Property Name='Position'>531,350,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>TrainingProgramPrimaryTxt</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='ExecutableName'>TrainingProgram</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>TrainingConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='PickListEditorButton' Type='Button'>
			<Properties>
				<Property Name='Position'>531,280,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>PickListEditor</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='ExecutableName'>PickListEditor</Data>
				<Data Name='PrimaryShowConfirmation'>true</Data>
				<Data Name='PrimaryShowConfirmationMessage'>PicklistConfirm</Data>
			</CustomData>
		</Control>
		<Control Name='MessageStatic' Type='Static'>
			<Properties>
				<Property Name='Position'>0,132,1024,564</Property>
				<Property Name='Font'>LeadthruFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='Z-Order'>2</Property>
			</Properties>
		</Control>
		<Control Name='CancelButton' Type='Button'>
			<Properties>
				<Property Name='Position'>360,552,250,78</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextFormat'>$CancelButtonText$</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_keypadLogon-med.png</Property>
				<Property Name='ClickMove'>2</Property>
				<Property Name='Z-Order'>3</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>$CancelButtonText$</Data>
			</CustomData>
		</Control>
		<Control Name='SignOnButton' Type='Button'>
			<Properties>
				<Property Name='Position'>636,696,179,71</Property>
				<Property Name='Font'>MainButtonFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='Audio'>%AudioPath%\BttnValid.wav</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_global.png</Property>
				<Property Name='TextPosition'>15,5,154,56</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='State'>2</Property>
				<Property Name='Z-Order'>1</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>SignOnButtonText</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='PrimaryFunction'>SwitchTo</Data>
			</CustomData>
		</Control>
		<Control Name='UtilityButton' Type='Button'>
			<Properties>
				<Property Name='Position'>837,696,179,71</Property>
				<Property Name='Font'>MainButtonFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='Audio'>%AudioPath%\BttnValid.wav</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_global.png</Property>
				<Property Name='TextPosition'>15,5,154,56</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Z-Order'>1</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>ReturnToShoppingButtonText</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='PrimaryFunction'>SwitchTo</Data>
			</CustomData>
		</Control>
		<Control Name='TerminalID' Type='Static'>
			<Properties>
				<Property Name='Position'>676,6,342,24</Property>
				<Property Name='Font'>DateTextFont</Property>
				<Property Name='TextColor'>White</Property>
				<Property Name='TextAlignment'>2</Property>
				<Property Name='Z-Order'>2</Property>
			</Properties>
		</Control>
		<Control Name='InterfaceVersion' Type='Static'>
			<Properties>
				<Property Name='Position'>676,27,342,24</Property>
				<Property Name='Font'>SoftwareVersionFont</Property>
				<Property Name='TextColor'>White</Property>
				<Property Name='TextAlignment'>2</Property>
				<Property Name='Z-Order'>2</Property>
			</Properties>
		</Control>
		<Control Name='StartMessage' Type='Static'>
			<Properties>
				<Property Name='Position'>250,330,500,96</Property>
				<Property Name='Font'>TitleFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextAlignment'>2</Property>
				<Property Name='Z-Order'>2</Property>
			</Properties>
		</Control>
		<Control Name='ConfirmMessage' Type='Static'>
			<Properties>
				<Property Name='Position'>256,180,512,340</Property>
				<Property Name='Font'>TitleFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextAlignment'>1</Property>
				<Property Name='Z-Order'>2</Property>
			</Properties>
		</Control>
		<Control Name='ConfirmYes' Type='Button'>
			<Properties>
				<Property Name='Position'>320,430,179,71</Property>
				<Property Name='Font'>LaneButtonTextFont</Property>
				<Property Name='TextFormat'>$YesText$</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='Audio'>%AudioPath%\BttnValid.wav</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_global.png</Property>
				<Property Name='Z-Order'>2</Property>
			</Properties>
		</Control>
		<Control Name='ConfirmNo' Type='Button'>
			<Properties>
				<Property Name='Position'>520,430,179,71</Property>
				<Property Name='Font'>LaneButtonTextFont</Property>
				<Property Name='TextFormat'>$NoText$</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='Audio'>%AudioPath%\BttnValid.wav</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_global.png</Property>
				<Property Name='Z-Order'>2</Property>
			</Properties>
		</Control>
		<Control Name='AlphaNumKey3LaunchPad' Type='Button'>
			<Properties>
				<Property Name='Position'>802,465,164,166</Property>
				<Property Name='Font'>KeyBoardFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextFormat'>$EnterButtonText$</Property>
				<Property Name='Audio'>%AudioPath%\BttnValid.wav</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_keypadLogon-enter.png</Property>
				<Property Name='ClickMove'>2</Property>
				<Property Name='Z-Order'>3</Property>
			</Properties>
		</Control>
		<Control Name='OperatorRegistrationUtilityButton' Type='Button'>
			<Properties>
				<Property Name='Position'>531,280,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='Z-Order'>3</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>OperatorRegistrationUtility</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='ExecutableName'>Oru</Data>
			</CustomData>
		</Control>
		<Control Name='RapConfigureButton' Type='Button'>
			<Properties>
				<Property Name='Position'>531,560,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='PictureTransparentColor'>BlueTransparent</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.PNG</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>RapConfigureBtnPrimaryTxt</Data>
				<Data Name='SecondaryText'>RapConfigureBtnPrimaryTxt</Data>
				<Data Name='PrimaryShowConfirmation'>false</Data>
				<Data Name='PrimaryShowConfirmationMessage'>MinMaxRAPBtnPrimaryShowConfirmation</Data>
				<Data Name='SecondaryShowConfirmation'>false</Data>
				<Data Name='SecondaryShowConfirmationMessage'>MinMaxRAPBtnPrimaryShowConfirmation</Data>
				<Data Name='PrimaryRequiredSecurity'>false</Data>
				<Data Name='SecondaryRequiredSecurity'>false</Data>
				<Data Name='DisabledOnDeadEnabledOnAliveMainExecutable'>false</Data>
				<Data Name='ToggleEnabled'>false</Data>
				<Data Name='ExecutableName'>RapConfigure</Data>
				<Data Name='MaintenanceSignOn'>true</Data>
			</CustomData>
		</Control>
		<Control Name='RunADDButton' Type='Button'>
			<Properties>
				<Property Name='Position'>41,630,440,57</Property>
				<Property Name='Font'>LaunchPadFont</Property>
				<Property Name='TextColor'>Black</Property>
				<Property Name='TextPosition'>8,3,429,47</Property>
				<Property Name='Z-Order'>5</Property>
				<Property Name='ClickMove'>3</Property>
				<Property Name='State'>0</Property>
				<Property Name='Picture'>%MediaPath%\10x7-btn_utility.png</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>RunADDTxt</Data>
				<Data Name='ToggleEnabled'>False</Data>
				<Data Name='ExecutableName'>RunADD</Data>
				<Data Name='PrimaryShowConfirmation'>True</Data>
				<Data Name='PrimaryShowConfirmationMessage'>RunADDConfirm</Data>
			</CustomData>
		</Control>
	</Controls>
	<Contexts>
		<Context Name='FastLaneContext'>
			<CustomData>
				<Data Name='LaneViewPosition'>0,0,1024,696</Data>
				<Data Name='State'>Monitoring</Data>
			</CustomData>
			<Properties>
				<Property Name='BackgroundColor'>Blue</Property>
			</Properties>
			<Include>
				<Control Name='MainBackground'>
				</Control>
				<Control Name='Title'>
					<Properties>
						<Property Name='TextFormat'>$UtilityFunctionsTitle$</Property>
					</Properties>
				</Control>
				<Control Name='TerminalID'>
				</Control>
				<Control Name='InterfaceVersion'>
				</Control>
				<Control Name='CommandPromptButton'>
					<Properties>
						<Property Name='Visible'>False</Property>
					</Properties>
				</Control>
				<Control Name='StopStartFastLaneButton'>
				</Control>
				<Control Name='ExitAllFastLaneButton'>
					<Properties>
						<Property Name='Visible'>False</Property>
					</Properties>
				</Control>
				<Control Name='RSMLEButton'>
					<Properties>
						<Property Name='Visible'>False</Property>
					</Properties>
				</Control>
				<Control Name='ShutdownSystemButton'>
				</Control>
				<Control Name='RebootSystemButton'>
				</Control>
				<Control Name='VolumeButton'>
				</Control>
				<Control Name='EventViewerButton'>
				</Control>
				<Control Name='TouchWareButton'>
				</Control>
				<Control Name='WindowsLogOnButton'>
				</Control>
				<Control Name='GenerateLogButton'>
				</Control>
				<Control Name='ExitFastLaneAndRunProfileButton'>
				</Control>
				<Control Name='TerminalInfoButton'>
				</Control>
				<Control Name='SignOnButton'>
				</Control>
				<Control Name='UtilityButton'>
				</Control>
				<Control Name='OperationID'>
				</Control>
				<Control Name='DateText'>
				</Control>
				<Control Name='OperatorRegistrationUtilityButton'>
					<Properties>
						<Property Name='Visible'>False</Property>
					</Properties>
				</Control>
				<Control Name='RapConfigureButton'>
				</Control>
				<Control Name='RunADDButton'>
				</Control>
			</Include>
		</Context>
		<Context Name='RAPContext'>
			<CustomData>
				<Data Name='LaneViewPosition'>0,0,1024,696</Data>
				<Data Name='State'>Monitoring</Data>
			</CustomData>
			<Properties>
				<Property Name='BackgroundColor'>Blue</Property>
			</Properties>
			<Include>
				<Control Name='MainBackground'>
				</Control>
				<Control Name='Title'>
					<Properties>
						<Property Name='TextFormat'>$UtilityFunctionsTitle$</Property>
					</Properties>
				</Control>
				<Control Name='TerminalID'>
				</Control>
				<Control Name='InterfaceVersion'>
				</Control>
				<Control Name='CommandPromptButton'>
					<Properties>
						<Property Name='Visible'>False</Property>
					</Properties>
				</Control>
				<Control Name='StopStartRAPButton'>
				</Control>
				<Control Name='ExitAllRAPButton'>
					<Properties>
						<Property Name='Visible'>False</Property>
					</Properties>
				</Control>
				<Control Name='RSMLEButton'>
					<Properties>
						<Property Name='Visible'>False</Property>
					</Properties>
				</Control>
				<Control Name='ShutdownSystemButton'>
				</Control>
				<Control Name='RebootSystemButton'>
				</Control>
				<Control Name='VolumeButton'>
				</Control>
				<Control Name='EventViewerButton'>
				</Control>
				<Control Name='TouchWareButton'>
				</Control>
				<Control Name='WindowsLogOnButton'>
				</Control>
				<Control Name='PickListEditorButton'>
				</Control>
				<Control Name='GenerateLogButton'>
				</Control>
				<Control Name='ExitRAPAndRunProfileButton'>
				</Control>
				<Control Name='TerminalInfoButton'>
				</Control>
				<Control Name='SignOnButton'>
				</Control>
				<Control Name='UtilityButton'>
				</Control>
				<Control Name='OperationID'>
				</Control>
				<Control Name='DateText'>
				</Control>
				<Control Name='OperatorRegistrationUtilityButton'>
					<Properties>
						<Property Name='Position'>531,350,440,57</Property>
						<Property Name='Visible'>False</Property>
					</Properties>
				</Control>
				<Control Name='RapConfigureButton'>
				</Control>
			</Include>
		</Context>
		<Context Name='StartupContext'>
			<Properties>
				<Property Name='BackgroundColor'>Blue</Property>
			</Properties>
			<Include>
				<Control Name='MainBackground'>
				</Control>
				<Control Name='Title'>
					<Properties>
						<Property Name='TextFormat'>$StartTitle$</Property>
					</Properties>
				</Control>
				<Control Name='StartMessage'>
					<Properties>
						<Property Name='TextFormat'>$SystemStartup$</Property>
					</Properties>
				</Control>
				<Control Name='DateText'>
				</Control>
			</Include>
		</Context>
		<Context Name='ConfirmationContext'>
			<Properties>
				<Property Name='BackgroundColor'>Blue</Property>
			</Properties>
			<Include>
				<Control Name='MainBackground'>
				</Control>
				<Control Name='Title'>
					<Properties>
						<Property Name='TextFormat'>$UtilityFunctionsTitle$</Property>
					</Properties>
				</Control>
				<Control Name='TerminalID'>
				</Control>
				<Control Name='InterfaceVersion'>
				</Control>
				<!--<Control Name='BackGround'>
        </Control>-->
				<Control Name='ConfirmMessage'>
				</Control>
				<Control Name='ConfirmYes'>
				</Control>
				<Control Name='ConfirmNo'>
				</Control>
				<Control Name='OperationID'>
				</Control>
				<Control Name='DateText'>
				</Control>
			</Include>
		</Context>
		<Context Name='LegalCaptionContext'>
			<CustomData>
				<Data Name='State'>LegalCaption</Data>
			</CustomData>
			<Properties>
				<Property Name='BackgroundColor'>Blue</Property>
			</Properties>
			<Include>
				<Control Name='MainBackground'>
				</Control>
				<Control Name='Title'>
					<Properties>
						<Property Name='TextFormat'>$UtilityFunctionsTitle$</Property>
					</Properties>
				</Control>
				<Control Name='TerminalID'>
				</Control>
				<Control Name='InterfaceVersion'>
				</Control>
				<!--<Control Name='BackGround'>
        </Control>-->
				<!--<Control Name='LegalCaptionMessage'>
        </Control>-->
				<!--<Control Name='LegalCaptionOk'>
        </Control>-->
				<Control Name='OperationID'>
				</Control>
				<Control Name='DateText'>
				</Control>
				<Control Name='UtilityButton'>
				</Control>
			</Include>
		</Context>
		<Context Name='PopupContext'>
			<Properties>
				<Property Name='BackgroundColor'>Blue</Property>
			</Properties>
			<Include>
				<Control Name='MainBackground'>
				</Control>
				<Control Name='MessageStatic'>
				</Control>
				<Control Name='CancelButton'>
				</Control>
			</Include>
		</Context>
		<Context Name='EnterID'>
			<CustomData>
				<Data Name='State'>SignOn</Data>
			</CustomData>
			<Properties>
				<Property Name='BackgroundColor'>Blue</Property>
			</Properties>
			<Include>
				<Control Name='KeyBoardP1'>
				</Control>
				<Control Name='KeyBoardP2'>
				</Control>
				<Control Name='SMNumericKeyBoard'>
				</Control>
				<Control Name='KeyBoardP4'>
					<Properties>
						<Property Name='Action'>Click,ChangeContext,EnterPassword</Property>
					</Properties>
				</Control>
				<Control Name='ButtonCommand0'>
				</Control>
				<Control Name='Title'>
					<Properties>
						<Property Name='TextFormat'>$UtilityFunctionsTitle$</Property>
					</Properties>
				</Control>
				<Control Name='TerminalID'>
				</Control>
				<Control Name='InterfaceVersion'>
				</Control>
				<Control Name='Leadthru'>
					<Properties>
						<Property Name='TextFormat'>$EnterIDLeadthru$</Property>
					</Properties>
				</Control>
				<Control Name='Echo'>
					<Properties>
						<Property Name='Action'>ChangeText,ChangeState,KeyBoardP4,Text</Property>
					</Properties>
				</Control>
				<Control Name='EchoBox'>
				</Control>
				<Control Name='MainBackground'>
				</Control>
				<Control Name='OperationID'>
				</Control>
				<Control Name='DateText'>
				</Control>
			</Include>
		</Context>
		<Context Name='EnterPassword'>
			<CustomData>
				<Data Name='State'>SignOn</Data>
			</CustomData>
			<Properties>
				<Property Name='BackgroundColor'>Blue</Property>
			</Properties>
			<Include>
				<Control Name='KeyBoardP1'>
				</Control>
				<Control Name='KeyBoardP2'>
				</Control>
				<Control Name='SMNumericKeyBoard'>
				</Control>
				<Control Name='KeyBoardP4'>
				</Control>
				<Control Name='ButtonCommand0'>
					<Properties>
						<Property Name='Action'>Click,ChangeContext,EnterID,,True</Property>
					</Properties>
				</Control>
				<Control Name='Title'>
					<Properties>
						<Property Name='TextFormat'>$UtilityFunctionsTitle$</Property>
					</Properties>
				</Control>
				<Control Name='TerminalID'>
				</Control>
				<Control Name='InterfaceVersion'>
				</Control>
				<Control Name='Leadthru'>
					<Properties>
						<Property Name='TextFormat'>$EnterPasswordLeadthru$</Property>
					</Properties>
				</Control>
				<Control Name='Echo'>
					<Properties>
						<Property Name='Password'>True</Property>
					</Properties>
				</Control>
				<Control Name='EchoBox'>
				</Control>
				<Control Name='MainBackground'>
				</Control>
				<Control Name='OperationID'>
				</Control>
				<Control Name='DateText'>
				</Control>
			</Include>
		</Context>
		<Context Name='EnterAlphaNumericID'>
			<CustomData>
				<Data Name='State'>SignOn</Data>
			</CustomData>
			<Properties>
				<Property Name='BackgroundColor'>Blue</Property>
			</Properties>
			<Include>
				<Control Name='AlphaNumP1'>
				</Control>
				<Control Name='AlphaNumP2'>
				</Control>
				<Control Name='AlphaNumP3'>
				</Control>
				<Control Name='AlphaNumP4'>
				</Control>
				<Control Name='AlphaNumKey3LaunchPad'>
					<Properties>
						<Property Name='Action'>Click,ChangeContext,EnterAlphaNumericPassword</Property>
					</Properties>
				</Control>
				<Control Name='ShiftKey'>
				</Control>
				<Control Name='SpaceKey'>
				</Control>
				<Control Name='BackSpaceKey'>
				</Control>
				<Control Name='ButtonCommand0'>
				</Control>
				<Control Name='Title'>
					<Properties>
						<Property Name='TextFormat'>$UtilityFunctionsTitle$</Property>
					</Properties>
				</Control>
				<Control Name='TerminalID'>
				</Control>
				<Control Name='InterfaceVersion'>
				</Control>
				<Control Name='Leadthru'>
					<Properties>
						<Property Name='TextFormat'>$EnterIDLeadthru$</Property>
						<Property Name='Position'>6,90,1017,45</Property>
					</Properties>
				</Control>
				<Control Name='Echo'>
					<Properties>
						<Property Name='Action'>ChangeText,ChangeState,AlphaNumKey3LaunchPad,Text</Property>
					</Properties>
				</Control>
				<Control Name='EchoBox'>
				</Control>
				<Control Name='MainBackground'>
				</Control>
				<Control Name='OperationID'>
				</Control>
				<Control Name='DateText'>
				</Control>
			</Include>
		</Context>
		<Context Name='EnterAlphaNumericPassword'>
			<CustomData>
				<Data Name='State'>SignOn</Data>
			</CustomData>
			<Properties>
				<Property Name='BackgroundColor'>Blue</Property>
			</Properties>
			<Include>
				<Control Name='AlphaNumP1'>
				</Control>
				<Control Name='AlphaNumP2'>
				</Control>
				<Control Name='AlphaNumP3'>
				</Control>
				<Control Name='AlphaNumP4'>
				</Control>
				<Control Name='AlphaNumKey3LaunchPad'>
				</Control>
				<Control Name='ShiftKey'>
				</Control>
				<Control Name='SpaceKey'>
				</Control>
				<Control Name='BackSpaceKey'>
				</Control>
				<Control Name='ButtonCommand0'>
					<Properties>
						<Property Name='Action'>Click,ChangeContext,EnterAlphaNumericID</Property>
					</Properties>
				</Control>
				<Control Name='Title'>
					<Properties>
						<Property Name='TextFormat'>$UtilityFunctionsTitle$</Property>
					</Properties>
				</Control>
				<Control Name='TerminalID'>
				</Control>
				<Control Name='InterfaceVersion'>
				</Control>
				<Control Name='Leadthru'>
					<Properties>
						<Property Name='TextFormat'>$EnterPasswordLeadthru$</Property>
					</Properties>
				</Control>
				<Control Name='Echo'>
					<Properties>
						<Property Name='Password'>True</Property>
					</Properties>
				</Control>
				<Control Name='EchoBox'>
				</Control>
				<Control Name='MainBackground'>
				</Control>
				<Control Name='OperationID'>
				</Control>
				<Control Name='DateText'>
				</Control>
			</Include>
		</Context>
	</Contexts>
</Display>"));
		}
		
		[TestAttribute]
		public void TestValues()
		{
			Assert.AreEqual("MinMaxFastLaneButton", display.Controls.Controls[0].Name);
			Assert.AreEqual("FastLaneContext", display.Contexts.Contexts[0].Name);
			Assert.IsNull(display.Controls.GetControl("Qwerty"));
			Assert.IsNull(display.Contexts.GetContext("Qwerty"));
			
			PsxControl control = display.Controls.GetControl("MinMaxFastLaneButton");
			Assert.AreEqual("Button", control.Type);
			Assert.AreEqual(7, control.Properties.Properties.Length);
			Assert.IsNull(control.Properties.GetProperty("Qwerty"));
			
			PsxProperty p = control.Properties.GetProperty("Position");
			Assert.AreEqual("531,490,440,57", p.Value);
			control.Properties.SetProperty("Position", "lalala");
			Assert.AreEqual("lalala", p.Value);
			
			PsxContext context = display.Contexts.GetContext("FastLaneContext");
			Assert.AreEqual(1, context.Properties.Properties.Length);
		}
	}
}
