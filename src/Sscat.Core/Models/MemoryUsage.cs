// <copyright file="MemoryUsage.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using Ncr.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the MemoryUsage class
    /// </summary>
    public class MemoryUsage : BaseModel<MemoryUsage>, IScriptEvent
    {
        /// <summary>
        /// Transaction number
        /// </summary>
        private int _transactionNumber;

        /// <summary>
        /// Date time
        /// </summary>
        private DateTime _date;

        /// <summary>
        /// Working set size
        /// </summary>
        private int _workingSetSize;

        /// <summary>
        /// Peak working set size
        /// </summary>
        private int _peakWorkingSetSize;

        /// <summary>
        /// Page file usage
        /// </summary>
        private int _pageFileUsage;

        /// <summary>
        /// Peak page file usage
        /// </summary>
        private int _peakPageFileUsage;

        /// <summary>
        /// Page fault count
        /// </summary>
        private int _pageFaultCount;

        /// <summary>
        /// Event result
        /// </summary>
        private Result _result;

        /// <summary>
        /// Initializes a new instance of the MemoryUsage class
        /// </summary>
        public MemoryUsage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the MemoryUsage class
        /// </summary>
        /// <param name="transactionNumber">transaction number</param>
        /// <param name="time">date time</param>
        /// <param name="workingSetSize">working set size</param>
        /// <param name="peakWorkingSetSize">peak working set size</param>
        /// <param name="pageFileUsage">page file usage</param>
        /// <param name="peekPageFileUsage">peek page file usage</param>
        /// <param name="pageFaultCount">page fault count</param>
        public MemoryUsage(int transactionNumber, DateTime time, int workingSetSize, int peakWorkingSetSize, int pageFileUsage, int peekPageFileUsage, int pageFaultCount)
        {
            TransactionNumber = transactionNumber;
            Date = time;
            WorkingSetSize = workingSetSize;
            PeakWorkingSetSize = peakWorkingSetSize;
            PageFileUsage = pageFileUsage;
            PeakPageFileUsage = peekPageFileUsage;
            PageFaultCount = pageFaultCount;
        }

        /// <summary>
        /// Event handler for result changed
        /// </summary>
        public event EventHandler<ResultEventArgs> ResultChanged;

        /// <summary>
        /// Gets or sets the result
        /// </summary>
        public Result Result
        {
            get
            {
                return _result;
            }

            set
            {
                _result = value;
                OnResultChanged(new ResultEventArgs(_result));
            }
        }

        /// <summary>
        /// Gets the type
        /// </summary>
        public string Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the screenshot link
        /// </summary>
        public string ScreenshotLink
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the script file name
        /// </summary>
        public string ScriptFileName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the new item value
        /// </summary>
        public string NewItemValue
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the Item
        /// </summary>
        public object Item
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the script index
        /// </summary>
        public int ScriptIndex
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the index
        /// </summary>
        public int Index
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the time
        /// </summary>
        public long Time
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the date ad time
        /// </summary>
        public DateTime DateAndTime
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the event's sequence id
        /// </summary>
        public int SequenceID
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the working set size in MB
        /// </summary>
        public double WorkingSetSizeInMB
        {
            get { return _workingSetSize / 1048576; }
        }

        /// <summary>
        /// Gets or sets the transaction number
        /// </summary>
        public int TransactionNumber
        {
            get { return _transactionNumber; }
            set { _transactionNumber = value; }
        }

        /// <summary>
        /// Gets or sets the date time
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        /// <summary>
        /// Gets or sets the working set size
        /// </summary>
        public int WorkingSetSize
        {
            get { return _workingSetSize; }
            set { _workingSetSize = value; }
        }

        /// <summary>
        /// Gets or sets the peak working set size
        /// </summary>
        public int PeakWorkingSetSize
        {
            get { return _peakWorkingSetSize; }
            set { _peakWorkingSetSize = value; }
        }

        /// <summary>
        /// Gets or sets the page file usage
        /// </summary>
        public int PageFileUsage
        {
            get { return _pageFileUsage; }
            set { _pageFileUsage = value; }
        }

        /// <summary>
        /// Gets or sets the peak page file usage
        /// </summary>
        public int PeakPageFileUsage
        {
            get { return _peakPageFileUsage; }
            set { _peakPageFileUsage = value; }
        }

        /// <summary>
        /// Gets or sets the page fault count
        /// </summary>
        public int PageFaultCount
        {
            get { return _pageFaultCount; }
            set { _pageFaultCount = value; }
        }

        /// <summary>
        /// Creates a string format with all the data pertaining to memory usage
        /// </summary>
        /// <returns>Returns all the info formatted</returns>
        public override string ToString()
        {
            return string.Format(
                "{0},{1},{2},{3},{4},{5},{6},{7}",
                TransactionNumber,
                Date.ToString("hh:mm:ss"),
                WorkingSetSize,
                PeakWorkingSetSize,
                PageFileUsage,
                PeakPageFileUsage,
                PageFaultCount,
                WorkingSetSizeInMB);
        }

        /// <summary>
        /// Creates a string about the script event
        /// </summary>
        /// <returns>Returns the script event information</returns>
        public IScriptEvent ToEvent()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if the given event is similar to this event
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        /// <returns>True if same, false otherwise</returns>
        public bool IsSimilarEvent(IScriptEvent scriptEvent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event for on result changed
        /// </summary>
        /// <param name="e">result event arguments</param>
        protected virtual void OnResultChanged(ResultEventArgs e)
        {
            if (ResultChanged != null)
            {
                ResultChanged(this, e);
            }
        }
    }
}
