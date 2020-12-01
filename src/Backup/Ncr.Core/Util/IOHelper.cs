// <copyright file="IOHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Collections;
    using System.IO;

    /// <summary>
    /// Initializes a new instance of the IOHelper class
    /// </summary>
    public class IOHelper
    {
        /// <summary>
        /// Read all lines from file
        /// </summary>
        /// <param name="file">file to read</param>
        /// <returns>Returns the array list from the file</returns>
        public static ArrayList ReadAllLines(string file)
        {
            ArrayList temp = new ArrayList();
            try
            {
                using (TextReader tr = new StreamReader(file))
                {
                    string s = string.Empty;
                    while ((s = tr.ReadLine()) != null)
                    {
                        temp.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                throw ex;
            }

            return temp;
        }
    }
}
