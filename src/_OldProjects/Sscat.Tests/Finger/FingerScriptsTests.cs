// <copyright file="FingerScriptsTests.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Tests.Finger
{
    using System.IO;
    using NUnit.Framework;
    using Sscat.Core.Finger;
    using Sscat.Core.Models;

    [TestFixture]
    public class FingerScriptsTests
    {
        FingerScripts s;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            s = FingerScripts.Deserialize(new StringReader(@"<FingerScripts>
	            <Script/>
	            <Script/>
            </FingerScripts>"));
        }

        [Test]
        public void TestConstructor()
        {
            s = new FingerScripts(new FingerScript[] { new FingerScript() });
            Assert.AreEqual(1, s.Scripts.Length);
        }

        [Test]
        public void TestAddScripts()
        {
            s.AddScripts(new IScript[] { new FingerScript() });
            Assert.AreEqual(3, s.Scripts.Length);
        }

        [Test]
        public void TestNoScripts()
        {
            s = FingerScripts.Deserialize(new StringReader(@"<FingerScripts/>"));
            Assert.AreEqual(0, s.Scripts.Length);
        }

        [Test]
        public void TestScriptsLengthValue()
        {
            if (s.Scripts.Length > 1)
            {
                Assert.AreEqual(2, s.Scripts.Length);
            }
            else
            {
                Assert.AreEqual(0, s.Scripts.Length);
            }
        }
    }
}
