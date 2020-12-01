// <copyright file="UIAutoTestEventCommandFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Sscat.Core.Commands.Events;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the UIAutoTestEventCommandFactory class
    /// </summary>
    public class UIAutoTestEventCommandFactory : EventCommandFactory
    {
        /// <summary>
        /// Interface for the auto test event item
        /// </summary>
        private IUIAutoTestEvent _item;

        /// <summary>
        /// Initializes a new instance of the UIAutoTestEventCommandFactory class
        /// </summary>
        /// <param name="item">auto pos emulator event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="hooks">scot log hook</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public UIAutoTestEventCommandFactory(IUIAutoTestEvent item, SscatLane lane, Dictionary<string, IScotLogHook> hooks, int timeout, bool enableHook)
            : base(lane, hooks, timeout, enableHook)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            _item = item;
        }

        /// <summary>
        /// Creates the UI auto test event command
        /// </summary>
        /// <returns>Returns event command</returns>
        public override IEventCommand CreateCommand()
        {
            switch (_item.EventType)
            {
                case Constants.UIAutoTestEvent.BUTTON_CLICK:
                    return new UIAutoTestButtonClick(Hooks[ScotLogHook.UIAutoTest], _item, Lane, Timeout, EnableHook);
                case Constants.UIAutoTestEvent.KEYBOARD_BUTTON_CLICK:
                    return new UIAutoTestKeyboardButtonClick(Hooks[ScotLogHook.UIAutoTest], _item, Lane, Timeout, EnableHook);
                case Constants.UIAutoTestEvent.CATEGORY_CLICK:
                    return new UIAutoTestCategoryClick(Hooks[ScotLogHook.UIAutoTest], _item, Lane, Timeout, EnableHook);
                case Constants.UIAutoTestEvent.SLIDING_GRID_PAGE_CLICK:
                    return new UIAutoTestGridPageClick(Hooks[ScotLogHook.UIAutoTest], _item, Lane, Timeout, EnableHook);
                case Constants.UIAutoTestEvent.LIST_BUTTON_CLICK:
                    return new UIAutoTestListButtonClick(Hooks[ScotLogHook.UIAutoTest], _item, Lane, Timeout, EnableHook);
                case Constants.UIAutoTestEvent.SIGN_SIGNATURE:
                    return new UIAutoTestSignSignature(Hooks[ScotLogHook.UIAutoTest], _item, Lane, Timeout, EnableHook);
                case Constants.UIAutoTestEvent.SWIPE_LEFT:
                    return new UIAutoTestSwipeLeft(Hooks[ScotLogHook.UIAutoTest], _item, Lane, Timeout, EnableHook);
                case Constants.UIAutoTestEvent.SWIPE_RIGHT:
                    return new UIAutoTestSwipeRight(Hooks[ScotLogHook.UIAutoTest], _item, Lane, Timeout, EnableHook);
                case Constants.UIAutoTestEvent.CONTEXT_CHANGED:
                    return new UIAutoTestContextChanged(Hooks[ScotLogHook.UIAutoTest], _item, Lane, Timeout, EnableHook);
                case Constants.UIAutoTestEvent.END_OF_TRANSACTION:
                    return new UIAutoTestEndOfTransaction(Hooks[ScotLogHook.UIAutoTest], _item, Lane, Timeout, EnableHook);
                case Constants.UIAutoTestEvent.HW_UNAV:
                    return new UIAutoTestHWuNav(Hooks[ScotLogHook.UIAutoTest], _item, Lane, Timeout, EnableHook);
                case Constants.UIAutoTestEvent.CART_INDEX_CHANGED:
                    return new UIAutoTestCartIndexChanged(Hooks[ScotLogHook.UIAutoTest], _item, Lane, Timeout, EnableHook);
                default:
                    throw new NotSupportedException(string.Format("UI auto test command '{0}' not supported.", _item.EventType));
            }
        }
    }
}
