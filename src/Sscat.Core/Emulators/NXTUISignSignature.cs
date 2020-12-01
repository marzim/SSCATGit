// <copyright file="NXTUISignSignature.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using Ncr.Core.Emulators;
    using Sscat.Core.Commands.Events.UIAutoTest;

    /// <summary>
    /// Initializes a new instance of the Login class
    /// </summary>
    public class NXTUISignSignature : LaneCommand
    {
        /// <summary>
        /// Runs the lane login
        /// </summary>
        public override void Run()
        {
            NextGenUITestClient.Instance.SignSignature("SignatureControl", "RequestSig");
        }
    }
}
