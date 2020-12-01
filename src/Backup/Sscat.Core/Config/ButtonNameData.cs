// <copyright file="ButtonNameData.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    /// <summary>
    /// Initializes a new instance of the ButtonNameData class
    /// </summary>
    public class ButtonNameData
    {
        /// <summary>
        /// Button name
        /// </summary>
        private string _buttonName;

        /// <summary>
        /// Button data
        /// </summary>
        private string _buttonData;

        /// <summary>
        /// Initializes a new instance of the ButtonNameData class
        /// </summary>
        public ButtonNameData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ButtonNameData class
        /// </summary>
        /// <param name="name">button name</param>
        /// <param name="data">button data</param>
        public ButtonNameData(string name, string data)
        {
            _buttonName = name;
            _buttonData = data;
        }

        /// <summary>
        /// Gets or sets the button name
        /// </summary>
        public string ButtonName
        {
            get { return _buttonName; }
            set { _buttonName = value; }
        }

        /// <summary>
        /// Gets or sets the button data
        /// </summary>
        public string ButtonData
        {
            get { return _buttonData; }
            set { _buttonData = value; }
        }
    }
}
