//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

namespace Sscat.Gui
{
	partial class ConnectToServerForm
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
			this.labelConnectToServer = new System.Windows.Forms.Label();
			this.textBoxServerName = new System.Windows.Forms.TextBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonConnectToLocalhost = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelConnectToServer
			// 
			this.labelConnectToServer.Location = new System.Drawing.Point(8, 8);
			this.labelConnectToServer.Name = "labelConnectToServer";
			this.labelConnectToServer.Size = new System.Drawing.Size(216, 32);
			this.labelConnectToServer.TabIndex = 0;
			this.labelConnectToServer.Text = "{server.connect}";
			// 
			// textBoxServerName
			// 
			this.textBoxServerName.Location = new System.Drawing.Point(8, 40);
			this.textBoxServerName.Name = "textBoxServerName";
			this.textBoxServerName.Size = new System.Drawing.Size(256, 21);
			this.textBoxServerName.TabIndex = 1;
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(32, 72);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(72, 40);
			this.buttonOk.TabIndex = 2;
			this.buttonOk.Text = "{button.ok}";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// buttonConnectToLocalhost
			// 
			this.buttonConnectToLocalhost.Location = new System.Drawing.Point(192, 72);
			this.buttonConnectToLocalhost.Name = "buttonConnectToLocalhost";
			this.buttonConnectToLocalhost.Size = new System.Drawing.Size(72, 40);
			this.buttonConnectToLocalhost.TabIndex = 4;
			this.buttonConnectToLocalhost.Text = "{localhost.connect}";
			this.buttonConnectToLocalhost.UseVisualStyleBackColor = true;
			this.buttonConnectToLocalhost.Click += new System.EventHandler(this.ButtonConnectToLocalhostClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(112, 72);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(72, 40);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "{button.cancel}";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// ConnectToServerForm
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(272, 119);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonConnectToLocalhost);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.textBoxServerName);
			this.Controls.Add(this.labelConnectToServer);
			this.Name = "ConnectToServerForm";
			this.Text = "{server.connect.text}";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonConnectToLocalhost;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.TextBox textBoxServerName;
		private System.Windows.Forms.Label labelConnectToServer;
	}
}
