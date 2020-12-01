//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]	
	public class AbstractScriptTests
	{
		//[OneTimeSetUp]
        //TODO: Either fix or remove empty setup
        public void OneTimeSetUp()
		{
		}
		
		//[Test]
        //TODO: Either fix or remove empty test
		public void TestMe()
		{
		}
	}
	
	class A : AbstractScript<Script>
	{
		A()
		{
		}
	}	
}
