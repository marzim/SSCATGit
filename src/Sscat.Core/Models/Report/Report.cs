// <copyright file="Report.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.Report
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Ncr.Core.Net;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the Report class
    /// </summary>
    [Serializable]
    public class Report : BaseModel<Report>, IReport, IContent
    {
        /// <summary>
        /// Report scripts
        /// </summary>
        private ReportScript[] _scripts;

        /// <summary>
        /// Script file name
        /// </summary>
        private string _fileName;

        /// <summary>
        /// Script date time
        /// </summary>
        private DateTime _dateTime;
        
        /// <summary>
        /// Initializes a new instance of the Report class
        /// </summary>
        public Report()
            : this(DnsHelper.GetHostName() + DateTime.Now.ToString("-yyyyMMdd-HHmmss") + ".xml")
        {
        }

        /// <summary>
        /// Initializes a new instance of the Report class
        /// </summary>
        /// <param name="repeat">repeat times</param>
        public Report(int repeat)
            : this(string.Format("{0}-{1}-{2}.xml", DnsHelper.GetHostName(), repeat, DateTime.Now.ToString("yyyyMMdd-HHmmss")))
        {
        }

        /// <summary>
        /// Initializes a new instance of the Report class
        /// </summary>
        /// <param name="fileName">file name</param>
        public Report(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Gets or sets the date time
        /// </summary>
        [XmlAttribute("Date")]
        public DateTime Date
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        /// <summary>
        /// Gets or sets the file name
        /// </summary>
        [XmlAttribute("FileName")]
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        /// Gets or sets the scripts
        /// </summary>
        [XmlElement("Script")]
        public ReportScript[] Scripts
        {
            get
            {
                if (_scripts == null)
                {
                    _scripts = new ReportScript[0];
                }

                return _scripts;
            }

            set
            {
                _scripts = value;
            }
        }

        /// <summary>
        /// Disposes of the scripts
        /// </summary>
        public override void Dispose()
        {
            Scripts = new ReportScript[0];
        }

        /// <summary>
        /// Adds scripts
        /// </summary>
        /// <param name="scripts">scripts to add</param>
        public void AddScript(ReportScript[] scripts)
        {
            foreach (ReportScript script in scripts)
            {
                AddScript(script);
            }
        }

        /// <summary>
        /// Adds a script
        /// </summary>
        /// <param name="script">script to add</param>
        public void AddScript(ReportScript script)
        {
            List<ReportScript> a = new List<ReportScript>(Scripts);
            a.Add(script);
            _scripts = new ReportScript[a.Count];
            a.CopyTo(_scripts);
        }
    }
}
