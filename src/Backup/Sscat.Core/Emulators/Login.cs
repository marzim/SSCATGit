// <copyright file="Login.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the Login class
    /// </summary>
    public class Login : LaneCommand
    {
        /// <summary>
        /// Runs the lane login
        /// </summary>
        public override void Run()
        {
            Lane.Login(5000);
        }
    }
}
