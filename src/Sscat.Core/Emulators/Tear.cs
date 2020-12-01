// <copyright file="Tear.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the Tear class
    /// </summary>
    public class Tear : LaneCommand
    {
        /// <summary>
        /// Runs the lane tear
        /// </summary>
        public override void Run()
        {
            Lane.Tear();
        }
    }
}
