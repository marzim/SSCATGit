namespace Sscat.Gui
{
    partial class CustomGeneratorPane
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomGeneratorPane));
        	this.labelDiagPath = new System.Windows.Forms.Label();
        	this.textBoxDiagPath = new System.Windows.Forms.TextBox();
        	this.buttonBrowseDiag = new System.Windows.Forms.Button();
        	this.grpBoxScriptAndDiagDetails = new System.Windows.Forms.GroupBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.labelScriptDescription = new System.Windows.Forms.Label();
        	this.labelScriptName = new System.Windows.Forms.Label();
        	this.textBoxScriptDescription = new System.Windows.Forms.TextBox();
        	this.textBoxScriptName = new System.Windows.Forms.TextBox();
        	this.checkBoxSegmented = new System.Windows.Forms.CheckBox();
        	this.buttonGenerateScript = new System.Windows.Forms.Button();
        	this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        	this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        	this.panel2 = new System.Windows.Forms.Panel();
        	this.buttonClose = new System.Windows.Forms.Button();
        	this.grpBoxCustomGenerateSettings = new System.Windows.Forms.GroupBox();
        	this.buttonEditDefaultMSCard = new System.Windows.Forms.Button();
        	this.textBoxDefaultMSCard = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.chkBoxDontShowMSCardEditor = new System.Windows.Forms.CheckBox();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.label4 = new System.Windows.Forms.Label();
        	this.numericUpDownLastScripts = new System.Windows.Forms.NumericUpDown();
        	this.checkBoxLastScripts = new System.Windows.Forms.CheckBox();
        	this.outputPane1 = new Sscat.Gui.OutputPane();
        	this.grpBoxScriptAndDiagDetails.SuspendLayout();
        	this.splitContainer1.Panel1.SuspendLayout();
        	this.splitContainer1.Panel2.SuspendLayout();
        	this.splitContainer1.SuspendLayout();
        	this.panel2.SuspendLayout();
        	this.grpBoxCustomGenerateSettings.SuspendLayout();
        	this.panel1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.numericUpDownLastScripts)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// labelDiagPath
        	// 
        	this.labelDiagPath.Location = new System.Drawing.Point(9, 91);
        	this.labelDiagPath.Name = "labelDiagPath";
        	this.labelDiagPath.Size = new System.Drawing.Size(201, 17);
        	this.labelDiagPath.TabIndex = 12;
        	this.labelDiagPath.Text = "SSCO Diag Zip File Path";
        	// 
        	// textBoxDiagPath
        	// 
        	this.textBoxDiagPath.Location = new System.Drawing.Point(9, 123);
        	this.textBoxDiagPath.Name = "textBoxDiagPath";
        	this.textBoxDiagPath.ReadOnly = true;
        	this.textBoxDiagPath.Size = new System.Drawing.Size(327, 22);
        	this.textBoxDiagPath.TabIndex = 10;
        	// 
        	// buttonBrowseDiag
        	// 
        	this.buttonBrowseDiag.BackColor = System.Drawing.Color.Transparent;
        	this.buttonBrowseDiag.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.buttonBrowseDiag.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.buttonBrowseDiag.ForeColor = System.Drawing.Color.Black;
        	this.buttonBrowseDiag.Image = ((System.Drawing.Image)(resources.GetObject("buttonBrowseDiag.Image")));
        	this.buttonBrowseDiag.Location = new System.Drawing.Point(342, 117);
        	this.buttonBrowseDiag.Name = "buttonBrowseDiag";
        	this.buttonBrowseDiag.Size = new System.Drawing.Size(35, 35);
        	this.buttonBrowseDiag.TabIndex = 11;
        	this.buttonBrowseDiag.Text = "...";
        	this.buttonBrowseDiag.UseVisualStyleBackColor = false;
        	this.buttonBrowseDiag.Click += new System.EventHandler(this.BrowseDiagClick);
        	// 
        	// grpBoxScriptAndDiagDetails
        	// 
        	this.grpBoxScriptAndDiagDetails.Controls.Add(this.label2);
        	this.grpBoxScriptAndDiagDetails.Controls.Add(this.labelScriptDescription);
        	this.grpBoxScriptAndDiagDetails.Controls.Add(this.labelScriptName);
        	this.grpBoxScriptAndDiagDetails.Controls.Add(this.labelDiagPath);
        	this.grpBoxScriptAndDiagDetails.Controls.Add(this.textBoxScriptDescription);
        	this.grpBoxScriptAndDiagDetails.Controls.Add(this.textBoxScriptName);
        	this.grpBoxScriptAndDiagDetails.Controls.Add(this.textBoxDiagPath);
        	this.grpBoxScriptAndDiagDetails.Controls.Add(this.buttonBrowseDiag);
        	this.grpBoxScriptAndDiagDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.grpBoxScriptAndDiagDetails.Location = new System.Drawing.Point(395, 12);
        	this.grpBoxScriptAndDiagDetails.Name = "grpBoxScriptAndDiagDetails";
        	this.grpBoxScriptAndDiagDetails.Size = new System.Drawing.Size(385, 166);
        	this.grpBoxScriptAndDiagDetails.TabIndex = 13;
        	this.grpBoxScriptAndDiagDetails.TabStop = false;
        	this.grpBoxScriptAndDiagDetails.Text = "STEP 2: Describe the script(s) and provide the diag location";
        	// 
        	// label2
        	// 
        	this.label2.BackColor = System.Drawing.Color.Transparent;
        	this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
        	this.label2.Location = new System.Drawing.Point(342, 23);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(34, 21);
        	this.label2.TabIndex = 23;
        	this.label2.Text = ".xml";
        	// 
        	// labelScriptDescription
        	// 
        	this.labelScriptDescription.Location = new System.Drawing.Point(7, 48);
        	this.labelScriptDescription.Name = "labelScriptDescription";
        	this.labelScriptDescription.Size = new System.Drawing.Size(100, 21);
        	this.labelScriptDescription.TabIndex = 12;
        	this.labelScriptDescription.Text = "Description";
        	this.labelScriptDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// labelScriptName
        	// 
        	this.labelScriptName.Location = new System.Drawing.Point(7, 21);
        	this.labelScriptName.Name = "labelScriptName";
        	this.labelScriptName.Size = new System.Drawing.Size(100, 21);
        	this.labelScriptName.TabIndex = 12;
        	this.labelScriptName.Text = "Script Name";
        	this.labelScriptName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// textBoxScriptDescription
        	// 
        	this.textBoxScriptDescription.Location = new System.Drawing.Point(113, 48);
        	this.textBoxScriptDescription.Name = "textBoxScriptDescription";
        	this.textBoxScriptDescription.Size = new System.Drawing.Size(264, 22);
        	this.textBoxScriptDescription.TabIndex = 10;
        	// 
        	// textBoxScriptName
        	// 
        	this.textBoxScriptName.Location = new System.Drawing.Point(113, 21);
        	this.textBoxScriptName.Name = "textBoxScriptName";
        	this.textBoxScriptName.Size = new System.Drawing.Size(223, 22);
        	this.textBoxScriptName.TabIndex = 10;
        	// 
        	// checkBoxSegmented
        	// 
        	this.checkBoxSegmented.AutoSize = true;
        	this.checkBoxSegmented.Location = new System.Drawing.Point(3, 3);
        	this.checkBoxSegmented.Name = "checkBoxSegmented";
        	this.checkBoxSegmented.Size = new System.Drawing.Size(288, 20);
        	this.checkBoxSegmented.TabIndex = 28;
        	this.checkBoxSegmented.Text = "Divide test scripts for Welcome-to-Welcome testing";
        	this.checkBoxSegmented.UseVisualStyleBackColor = true;
        	this.checkBoxSegmented.CheckedChanged += new System.EventHandler(this.CheckBoxSegmentedCheckedChanged);
        	// 
        	// buttonGenerateScript
        	// 
        	this.buttonGenerateScript.BackColor = System.Drawing.Color.Transparent;
        	this.buttonGenerateScript.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.buttonGenerateScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.buttonGenerateScript.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenerateScript.Image")));
        	this.buttonGenerateScript.Location = new System.Drawing.Point(729, 2);
        	this.buttonGenerateScript.Name = "buttonGenerateScript";
        	this.buttonGenerateScript.Size = new System.Drawing.Size(35, 35);
        	this.buttonGenerateScript.TabIndex = 13;
        	this.buttonGenerateScript.UseVisualStyleBackColor = false;
        	this.buttonGenerateScript.Click += new System.EventHandler(this.ButtonGenerateClick);
        	// 
        	// openFileDialog1
        	// 
        	this.openFileDialog1.FileName = "";
        	this.openFileDialog1.Filter = "Diagnostic Files (*.zip, *.7z) | *.zip; *.7z";
        	// 
        	// splitContainer1
        	// 
        	this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer1.Location = new System.Drawing.Point(0, 0);
        	this.splitContainer1.Name = "splitContainer1";
        	this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        	// 
        	// splitContainer1.Panel1
        	// 
        	this.splitContainer1.Panel1.Controls.Add(this.panel2);
        	this.splitContainer1.Panel1.Controls.Add(this.grpBoxCustomGenerateSettings);
        	this.splitContainer1.Panel1.Controls.Add(this.grpBoxScriptAndDiagDetails);
        	this.splitContainer1.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	// 
        	// splitContainer1.Panel2
        	// 
        	this.splitContainer1.Panel2.Controls.Add(this.outputPane1);
        	this.splitContainer1.Size = new System.Drawing.Size(934, 511);
        	this.splitContainer1.SplitterDistance = 255;
        	this.splitContainer1.TabIndex = 14;
        	// 
        	// panel2
        	// 
        	this.panel2.BackColor = System.Drawing.Color.Transparent;
        	this.panel2.Controls.Add(this.buttonGenerateScript);
        	this.panel2.Controls.Add(this.buttonClose);
        	this.panel2.Location = new System.Drawing.Point(8, 182);
        	this.panel2.Name = "panel2";
        	this.panel2.Size = new System.Drawing.Size(772, 39);
        	this.panel2.TabIndex = 32;
        	// 
        	// buttonClose
        	// 
        	this.buttonClose.BackColor = System.Drawing.Color.Transparent;
        	this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("buttonClose.Image")));
        	this.buttonClose.Location = new System.Drawing.Point(688, 3);
        	this.buttonClose.Name = "buttonClose";
        	this.buttonClose.Size = new System.Drawing.Size(35, 35);
        	this.buttonClose.TabIndex = 30;
        	this.buttonClose.UseVisualStyleBackColor = false;
        	this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
        	// 
        	// grpBoxCustomGenerateSettings
        	// 
        	this.grpBoxCustomGenerateSettings.Controls.Add(this.buttonEditDefaultMSCard);
        	this.grpBoxCustomGenerateSettings.Controls.Add(this.textBoxDefaultMSCard);
        	this.grpBoxCustomGenerateSettings.Controls.Add(this.label1);
        	this.grpBoxCustomGenerateSettings.Controls.Add(this.chkBoxDontShowMSCardEditor);
        	this.grpBoxCustomGenerateSettings.Controls.Add(this.panel1);
        	this.grpBoxCustomGenerateSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.grpBoxCustomGenerateSettings.Location = new System.Drawing.Point(8, 12);
        	this.grpBoxCustomGenerateSettings.Name = "grpBoxCustomGenerateSettings";
        	this.grpBoxCustomGenerateSettings.Size = new System.Drawing.Size(385, 166);
        	this.grpBoxCustomGenerateSettings.TabIndex = 31;
        	this.grpBoxCustomGenerateSettings.TabStop = false;
        	this.grpBoxCustomGenerateSettings.Text = "STEP 1: Confirm how you want to generate the script(s)";
        	// 
        	// buttonEditDefaultMSCard
        	// 
        	this.buttonEditDefaultMSCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonEditDefaultMSCard.BackColor = System.Drawing.Color.Transparent;
        	this.buttonEditDefaultMSCard.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.buttonEditDefaultMSCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.buttonEditDefaultMSCard.ForeColor = System.Drawing.Color.Black;
        	this.buttonEditDefaultMSCard.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditDefaultMSCard.Image")));
        	this.buttonEditDefaultMSCard.Location = new System.Drawing.Point(334, 120);
        	this.buttonEditDefaultMSCard.Name = "buttonEditDefaultMSCard";
        	this.buttonEditDefaultMSCard.Size = new System.Drawing.Size(35, 35);
        	this.buttonEditDefaultMSCard.TabIndex = 90;
        	this.buttonEditDefaultMSCard.Tag = "delete";
        	this.buttonEditDefaultMSCard.UseVisualStyleBackColor = false;
        	this.buttonEditDefaultMSCard.Click += new System.EventHandler(this.ButtonEditDefaultMSCardClick);
        	// 
        	// textBoxDefaultMSCard
        	// 
        	this.textBoxDefaultMSCard.Enabled = false;
        	this.textBoxDefaultMSCard.ForeColor = System.Drawing.SystemColors.WindowText;
        	this.textBoxDefaultMSCard.Location = new System.Drawing.Point(148, 126);
        	this.textBoxDefaultMSCard.Name = "textBoxDefaultMSCard";
        	this.textBoxDefaultMSCard.Size = new System.Drawing.Size(182, 22);
        	this.textBoxDefaultMSCard.TabIndex = 32;
        	this.textBoxDefaultMSCard.Text = "Default";
        	// 
        	// label1
        	// 
        	this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.label1.Location = new System.Drawing.Point(25, 126);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(117, 21);
        	this.label1.TabIndex = 31;
        	this.label1.Text = "Default MS Card:";
        	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// chkBoxDontShowMSCardEditor
        	// 
        	this.chkBoxDontShowMSCardEditor.Location = new System.Drawing.Point(9, 91);
        	this.chkBoxDontShowMSCardEditor.Name = "chkBoxDontShowMSCardEditor";
        	this.chkBoxDontShowMSCardEditor.Size = new System.Drawing.Size(372, 32);
        	this.chkBoxDontShowMSCardEditor.TabIndex = 30;
        	this.chkBoxDontShowMSCardEditor.Text = "Don\'t show Card Editor and immediately use default card";
        	this.chkBoxDontShowMSCardEditor.UseVisualStyleBackColor = true;
        	this.chkBoxDontShowMSCardEditor.CheckedChanged += new System.EventHandler(this.CheckBoxShowMSCardEditorCheckedChanged);
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.label4);
        	this.panel1.Controls.Add(this.checkBoxSegmented);
        	this.panel1.Controls.Add(this.numericUpDownLastScripts);
        	this.panel1.Controls.Add(this.checkBoxLastScripts);
        	this.panel1.Location = new System.Drawing.Point(6, 20);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(363, 60);
        	this.panel1.TabIndex = 29;
        	// 
        	// label4
        	// 
        	this.label4.Location = new System.Drawing.Point(156, 28);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(98, 19);
        	this.label4.TabIndex = 36;
        	this.label4.Text = "transaction(s)";
        	// 
        	// numericUpDownLastScripts
        	// 
        	this.numericUpDownLastScripts.Enabled = false;
        	this.numericUpDownLastScripts.Location = new System.Drawing.Point(88, 26);
        	this.numericUpDownLastScripts.Minimum = new decimal(new int[] {
        	        	        	1,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.numericUpDownLastScripts.Name = "numericUpDownLastScripts";
        	this.numericUpDownLastScripts.Size = new System.Drawing.Size(62, 22);
        	this.numericUpDownLastScripts.TabIndex = 35;
        	this.numericUpDownLastScripts.Value = new decimal(new int[] {
        	        	        	1,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.numericUpDownLastScripts.ValueChanged += new System.EventHandler(this.NumericUpDownLastScriptsValueChanged);
        	// 
        	// checkBoxLastScripts
        	// 
        	this.checkBoxLastScripts.Enabled = false;
        	this.checkBoxLastScripts.Location = new System.Drawing.Point(23, 26);
        	this.checkBoxLastScripts.Name = "checkBoxLastScripts";
        	this.checkBoxLastScripts.Size = new System.Drawing.Size(55, 21);
        	this.checkBoxLastScripts.TabIndex = 34;
        	this.checkBoxLastScripts.Text = "Last";
        	this.checkBoxLastScripts.UseVisualStyleBackColor = true;
        	this.checkBoxLastScripts.CheckedChanged += new System.EventHandler(this.CheckBoxLastScriptsCheckedChanged);
        	// 
        	// outputPane1
        	// 
        	this.outputPane1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.outputPane1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.outputPane1.Location = new System.Drawing.Point(0, 0);
        	this.outputPane1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
        	this.outputPane1.Name = "outputPane1";
        	this.outputPane1.Size = new System.Drawing.Size(934, 252);
        	this.outputPane1.TabIndex = 1;
        	// 
        	// CustomGeneratorPane
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.splitContainer1);
        	this.Name = "CustomGeneratorPane";
        	this.Size = new System.Drawing.Size(934, 511);
        	this.grpBoxScriptAndDiagDetails.ResumeLayout(false);
        	this.grpBoxScriptAndDiagDetails.PerformLayout();
        	this.splitContainer1.Panel1.ResumeLayout(false);
        	this.splitContainer1.Panel2.ResumeLayout(false);
        	this.splitContainer1.ResumeLayout(false);
        	this.panel2.ResumeLayout(false);
        	this.grpBoxCustomGenerateSettings.ResumeLayout(false);
        	this.grpBoxCustomGenerateSettings.PerformLayout();
        	this.panel1.ResumeLayout(false);
        	this.panel1.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.numericUpDownLastScripts)).EndInit();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.CheckBox chkBoxDontShowMSCardEditor;
        private System.Windows.Forms.GroupBox grpBoxScriptAndDiagDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonEditDefaultMSCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDefaultMSCard;
        private System.Windows.Forms.CheckBox checkBoxLastScripts;
        private System.Windows.Forms.NumericUpDown numericUpDownLastScripts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpBoxCustomGenerateSettings;

        #endregion

        private System.Windows.Forms.Label labelDiagPath;
        private System.Windows.Forms.TextBox textBoxDiagPath;
        private System.Windows.Forms.Button buttonBrowseDiag;
        private System.Windows.Forms.Button buttonGenerateScript;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelScriptDescription;
        private System.Windows.Forms.Label labelScriptName;
        private System.Windows.Forms.TextBox textBoxScriptDescription;
        private System.Windows.Forms.TextBox textBoxScriptName;
        private System.Windows.Forms.CheckBox checkBoxSegmented;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private OutputPane outputPane1;
        private System.Windows.Forms.Button buttonClose;
    }
}
