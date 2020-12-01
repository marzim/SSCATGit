// <copyright file="TriColorLightFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;
    
    /// <summary>
    /// Initializes a new instance of the TriColorLightFactory class
    /// </summary>
    public class TriColorLightFactory
    {
        /// <summary>
        /// Gets the device event string
        /// </summary>
        /// <param name="deviceEvent">device event</param>
        /// <returns>Returns the string for the event</returns>
        public static string GetString(IDeviceEvent deviceEvent)
        {
            string[] v = deviceEvent.Value.Split('~');
            int color = ConvertUtility.ToInt32(v[0]);
            int state = ConvertUtility.ToInt32(v[1]);
            return string.Format("[Device] TriLight: Color={0} State='{1}'", GetColor(color), GetState(state));
        }

        /// <summary>
        /// Gets the current state of the tri color event
        /// </summary>
        /// <param name="state">event state</param>
        /// <returns>Returns the event state</returns>
        public static string GetState(int state)
        {
            switch (state)
            {
                case Constants.TriColorLightState.OFF: return "Off";
                case Constants.TriColorLightState.ON: return "On";
                case Constants.TriColorLightState.BLINK_QUARTER_HERTZ: return "blinking a Quarter Hertz";
                case Constants.TriColorLightState.BLINK_HALF_HERTZ: return "blinking Half Hertz";
                case Constants.TriColorLightState.BLINK_1_HERTZ: return "blinking 1 Hertz";
                case Constants.TriColorLightState.BLINK_2_HERTZ: return "blinking 2 Hertz";
                case Constants.TriColorLightState.BLINK_4_HERTZ: return "blinking 4 Hertz";
                default: throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Gets the current tri color light color
        /// </summary>
        /// <param name="color">light color</param>
        /// <returns>Returns the color name</returns>
        public static string GetColor(int color)
        {
            switch (color)
            {
                case Constants.TriColorLight.GREEN: return "Green";
                case Constants.TriColorLight.YELLOW: return "Yellow";
                case Constants.TriColorLight.RED: return "Red";
                default: throw new NotSupportedException();
            }
        }
    }
}
