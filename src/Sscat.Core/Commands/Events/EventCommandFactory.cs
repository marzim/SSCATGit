// <copyright file="EventCommandFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Sscat.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Ncr.Core.Models;
    using Sscat.Core.Commands.Events;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the EventCommandFactory class
    /// </summary>
    public abstract class EventCommandFactory : BaseModel<EventCommandFactory>, IEventCommandFactory
    {
        /// <summary>
        /// Gets or sets the scot log hooks
        /// </summary>        
        private Dictionary<string, IScotLogHook> _hooks;

        /// <summary>
        /// timeout of an event
        /// </summary>
        private int _timeout;

        /// <summary>
        /// sscat lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// whether the hook is enabled
        /// </summary>
        private bool _enableHook;

        /// <summary>
        /// Initializes a new instance of the EventCommandFactory class
        /// </summary>
        public EventCommandFactory()
        {
        }

        /// <summary>
        /// Initializes a new instance of the EventCommandFactory class
        /// </summary>
        /// <param name="lane">sscat lane</param>
        /// <param name="hooks">scot log hooks</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public EventCommandFactory(SscatLane lane, Dictionary<string, IScotLogHook> hooks, int timeout, bool enableHook)
        {
            if (hooks == null)
            {
                throw new ArgumentException("Hooks is null");
            }

            Lane = lane;
            Hooks = hooks;
            Timeout = timeout;
            EnableHook = enableHook;
        }

        /// <summary>
        /// Gets or sets the scot log hooks
        /// </summary>
        protected Dictionary<string, IScotLogHook> Hooks
        {
            get { return _hooks; }
            set { _hooks = value; }
        }

        /// <summary>
        /// Gets or sets the timeout
        /// </summary>
        protected int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        /// <summary>
        /// Gets or sets the sscat lane
        /// </summary>
        protected SscatLane Lane
        {
            get { return _lane; }
            set { _lane = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the hook is enabled
        /// </summary>
        protected bool EnableHook
        {
            get { return _enableHook; }
            set { _enableHook = value; }
        }

        /// <summary>
        /// Gets the corresponding command factory
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="hooks">scot log hooks</param>
        /// <param name="timeout">timeout amount</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        /// <returns>Returns the event command factory for the script event</returns>
        public static IEventCommandFactory GetCommandFactory(IScriptEvent scriptEvent, SscatLane lane, Dictionary<string, IScotLogHook> hooks, int timeout, bool enableHook)
        {
            if (scriptEvent.Item is ILaunchPadPsxEvent)
            {
                return new LaunchPadPsxEventCommandFactory(scriptEvent.Item as ILaunchPadPsxEvent, lane, hooks, timeout, enableHook);
            }
            else if (scriptEvent.Item is IPsxEvent)
            {
                return new PsxEventCommandFactory(scriptEvent.Item as IPsxEvent, lane, hooks, timeout, enableHook);
            }
            else if (scriptEvent.Item is IDeviceEvent)
            {
                return new DeviceEventCommandFactory(scriptEvent.Item as IDeviceEvent, lane, hooks, timeout, enableHook);
            }
            else if (scriptEvent.Item is IWldbEvent)
            {
                return new WldbEventCommandFactory(scriptEvent.Item as IWldbEvent, lane);
            }
            else if (scriptEvent.Item is IApplicationLauncherEvent)
            {
                return new ApplicationLauncherCommandFactory(scriptEvent.Item as IApplicationLauncherEvent, lane.ApplicationLauncher);
            }
            else if (scriptEvent.Item is IReportEvent)
            {
                return new ReportEventCommandFactory(scriptEvent.Item as IReportEvent, lane, hooks, timeout, enableHook);
            }
            else if (scriptEvent.Item is IXmEvent)
            {
                return new XmEventCommandFactory(scriptEvent.Item as IXmEvent, lane, hooks, timeout, enableHook);
#if NET40
            }
            else if (scriptEvent.Item is IUIAutoTestEvent)
            {
                return new UIAutoTestEventCommandFactory(scriptEvent.Item as IUIAutoTestEvent, lane, hooks, timeout, enableHook);
            }
            else if (scriptEvent.Item is IUIValidationEvents)
            {
                return new UIValidationEventCommandFactory(scriptEvent.Item as IUIValidationEvents, lane, hooks, timeout, enableHook);
            }
            else if (scriptEvent.Item is IUtilityEvent)
            {
                return new UtilityEventCommandFactory(scriptEvent.Item as IUtilityEvent, lane, hooks, timeout, enableHook);
#endif
            }
            else
            {
                throw new NotSupportedException(string.Format("Command factory for '{0}' event type not supported", scriptEvent.Type));
            }
        }

        /// <summary>
        /// Validates the hooks and emulators
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            AddErrorIf("Hooks shouldn't be null", Hooks == null);
            AddErrorIf("Emulators shouldn't be null", Lane.Emulators == null);
        }

        /// <summary>
        /// Creates a command
        /// </summary>
        /// <returns>Returns the event command</returns>
        public abstract IEventCommand CreateCommand();
    }
}
