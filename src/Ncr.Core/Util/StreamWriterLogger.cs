// <copyright file="StreamWriterLogger.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.IO;

    /// <summary>
    /// Initializes a new instance of the StreamWriterLogger class
    /// </summary>
    public class StreamWriterLogger : AbstractLogger
    {
        /// <summary>
        /// Writer Lock
        /// </summary>
        private readonly object _writerLock = new object();

        /// <summary>
        /// Path name
        /// </summary>
        private string _path;

        /// <summary>
        /// Initializes a new instance of the StreamWriterLogger class
        /// </summary>
        /// <param name="path">path name</param>
        /// <param name="formatter">log formatter</param>
        public StreamWriterLogger(string path, ILogFormatter formatter)
            : base(formatter)
        {
            DirectoryHelper.CreateDirectory(Path.GetDirectoryName(path));
            _path = path;
        }

        /// <summary>
        /// Create message
        /// </summary>
        /// <param name="message">message to log</param>
        public override void Create(string message)
        {
            lock (_writerLock)
            {
                using (StreamWriter w = new StreamWriter(_path, true))
                {
                    w.WriteLine(Formatter.Format(message, LogLevel.Create));
                }
            }
        }

        /// <summary>
        /// Debug message
        /// </summary>
        /// <param name="message">message to log</param>
        public override void Debug(string message)
        {
            lock (_writerLock)
            {
                using (StreamWriter w = new StreamWriter(_path, true))
                {
                    w.WriteLine(Formatter.Format(message, LogLevel.Debug));
                }
            }
        }

        /// <summary>
        /// Error message
        /// </summary>
        /// <param name="message">message to log</param>
        public override void Error(string message)
        {
            lock (_writerLock)
            {
                using (StreamWriter w = new StreamWriter(_path, true))
                {
                    w.WriteLine(Formatter.Format(message, LogLevel.Error));
                }
            }
        }

        /// <summary>
        /// Exists message
        /// </summary>
        /// <param name="message">message to log</param>
        public override void Exists(string message)
        {
            lock (_writerLock)
            {
                using (StreamWriter w = new StreamWriter(_path, true))
                {
                    w.WriteLine(Formatter.Format(message, LogLevel.Exists));
                }
            }
        }

        /// <summary>
        /// Information message
        /// </summary>
        /// <param name="message">message to log</param>
        public override void Info(string message)
        {
            lock (_writerLock)
            {
                using (StreamWriter w = new StreamWriter(_path, true))
                {
                    w.WriteLine(Formatter.Format(message, LogLevel.Info));
                }
            }
        }

        /// <summary>
        /// Warning message
        /// </summary>
        /// <param name="message">message to log</param>
        public override void Warning(string message)
        {
            lock (_writerLock)
            {
                using (StreamWriter w = new StreamWriter(_path, true))
                {
                    w.WriteLine(Formatter.Format(message, LogLevel.Warning));
                }
            }
        }
    }
}
