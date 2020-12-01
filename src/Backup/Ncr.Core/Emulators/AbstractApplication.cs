// <copyright file="AbstractApplication.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using Ncr.Core.Models;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the AbstractApplication class
    /// </summary>
    public abstract class AbstractApplication : BaseModel<AbstractApplication>, IApplication
    {
        /// <summary>
        /// Launch pad interface
        /// </summary>
        private ILaunchPad _launchPad;

        /// <summary>
        /// Application caption
        /// </summary>
        private string _caption;

        /// <summary>
        /// Initializes a new instance of the AbstractApplication class
        /// </summary>
        /// <param name="caption">Application caption</param>
        public AbstractApplication(string caption)
        {
            Caption = caption;
        }

        /// <summary>
        /// Gets the file name
        /// </summary>
        public abstract string FileName { get; }

        /// <summary>
        /// Gets a value indicating whether the application exists or not
        /// </summary>
        public virtual bool Exists
        {
            get
            {
                try
                {
                    return FileHelper.Exists(FileName);
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets or sets the caption
        /// </summary>
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }
        
        /// <summary>
        /// Gets or sets the launch pad
        /// </summary>
        public virtual ILaunchPad LaunchPad
        {
            get
            {
                return _launchPad;
            }

            set
            {
                _launchPad = value;
                _launchPad.Application = this;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the application has started or not
        /// </summary>
        public virtual bool HasStarted
        {
            get { return ProcessUtility.HasStarted(ProcessName); }
        }

        /// <summary>
        /// Gets the process name
        /// </summary>
        public abstract string ProcessName { get; }

        /// <summary>
        /// Start the process
        /// </summary>
        public virtual void Start()
        {
            ProcessUtility.Start(FileName);
        }

        /// <summary>
        /// Kill the process
        /// </summary>
        public virtual void Kill()
        {
            ProcessUtility.Kill(ProcessName, true);
        }

        /// <summary>
        /// Force Kill the process
        /// </summary>
        public virtual void ForceKill()
        {
            LaunchPad.Kill();
        }
    }
}
