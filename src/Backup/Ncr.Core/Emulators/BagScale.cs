// <copyright file="BagScale.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System;
    using Microsoft.Win32;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the BagScale class
    /// </summary>
    public class BagScale : Scale, IBagScale
    {
        /// <summary>
        /// Bag scale unit
        /// </summary>
        private string _bagScaleUnit;

        /// <summary>
        /// Initializes a new instance of the BagScale class
        /// </summary>
        public BagScale()
            : base(Emulator.BagScaleCaption)
        {
            Controls.Add("BagScale_ScaleWeight", 0x3eb);
            Controls.Add("BagScale_Weigh", 0x3ed);
        }

        /// <summary>
        /// Gets or sets the bag scale unit
        /// </summary>
        public string BagScaleUnit
        {
            get { return GetBagScaleUnit(); }
            set { _bagScaleUnit = value; }
        }

        /// <summary>
        /// Weigh item on bag scale unit
        /// </summary>
        /// <param name="weight">weight of item</param>
        /// <param name="timeout">scale timeout</param>
        public override void Weigh(int weight, int timeout)
        {
            LoggingService.Info(string.Format("Detected bag scale unit: {0}", BagScaleUnit.ToString()));
            if ((Convert.ToInt16(BagScaleUnit) != 4) && (weight > 0))
            {
                weight = ConvertToPounds(weight);
            }

            OnEmulating(string.Format("Bagscale weighing {0}", weight));
            SetText("BagScale_ScaleWeight", weight.ToString(), timeout);
            ClickButton("BagScale_Weigh", timeout);
        }

        /// <summary>
        /// Convert given weight to pounds
        /// </summary>
        /// <param name="weight">weight to convert</param>
        /// <returns>Returns the weight in pounds</returns>
        public int ConvertToPounds(int weight)
        {
            int newWeight = 0;
            switch (Convert.ToInt16(BagScaleUnit))
            {
                case 1:
                    newWeight = (int)Math.Floor(weight * 453.59237);
                    LoggingService.Info(string.Format("{0} lbs weight detected, converting to {1} gram/s.", weight, newWeight));
                    break;
                case 2:
                    newWeight = (int)Math.Floor(weight * .45359237);
                    LoggingService.Info(string.Format("{0} lbs weight detected, converting to {1} kilogram/s.", weight, newWeight));
                    break;
                case 3:
                    newWeight = (int)Math.Floor(weight * 16.00);
                    LoggingService.Info(string.Format("{0} lbs weight detected, converting to {1} ounce/s", weight, newWeight));
                    break;
                case 4:
                    return weight;
                default:
                    throw new Exception(string.Format(@"Unsupported Scale Unit. Please check [HKEY_LOCAL_MACHINE\{0}] - 'Units'.", RegistryAddress.BagScaleEmulatorKey));
            }

            return newWeight;
        }

        /// <summary>
        /// Get bag scale unit
        /// </summary>
        /// <returns>Returns the bag scale unit</returns>
        public virtual string GetBagScaleUnit()
        {
            try
            {
                // 2 -> SCAL_WU_GRAM = 1, SCAL_WU_KILOGRAM = 2,  SCAL_WU_OUNCE = 3, SCAL_WU_POUND = 4
                if (RegistryHelper.Exists(RegistryAddress.BagScaleEmulatorKey, Registry.LocalMachine))
                {
                    return string.Format(@"{0}", RegistryHelper.GetValue("Units", Registry.LocalMachine.OpenSubKey(RegistryAddress.BagScaleEmulatorKey)).Split(' ')[0]);
                }
                else if (RegistryHelper.Exists(RegistryAddress.BagEmulatorKey, Registry.LocalMachine))
                {
                    return string.Format(@"{0}", RegistryHelper.GetValue("Units", Registry.LocalMachine.OpenSubKey(RegistryAddress.BagEmulatorKey)).Split(' ')[0]);
                }
                else if (RegistryHelper.Exists(RegistryAddress.CADDBagScaleDeviceKey, Registry.LocalMachine))
                {
                    return string.Format(@"{0}", RegistryHelper.GetValue("ScaleUnit", Registry.LocalMachine.OpenSubKey(RegistryAddress.CADDBagScaleDeviceKey)).Split(' ')[0]);
                }
                else
                {
                    LoggingService.Warning("Bag scale unit not found in registry file.");
                    return "4";
                }
            }
            catch (Exception ex)
            {
                LoggingService.Warning(ex.ToString());
                return "4";
            }
        }
    }
}
