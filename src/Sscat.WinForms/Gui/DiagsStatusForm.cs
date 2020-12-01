// <copyright file="DiagsStatusForm.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Gui
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the DiagsStatusForm class
    /// </summary>
    public class DiagsStatusForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Form text box
        /// </summary>
        private TextBox _textBox1;

        /// <summary>
        /// Form button
        /// </summary>
        private Button _button1;

        /// <summary>
        /// Form components
        /// </summary>
        private Container _components = null;

        /// <summary>
        /// Initializes a new instance of the DiagsStatusForm class
        /// </summary>
        public DiagsStatusForm()
            : this("Generating Diags")
        {
        }

        /// <summary>
        /// Initializes a new instance of the DiagsStatusForm class
        /// </summary>
        /// <param name="text">form text</param>
        public DiagsStatusForm(string text)
        {
            InitializeComponent();
            Text = text;
        }

        /// <summary>
        /// Gets the form button
        /// </summary>
        public Button Button1
        {
            get { return _button1; }
        }

        /// <summary>
        /// Appends the given text
        /// </summary>
        /// <param name="text">text to append</param>
        public void AppendText(string text)
        {
            _textBox1.AppendText(text + Environment.NewLine);
        }

        /// <summary>
        /// Dispose the components
        /// </summary>
        /// <param name="disposing">whether or not method is disposing</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_components != null)
                {
                    _components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._textBox1 = new System.Windows.Forms.TextBox();
            this._button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this._textBox1.BackColor = System.Drawing.Color.Black;
            this._textBox1.ForeColor = System.Drawing.Color.White;
            this._textBox1.Location = new System.Drawing.Point(7, 7);
            this._textBox1.MaxLength = 500000;
            this._textBox1.Multiline = true;
            this._textBox1.Name = "textBox1";
            this._textBox1.ReadOnly = true;
            this._textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._textBox1.Size = new System.Drawing.Size(780, 329);
            this._textBox1.TabIndex = 0;
            this._textBox1.Text = string.Empty;
            // 
            // button1
            // 
            this._button1.Location = new System.Drawing.Point(360, 344);
            this._button1.Name = "button1";
            this._button1.TabIndex = 1;
            this._button1.Text = "Close";
            this._button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // DiagsStatusForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(794, 375);
            this.ControlBox = false;
            this.Controls.Add(this._button1);
            this.Controls.Add(this._textBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiagsStatusForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generating Diags";
            this.TopMost = true;
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// Click the close button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void Button1Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
