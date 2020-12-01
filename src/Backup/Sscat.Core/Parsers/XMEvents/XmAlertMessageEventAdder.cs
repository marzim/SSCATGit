// <copyright file="XmAlertMessageEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.XMEvents
{
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the XmAlertMessageEventAdder class
    /// </summary>
    public class XmAlertMessageEventAdder : XmEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the XmAlertMessageEventAdder class
        /// </summary>
        public XmAlertMessageEventAdder()
            : base(Constants.XmEvent.XM_ALERT_MESSAGE)
        {
        }
    }
}
