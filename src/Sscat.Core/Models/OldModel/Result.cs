// <copyright file="Result.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.OldModel
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the Result class
    /// </summary>
    [XmlRoot("Result"), Serializable()]
    public class Result
    {
        /// <summary>
        /// Result Type
        /// </summary>
        private string _type = string.Empty;

        /// <summary>
        /// Screenshot path
        /// </summary>
        private string _screenshotPath = string.Empty;

        /// <summary>
        /// Diagnostic path
        /// </summary>
        private string _diagnosticPath = string.Empty;

        /// <summary>
        /// Screenshot link
        /// </summary>
        private string _screenshotLink = string.Empty;

        /// <summary>
        /// Expected result
        /// </summary>
        private string _expectedResult = string.Empty;

        /// <summary>
        /// Actual result
        /// </summary>
        private string _actualResult = string.Empty;

        /// <summary>
        /// Repetition index
        /// </summary>
        private int _repetitionIndex = 0;

        /// <summary>
        /// Number of warnings
        /// </summary>
        private int _numberOfWarnings = 0;

        /// <summary>
        /// Script duration
        /// </summary>
        private int _duration = 0;

        /// <summary>
        /// Initializes a new instance of the Result class
        /// </summary>
        public Result()
        {
        }

        /// <summary>
        /// Gets or sets the result notes
        /// </summary>
        [XmlAttribute("Type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets or sets the number of warnings
        /// </summary>
        [XmlAttribute("NumberOfWarnings")]
        public int NumberOfWarnings
        {
            get { return _numberOfWarnings; }
            set { _numberOfWarnings = value; }
        }

        /// <summary>
        /// Gets or sets the repetition index
        /// </summary>
        [XmlAttribute("RepetitionIndex")]
        public int RepetitionIndex
        {
            get { return _repetitionIndex; }
            set { _repetitionIndex = value; }
        }

        /// <summary>
        /// Gets or sets the expected result
        /// </summary>
        [XmlAttribute("ExpectedResult")]
        public string ExpectedResult
        {
            get
            {
                if (_expectedResult == null)
                {
                    _expectedResult = string.Empty;
                }

                return _expectedResult;
            }

            set
            {
                _expectedResult = value;
            }
        }

        /// <summary>
        /// Gets or sets the actual result
        /// </summary>
        [XmlAttribute("ActualResult")]
        public string ActualResult
        {
            get
            {
                if (_actualResult == null)
                {
                    _actualResult = string.Empty;
                }

                return _actualResult;
            }

            set
            {
                _actualResult = value;
            }
        }

        /// <summary>
        /// Gets or sets the screenshot path
        /// </summary>
        [XmlAttribute("ScreenshotPath")]
        public string ScreenshotPath
        {
            get
            {
                if (_screenshotPath == null)
                {
                    _screenshotPath = string.Empty;
                }

                return _screenshotPath;
            }

            set
            {
                _screenshotPath = value;
            }
        }

        /// <summary>
        /// Gets or sets the diagnostic path
        /// </summary>
        [XmlAttribute("DiagnosticPath")]
        public string DiagnosticPath
        {
            get
            {
                if (_diagnosticPath == null)
                {
                    _diagnosticPath = string.Empty;
                }

                return _diagnosticPath;
            }

            set
            {
                _diagnosticPath = value;
            }
        }

        /// <summary>
        /// Gets or sets the screenshot link
        /// </summary>
        [XmlAttribute("ScreenshotLink")]
        public string ScreenshotLink
        {
            get
            {
                if (_screenshotLink == null)
                {
                    _screenshotLink = string.Empty;
                }

                return _screenshotLink;
            }

            set
            {
                _screenshotLink = value;
            }
        }

        /// <summary>
        /// Gets or sets the script duration in milliseconds.
        /// </summary>
        [XmlAttribute("Duration")]
        public virtual int Duration
        {
            get
            {
                return _duration;
            }

            set
            {
                _duration = value;
            }
        }
    }
}
