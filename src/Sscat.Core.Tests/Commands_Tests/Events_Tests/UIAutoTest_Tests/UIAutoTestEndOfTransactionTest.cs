// <copyright file="UIAutoTestEndOfTransactionTest.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Tests.Commands_Tests.Events_Tests.UIAutoTest_Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Sscat.Core.Commands;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// UIAutoTestEndOfTransaction Test Class.
    /// </summary>
    [TestClass]
    public class UIAutoTestEndOfTransactionTest
    { 
        /// <summary>
        /// UIAutoTestEndOfTransaction object under test.
        /// </summary>
        private UIAutoTestEndOfTransaction _uiAutoTestEndOfTransaction;

        /// <summary>
        /// Creates a mock implementation of interfacing SCOT log hook class.
        /// </summary>
        private Mock<IScotLogHook> _scotLogHookMock;

        /// <summary>
        /// Creates a mock implementation of interfacing UI Auto Test Event class.
        /// </summary>
        private Mock<IUIAutoTestEvent> _uiAutoTestEventMock;

        /// <summary>
        /// Instantiates the mocks before each test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _scotLogHookMock = new Mock<IScotLogHook>();
            _uiAutoTestEventMock = new Mock<IUIAutoTestEvent>();

            _uiAutoTestEndOfTransaction = new UIAutoTestEndOfTransaction(
                _scotLogHookMock.Object,
                _uiAutoTestEventMock.Object,
                null,
                0,
                false);
        }

        /// <summary>
        /// Cleans up all the mocks and the class under test instance after each test.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            _uiAutoTestEndOfTransaction = null;
            _uiAutoTestEventMock = null;
            _scotLogHookMock = null;
        }

        /// <summary>
        /// Tests if the UIAutoTestEndOfTransaction event will run.
        /// </summary>
        [TestMethod]
        public void TestUIAutoTestEndOfTransaction_Run()
        {
            // arrange

            // act
            _uiAutoTestEndOfTransaction.Run();

            // assert
            Assert.AreEqual(_uiAutoTestEndOfTransaction.Result.Type, ResultType.Passed);
        }
    }
}
