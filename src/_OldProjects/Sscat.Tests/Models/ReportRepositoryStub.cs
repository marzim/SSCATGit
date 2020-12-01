//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.IO;

using Ncr.Core;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Repositories;

namespace Sscat.Tests.Models
{
	public class ReportRepositoryStub : BaseRepository, IReportRepository
	{
		public void Save(Report playback)
		{
			OnAccessing(new NcrEventArgs("Saving " + playback.ToString()));
		}
		
		public void Save(Report playback, string text)
		{
		}
		
		public ArrayList FindAll()
		{
			throw new NotImplementedException();
		}
		
		public Report Read(string file)
		{
			throw new NotImplementedException();
		}
	}
}
