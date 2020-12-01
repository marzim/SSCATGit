//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

namespace Sscat.Gui
{
	partial class GeneratorPane
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratorPane));
            this.pnlActionButtons = new System.Windows.Forms.Panel();
            this.buttonGenerateScript = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.groupBoxHowToGenerate = new System.Windows.Forms.GroupBox();
            this.checkBoxUIValidation = new System.Windows.Forms.CheckBox();
            this.buttonEditDefaultMSCard = new System.Windows.Forms.Button();
            this.textBoxDefaultMSCard = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkBoxDontShowMSCardEditor = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxLastScripts = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxSegmented = new System.Windows.Forms.CheckBox();
            this.numericUpDownLastScripts = new System.Windows.Forms.NumericUpDown();
            this.groupBoxScriptDetails = new System.Windows.Forms.GroupBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlActionButtons.SuspendLayout();
            this.groupBoxHowToGenerate.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLastScripts)).BeginInit();
            this.groupBoxScriptDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlActionButtons.Controls.Add(this.buttonGenerateScript);
            this.pnlActionButtons.Controls.Add(this.buttonStop);
            this.pnlActionButtons.Location = new System.Drawing.Point(8, 205);
            this.pnlActionButtons.Margin = new System.Windows.Forms.Padding(2);
            this.pnlActionButtons.Name = "pnlActionButtons";
            this.pnlActionButtons.Size = new System.Drawing.Size(772, 39);
            this.pnlActionButtons.TabIndex = 78;
            // 
            // buttonGenerateScript
            // 
            this.buttonGenerateScript.BackColor = System.Drawing.Color.Transparent;
            this.buttonGenerateScript.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGenerateScript.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGenerateScript.Font = new System.Drawing.Font("Tahoma", 10F);
            this.buttonGenerateScript.ForeColor = System.Drawing.Color.Black;
            this.buttonGenerateScript.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenerateScript.Image")));
            this.buttonGenerateScript.Location = new System.Drawing.Point(729, 2);
            this.buttonGenerateScript.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGenerateScript.Name = "buttonGenerateScript";
            this.buttonGenerateScript.Size = new System.Drawing.Size(35, 35);
            this.buttonGenerateScript.TabIndex = 27;
            this.buttonGenerateScript.UseVisualStyleBackColor = false;
            this.buttonGenerateScript.Click += new System.EventHandler(this.ButtonGenerateScriptClick);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.BackColor = System.Drawing.Color.Transparent;
            this.buttonStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStop.Enabled = false;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStop.Font = new System.Drawing.Font("Tahoma", 10F);
            this.buttonStop.ForeColor = System.Drawing.Color.Black;
            this.buttonStop.Image = ((System.Drawing.Image)(resources.GetObject("buttonStop.Image")));
            this.buttonStop.Location = new System.Drawing.Point(688, 2);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(35, 35);
            this.buttonStop.TabIndex = 77;
            this.buttonStop.Tag = "delete";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStopClick);
            // 
            // groupBoxHowToGenerate
            // 
            this.groupBoxHowToGenerate.Controls.Add(this.checkBoxUIValidation);
            this.groupBoxHowToGenerate.Controls.Add(this.buttonEditDefaultMSCard);
            this.groupBoxHowToGenerate.Controls.Add(this.textBoxDefaultMSCard);
            this.groupBoxHowToGenerate.Controls.Add(this.label5);
            this.groupBoxHowToGenerate.Controls.Add(this.chkBoxDontShowMSCardEditor);
            this.groupBoxHowToGenerate.Controls.Add(this.panel1);
            this.groupBoxHowToGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxHowToGenerate.Location = new System.Drawing.Point(8, 12);
            this.groupBoxHowToGenerate.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxHowToGenerate.Name = "groupBoxHowToGenerate";
            this.groupBoxHowToGenerate.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxHowToGenerate.Size = new System.Drawing.Size(385, 188);
            this.groupBoxHowToGenerate.TabIndex = 26;
            this.groupBoxHowToGenerate.TabStop = false;
            this.groupBoxHowToGenerate.Text = "STEP 1: Confirm how you want to generate the script(s)";
            // 
            // checkBoxUIValidation
            // 
            this.checkBoxUIValidation.AutoSize = true;
            this.checkBoxUIValidation.Location = new System.Drawing.Point(5, 85);
            this.checkBoxUIValidation.Name = "checkBoxUIValidation";
            this.checkBoxUIValidation.Size = new System.Drawing.Size(149, 20);
            this.checkBoxUIValidation.TabIndex = 95;
            this.checkBoxUIValidation.Text = "Enable UI Validation";
            this.checkBoxUIValidation.UseVisualStyleBackColor = true;
            this.checkBoxUIValidation.CheckedChanged += new System.EventHandler(this.CheckBoxUIValidationCheckedChanged);
            // 
            // buttonEditDefaultMSCard
            // 
            this.buttonEditDefaultMSCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditDefaultMSCard.BackColor = System.Drawing.Color.Transparent;
            this.buttonEditDefaultMSCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEditDefaultMSCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEditDefaultMSCard.ForeColor = System.Drawing.Color.Black;
            this.buttonEditDefaultMSCard.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditDefaultMSCard.Image")));
            this.buttonEditDefaultMSCard.Location = new System.Drawing.Point(331, 139);
            this.buttonEditDefaultMSCard.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEditDefaultMSCard.Name = "buttonEditDefaultMSCard";
            this.buttonEditDefaultMSCard.Size = new System.Drawing.Size(35, 35);
            this.buttonEditDefaultMSCard.TabIndex = 94;
            this.buttonEditDefaultMSCard.Tag = "delete";
            this.buttonEditDefaultMSCard.UseVisualStyleBackColor = false;
            this.buttonEditDefaultMSCard.Click += new System.EventHandler(this.ButtonEditDefaultMSCardClick);
            // 
            // textBoxDefaultMSCard
            // 
            this.textBoxDefaultMSCard.Enabled = false;
            this.textBoxDefaultMSCard.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxDefaultMSCard.Location = new System.Drawing.Point(145, 145);
            this.textBoxDefaultMSCard.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDefaultMSCard.Name = "textBoxDefaultMSCard";
            this.textBoxDefaultMSCard.Size = new System.Drawing.Size(182, 22);
            this.textBoxDefaultMSCard.TabIndex = 93;
            // 
            // label5
            // 
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(22, 145);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 21);
            this.label5.TabIndex = 92;
            this.label5.Text = "Default MS Card:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkBoxDontShowMSCardEditor
            // 
            this.chkBoxDontShowMSCardEditor.Location = new System.Drawing.Point(6, 110);
            this.chkBoxDontShowMSCardEditor.Margin = new System.Windows.Forms.Padding(2);
            this.chkBoxDontShowMSCardEditor.Name = "chkBoxDontShowMSCardEditor";
            this.chkBoxDontShowMSCardEditor.Size = new System.Drawing.Size(372, 32);
            this.chkBoxDontShowMSCardEditor.TabIndex = 91;
            this.chkBoxDontShowMSCardEditor.Text = "Don\'t show Card Editor and immediately use default card";
            this.chkBoxDontShowMSCardEditor.UseVisualStyleBackColor = true;
            this.chkBoxDontShowMSCardEditor.CheckedChanged += new System.EventHandler(this.CheckBoxShowMSCardEditorCheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxLastScripts);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.checkBoxSegmented);
            this.panel1.Controls.Add(this.numericUpDownLastScripts);
            this.panel1.Location = new System.Drawing.Point(6, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 60);
            this.panel1.TabIndex = 28;
            // 
            // checkBoxLastScripts
            // 
            this.checkBoxLastScripts.Enabled = false;
            this.checkBoxLastScripts.Location = new System.Drawing.Point(23, 26);
            this.checkBoxLastScripts.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxLastScripts.Name = "checkBoxLastScripts";
            this.checkBoxLastScripts.Size = new System.Drawing.Size(55, 21);
            this.checkBoxLastScripts.TabIndex = 37;
            this.checkBoxLastScripts.Text = "Last";
            this.checkBoxLastScripts.UseVisualStyleBackColor = true;
            this.checkBoxLastScripts.CheckedChanged += new System.EventHandler(this.CheckBoxLastScriptsCheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(156, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 19);
            this.label4.TabIndex = 36;
            this.label4.Text = "transaction(s)";
            // 
            // checkBoxSegmented
            // 
            this.checkBoxSegmented.AutoSize = true;
            this.checkBoxSegmented.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSegmented.Location = new System.Drawing.Point(3, 3);
            this.checkBoxSegmented.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSegmented.Name = "checkBoxSegmented";
            this.checkBoxSegmented.Size = new System.Drawing.Size(330, 20);
            this.checkBoxSegmented.TabIndex = 27;
            this.checkBoxSegmented.Text = "Divide test scripts for Welcome-to-Welcome testing";
            this.checkBoxSegmented.UseVisualStyleBackColor = true;
            this.checkBoxSegmented.CheckedChanged += new System.EventHandler(this.CheckBoxSegmentedCheckedChanged);
            // 
            // numericUpDownLastScripts
            // 
            this.numericUpDownLastScripts.Enabled = false;
            this.numericUpDownLastScripts.Location = new System.Drawing.Point(88, 26);
            this.numericUpDownLastScripts.Margin = new System.Windows.Forms.Padding(2);
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
            // groupBoxScriptDetails
            // 
            this.groupBoxScriptDetails.Controls.Add(this.textBoxDescription);
            this.groupBoxScriptDetails.Controls.Add(this.label3);
            this.groupBoxScriptDetails.Controls.Add(this.label2);
            this.groupBoxScriptDetails.Controls.Add(this.textBoxName);
            this.groupBoxScriptDetails.Controls.Add(this.label1);
            this.groupBoxScriptDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxScriptDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxScriptDetails.Location = new System.Drawing.Point(395, 12);
            this.groupBoxScriptDetails.Name = "groupBoxScriptDetails";
            this.groupBoxScriptDetails.Size = new System.Drawing.Size(385, 188);
            this.groupBoxScriptDetails.TabIndex = 25;
            this.groupBoxScriptDetails.TabStop = false;
            this.groupBoxScriptDetails.Text = "STEP 2: Describe the script(s)";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxDescription.Location = new System.Drawing.Point(113, 48);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(264, 22);
            this.textBoxDescription.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(7, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 24;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(342, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 21);
            this.label2.TabIndex = 22;
            this.label2.Text = ".xml";
            // 
            // textBoxName
            // 
            this.textBoxName.AcceptsTab = true;
            this.textBoxName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxName.Location = new System.Drawing.Point(113, 21);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(223, 22);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.Tag = "";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Script Name";
            // 
            // GeneratorPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlActionButtons);
            this.Controls.Add(this.groupBoxHowToGenerate);
            this.Controls.Add(this.groupBoxScriptDetails);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GeneratorPane";
            this.Size = new System.Drawing.Size(800, 252);
            this.pnlActionButtons.ResumeLayout(false);
            this.groupBoxHowToGenerate.ResumeLayout(false);
            this.groupBoxHowToGenerate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLastScripts)).EndInit();
            this.groupBoxScriptDetails.ResumeLayout(false);
            this.groupBoxScriptDetails.PerformLayout();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.GroupBox groupBoxHowToGenerate;
		private System.Windows.Forms.CheckBox chkBoxDontShowMSCardEditor;
		private System.Windows.Forms.GroupBox groupBoxScriptDetails;
		private System.Windows.Forms.Panel pnlActionButtons;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxDefaultMSCard;
		private System.Windows.Forms.Button buttonEditDefaultMSCard;
		private System.Windows.Forms.CheckBox checkBoxLastScripts;
		private System.Windows.Forms.NumericUpDown numericUpDownLastScripts;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonGenerateScript;
        private System.Windows.Forms.CheckBox checkBoxSegmented;
        private System.Windows.Forms.CheckBox checkBoxUIValidation;
	}
}
