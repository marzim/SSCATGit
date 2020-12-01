//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

namespace Sscat.Gui
{
	partial class WldbManagerPane
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
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.radioButtonCreateBackupWLDBScript = new System.Windows.Forms.RadioButton();
			this.radioButtonUpdate = new System.Windows.Forms.RadioButton();
			this.radioButtonCreateUpdateWLDBScript = new System.Windows.Forms.RadioButton();
			this.radioButtonBackup = new System.Windows.Forms.RadioButton();
			this.buttonClose = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.buttonBrowseFolderSAConfig = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonBrowseFolderWLDB = new System.Windows.Forms.Button();
			this.textBoxWLDB = new System.Windows.Forms.TextBox();
			this.buttonBrowseWLDB = new System.Windows.Forms.Button();
			this.textBoxSAConfig = new System.Windows.Forms.TextBox();
			this.buttonBrowseSAConfig = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxRemoteServer = new System.Windows.Forms.TextBox();
			this.textBoxScriptFileName = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonManage = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.radioButtonCreateBackupWLDBScript);
			this.groupBox3.Controls.Add(this.radioButtonUpdate);
			this.groupBox3.Controls.Add(this.radioButtonCreateUpdateWLDBScript);
			this.groupBox3.Controls.Add(this.radioButtonBackup);
			this.groupBox3.Location = new System.Drawing.Point(8, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(218, 238);
			this.groupBox3.TabIndex = 30;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Mode";
			// 
			// radioButtonCreateBackupWLDBScript
			// 
			this.radioButtonCreateBackupWLDBScript.Location = new System.Drawing.Point(24, 124);
			this.radioButtonCreateBackupWLDBScript.Name = "radioButtonCreateBackupWLDBScript";
			this.radioButtonCreateBackupWLDBScript.Size = new System.Drawing.Size(182, 26);
			this.radioButtonCreateBackupWLDBScript.TabIndex = 3;
			this.radioButtonCreateBackupWLDBScript.Text = "Create Backup WLDB Script";
			this.radioButtonCreateBackupWLDBScript.CheckedChanged += new System.EventHandler(this.RadioButtonUpdateCheckedChanged);
			// 
			// radioButtonUpdate
			// 
			this.radioButtonUpdate.Location = new System.Drawing.Point(24, 25);
			this.radioButtonUpdate.Name = "radioButtonUpdate";
			this.radioButtonUpdate.Size = new System.Drawing.Size(128, 26);
			this.radioButtonUpdate.TabIndex = 0;
			this.radioButtonUpdate.Text = "Update WLDB files";
			this.radioButtonUpdate.CheckedChanged += new System.EventHandler(this.RadioButtonUpdateCheckedChanged);
			// 
			// radioButtonCreateUpdateWLDBScript
			// 
			this.radioButtonCreateUpdateWLDBScript.Location = new System.Drawing.Point(24, 92);
			this.radioButtonCreateUpdateWLDBScript.Name = "radioButtonCreateUpdateWLDBScript";
			this.radioButtonCreateUpdateWLDBScript.Size = new System.Drawing.Size(164, 26);
			this.radioButtonCreateUpdateWLDBScript.TabIndex = 2;
			this.radioButtonCreateUpdateWLDBScript.Text = "Create Update WLDB Script";
			this.radioButtonCreateUpdateWLDBScript.CheckedChanged += new System.EventHandler(this.RadioButtonUpdateCheckedChanged);
			// 
			// radioButtonBackup
			// 
			this.radioButtonBackup.Location = new System.Drawing.Point(24, 60);
			this.radioButtonBackup.Name = "radioButtonBackup";
			this.radioButtonBackup.Size = new System.Drawing.Size(136, 26);
			this.radioButtonBackup.TabIndex = 1;
			this.radioButtonBackup.Text = "Backup WLDB files";
			this.radioButtonBackup.CheckedChanged += new System.EventHandler(this.RadioButtonUpdateCheckedChanged);
			// 
			// buttonClose
			// 
			this.buttonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonClose.Location = new System.Drawing.Point(435, 261);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(112, 34);
			this.buttonClose.TabIndex = 29;
			this.buttonClose.Text = "Close";
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.buttonBrowseFolderSAConfig);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.buttonBrowseFolderWLDB);
			this.groupBox2.Controls.Add(this.textBoxWLDB);
			this.groupBox2.Controls.Add(this.buttonBrowseWLDB);
			this.groupBox2.Controls.Add(this.textBoxSAConfig);
			this.groupBox2.Controls.Add(this.buttonBrowseSAConfig);
			this.groupBox2.Location = new System.Drawing.Point(232, 110);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(456, 136);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "WLDB Files";
			// 
			// buttonBrowseFolderSAConfig
			// 
			this.buttonBrowseFolderSAConfig.Location = new System.Drawing.Point(401, 70);
			this.buttonBrowseFolderSAConfig.Name = "buttonBrowseFolderSAConfig";
			this.buttonBrowseFolderSAConfig.Size = new System.Drawing.Size(32, 23);
			this.buttonBrowseFolderSAConfig.TabIndex = 12;
			this.buttonBrowseFolderSAConfig.Text = "...";
			this.buttonBrowseFolderSAConfig.Visible = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(25, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 18);
			this.label2.TabIndex = 10;
			this.label2.Text = "SAConfig.mdb";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(25, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 17);
			this.label1.TabIndex = 9;
			this.label1.Text = "WLDB.mdb";
			// 
			// buttonBrowseFolderWLDB
			// 
			this.buttonBrowseFolderWLDB.Location = new System.Drawing.Point(401, 14);
			this.buttonBrowseFolderWLDB.Name = "buttonBrowseFolderWLDB";
			this.buttonBrowseFolderWLDB.Size = new System.Drawing.Size(32, 22);
			this.buttonBrowseFolderWLDB.TabIndex = 11;
			this.buttonBrowseFolderWLDB.Text = "...";
			this.buttonBrowseFolderWLDB.Visible = false;
			// 
			// textBoxWLDB
			// 
			this.textBoxWLDB.Location = new System.Drawing.Point(25, 42);
			this.textBoxWLDB.Name = "textBoxWLDB";
			this.textBoxWLDB.Size = new System.Drawing.Size(370, 21);
			this.textBoxWLDB.TabIndex = 3;
			// 
			// buttonBrowseWLDB
			// 
			this.buttonBrowseWLDB.Location = new System.Drawing.Point(401, 42);
			this.buttonBrowseWLDB.Name = "buttonBrowseWLDB";
			this.buttonBrowseWLDB.Size = new System.Drawing.Size(32, 22);
			this.buttonBrowseWLDB.TabIndex = 6;
			this.buttonBrowseWLDB.Text = "...";
			this.buttonBrowseWLDB.Click += new System.EventHandler(this.ButtonBrowseWLDBClick);
			// 
			// textBoxSAConfig
			// 
			this.textBoxSAConfig.Location = new System.Drawing.Point(25, 94);
			this.textBoxSAConfig.Name = "textBoxSAConfig";
			this.textBoxSAConfig.Size = new System.Drawing.Size(370, 21);
			this.textBoxSAConfig.TabIndex = 7;
			// 
			// buttonBrowseSAConfig
			// 
			this.buttonBrowseSAConfig.Location = new System.Drawing.Point(401, 94);
			this.buttonBrowseSAConfig.Name = "buttonBrowseSAConfig";
			this.buttonBrowseSAConfig.Size = new System.Drawing.Size(32, 23);
			this.buttonBrowseSAConfig.TabIndex = 8;
			this.buttonBrowseSAConfig.Text = "...";
			this.buttonBrowseSAConfig.Click += new System.EventHandler(this.ButtonBrowseSAConfigClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.textBoxRemoteServer);
			this.groupBox1.Controls.Add(this.textBoxScriptFileName);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(232, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(456, 96);
			this.groupBox1.TabIndex = 27;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "WLDB Info";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(25, 63);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(89, 23);
			this.label7.TabIndex = 33;
			this.label7.Text = "Script File Name";
			// 
			// textBoxRemoteServer
			// 
			this.textBoxRemoteServer.Location = new System.Drawing.Point(145, 25);
			this.textBoxRemoteServer.Name = "textBoxRemoteServer";
			this.textBoxRemoteServer.Size = new System.Drawing.Size(288, 21);
			this.textBoxRemoteServer.TabIndex = 0;
			// 
			// textBoxScriptFileName
			// 
			this.textBoxScriptFileName.Location = new System.Drawing.Point(145, 60);
			this.textBoxScriptFileName.Name = "textBoxScriptFileName";
			this.textBoxScriptFileName.Size = new System.Drawing.Size(261, 21);
			this.textBoxScriptFileName.TabIndex = 0;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(25, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(114, 23);
			this.label6.TabIndex = 32;
			this.label6.Text = "Remote Server Name";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(412, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 23);
			this.label3.TabIndex = 31;
			this.label3.Text = ".xml";
			// 
			// buttonManage
			// 
			this.buttonManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonManage.Location = new System.Drawing.Point(567, 261);
			this.buttonManage.Name = "buttonManage";
			this.buttonManage.Size = new System.Drawing.Size(121, 34);
			this.buttonManage.TabIndex = 26;
			this.buttonManage.Click += new System.EventHandler(this.ButtonManageClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Database Files (*.mdb)|*.mdb";
			this.openFileDialog1.InitialDirectory = "C:\\SSCAT";
			// 
			// folderBrowserDialog1
			// 
			this.folderBrowserDialog1.SelectedPath = "C:\\SSCAT";
			// 
			// WldbManagerPane
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonManage);
			this.Name = "WldbManagerPane";
			this.Size = new System.Drawing.Size(699, 314);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button buttonBrowseFolderSAConfig;
		private System.Windows.Forms.Button buttonBrowseFolderWLDB;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBoxScriptFileName;
		private System.Windows.Forms.RadioButton radioButtonCreateUpdateWLDBScript;
		private System.Windows.Forms.RadioButton radioButtonCreateBackupWLDBScript;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.RadioButton radioButtonBackup;
		private System.Windows.Forms.TextBox textBoxSAConfig;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton radioButtonUpdate;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonBrowseSAConfig;
		private System.Windows.Forms.TextBox textBoxWLDB;
		private System.Windows.Forms.Button buttonManage;
		private System.Windows.Forms.TextBox textBoxRemoteServer;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonBrowseWLDB;
	}
}
