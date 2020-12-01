//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

//Code 128: 	Scanned in Emulator: 0111111
//      <deviceId>Scanner</deviceId>
//      <deviceValue>B30111111~0111111~110~0</deviceValue>
//			
//EAN13-JAN13:	Scanned in Emulator: 201547890450
//      <deviceId>Scanner</deviceId>
//      <deviceValue>F2015478904505~2015478904505~104~0</deviceValue>
//			
//UPC A:	Scanned in Emulator: 03000007060
//      <deviceId>Scanner</deviceId>
//      <deviceValue>A030000070604~030000070604~101~0</deviceValue>
//			
//UPC E:	Scanned in Emulator: 0120850
//      <deviceId>Scanner</deviceId>
//      <deviceValue>E0120850~0120850~102~0</deviceValue>
//
namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class ScannerTests
	{
		Scanner s;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			ThreadHelper.Attach(new ThreadManagerStub());
			RegistryHelper.Attach(new RegistryManagerStub());
			
			s = new Scanner();
		}
		
		[Test]
		public void TestScan()
		{
			s.Scan("F4800011186924~4800011186924~104", 100);
		}
		
		[Test]
		public void TestScan2()
		{
			s.Scan("81109482911323343423434231234567~81109482911323343423434231234567~132", 100);
		}
	}
}
