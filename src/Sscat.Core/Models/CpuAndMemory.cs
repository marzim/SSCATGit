// <copyright file="CpuAndMemory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    /// <summary>
    /// Initializes a new instance of the CpuAndMemory class
    /// </summary>
    public class CpuAndMemory
    {
        /// <summary>
        /// The CPU
        /// </summary>
        private float _cpu;

        /// <summary>
        /// Computer memory
        /// </summary>
        private float _memory;

        /// <summary>
        /// Initializes a new instance of the CpuAndMemory class
        /// </summary>
        /// <param name="cpu">the cpu</param>
        /// <param name="memory">computer memory</param>
        public CpuAndMemory(float cpu, float memory)
        {
            _cpu = cpu;
            _memory = memory;
        }

        /// <summary>
        /// Gets or sets the CPU
        /// </summary>
        public float Cpu
        {
            get { return _cpu; }
            set { _cpu = value; }
        }

        /// <summary>
        /// Gets or sets the computer memory
        /// </summary>
        public float Memory
        {
            get { return _memory; }
            set { _memory = value; }
        }
        
        /// <summary>
        /// Creates a string about the CPU and Memory
        /// </summary>
        /// <returns>Returns the CPU and Memory information</returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}", _cpu, _memory);
        }
    }
}
