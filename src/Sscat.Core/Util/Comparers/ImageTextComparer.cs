//	<file>
//		<license></license>
//		<owner name="Marvin Casagnap" email="marvin.casagnap@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.Windows.Forms;

namespace Sscat.Core
{
	public class ImageTextComparer : IComparer
	{
		//private CaseInsensitiveComparer ObjectCompare;
		private NumberCaseInsensitiveComparer objectCompare;
	
		public ImageTextComparer()
		{
			// Initialize the CaseInsensitiveComparer object
			objectCompare = new NumberCaseInsensitiveComparer();
		}

		public int Compare(object x, object y)
		{
			//int compareResult;
			int image1, image2;
			ListViewItem listviewX, listviewY;
			// Cast the objects to be compared to ListViewItem objects
			listviewX = (ListViewItem)x;
			image1 = listviewX.ImageIndex;
			listviewY = (ListViewItem)y;
			image2 = listviewY.ImageIndex;
			if (image1 < image2) {
				return -1;
			} else if (image1 == image2) {
				return objectCompare.Compare(listviewX.Text, listviewY.Text);
			} else {
				return 1;
			}
		}
	}
}
