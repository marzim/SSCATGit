// <copyright file="StringLogicalComparer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the StringLogicalComparer class
    /// </summary>
    public static class StringLogicalComparer
    {
        /// <summary>
        /// Compares two strings
        /// </summary>
        /// <param name="s1">string one</param>
        /// <param name="s2">string two</param>
        /// <returns>Returns a numerical value based on comparing the two strings</returns>
        public static int Compare(string s1, string s2)
        {
            // get rid of special cases
            if ((s1 == null) && (s2 == null))
            {
                return 0;
            }
            else if (s1 == null)
            {
                return -1;
            }
            else if (s2 == null)
            {
                return 1;
            }

            if (s1.Equals(string.Empty) && s2.Equals(string.Empty))
            {
                return 0;
            }
            else if (s1.Equals(string.Empty))
            {
                return -1;
            }
            else if (s2.Equals(string.Empty))
            {
                return -1;
            }

            // WE style, special case
            bool sp1 = char.IsLetterOrDigit(s1, 0);
            bool sp2 = char.IsLetterOrDigit(s2, 0);

            if (sp1 && !sp2)
            {
                return 1;
            }

            if (!sp1 && sp2)
            {
                return -1;
            }

            int i1 = 0, i2 = 0; // current index
            int r = 0; // temp result

            while (true)
            {
                bool c1 = char.IsDigit(s1, i1);
                bool c2 = char.IsDigit(s2, i2);
                if (!c1 && !c2)
                {
                    bool letter1 = char.IsLetter(s1, i1);
                    bool letter2 = char.IsLetter(s2, i2);

                    if ((letter1 && letter2) || (!letter1 && !letter2))
                    {
                        if (letter1 && letter2)
                        {
                            r = char.ToLower(s1[i1]).CompareTo(char.ToLower(s2[i2]));
                        }
                        else
                        {
                            r = s1[i1].CompareTo(s2[i2]);
                        }

                        if (r != 0)
                        {
                            return r;
                        }
                    }
                    else if (!letter1 && letter2)
                    {
                        return -1;
                    }
                    else if (letter1 && !letter2)
                    {
                        return 1;
                    }
                }
                else if (c1 && c2)
                {
                    r = CompareNum(s1, ref i1, s2, ref i2);

                    if (r != 0)
                    {
                        return r;
                    }
                }
                else if (c1)
                {
                    return -1;
                }
                else if (c2)
                {
                    return 1;
                }

                i1++;
                i2++;

                if ((i1 >= s1.Length) && (i2 >= s2.Length))
                {
                    return 0;
                }
                else if (i1 >= s1.Length)
                {
                    return -1;
                }
                else if (i2 >= s2.Length)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Compare numeric values
        /// </summary>
        /// <param name="s1">string one</param>
        /// <param name="i1">integer one</param>
        /// <param name="s2">string two</param>
        /// <param name="i2">integer two</param>
        /// <returns>Returns the numeric result from comparing the two strings with their start points</returns>
        private static int CompareNum(string s1, ref int i1, string s2, ref int i2)
        {
            int nonZeroStart1 = i1, nonZeroStart2 = i2; // nz = non zero
            int end1 = i1, end2 = i2;

            ScanNumEnd(s1, i1, ref end1, ref nonZeroStart1);
            ScanNumEnd(s2, i2, ref end2, ref nonZeroStart2);

            int start1 = i1; 
            i1 = end1 - 1;

            int start2 = i2; 
            i2 = end2 - 1;

            int nonZeroLength1 = end1 - nonZeroStart1;
            int nonZeroLength2 = end2 - nonZeroStart2;

            if (nonZeroLength1 < nonZeroLength2)
            {
                return -1;
            }
            else if (nonZeroLength1 > nonZeroLength2)
            {
                return 1;
            }

            for (int j1 = nonZeroStart1, j2 = nonZeroStart2; j1 <= i1; j1++, j2++)
            {
                int r = s1[j1].CompareTo(s2[j2]);
                if (r != 0)
                {
                    return r;
                }
            }

            // The nz parts are equal
            int length1 = end1 - start1;
            int length2 = end2 - start2;

            if (length1 == length2)
            {
                return 0;
            }

            if (length1 > length2)
            {
                return -1;
            }

            return 1;
        }

        /// <summary>
        /// Scans the number to the end
        /// </summary>
        /// <param name="s">given string</param>
        /// <param name="start">start index</param>
        /// <param name="end">end index</param>
        /// <param name="nonZeroStart">non zero start</param>
        private static void ScanNumEnd(string s, int start, ref int end, ref int nonZeroStart)
        {
            nonZeroStart = start;
            end = start;
            bool countZeros = true;

            while (char.IsDigit(s, end))
            {
                if (countZeros && s[end].Equals('0'))
                {
                    nonZeroStart++;
                }
                else
                {
                    countZeros = false;
                }

                end++;
                
                if (end >= s.Length)
                {
                    break;
                }
            }
        }
    }
}
