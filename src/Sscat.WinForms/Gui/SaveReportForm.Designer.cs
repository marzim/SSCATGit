/*
 * Created by SharpDevelop.
 * User: scot
 * Date: 8/13/2013
 * Time: 12:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Sscat.Gui
{
	partial class SaveReportForm
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
			this.textBoxReportFilename = new System.Windows.Forms.TextBox();
			this.textBoxReportOutputDirectory = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonReportOutputDirectory = new System.Windows.Forms.Button();
			this.folderBrowserDialogReportOutputDirectory = new System.Windows.Forms.FolderBrowserDialog();
			this.buttonOpenContainingFolder = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Report Filename";
			// 
			// textBoxReportFilename
			// 
			this.textBoxReportFilename.Location = new System.Drawing.Point(161, 6);
			this.textBoxReportFilename.Name = "textBoxReportFilename";
			this.textBoxReportFilename.Size = new System.Drawing.Size(207, 22);
			this.textBoxReportFilename.TabIndex = 1;
			this.textBoxReportFilename.TextChanged += new System.EventHandler(this.TextBoxReportFilenameTextChanged);
			// 
			// textBoxReportOutputDirectory
			// 
			this.textBoxReportOutputDirectory.Location = new System.Drawing.Point(161, 34);
			this.textBoxReportOutputDirectory.Name = "textBoxReportOutputDirectory";
			this.textBoxReportOutputDirectory.ReadOnly = true;
			this.textBoxReportOutputDirectory.Size = new System.Drawing.Size(207, 22);
			this.textBoxReportOutputDirectory.TabIndex = 2;
			this.textBoxReportOutputDirectory.Text = "C:\\SSCAT\\Reports";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(149, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Report Output Directory";
			// 
			// buttonReportOutputDirectory
			// 
			this.buttonReportOutputDirectory.Location = new System.Drawing.Point(374, 34);
			this.buttonReportOutputDirectory.Name = "buttonReportOutputDirectory";
			this.buttonReportOutputDirectory.Size = new System.Drawing.Size(34, 23);
			this.buttonReportOutputDirectory.TabIndex = 2;
			this.buttonReportOutputDirectory.Text = "...";
			this.buttonReportOutputDirectory.UseVisualStyleBackColor = true;
			this.buttonReportOutputDirectory.Click += new System.EventHandler(this.ButtonReportOutputDirectoryClick);
			// 
			// buttonOpenContainingFolder
			// 
			this.buttonOpenContainingFolder.Location = new System.Drawing.Point(161, 80);
			this.buttonOpenContainingFolder.Name = "buttonOpenContainingFolder";
			this.buttonOpenContainingFolder.Size = new System.Drawing.Size(127, 42);
			this.buttonOpenContainingFolder.TabIndex = 4;
			this.buttonOpenContainingFolder.Text = "Open Containing Folder";
			this.buttonOpenContainingFolder.UseVisualStyleBackColor = true;
			this.buttonOpenContainingFolder.Click += new System.EventHandler(this.ButtonOpenContainingFolderClick);
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(41, 80);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(114, 42);
			this.buttonOk.TabIndex = 3;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(294, 80);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(114, 42);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(374, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = ".zip";
			// 
			// SaveReportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(420, 137);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonOpenContainingFolder);
			this.Controls.Add(this.buttonReportOutputDirectory);
			this.Controls.Add(this.textBoxReportOutputDirectory);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxReportFilename);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SaveReportForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Save Report";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOpenContainingFolder;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogReportOutputDirectory;
		private System.Windows.Forms.Button buttonReportOutputDirectory;
		private System.Windows.Forms.TextBox textBoxReportOutputDirectory;
		private System.Windows.Forms.TextBox textBoxReportFilename;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
