// <copyright file="ScriptEventComparer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System.Collections.Generic;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptEventComparer class
    /// </summary>
    public class ScriptEventComparer : IComparer<IScriptEvent>
    {
        /// <summary>
        /// Compares two script events
        /// </summary>
        /// <param name="x">script event one</param>
        /// <param name="y">script event two</param>
        /// <returns>Returns a numerical value based on whether or not the item happens first and is a stimulus event</returns>
        int IComparer<IScriptEvent>.Compare(IScriptEvent x, IScriptEvent y)
        {
            int num = x.Time.CompareTo(y.Time);
            if (num == 0)
            {
                IStimulus item1 = x.Item as IStimulus;
                IStimulus item2 = y.Item as IStimulus;
                if (item1.IsStimulus && !item2.IsStimulus)
                {
                    return -1;
                }
                else if (!item1.IsStimulus && item2.IsStimulus)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return num;
            }
        }
    }
}
