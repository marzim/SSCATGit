// <copyright file="ESAEmulator.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ESA emulator class
    /// </summary>
    public class ESAEmulator : Emulator, IEsaEmulator
    {
        /// <summary>
        /// ESA InterventionWindow
        /// </summary>
        private ESAInterventionWindow esaInterventionWindow;

        /// <summary>
        /// Key for intervention button
        /// </summary>
        private string interventionKey = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ESAEmulator"/> class.
        /// </summary>
        public ESAEmulator()
            : base(Emulator.ESAEmulatorCaption)
        {
            Controls.Add("WeightMismatch", 0x405);
            Controls.Add("TicketSwitching", 0x406);
            Controls.Add("UnexpectedWeightIncrease", 0x407);
            Controls.Add("UnscannedItemLeftBehind", 0x408);
            Controls.Add("UnscannedItemPassAround", 0x409);
            Controls.Add("Ok", 0x2);
            Controls.Add("SLSecurity", 0x3F6);
            Controls.Add("Frequency", 0x3FA);

            esaInterventionWindow = new ESAInterventionWindow();
        }

        /// <summary>
        /// Performs the Intervention
        /// </summary>
        /// <param name="intervention">intervention to perform</param>
        /// <param name="timeout">timeout amount</param>
        public virtual void Intervene(string intervention, int timeout)
        {
            interventionKey = IdentifyIntervention(intervention);
            if (!string.IsNullOrEmpty(interventionKey))
            {
                ClickButtonInChildWindow(interventionKey, timeout, true, "ESAIntervention", null);
                ThreadHelper.Sleep(1000);

                esaInterventionWindow.SendIntervention(timeout);
                
                ClickButtonInChildWindow("Ok", timeout, false, null, null);
                ThreadHelper.Sleep(1000);

                esaInterventionWindow.CloseIntervention(timeout);
            }
        }
        
        /// <summary>
        /// Identifies the key for the Intervention
        /// </summary>
        /// <param name="intervention">intervention to identify</param>
        /// <returns>returns key string for button intervention</returns>
        private string IdentifyIntervention(string intervention)
        {
            switch (intervention)
            {
                case "SMDataEntryWeightBasedMismatch":
                    return "WeightMismatch";
                case "SMDataEntryCVBMismatch":
                    return "TicketSwitching";
                case "SMDataEntryWeightBasedUnexpectedIncrease":
                    return "UnexpectedWeightIncrease";
                case "SMDataEntryCVBUnexpectedIncrease":
                   return "UnscannedItemPassAround";
                case "SMDataEntryCVBDuringFinalizationUnexpectedIncrease":
                    return "UnscannedItemLeftBehind";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Sets text on ESA Emulator to ON
        /// </summary>
        public void SetEmulatorOn(int timeout)
        {
            LoggingService.Info("Setting ESA Emulator state to ON");
            SetText("SLSecurity","ON", timeout);
            LoggingService.Info("Setting ESA Emulator frequency to 2500");
            SetText("Frequency", "2500", timeout);
        }
    }
}
