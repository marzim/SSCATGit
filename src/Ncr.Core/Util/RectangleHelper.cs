// <copyright file="RectangleHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.Drawing;

    /// <summary>
    /// Initializes static members of the RectangleHelper class
    /// </summary>
    public static class RectangleHelper
    {
        /// <summary>
        /// Get rectangle
        /// </summary>
        /// <param name="position">rectangle position</param>
        /// <returns>Returns the rectangle</returns>
        public static Rectangle GetRectangle(string[] position)
        {
            return new Rectangle(ConvertUtility.ToInt32(position[0], true), ConvertUtility.ToInt32(position[1], true), ConvertUtility.ToInt32(position[2], true), ConvertUtility.ToInt32(position[3], true));
        }

        /// <summary>
        /// Get rectangle the center point
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="width">rectangle width</param>
        /// <param name="height">rectangle height</param>
        /// <returns>Returns the rectangle center point</returns>
        public static Point GetRectangleCenterPoint(int x, int y, int width, int height)
        {
            return GetRectangleCenterPoint(new Rectangle(x, y, width, height));
        }

        /// <summary>
        /// Get rectangle the center point
        /// </summary>
        /// <param name="rect">rectangle to check</param>
        /// <returns>Returns the rectangle center point</returns>
        public static Point GetRectangleCenterPoint(Rectangle rect)
        {
            return new Point(rect.X + (rect.Width / 2), rect.Y + (rect.Height / 2));
        }
    }
}
