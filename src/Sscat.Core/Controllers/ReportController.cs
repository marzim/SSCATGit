//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Controllers;
using Ncr.Core.Views;
using Sscat.Core.Models;
using Sscat.Core.Models.Dao;
using Sscat.Core.Views;

namespace Sscat.Core.Controllers
{
	public interface IReportController : IController
	{
		IView Index();
	}
	
	public class ReportController : AbstractController, IReportController
	{
		IReportView reportView;
		
		public ReportController(StringReader reader, IReportView reportView) : this(Report.Deserialize(reader), reportView)
		{
		}
		
		public ReportController(IReport report, IReportView reportView)
		{
			this.reportView = reportView;
		}
		
		public IView Index()
		{
			return reportView;
		}
	}
}
