//	<file>
//		<license></license>
//		<owner name="Marvin Casagnap" email="marvin.casagnap@ncr.com"/>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

namespace Sscat.Core.Gui
{
	partial class CardForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardForm));
			this.labelCardName = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxTrack1 = new System.Windows.Forms.TextBox();
			this.labelTrack1 = new System.Windows.Forms.Label();
			this.textBoxTrack2 = new System.Windows.Forms.TextBox();
			this.labelTrack2 = new System.Windows.Forms.Label();
			this.textBoxTrack3 = new System.Windows.Forms.TextBox();
			this.labelTrack3 = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelNote = new System.Windows.Forms.Label();
			this.panelInstructions = new System.Windows.Forms.Panel();
			this.groupBoxCardDetails = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panelInstructions.SuspendLayout();
			this.groupBoxCardDetails.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelCardName
			// 
			this.labelCardName.Location = new System.Drawing.Point(7, 18);
			this.labelCardName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelCardName.Name = "labelCardName";
			this.labelCardName.Size = new System.Drawing.Size(105, 28);
			this.labelCardName.TabIndex = 0;
			this.labelCardName.Text = "Card Name:";
			// 
			// textBoxName
			// 
			this.textBoxName.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxName.Location = new System.Drawing.Point(123, 18);
			this.textBoxName.Margin = new System.Windows.Forms.Padding(0);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(315, 22);
			this.textBoxName.TabIndex = 1;
			// 
			// textBoxTrack1
			// 
			this.textBoxTrack1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxTrack1.Location = new System.Drawing.Point(123, 49);
			this.textBoxTrack1.Margin = new System.Windows.Forms.Padding(0);
			this.textBoxTrack1.Name = "textBoxTrack1";
			this.textBoxTrack1.Size = new System.Drawing.Size(315, 22);
			this.textBoxTrack1.TabIndex = 3;
			// 
			// labelTrack1
			// 
			this.labelTrack1.Location = new System.Drawing.Point(7, 49);
			this.labelTrack1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelTrack1.Name = "labelTrack1";
			this.labelTrack1.Size = new System.Drawing.Size(105, 28);
			this.labelTrack1.TabIndex = 2;
			this.labelTrack1.Text = "Track 1:";
			// 
			// textBoxTrack2
			// 
			this.textBoxTrack2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxTrack2.Location = new System.Drawing.Point(123, 79);
			this.textBoxTrack2.Margin = new System.Windows.Forms.Padding(0);
			this.textBoxTrack2.Name = "textBoxTrack2";
			this.textBoxTrack2.Size = new System.Drawing.Size(315, 22);
			this.textBoxTrack2.TabIndex = 5;
			// 
			// labelTrack2
			// 
			this.labelTrack2.Location = new System.Drawing.Point(7, 79);
			this.labelTrack2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelTrack2.Name = "labelTrack2";
			this.labelTrack2.Size = new System.Drawing.Size(105, 28);
			this.labelTrack2.TabIndex = 4;
			this.labelTrack2.Text = "Track 2:";
			// 
			// textBoxTrack3
			// 
			this.textBoxTrack3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBoxTrack3.Location = new System.Drawing.Point(123, 109);
			this.textBoxTrack3.Margin = new System.Windows.Forms.Padding(0);
			this.textBoxTrack3.Name = "textBoxTrack3";
			this.textBoxTrack3.Size = new System.Drawing.Size(315, 22);
			this.textBoxTrack3.TabIndex = 7;
			// 
			// labelTrack3
			// 
			this.labelTrack3.Location = new System.Drawing.Point(7, 109);
			this.labelTrack3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelTrack3.Name = "labelTrack3";
			this.labelTrack3.Size = new System.Drawing.Size(105, 28);
			this.labelTrack3.TabIndex = 6;
			this.labelTrack3.Text = "Track 3:";
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(230, 4);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(4);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(100, 40);
			this.buttonOK.TabIndex = 8;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(338, 4);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(100, 40);
			this.buttonCancel.TabIndex = 9;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// labelNote
			// 
			this.labelNote.ForeColor = System.Drawing.SystemColors.WindowText;
			this.labelNote.Location = new System.Drawing.Point(7, 17);
			this.labelNote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelNote.Name = "labelNote";
			this.labelNote.Size = new System.Drawing.Size(431, 41);
			this.labelNote.TabIndex = 10;
			// 
			// panelInstructions
			// 
			this.panelInstructions.BackColor = System.Drawing.Color.Transparent;
			this.panelInstructions.Controls.Add(this.groupBoxCardDetails);
			this.panelInstructions.Controls.Add(this.groupBox1);
			this.panelInstructions.Controls.Add(this.panel1);
			this.panelInstructions.Location = new System.Drawing.Point(14, 12);
			this.panelInstructions.Name = "panelInstructions";
			this.panelInstructions.Size = new System.Drawing.Size(448, 278);
			this.panelInstructions.TabIndex = 11;
			// 
			// groupBoxCardDetails
			// 
			this.groupBoxCardDetails.Controls.Add(this.labelCardName);
			this.groupBoxCardDetails.Controls.Add(this.textBoxTrack3);
			this.groupBoxCardDetails.Controls.Add(this.labelTrack2);
			this.groupBoxCardDetails.Controls.Add(this.textBoxName);
			this.groupBoxCardDetails.Controls.Add(this.textBoxTrack2);
			this.groupBoxCardDetails.Controls.Add(this.textBoxTrack1);
			this.groupBoxCardDetails.Controls.Add(this.labelTrack3);
			this.groupBoxCardDetails.Controls.Add(this.labelTrack1);
			this.groupBoxCardDetails.Location = new System.Drawing.Point(3, 73);
			this.groupBoxCardDetails.Name = "groupBoxCardDetails";
			this.groupBoxCardDetails.Size = new System.Drawing.Size(442, 141);
			this.groupBoxCardDetails.TabIndex = 12;
			this.groupBoxCardDetails.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labelNote);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(442, 64);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Instruction";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonOK);
			this.panel1.Controls.Add(this.buttonCancel);
			this.panel1.Location = new System.Drawing.Point(3, 218);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(442, 47);
			this.panel1.TabIndex = 13;
			// 
			// CardForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(479, 302);
			this.Controls.Add(this.panelInstructions);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CardForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MS Card Form";
			this.panelInstructions.ResumeLayout(false);
			this.groupBoxCardDetails.ResumeLayout(false);
			this.groupBoxCardDetails.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.GroupBox groupBoxCardDetails;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label labelTrack2;
		private System.Windows.Forms.Label labelTrack3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelCardName;
		private System.Windows.Forms.Label labelTrack1;
		private System.Windows.Forms.Panel panelInstructions;
		private System.Windows.Forms.Label labelNote;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.TextBox textBoxTrack3;
		private System.Windows.Forms.TextBox textBoxTrack2;
		private System.Windows.Forms.TextBox textBoxTrack1;
		private System.Windows.Forms.TextBox textBoxName;
	}
}
