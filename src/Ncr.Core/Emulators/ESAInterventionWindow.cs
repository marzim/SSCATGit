// <copyright file="ESAInterventionWindow.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ESA intervention window class
    /// </summary>
    public class ESAInterventionWindow : Emulator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ESAInterventionWindow"/> class
        /// </summary>
        public ESAInterventionWindow()
            : base(Emulator.ESAInterventionWindowCaption)
        {
            Controls.Add("Send", 0x407);
            Controls.Add("Close", 0x8);
            Controls.Add("Ok", 0x2);
        }

        /// <summary>
        /// Sends the intervention window
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public virtual void SendIntervention(int timeout)
        {
            LoggingService.Info("ESA INTERVENTION : Attempting to click send");
            ClickButtonInChildWindow("Send", timeout, true, "ESAEmulator", "Ok");
            LoggingService.Info("ESA INTERVENTION : Clicked send");
            ThreadHelper.Sleep(100);
        }

        /// <summary>
        /// Closes the intervention window
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public virtual void CloseIntervention(int timeout)
        {
            LoggingService.Info("ESA INTERVENTION : Attempting to click close");
            ClickButtonInChildWindow("Close", timeout, false, "ESAEmulator", "Ok");
            LoggingService.Info("ESA INTERVENTION : Clicked close");
            ThreadHelper.Sleep(100);
        }
    }
}
