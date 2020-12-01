//	<file>
//		<license></license>
//		<owner name="Marvin Casagnap" email="marvin.casagnap@ncr.com"/>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

namespace Sscat.Gui
{
	partial class MSRCardForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxTrack1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxTrack2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxTrack3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(21, 20);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(133, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "Card Name";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(128, 20);
			this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(233, 22);
			this.textBoxName.TabIndex = 1;
			// 
			// textBoxTrack1
			// 
			this.textBoxTrack1.Location = new System.Drawing.Point(128, 49);
			this.textBoxTrack1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBoxTrack1.Name = "textBoxTrack1";
			this.textBoxTrack1.Size = new System.Drawing.Size(233, 22);
			this.textBoxTrack1.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(21, 49);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(133, 28);
			this.label2.TabIndex = 2;
			this.label2.Text = "Track 1";
			// 
			// textBoxTrack2
			// 
			this.textBoxTrack2.Location = new System.Drawing.Point(128, 79);
			this.textBoxTrack2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBoxTrack2.Name = "textBoxTrack2";
			this.textBoxTrack2.Size = new System.Drawing.Size(233, 22);
			this.textBoxTrack2.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(21, 79);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(133, 28);
			this.label3.TabIndex = 4;
			this.label3.Text = "Track 2";
			// 
			// textBoxTrack3
			// 
			this.textBoxTrack3.Location = new System.Drawing.Point(128, 108);
			this.textBoxTrack3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBoxTrack3.Name = "textBoxTrack3";
			this.textBoxTrack3.Size = new System.Drawing.Size(233, 22);
			this.textBoxTrack3.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(21, 108);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(133, 28);
			this.label4.TabIndex = 6;
			this.label4.Text = "Track 3";
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(171, 177);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(100, 28);
			this.buttonOK.TabIndex = 8;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(277, 177);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(100, 28);
			this.buttonCancel.TabIndex = 9;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// MSRCardForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(395, 230);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.textBoxTrack3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBoxTrack2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxTrack1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MSRCardForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MSRCardForm";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.TextBox textBoxTrack3;
		private System.Windows.Forms.TextBox textBoxTrack2;
		private System.Windows.Forms.TextBox textBoxTrack1;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
