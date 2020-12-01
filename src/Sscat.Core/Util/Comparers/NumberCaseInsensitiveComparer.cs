//	<file>
//		<license></license>
//		<owner name="Marvin Casagnap" email="marvin.casagnap@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Sscat.Core
{
    public class NumberCaseInsensitiveComparer : CaseInsensitiveComparer
    {
        public NumberCaseInsensitiveComparer()
        {
        }

        public new int Compare(object x, object y)
        {
            // in case x,y are strings and actually number,
            // convert them to int and use the base.Compare for comparison
            if ((x is System.String) && IsWholeNumber((string)x)
                && (y is System.String) && IsWholeNumber((string)y)) {
                return base.Compare(System.Convert.ToInt32(x), System.Convert.ToInt32(y));
            } else {
                return base.Compare(x, y);
            }
        }

        private bool IsWholeNumber(string strNumber)
        {
            // use a regular expression to find out if string is actually a number
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strNumber);
        }
    }
}