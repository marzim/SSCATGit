// <copyright file="Result.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Ncr.Core.Net;

    /// <summary>
    /// Result event handler delegate
    /// </summary>
    /// <param name="sender">object sender</param>
    /// <param name="e">result event arguments</param>
    public delegate void ResultEventHandler(object sender, ResultEventArgs e);

    /// <summary>
    /// Result types for the events
    /// </summary>
    public enum ResultType
    {
        /// <summary>
        /// Result none
        /// </summary>
        None,

        /// <summary>
        /// Result passed
        /// </summary>
        Passed,

        /// <summary>
        /// Result failed
        /// </summary>
        Failed,

        /// <summary>
        /// Result skipped
        /// </summary>
        Skipped,

        /// <summary>
        /// Result exception
        /// </summary>
        Exception,

        /// <summary>
        /// Result unknown
        /// </summary>
        Unknown,

        /// <summary>
        /// Result running
        /// </summary>
        Running,

        /// <summary>
        /// Result stopped
        /// </summary>
        Stopped,

        /// <summary>
        /// Result warning
        /// </summary>
        Warning,

        /// <summary>
        /// Result error
        /// </summary>
        Error
    }

    /// <summary>
    /// Initializes a new instance of the Result class
    /// </summary>
    [Serializable]
    public class Result : BaseSerializable<Result>, IContent
    {
        /// <summary>
        /// Result type
        /// </summary>
        private ResultType _type;

        /// <summary>
        /// Result notes
        /// </summary>
        private string _notes;

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
            : this(ResultType.None, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Result class
        /// </summary>
        /// <param name="result">result type</param>
        public Result(ResultType result)
            : this(result, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Result class
        /// </summary>
        /// <param name="result">result type</param>
        /// <param name="notes">result notes</param>
        public Result(ResultType result, string notes)
            : this(result, notes, string.Empty, string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Result class
        /// </summary>
        /// <param name="result">result type</param>
        /// <param name="notes">result notes</param>
        /// <param name="numberOfWarnings">number of warnings</param>
        public Result(ResultType result, string notes, int numberOfWarnings)
        {
            _type = result;
            _notes = notes;
            _numberOfWarnings = numberOfWarnings;
        }

        /// <summary>
        /// Initializes a new instance of the Result class
        /// </summary>
        /// <param name="result">result type</param>
        /// <param name="notes">result notes</param>
        /// <param name="numberOfWarnings">number of warnings</param>
        /// <param name="repetitionIndex">repetition index</param>
        public Result(ResultType result, string notes, int numberOfWarnings, int repetitionIndex)
        {
            _type = result;
            _notes = notes;
            _numberOfWarnings = numberOfWarnings;
            _repetitionIndex = repetitionIndex;
        }

        /// <summary>
        /// Initializes a new instance of the Result class
        /// </summary>
        /// <param name="result">result type</param>
        /// <param name="notes">result notes</param>
        /// <param name="screenshotPath">screenshot path</param>
        /// <param name="diagnosticPath">diagnostic path</param>
        /// <param name="screenshotLink">screenshot link</param>
        public Result(ResultType result, string notes, string screenshotPath, string diagnosticPath, string screenshotLink)
        {
            Type = result;
            Notes = notes;
            ScreenshotPath = screenshotPath;
            DiagnosticPath = diagnosticPath;
            ScreenshotLink = screenshotLink;
        }

        /// <summary>
        /// Initializes a new instance of the Result class
        /// </summary>
        /// <param name="result">result type</param>
        /// <param name="expectedResult">expected result</param>
        /// <param name="actualResult">actual result</param>
        /// <param name="notes">result notes</param>
        public Result(ResultType result, string expectedResult, string actualResult, string notes)
        {
           Type = result;
           _expectedResult = expectedResult;
           _actualResult = actualResult;
           _notes = notes;
        }

        /// <summary>
        /// Gets a value indicating whether or not the result was a failure
        /// </summary>
        public bool IsFailure
        {
            get { return _type == ResultType.Failed || _type == ResultType.Exception; }
        }

        /// <summary>
        /// Gets a value indicating whether or not the result was an error
        /// </summary>
        public bool IsError
        {
            get { return _type == ResultType.Error; }
        }

        /// <summary>
        /// Gets or sets the result type
        /// </summary>
        [XmlAttribute("Type")]
        public ResultType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets or sets the result notes
        /// </summary>
        [XmlAttribute("Notes")]
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
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

        /// <summary>
        /// Formats the ToString to include the result type
        /// </summary>
        /// <returns>Returns the formatted string with result information</returns>
        public override string ToString()
        {
            return string.Format("{0}", Type);
        }

        /// <summary>
        /// Formats the ToRepresentation to include the result type, notes, expected result, and actual result
        /// </summary>
        /// <returns>Returns the formatted string with result information</returns>
        public string ToRepresentation()
        {
            if (Type.Equals(ResultType.Warning))
            {
                return string.Format("{0}, {1} - Expected: {2}; Actual: {3}", Type, Notes, ExpectedResult, ActualResult);
            }
            else
            {
                return string.Format("EventStatus = {0}; {1}", Type, Notes);
            }
        }

        /// <summary>
        /// ShouldSerialize* pattern for Type
        /// </summary>
        /// <returns>returns if Type is ResultType.None</returns>
        public bool ShouldSerializeType()
        {
            return !(Type == ResultType.None);
        }

        /// <summary>
        /// ShouldSerialize* pattern for NumberOfWarnings
        /// </summary>
        /// <returns>returns if NumberOfWarnings is null or empty</returns>
        public bool ShouldSerializeNumberOfWarnings()
        {
            return !NumberOfWarnings.Equals(0);
        }

        /// <summary>
        /// ShouldSerialize* pattern for RepetitionIndex
        /// </summary>
        /// <returns>returns if RepetitionIndex is null or empty</returns>
        public bool ShouldSerializeRepetitionIndex()
        {
            return !RepetitionIndex.Equals(0);
        }

        /// <summary>
        /// ShouldSerialize* pattern for Notes
        /// </summary>
        /// <returns>returns if Notes is null or empty</returns>
        public bool ShouldSerializeNotes()
        {
            return !string.IsNullOrEmpty(Notes);
        }

        /// <summary>
        /// ShouldSerialize* pattern for ActualResult
        /// </summary>
        /// <returns>returns if ActualResult is null or empty</returns>
        public bool ShouldSerializeActualResult()
        {
            return !string.IsNullOrEmpty(ActualResult);
        }

        /// <summary>
        /// ShouldSerialize* pattern for ExpectedResult
        /// </summary>
        /// <returns>returns if ExpectedResult is null or empty</returns>
        public bool ShouldSerializeExpectedResult()
        {
            return !string.IsNullOrEmpty(ExpectedResult);
        }

        /// <summary>
        /// ShouldSerialize* pattern for ScreenshotPath
        /// </summary>
        /// <returns>returns if ScreenshotPath is null or empty</returns>
        public bool ShouldSerializeScreenshotPath()
        {
            return !string.IsNullOrEmpty(ScreenshotPath);
        }

        /// <summary>
        /// ShouldSerialize* pattern for DiagnosticPath
        /// </summary>
        /// <returns>returns if DiagnosticPath is null or empty</returns>
        public bool ShouldSerializeDiagnosticPath()
        {
            return !string.IsNullOrEmpty(DiagnosticPath);
        }

        /// <summary>
        /// ShouldSerialize* pattern for ScreenshotLink
        /// </summary>
        /// <returns>returns if ScreenshotLink is null or empty</returns>
        public bool ShouldSerializeScreenshotLink()
        {
            return !string.IsNullOrEmpty(ScreenshotLink);
        }

        /// <summary>
        /// ShouldSerialize* pattern for Duration
        /// </summary>
        /// <returns>returns if Duration is null or empty</returns>
        public bool ShouldSerializeDuration()
        {
            return !Duration.Equals(0);
        }
    }
}
