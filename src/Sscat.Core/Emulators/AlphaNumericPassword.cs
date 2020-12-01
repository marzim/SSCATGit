// <copyright file="AlphaNumericPassword.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the AlphaNumericPassword class
    /// </summary>
    public class AlphaNumericPassword : LaneCommand
    {
        /// <summary>
        /// Runs the lane alpha numeric password
        /// </summary>
        public override void Run()
        {
            Lane.AlphaNumericPassword(5000);
        }
    }
}
