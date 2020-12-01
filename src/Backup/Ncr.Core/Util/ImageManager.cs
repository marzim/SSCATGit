// <copyright file="ImageManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Util
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    
    /// <summary>
    /// Initializes a new instance of the ImageManager class
    /// </summary>
    public class ImageManager : IImageManager
    {
        /// <summary>
        /// Image from file
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>Returns image</returns>
        public Image FromFile(string path)
        {
            return Image.FromFile(path);
        }

        /// <summary>
        /// Save the image
        /// </summary>
        /// <param name="bitmap">image bitmap</param>
        /// <param name="filename">file name</param>
        /// <param name="format">image format</param>
        public void Save(Bitmap bitmap, string filename, ImageFormat format)
        {
            bitmap.Save(filename, format);
        }

        /// <summary>
        /// Save the image
        /// </summary>
        /// <param name="image">image to save</param>
        /// <param name="filename">file name</param>
        /// <param name="quality">quality amount</param>
        public void Save(Image image, string filename, int quality)
        {
            if (quality < 0 || quality > 100)
            {
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");
            }

            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            image.Save(filename, jpegCodec, encoderParams);
        }

        /// <summary>
        /// Get encoder information
        /// </summary>
        /// <param name="mimeType">mime type</param>
        /// <returns>Returns the image codec information</returns>
        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < codecs.Length; i++)
            {
                if (codecs[i].MimeType == mimeType)
                {
                    return codecs[i];
                }
            }

            return null;
        }
    }
}
