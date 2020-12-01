// <copyright file="AbstractParser.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the AbstractParser class
    /// </summary>
    public abstract class AbstractParser : IParser
    {
        /// <summary>
        /// Parser has stopped or not
        /// </summary>
        private volatile bool _hasStopped = false;

        /// <summary>
        /// Parser has stopped or not
        /// </summary>
        private bool _isBinary = false;

        /// <summary>
        /// Interface for Extended text reader
        /// </summary>
        private IExtendedTextReader _reader;

        /// <summary>
        /// Binary Formatter
        /// </summary>
        private FileStream _stream;

        /// <summary>
        /// Parser name
        /// </summary>
        private string _name;

        /// <summary>
        /// Initializes a new instance of the AbstractParser class
        /// </summary>
        public AbstractParser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AbstractParser class
        /// </summary>
        /// <param name="name">parser name</param>
        /// <param name="reader">text reader</param>
        public AbstractParser(string name, IExtendedTextReader reader)
        {
            _name = name;
            _reader = reader;
        }

        /// <summary>
        /// Initializes a new instance of the AbstractParser class
        /// </summary>
        /// <param name="name">parser name</param>
        /// <param name="stream">stream reader</param>
        public AbstractParser(string name, FileStream stream)
        {
            _name = name;
            _stream = stream;
            _isBinary = true;
        }
        
        /// <summary>
        /// Finalizes an instance of the AbstractParser class
        /// </summary>
        ~AbstractParser()
        {
            if (_reader != null)
            {
                _reader.Close();
            }
        }

        /// <summary>
        /// Event handler for parse
        /// </summary>
        public event EventHandler<ProgressEventArgs> Parse;

        /// <summary>
        /// Gets or sets a value indicating whether or not the parser has stopped
        /// </summary>
        public bool HasStopped
        {
            get { return _hasStopped; }
            set { _hasStopped = value; }
        }
        
        /// <summary>
        /// Gets a value indicating whether or not the parser is binary
        /// </summary>
        public bool IsBinary
        {
            get { return _isBinary; }
        }

        /// <summary>
        /// Gets the parser name
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Perform parse
        /// </summary>
        /// <param name="reader">text reader</param>
        /// <returns>Returns the script event</returns>
        public abstract List<IScriptEvent> PerformParse(IExtendedTextReader reader);

        /// <summary>
        /// Perform parse
        /// </summary>
        /// <returns>Returns the script event</returns>
        public virtual List<IScriptEvent> PerformParse()
        {
            List<IScriptEvent> events = PerformParse(_reader);
            _reader.Close();
            return events;
        }

        /// <summary>
        /// Perform the binary parse
        /// </summary>
        /// <param name="stream">File stream</param>
        /// <returns>Returns the script event parsed out</returns>
        public abstract List<IScriptEvent> PerformBinaryParse(FileStream stream);

        /// <summary>
        /// Perform parse
        /// </summary>
        /// <returns>Returns the script event</returns>
        public virtual List<IScriptEvent> PerformBinaryParse()
        {
            List<IScriptEvent> events = PerformBinaryParse(_stream);
            _stream.Close();
            return events;
        }

        /// <summary>
        /// Parser has stopped
        /// </summary>
        public void Stop()
        {
            _hasStopped = true;
        }

        /// <summary>
        /// Close the reader
        /// </summary>
        public virtual void Dispose()
        {
            if (_reader != null)
            {
                _reader.Close();
            }
        }

        /// <summary>
        /// Event for on parse
        /// </summary>
        /// <param name="e">progress event arguments</param>
        protected virtual void OnParse(ProgressEventArgs e)
        {
            if (Parse != null)
            {
                Parse(this, e);
            }
        }

        /// <summary>
        /// Parse with a given message
        /// </summary>
        /// <param name="message">message to include during parsing</param>
        protected virtual void OnParse(string message)
        {
            OnParse(new ProgressEventArgs(message));
        }
    }
}
