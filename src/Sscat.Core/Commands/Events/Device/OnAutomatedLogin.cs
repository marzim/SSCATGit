// <copyright file="OnAutomatedLogin.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Sscat.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    using Sscat.Core.Commands.Events.UIAutoTest;
    using Sscat.Core.Config;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the OnAutomatedLogin class
    /// </summary>
    public class OnAutomatedLogin : DeviceEventCommand
    {
        /// <summary>
        /// Dictionary containing the keypads with their corresponding button name and data
        /// </summary>
        private Dictionary<string, ButtonNameData> _autoTestKeypadDictionary;

        /// <summary>
        /// login ID
        /// </summary>
        private string _loginId;

        /// <summary>
        /// login password
        /// </summary>
        private string _password;

        /// <summary>
        /// name of the keypad
        /// </summary>
        private string _keypadName;

        /// <summary>
        /// the keypad type
        /// </summary>
        private string _keypadType;

        /// <summary>
        /// an invalid login ID
        /// </summary>
        private string _invalidLoginId;

        /// <summary>
        /// an invalid login password
        /// </summary>
        private string _invalidPassword;

        /// <summary>
        /// the enter key name
        /// </summary>
        private string _enterKeyName;

        /// <summary>
        /// whether or not the keypad is an operator numeric type
        /// </summary>
        private bool _isOperatorNumericKeyPad;

        /// <summary>
        /// whether or not the keypad is an operator numeric type
        /// </summary>
        private bool _enterPasswordEnable;

        /// <summary>
        /// Initializes a new instance of the OnAutomatedLogin class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public OnAutomatedLogin(IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
            _loginId = lane.Configuration.PlayerConfiguration.LoginId;
            _password = lane.Configuration.PlayerConfiguration.Password;
            _keypadName = lane.Configuration.PlayerConfiguration.AutomatedLoginConfig.Name;
            _isOperatorNumericKeyPad = lane.IsOperatorNumericKeyPad;
            _enterPasswordEnable = lane.Configuration.PlayerConfiguration.EnterPasswordEnable;

            _keypadType = _isOperatorNumericKeyPad ? "Numeric" : "AlphaNumeric";
            _autoTestKeypadDictionary = new Dictionary<string, ButtonNameData>();
            foreach (KeyPad keypad in lane.Configuration.PlayerConfiguration.AutomatedLoginConfig.KeyPads)
            {
                bool isKeypadNameEqual = string.Equals(_keypadName, keypad.Name, StringComparison.OrdinalIgnoreCase);
                bool isKeypadTypeEqual = string.Equals(_keypadType, keypad.Type, StringComparison.OrdinalIgnoreCase);
                if (isKeypadNameEqual && isKeypadTypeEqual)
                {
                    _invalidLoginId = keypad.InvalidId;
                    _invalidPassword = keypad.InvalidPassword;
                    _enterKeyName = keypad.EnterKeyName;
                    foreach (Key key in keypad.Keys)
                    {
                        LoggingService.Info(string.Format("Adding keypad keys {0} with button name {1} and button data {2}.", key.Name, key.ButtonName, key.ButtonData));
                        _autoTestKeypadDictionary.Add(key.Name, new ButtonNameData(key.ButtonName, key.ButtonData));
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// Runs the automated login process
        /// </summary>
        public override void Run()
        {
            try
            {
                string id = (Item.Value == "1") ? _loginId : _invalidLoginId;
                string pass = (Item.Value == "1") ? _password : _invalidPassword;
                
                switch (_keypadType)
                {
                    case "Numeric":
                        AutoTestKeyIn(id, "EnterId");
                        if(WaitForEnterPasswordContext())
                        {
                            AutoTestKeyIn(pass, "EnterPassword");
                        }
                        break;
                    case "AlphaNumeric":
                        string cont = NextGenUITestClient.Instance.GetCurrentContext();
                        AutoTestAlphaNumericKeyIn(id, cont);
                        if (cont == "StoreModeKeyboard")
                        {
                            LoggingService.Info("Automated login sleeping for 2000ms");
                            ThreadHelper.Sleep(2000);
                            cont = NextGenUITestClient.Instance.GetCurrentContext();
                            AutoTestAlphaNumericKeyIn(pass, "StoreModeKeyboard");
                        }
                        else
                        {
                            LoggingService.Info("Automated login sleeping for 2000ms");
                            ThreadHelper.Sleep(2000);
                            cont = NextGenUITestClient.Instance.GetCurrentContext();
                            if (WaitForEnterPasswordContext())
                            {
                                AutoTestAlphaNumericKeyIn(pass, "EnterPassword");
                            } 
                        }

                        break;
                }

                base.Run();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Waits until the password context state change occurs
        /// </summary>
        private bool WaitForEnterPasswordContext()
        {
            bool isSignal = TestEvents.EnterPasswordReadyEvent.WaitOne(new TimeSpan(0, 0, 30));
            
            if (!isSignal)
            {
                if(_enterPasswordEnable)
                {
                    throw new TimeoutException("Enter Password context did not arrive.");
                }
                else
                {
                    return false;
                }
            }
            
            return true;
        }

        /// <summary>
        /// Automates the login button clicks for alpha numeric keyboard
        /// </summary>
        /// <param name="data">keypad data</param>
        /// <param name="contextName">name of the context</param>
        private void AutoTestAlphaNumericKeyIn(string data, string contextName)
        {
            ButtonNameData buttonNameData = new ButtonNameData();

            CheckKeyPadCompatibility(data);
            LoggingService.Info("keying " + data);

            foreach (char c in data.ToCharArray())
            {
                if (_autoTestKeypadDictionary.TryGetValue(c.ToString(), out buttonNameData))
                {
                    if (char.IsWhiteSpace(c))
                    {
                        NextGenUITestClient.Instance.ClickButton(buttonNameData.ButtonName, contextName);
                    }
                    else
                    {
                        NextGenUITestClient.Instance.ClickKeyboardButton(buttonNameData.ButtonName, buttonNameData.ButtonData, contextName);
                    }
                }
            }

            // Enter/OK button
            if (_autoTestKeypadDictionary.TryGetValue(_enterKeyName.ToString(), out buttonNameData))
            {
                NextGenUITestClient.Instance.ClickButton(buttonNameData.ButtonName, contextName);
            }
        }

        /// <summary>
        /// Automates the login button clicks for keypad
        /// </summary>
        /// <param name="data">keypad data</param>
        /// <param name="contextName">name of the context</param>
        private void AutoTestKeyIn(string data, string contextName)
        {
            ButtonNameData buttonNameData = new ButtonNameData();

            CheckKeyPadCompatibility(data);

            foreach (char c in data)
            {
                if (_autoTestKeypadDictionary.TryGetValue(c.ToString(), out buttonNameData))
                {
                    NextGenUITestClient.Instance.ClickButton(buttonNameData.ButtonName, contextName);
                }
            }

            // Enter/OK button
            if (_autoTestKeypadDictionary.TryGetValue(_enterKeyName.ToString(), out buttonNameData))
            {
                NextGenUITestClient.Instance.ClickButton(buttonNameData.ButtonName, contextName);
            }
        }

        /// <summary>
        /// Checks the key pad compatibility
        /// </summary>
        /// <param name="data">keypad data</param>
        private void CheckKeyPadCompatibility(string data)
        {
            if (Lane.IsOperatorNumericKeyPad)
            {
                try
                {
                    Convert.ToInt32(data);
                }
                catch (FormatException ex)
                {
                    throw new FormatException(string.Format("Cannot process user credential \"{0}\" in NumericKeyPad. {1}", data, ex.ToString()));
                }
            }
        }
    }
}