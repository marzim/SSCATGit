//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	public class ZipManagerStub : IZipManager
	{
		bool throwError;
		
		public ZipManagerStub() : this(false)
		{
		}
		
		public ZipManagerStub(bool throwError)
		{
			this.throwError = throwError;
		}
		
		public virtual string Extract(string zipFileSource, string destinationFolder, string password, string fileNameToExtract, string parserName)
		{
			if (throwError) {
				throw new Exception();
			} else {
				return "";
			}
		}
			
		public virtual void Extract(string zipFileSource, string destinationFolder, string password, string fileNameToExtract)
		{
			if (throwError) {
				throw new Exception();
			}
		}
		
		public virtual void CompressFolder(string fileName, string sourceDirectory)
		{
			if (throwError) {
				throw new Exception();
			}
		}
	}
}
