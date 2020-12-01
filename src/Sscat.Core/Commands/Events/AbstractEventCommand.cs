// <copyright file="AbstractEventCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using Ncr.Core.Commands;
    using Ncr.Core.Models;
    using Sscat.Core.Commands.Events;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the AbstractEventCommand class
    /// </summary>
    public abstract class AbstractEventCommand : AbstractCommand, IEventCommand
    {
        /// <summary>
        /// Event command result
        /// </summary>
        private Result _result;

        /// <summary>
        /// Interface for the scot log hook
        /// </summary>
        private IScotLogHook _hook;

        /// <summary>
        /// Timeout amount for event
        /// </summary>
        private int _timeout;

        /// <summary>
        /// SSCAT lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// Whether or not hook is enabled
        /// </summary>
        private bool _enableHook;
        
        /// <summary>
        /// Script Event Item
        /// </summary>
        private IScriptEventItem _scriptEventItem;

        /// <summary>
        /// Initializes a new instance of the AbstractEventCommand class
        /// </summary>
        public AbstractEventCommand()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AbstractEventCommand class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">script event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public AbstractEventCommand(IScotLogHook hook, IScriptEventItem item, SscatLane lane, int timeout, bool enableHook)
        {
            if (hook == null)
            {
                throw new ArgumentNullException("Hook");
            }

            Hook = hook;
            ScriptEventItem = item;
            Lane = lane;
            Timeout = timeout;
            EnableHook = enableHook;
        }

        /// <summary>
        /// Event handler for adding connection
        /// </summary>
        public event EventHandler<PsxWrapperEventArgs> ConnectionAdding;

        /// <summary>
        /// Gets or sets a value indicating whether the hook is enabled
        /// </summary>
        public bool EnableHook
        {
            get { return _enableHook; }
            set { _enableHook = value; }
        }

        /// <summary>
        /// Gets or sets the SSCAT lane
        /// </summary>
        public SscatLane Lane
        {
            get { return _lane; }
            set { _lane = value; }
        }

        /// <summary>
        /// Gets or sets the timeout
        /// </summary>
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        /// <summary>
        /// Gets or sets the scot log hook
        /// </summary>
        public IScotLogHook Hook
        {
            get { return _hook; }
            set { _hook = value; }
        }

        /// <summary>
        /// Gets or sets the result
        /// </summary>
        public Result Result
        {
            get { return _result; }
            set { _result = value; }
        }

        /// <summary>
        /// Gets or sets the script event item
        /// </summary>
        protected IScriptEventItem ScriptEventItem
        {
            get { return _scriptEventItem; }
            set { _scriptEventItem = value; }
        }
        
        /// <summary>
        /// Ran before the event
        /// </summary>
        public virtual void PreRun()
        {
        }

        /// <summary>
        /// Runs the abstract event command
        /// </summary>
        public override void Run()
        {
            if (_scriptEventItem.IsForgivable && !_scriptEventItem.Type.Equals("UIAutoTest") && _lane.Configuration.PlayerConfiguration.EnableSkipForgivableEvents)
            {
                Result = new Result(ResultType.Skipped, "SkipForgivableEvents is enabled");
            }
            else if (EnableHook)
            {
                try
                {
                    Hook.Checking += new EventHandler<SscatEventArgs>(HookChecking);
                    Result = Hook.Check(ScriptEventItem.CreateEvent(), Timeout);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    Hook.Checking -= new EventHandler<SscatEventArgs>(HookChecking);
                }
            }
            else
            {
                Result = new Result(ResultType.Passed, "Log Hook Disabled");
            }
        }

        /// <summary>
        /// Event for adding the connection
        /// </summary>
        /// <param name="e">PSX wrapper event arguments</param>
        protected virtual void OnConnectionAdding(PsxWrapperEventArgs e)
        {
            if (ConnectionAdding != null)
            {
                ConnectionAdding(this, e);
            }
        }

        /// <summary>
        /// Event for checking the hook
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">sscat event arguments</param>
        private void HookChecking(object sender, SscatEventArgs e)
        {
            OnRunning(e.Message);
        }
    }
}
