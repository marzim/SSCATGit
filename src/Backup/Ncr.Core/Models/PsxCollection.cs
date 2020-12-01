// <copyright file="PsxCollection.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Initializes a new instance of the PsxCollection class
    /// </summary>
    public class PsxCollection : Dictionary<string, IPsx>
    {
        /// <summary>
        /// Initializes a new instance of the PsxCollection class
        /// </summary>
        public PsxCollection()
        {
        }

        /// <summary>
        /// Add the PSX
        /// </summary>
        /// <param name="psx">PSX to add</param>
        public void Add(IPsx psx)
        {
            Add(psx.ConnectionName, psx);
        }
    }
}
