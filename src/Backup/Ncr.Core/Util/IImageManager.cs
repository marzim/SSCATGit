// <copyright file="IImageManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.Drawing;
    using System.Drawing.Imaging;

    /// <summary>
    /// Initializes a new instance of the IImageManager interface
    /// </summary>
    public interface IImageManager
    {
        /// <summary>
        /// Image from file
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>Returns image</returns>
        Image FromFile(string path);

        /// <summary>
        /// Save the image
        /// </summary>
        /// <param name="bitmap">image bitmap</param>
        /// <param name="filename">file name</param>
        /// <param name="format">image format</param>
        void Save(Bitmap bitmap, string filename, ImageFormat format);

        /// <summary>
        /// Save the image
        /// </summary>
        /// <param name="image">image to save</param>
        /// <param name="filename">file name</param>
        /// <param name="quality">quality amount</param>
        void Save(Image image, string filename, int quality);
    }
}
