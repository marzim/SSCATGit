// <copyright file="DNSManagerTest.cs" company="NCR">
//     Copyright 2018 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Tests.Util
{
    using System;
    using System.Net;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Ncr.Core.Util;

    /// <summary>
    /// DNSManager Test Class.
    /// </summary>
    [TestClass]
    public class DNSManagerTest
    {
        /// <summary>
        /// Private type for the DnsManager class.
        /// </summary>
        private DnsManager _dNSManager;
        
        /// <summary>
        /// Private type for the IPHostEntry class.
        /// </summary>
        private IPHostEntry ipHostEntrty;

        /// <summary>
        /// Creates a mock implementation of interfacing DNSManager class.
        /// </summary>
        private Mock<IDnsManager> _ipHostEntryMock;

        /// <summary>
        /// Instantiates the mocks and sets up the instance for DNSManager class before each test.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _dNSManager = new DnsManager();
            _ipHostEntryMock = new Mock<IDnsManager>();
        }

        /// <summary>
        /// Tests if the DnsManager GetHostByName function returns the expected value
        /// </summary>
        [TestMethod]
        public void TestMethodGetHostByName()
        {
            ////Arrange
            
            ////Act
            ipHostEntrty = _dNSManager.GetHostByName("localhost");

            ////Assert
        }
    }
}
