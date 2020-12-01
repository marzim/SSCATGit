//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

namespace Sscat.Gui
{
	partial class UpdateWldbPane
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxWLDB = new System.Windows.Forms.TextBox();
			this.buttonBrowseWLDB = new System.Windows.Forms.Button();
			this.textBoxSAConfig = new System.Windows.Forms.TextBox();
			this.buttonBrowseSAConfig = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBoxRemoteServer = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBoxServerPasword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxServerUsername = new System.Windows.Forms.TextBox();
			this.buttonManage = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBoxWLDB);
			this.groupBox1.Controls.Add(this.buttonBrowseWLDB);
			this.groupBox1.Controls.Add(this.textBoxSAConfig);
			this.groupBox1.Controls.Add(this.buttonBrowseSAConfig);
			this.groupBox1.Location = new System.Drawing.Point(12, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(456, 75);
			this.groupBox1.TabIndex = 30;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Indicate the current location of the WLDB files to preserve";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(131, 18);
			this.label2.TabIndex = 10;
			this.label2.Text = "SAConfig.mdb Location";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 19);
			this.label1.TabIndex = 9;
			this.label1.Text = "WLDB.mdb Location";
			// 
			// textBoxWLDB
			// 
			this.textBoxWLDB.Enabled = false;
			this.textBoxWLDB.Location = new System.Drawing.Point(147, 20);
			this.textBoxWLDB.Name = "textBoxWLDB";
			this.textBoxWLDB.Size = new System.Drawing.Size(248, 21);
			this.textBoxWLDB.TabIndex = 3;
			// 
			// buttonBrowseWLDB
			// 
			this.buttonBrowseWLDB.Location = new System.Drawing.Point(401, 18);
			this.buttonBrowseWLDB.Name = "buttonBrowseWLDB";
			this.buttonBrowseWLDB.Size = new System.Drawing.Size(32, 22);
			this.buttonBrowseWLDB.TabIndex = 6;
			this.buttonBrowseWLDB.Text = "...";
			this.buttonBrowseWLDB.Click += new System.EventHandler(this.ButtonBrowseWLDBClick);
			// 
			// textBoxSAConfig
			// 
			this.textBoxSAConfig.Enabled = false;
			this.textBoxSAConfig.Location = new System.Drawing.Point(147, 47);
			this.textBoxSAConfig.Name = "textBoxSAConfig";
			this.textBoxSAConfig.Size = new System.Drawing.Size(248, 21);
			this.textBoxSAConfig.TabIndex = 7;
			// 
			// buttonBrowseSAConfig
			// 
			this.buttonBrowseSAConfig.Location = new System.Drawing.Point(401, 45);
			this.buttonBrowseSAConfig.Name = "buttonBrowseSAConfig";
			this.buttonBrowseSAConfig.Size = new System.Drawing.Size(32, 23);
			this.buttonBrowseSAConfig.TabIndex = 8;
			this.buttonBrowseSAConfig.Text = "...";
			this.buttonBrowseSAConfig.Click += new System.EventHandler(this.ButtonBrowseSAConfigClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBoxRemoteServer);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Location = new System.Drawing.Point(12, 87);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(456, 145);
			this.groupBox2.TabIndex = 29;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Fill in the Store Server (or Security Server) details";
			// 
			// textBoxRemoteServer
			// 
			this.textBoxRemoteServer.Location = new System.Drawing.Point(130, 25);
			this.textBoxRemoteServer.Name = "textBoxRemoteServer";
			this.textBoxRemoteServer.Size = new System.Drawing.Size(303, 21);
			this.textBoxRemoteServer.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(131, 23);
			this.label3.TabIndex = 32;
			this.label3.Text = "Store Server Hostname";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBoxServerPasword);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.textBoxServerUsername);
			this.groupBox3.Location = new System.Drawing.Point(87, 54);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(346, 83);
			this.groupBox3.TabIndex = 29;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Login Credentials";
			// 
			// textBoxServerPasword
			// 
			this.textBoxServerPasword.Location = new System.Drawing.Point(101, 52);
			this.textBoxServerPasword.Name = "textBoxServerPasword";
			this.textBoxServerPasword.PasswordChar = '*';
			this.textBoxServerPasword.Size = new System.Drawing.Size(228, 21);
			this.textBoxServerPasword.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 28);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 23);
			this.label4.TabIndex = 32;
			this.label4.Text = "Username";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 55);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 23);
			this.label5.TabIndex = 32;
			this.label5.Text = "Password";
			// 
			// textBoxServerUsername
			// 
			this.textBoxServerUsername.Location = new System.Drawing.Point(101, 25);
			this.textBoxServerUsername.Name = "textBoxServerUsername";
			this.textBoxServerUsername.Size = new System.Drawing.Size(228, 21);
			this.textBoxServerUsername.TabIndex = 0;
			// 
			// buttonManage
			// 
			this.buttonManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonManage.Location = new System.Drawing.Point(347, 238);
			this.buttonManage.Name = "buttonManage";
			this.buttonManage.Size = new System.Drawing.Size(121, 34);
			this.buttonManage.TabIndex = 31;
			this.buttonManage.Text = "Update WLDB";
			this.buttonManage.Click += new System.EventHandler(this.ButtonManageClick);
			// 
			// buttonClose
			// 
			this.buttonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonClose.Location = new System.Drawing.Point(229, 238);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(112, 34);
			this.buttonClose.TabIndex = 32;
			this.buttonClose.Text = "Close";
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "WLDB.mdb Files (WLDB.mdb)|WLDB.mdb";
			// 
			// openFileDialog2
			// 
			this.openFileDialog2.FileName = "openFileDialog2";
			this.openFileDialog2.Filter = "SACONFIG.mdb Files (SACONFIG.mdb)|SACONFIG.mdb";
			// 
			// UpdateWldbPane
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonManage);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "UpdateWldbPane";
			this.Size = new System.Drawing.Size(482, 282);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.OpenFileDialog openFileDialog2;
		private System.Windows.Forms.TextBox textBoxServerUsername;
		private System.Windows.Forms.TextBox textBoxServerPasword;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonManage;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button buttonBrowseSAConfig;
		private System.Windows.Forms.TextBox textBoxSAConfig;
		private System.Windows.Forms.Button buttonBrowseWLDB;
		private System.Windows.Forms.TextBox textBoxWLDB;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBoxRemoteServer;
	}
}
