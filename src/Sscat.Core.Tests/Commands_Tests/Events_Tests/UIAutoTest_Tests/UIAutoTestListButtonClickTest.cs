// <copyright file="UIAutoTestListButtonClickTest.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Tests.Commands_Tests.Events_Tests.UIAutoTest_Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Sscat.Core.Commands;
    using Sscat.Core.Commands.Events.UIAutoTest;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// UIAutoTestListButtonClick Test Class.
    /// </summary>
    [TestClass]
    public class UIAutoTestListButtonClickTest
    {
        /// <summary>
        /// Private type for the NextGenUITestClient class.
        /// </summary>
        private static PrivateType _nextGenUITestClientPrivateType;

        /// <summary>
        /// UIAutoTestListButtonClick object under test.
        /// </summary>
        private UIAutoTestListButtonClick _uiAutoTestListButtonClick;

        /// <summary>
        /// Creates a mock implementation of interfacing SCOT log hook class.
        /// </summary>
        private Mock<IScotLogHook> _scotLogHookMock;

        /// <summary>
        /// Creates a mock implementation of interfacing UI Auto Test Event class.
        /// </summary>
        private Mock<IUIAutoTestEvent> _uiAutoTestEventMock;

        /// <summary>
        /// Creates a mock implementation of interfacing NextGenUITestClient class.
        /// </summary>
        private Mock<INextGenUITestClient> _nextGenUITestClientMock;

        /// <summary>
        /// Initializes the static fields for the test class.
        /// </summary>
        /// <param name="testContext">Used to store information that is provided to unit tests.</param>
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _nextGenUITestClientPrivateType = new PrivateType(typeof(NextGenUITestClient));
        }

        /// <summary>
        /// Cleans up the static fields for the test class.
        /// </summary>
        [ClassCleanup]
        public static void ClassCleanup()
        {
            _nextGenUITestClientPrivateType = null;
        }

        /// <summary>
        /// Instantiates the mocks and sets up the lazy load instance for NextGenUITestClient class before each test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _scotLogHookMock = new Mock<IScotLogHook>();
            _uiAutoTestEventMock = new Mock<IUIAutoTestEvent>();
            _nextGenUITestClientMock = new Mock<INextGenUITestClient>();

            Lazy<INextGenUITestClient> lazyTestClient =
                new Lazy<INextGenUITestClient>(() => _nextGenUITestClientMock.Object);
            _nextGenUITestClientPrivateType.SetStaticField("__instance", lazyTestClient);

            _uiAutoTestListButtonClick = new UIAutoTestListButtonClick(
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
            _uiAutoTestListButtonClick = null;
            _nextGenUITestClientMock = null;
            _uiAutoTestEventMock = null;
            _scotLogHookMock = null;
        }

        /// <summary>
        /// Tests if the UIAutoTestListButtonClick event will click the button.
        /// </summary>
        [TestMethod]
        public void TestUIAutoTestListButtonClick_Run_ButtonIsClicked()
        {
            // arrange

            // act
            _uiAutoTestListButtonClick.Run();

            // assert
            _nextGenUITestClientMock.Verify(x => x.ClickListButton(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }
    }
}
