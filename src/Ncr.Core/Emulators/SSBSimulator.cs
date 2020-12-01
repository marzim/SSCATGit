// <copyright file="SSBSimulator.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using Ncr.Core.PInvoke;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the SSBSimulator class
    /// </summary>
    public class SSBSimulator : Emulator
    {
        /// <summary>
        /// Initializes a new instance of the SSBSimulator class
        /// </summary>
        public SSBSimulator()
            : this(Emulator.SSBSimulatorCaption)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SSBSimulator class
        /// </summary>
        /// <param name="caption">caption text</param>
        public SSBSimulator(string caption)
            : base(caption)
        {
            Controls.Add("DisableSimulator", 0x405);
            Controls.Add("CenteringError", 0x401);
            Controls.Add("PAConfigError", 0x400);
            Controls.Add("PLAConfigError", 0x3FF);
            Controls.Add("PAVerifyItemAlert", 0x402);
            Controls.Add("PLAVerifyItemAlert", 0x403);
            Controls.Add("ErrorStatus", 0x404);
        }

        /// <summary>
        /// Checks the status of checkbox
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        /// <param name="folderName">script config folder name where PAPLASettings.ini is stored</param>
        public void SetCheckBox(int timeout, string folderName)
        {
            try
            {
                string section = "SSBApplication";
                CheckBox("DisableSimulator", SSCOHelper.CheckSSBConfig(section, "DisableSimulator", folderName), timeout);
                CheckBox("CenteringError", SSCOHelper.CheckSSBConfig(section, "CenteringError", folderName), timeout);
                CheckBox("PAConfigError", SSCOHelper.CheckSSBConfig(section, "PAConfigError", folderName), timeout);
                CheckBox("PLAConfigError", SSCOHelper.CheckSSBConfig(section, "PLAConfigError", folderName), timeout);
                CheckBox("PAVerifyItemAlert", SSCOHelper.CheckSSBConfig(section, "PAVerifyItemAlert", folderName), timeout);
                CheckBox("PLAVerifyItemAlert", SSCOHelper.CheckSSBConfig(section, "PLAVerifyItemAlert", folderName), timeout);
                CheckBox("ErrorStatus", SSCOHelper.CheckSSBConfig(section, "ErrorStatus", folderName), timeout);
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Sets the PAPLASetting ini file
        /// </summary>
        /// <param name="filename">filename and path of the setting to be updated</param>
        public void SetPAPLASetting(string filename)
        {
            LoggingService.Info(filename);
            string section = "SSBApplication";
            try
            {
                IniFileHelper.SetString(filename, section, "DisableSimulator", IsCheckBoxCheck("DisableSimulator") ? "Y" : "N");
                IniFileHelper.SetString(filename, section, "CenteringError", IsCheckBoxCheck("CenteringError") ? "Y" : "N");
                IniFileHelper.SetString(filename, section, "PAConfigError", IsCheckBoxCheck("PAConfigError") ? "Y" : "N");
                IniFileHelper.SetString(filename, section, "PLAConfigError", IsCheckBoxCheck("PLAConfigError") ? "Y" : "N");
                IniFileHelper.SetString(filename, section, "PAVerifyItemAlert", IsCheckBoxCheck("PAVerifyItemAlert") ? "Y" : "N");
                IniFileHelper.SetString(filename, section, "PLAVerifyItemAlert", IsCheckBoxCheck("PLAVerifyItemAlert") ? "Y" : "N");
                IniFileHelper.SetString(filename, section, "ErrorStatus", IsCheckBoxCheck("ErrorStatus") ? "Y" : "N");
                IniFileHelper.SetString(filename, section, "SSBCommunicator", ProcessUtility.HasStarted("SSBCommunicator") ? "Y" : "N");
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                throw ex;
            }
        }
    }
}
