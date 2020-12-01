//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Xml.Serialization;
using Ncr.Core.Models;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Models
{
	[TestFixture]
	public class BaseSerializableTests
	{
		Life life;
		Life fromFile;
		string filename = @"C:\Projects\finger\trunk\tests\life.xml";
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			DirectoryHelper.Attach(new DirectoryManager());
			life = new BaseSerializableTests.Life();
			new Life().Serialize(filename);
			fromFile = Life.Deserialize(filename);
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual(
				@"<?xml version=""1.0"" encoding=""utf-16""?>
<Life />",
				life.Serialize()
			);
		}
		
		[Test]
		public void TestSerialize()
		{
			life.Serialize(filename, @"type='text/xsl' href='C:\Projects\finger\trunk\tests\life.xsl'");
		}
		
		[XmlRoot("Life")]
		public class Life : BaseSerializable<Life>
		{
		}
	}
}
