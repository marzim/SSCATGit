// <copyright file="UIAutoTestContextChangedTest.cs" company="NCR">
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
    /// UIAutoTestContextChanged Test Class.
    /// </summary>
    [TestClass]
    public class UIAutoTestContextChangedTest
    { 
        /// <summary>
        /// UIAutoTestContextChanged object under test.
        /// </summary>
        private UIAutoTestContextChanged _uiAutoTestContextChanged;

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

            _uiAutoTestContextChanged = new UIAutoTestContextChanged(
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
            _uiAutoTestContextChanged = null;
            _uiAutoTestEventMock = null;
            _scotLogHookMock = null;
        }

        /// <summary>
        /// Tests if the UIAutoTestContextChanged event will run.
        /// </summary>
        [TestMethod]
        public void TestUIAutoTestContextChanged_Run()
        {
            // arrange

            // act
            _uiAutoTestContextChanged.Run();

            // assert
            Assert.AreEqual(_uiAutoTestContextChanged.Result.Type, ResultType.Passed);
        }
    }
}
