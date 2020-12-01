//	<file>
//		<license></license>
//		<owner name="Marvin Casagnap" email="marvin.casagnap@ncr.com"/>
//	</file>

using System;
using System.Collections;

namespace Sscat.Core.Util
{
	public class DateTimeComparer : IComparer
	{
		bool sortDescending;
		
		public DateTimeComparer() : this(false)
		{
		}

		public DateTimeComparer(bool descending)
		{
			this.sortDescending = descending;
		}

		public int Compare(object x, object y)
		{
			if (x.ToString().IndexOf(",") > 0) {
				string a = x.ToString().Split(',')[0];
				string b = y.ToString().Split(',')[0];

				DateTime x2 = DateTime.Parse(a);
				DateTime y2 = DateTime.Parse(b);
                if (sortDescending) {
                    return y2.CompareTo(x2);
                } else {
                    return x2.CompareTo(y2);
                }
			} else {
				if ((x is DateTime) && (y is DateTime)) {
					DateTime x2 = (DateTime)x;
					DateTime y2 = (DateTime)y;
                    if (sortDescending) {
                        return y2.CompareTo(x2);
                    } else {
                        return x2.CompareTo(y2);
                    }
				}
			}
			return -1;
		}
	}
}
