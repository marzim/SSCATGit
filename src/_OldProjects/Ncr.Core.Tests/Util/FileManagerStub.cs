//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	public class FileManagerStub : FileManager
	{
		public override bool Exists(string path)
		{
			return path != @"C:\Not.Found";
		}
		
		public override Version GetFileVersion(string filename)
		{
			return new Version(3, 0, 0, 0);
		}
		
		public override void Copy(string source, string destination)
		{
		}
		
		public override void Create(string path)
		{
		}
		
		public override void Delete(string path)
		{
		}
		
		public override string ReadToEnd(string filename)
		{
			return "Chuck Norris";
		}
		
		public override string GetExtension(string filePath)
		{
			return "";
		}
	}
}
