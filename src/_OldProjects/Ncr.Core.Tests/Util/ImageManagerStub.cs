//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	public class ImageManagerStub : IImageManager
	{
		public Image FromFile(string path)
		{
			return new PictureBox().Image;
		}
		
		public void Save(Bitmap bitmap, string filename, ImageFormat format)
		{
		}
		
		public void Save(Image image, string filename, int quality)
		{
		}
	}
}
