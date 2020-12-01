// <copyright file="ImageHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Drawing;

    /// <summary>
    /// Initializes static members of the ImageHelper class
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// Image manager interface
        /// </summary>
        private static IImageManager _manager;

        /// <summary>
        /// Initializes static members of the ImageHelper class
        /// </summary>
        static ImageHelper()
        {
            Attach(new ImageManager());
        }

        /// <summary>
        /// Attach image manager
        /// </summary>
        /// <param name="manager">image manager</param>
        public static void Attach(IImageManager manager)
        {
            ImageHelper._manager = manager;
        }

        /// <summary>
        /// Image from file
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>Returns image</returns>
        public static Image FromFile(string path)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ImageManager");
            }

            return _manager.FromFile(path);
        }

        /// <summary>
        /// Save the image
        /// </summary>
        /// <param name="image">image to save</param>
        /// <param name="filename">file name</param>
        /// <param name="quality">quality amount</param>
        public static void Save(Image image, string filename, int quality)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ImageManager");
            }

            _manager.Save(image, filename, quality);
        }
    }
}
