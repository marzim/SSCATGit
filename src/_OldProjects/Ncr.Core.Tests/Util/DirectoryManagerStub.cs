//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;

namespace Ncr.Core.Tests.Util
{
	public class DirectoryManagerStub : IDirectoryManager
	{
		public string[] GetFiles(string path, string searchPattern)
		{
			return new string[] { "test.txt", "test2.txt" };
		}
		
		public void SetCurrentDirectory(string dir)
		{
		}
		
		public bool Exists(string dir)
		{
			return true;
		}
		
		public void DeleteDirectory(string dir)
		{
		}
		
		public string GetCurrentDirectory()
		{
			return @"C:\Projects\finger\trunk\tests";
		}
		
		public void CreateDirectory(string dir)
		{
		}
		
		public string[] GetDirectories(string path)
		{
			return Directory.GetDirectories(path);
		}
	}
}
