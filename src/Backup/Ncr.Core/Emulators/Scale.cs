// <copyright file="Scale.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using Ncr.Core.Util;
    
    /// <summary>
    /// Initializes a new instance of the Scale class
    /// </summary>
    public class Scale : Emulator, IScale, ITear
    {
        /// <summary>
        /// Initializes a new instance of the Scale class
        /// </summary>
        public Scale()
            : this(Emulator.ScaleCaption)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Scale class
        /// </summary>
        /// <param name="caption">caption text</param>
        public Scale(string caption)
            : base(caption)
        {
            Controls.Add("ProduceScale_ScaleWeight", 0x3eb);
            Controls.Add("ProduceScale_Weigh", 0x3ed);
            Controls.Add("ProduceScale_StatusComboBox", 0x409);
        }

        /// <summary>
        /// Gets the weight
        /// </summary>
        public int Weight
        {
            get
            {
                return ConvertUtility.ToInt32(GetText("ProduceScale_ScaleWeight", 3000));
            }
        }

        /// <summary>
        /// Sets weight to 0
        /// </summary>
        public void Tear()
        {
            if (Available())
            {
                Weigh(0, 2000);
            }
        }

        /// <summary>
        /// Scale weighing emulator
        /// </summary>
        /// <param name="weight">weight to weigh on scale emulator</param>
        /// <param name="timeout">timeout amount</param>
        public virtual void Weigh(int weight, int timeout)
        {
            OnEmulating(string.Format("Scale weighing {0}", weight));
            if (weight >= 0)
            {
                SelectIndex("ProduceScale_StatusComboBox", 4, timeout);
                SetText("ProduceScale_ScaleWeight", weight.ToString(), timeout);
                ClickButton("ProduceScale_Weigh", timeout);
            }
            else
            {
                SelectIndex("ProduceScale_StatusComboBox", 1, timeout);
            }
        }
    }
}
