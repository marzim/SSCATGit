// <copyright file="LaunchPadPsxClick.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.LaunchPadPsx
{
    using System;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.PsxDisplay;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Repositories;

    /// <summary>
    /// Initializes a new instance of the LaunchPadPsxClick class
    /// </summary>
    public class LaunchPadPsxClick : LaunchPadPsxEventCommand
    {
        /// <summary>
        /// Interface for the psx display repository
        /// </summary>
        private IPsxDisplayRepository _displayRepository;

        /// <summary>
        /// Initializes a new instance of the LaunchPadPsxClick class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="launchPad">launch pad</param>
        /// <param name="item">launch pad psx event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="displayRepository">psx display repository</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public LaunchPadPsxClick(IScotLogHook hook, ISscatLaunchPad launchPad, ILaunchPadPsxEvent item, SscatLane lane, IPsxDisplayRepository displayRepository, int timeout, bool enableHook)
            : base(hook, launchPad, item, lane, timeout, enableHook)
        {
            _displayRepository = displayRepository;
        }

        /// <summary>
        /// Runs the launch pad click event
        /// </summary>
        public override void Run()
        {
            try
            {
                LaunchPad.ClickAt(GetPosition(Item, _displayRepository.Load(Item.Context)));
                LaunchPad.PerformLaunchPadEvent(Item);
                base.Run();
            }
            catch (Exception ex)
            {
                Result = new Result(ResultType.Failed, Regex.Replace(ex.Message, @"\t|\n|\r", "; "));
            }
        }

        /// <summary>
        /// Gets the launch pad position point
        /// </summary>
        /// <param name="item">launch pad event</param>
        /// <param name="display">psx display</param>
        /// <returns>Returns the coordinate point for the launch pad click</returns>
        private Point GetPosition(ILaunchPadPsxEvent item, PsxDisplay display)
        {
            switch (item.Control)
            {
                case "AlphaNumKey3LaunchPad": return new Point(880, 540);
                case "KeyBoardP1":
                    switch (item.Param)
                    {
                        case "1": return new Point(400, 420);
                        case "2": return new Point(500, 420);
                        case "3": return new Point(600, 420);
                        case "4": return new Point(400, 340);
                        case "5": return new Point(500, 340);
                        case "6": return new Point(600, 340);
                        case "7": return new Point(400, 250);
                        case "8": return new Point(500, 250);
                        case "9": return new Point(600, 250);
                    }

                    break;
                case "AlphaNumP1":
                    switch (item.Param)
                    {
                        case "1": return new Point(50, 240);
                        case "2": return new Point(140, 240);
                        case "3": return new Point(220, 240);
                        case "4": return new Point(310, 240);
                        case "5": return new Point(400, 240);
                        case "6": return new Point(480, 240);
                        case "7": return new Point(570, 240);
                        case "8": return new Point(660, 240);
                        case "9": return new Point(740, 240);
                        case "0": return new Point(830, 240);
                    }

                    break;
                case "AlphaNumP2":
                    switch (item.Param.ToLower())
                    {
                        case "q": return new Point(50, 330);
                        case "w": return new Point(140, 330);
                        case "e": return new Point(220, 330);
                        case "r": return new Point(310, 330);
                        case "t": return new Point(400, 330);
                        case "y": return new Point(480, 330);
                        case "u": return new Point(570, 330);
                        case "i": return new Point(660, 330);
                        case "o": return new Point(740, 330);
                        case "p": return new Point(830, 330);
                    }

                    break;
                case "AlphaNumP3":
                    switch (item.Param.ToLower())
                    {
                        case "a": return new Point(100, 415);
                        case "s": return new Point(185, 415);
                        case "d": return new Point(270, 415);
                        case "f": return new Point(355, 415);
                        case "g": return new Point(440, 415);
                        case "h": return new Point(530, 415);
                        case "j": return new Point(610, 415);
                        case "k": return new Point(700, 415);
                        case "l": return new Point(785, 415);
                    }

                    break;
                case "AlphaNumP4":
                    switch (item.Param.ToLower())
                    {
                        case "z": return new Point(140, 500);
                        case "x": return new Point(225, 500);
                        case "c": return new Point(315, 500);
                        case "v": return new Point(400, 500);
                        case "b": return new Point(485, 500);
                        case "n": return new Point(570, 500);
                        case "m": return new Point(655, 500);
                        case ".": return new Point(740, 500);
                    }

                    break;
            }

            PsxControl c = display.Controls.GetControl(item.Control);
            PsxProperty p = c.Properties.GetProperty("Position");
            Rectangle rect = RectangleHelper.GetRectangle(p.Value.Split(','));
            ThreadHelper.Sleep(100);
            return RectangleHelper.GetRectangleCenterPoint(rect);
        }
    }
}
