// <copyright file="Gdi32.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.PInvoke
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Enables applications to use graphics and formatted text on both the video display and the printer.
    /// </summary>
    public static class Gdi32
    {
        /// <summary>
        /// Copies the source rectangle directly to the destination rectangle.
        /// </summary>
        public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter

        /// <summary>
        /// Performs a bit-block transfer of the color data corresponding to a rectangle of pixels from the specified source device context into a destination device context.
        /// </summary>
        /// <param name="handle">A handle to the destination device context.</param>
        /// <param name="xDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
        /// <param name="yDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</param>
        /// <param name="width">The width, in logical units, of the source and destination rectangles.</param>
        /// <param name="height">The height, in logical units, of the source and the destination rectangles.</param>
        /// <param name="objectSource">A handle to the source device context.</param>
        /// <param name="xSrc">The x-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
        /// <param name="ySrc">The y-coordinate, in logical units, of the upper-left corner of the source rectangle.</param>
        /// <param name="rasterOp">A raster-operation code. These codes define how the color data for the source rectangle is to be combined with the color data for the destination rectangle to achieve the final color.</param>
        /// <returns>If the function succeeds, the return value is nonzero, otherwise the return value is zero.</returns>
        [DllImportAttribute("gdi32.dll")]
        public static extern bool BitBlt(IntPtr handle, int xDest, int yDest, int width, int height, IntPtr objectSource, int xSrc, int ySrc, int rasterOp);

        /// <summary>
        /// Creates a bitmap compatible with the device that is associated with the specified device context.
        /// </summary>
        /// <param name="hDC">A handle to a device context.</param>
        /// <param name="width">The bitmap width, in pixels.</param>
        /// <param name="height">The bitmap height, in pixels.</param>
        /// <returns>If the function succeeds, the return value is a handle to the compatible bitmap, otherwise the return value is NULL.</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int width, int height);

        /// <summary>
        /// Creates a memory device context (DC) compatible with the specified device.
        /// </summary>
        /// <param name="hDC">A handle to an existing DC. If this handle is NULL, the function creates a memory DC compatible with the application's current screen.</param>
        /// <returns>If the function succeeds, the return value is the handle to a memory DC, otherwise the return value is NULL.</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        /// <summary>
        /// Deletes the specified device context (DC).
        /// </summary>
        /// <param name="hDC">A handle to the device context.</param>
        /// <returns>If the function succeeds, the return value is nonzero, otherwise the return value is zero</returns>
        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hDC);

        /// <summary>
        /// Deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated with the object. After the object is deleted, the specified handle is no longer valid.
        /// </summary>
        /// <param name="handle">A handle to a logical pen, brush, font, bitmap, region, or palette.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the specified handle is not valid or is currently selected into a DC, the return value is zero.</returns>
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr handle);

        /// <summary>
        /// Selects an object into the specified device context (DC). The new object replaces the previous object of the same type.
        /// </summary>
        /// <param name="hDC">A handle to the DC.</param>
        /// <param name="handle">A handle to the object to be selected. The specified object must have been created by using one of the following functions.</param>
        /// <returns>If the selected object is not a region and the function succeeds, the return value is a handle to the object being replaced. If the selected object is a region and the function succeeds, the return value is one of the following values.</returns>
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr handle);

        /// <summary>
        /// Captures window of the given handle
        /// </summary>
        /// <param name="handle">window handle</param>
        /// <returns>Returns the image captured.</returns>
        public static Image CaptureWindow(IntPtr handle)
        {
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            RECT window = new RECT();
            User32.GetWindowRect(handle, out window);

            int width = window.Right - window.Left;
            int height = window.Bottom - window.Top;

            IntPtr hdcDest = CreateCompatibleDC(hdcSrc);
            IntPtr bitMap = CreateCompatibleBitmap(hdcSrc, width, height);
            IntPtr hold = SelectObject(hdcDest, bitMap);

            BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, SRCCOPY);
            SelectObject(hdcDest, hold);
            DeleteDC(hdcDest);

            User32.ReleaseDC(handle, hdcSrc);
            Image img = Image.FromHbitmap(bitMap);
            DeleteObject(bitMap);
            return img;
        }

        /// <summary>
        /// Captures the desktop window
        /// </summary>
        /// <returns>Returns image of the desktop window</returns>
        public static Image CaptureDesktop()
        {
            return CaptureWindow(User32.GetDesktopWindow());
        }
    }
}
