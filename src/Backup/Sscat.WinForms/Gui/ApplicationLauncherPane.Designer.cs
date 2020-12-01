/*
 * Created by SharpDevelop.
 * User: scot
 * Date: 8/8/2012
 * Time: 5:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Sscat.Gui
{
	partial class ApplicationLauncherPane
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
			this.buttonCreate = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxApplicationPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxHostName = new System.Windows.Forms.TextBox();
			this.textBoxScriptFileName = new System.Windows.Forms.TextBox();
			this.buttonBrowseApplicationPath = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonCreate
			// 
			this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonCreate.Location = new System.Drawing.Point(496, 124);
			this.buttonCreate.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCreate.Name = "buttonCreate";
			this.buttonCreate.Size = new System.Drawing.Size(161, 42);
			this.buttonCreate.TabIndex = 32;
			this.buttonCreate.Text = "Create";
			this.buttonCreate.Click += new System.EventHandler(this.ButtonCreateClick);
			// 
			// buttonClose
			// 
			this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonClose.Location = new System.Drawing.Point(339, 124);
			this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(149, 42);
			this.buttonClose.TabIndex = 33;
			this.buttonClose.Text = "Close";
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(9, 78);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 28);
			this.label2.TabIndex = 35;
			this.label2.Text = "Application Path";
			// 
			// textBoxApplicationPath
			// 
			this.textBoxApplicationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxApplicationPath.Location = new System.Drawing.Point(131, 78);
			this.textBoxApplicationPath.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxApplicationPath.Name = "textBoxApplicationPath";
			this.textBoxApplicationPath.Size = new System.Drawing.Size(460, 22);
			this.textBoxApplicationPath.TabIndex = 38;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(9, 50);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 28);
			this.label1.TabIndex = 34;
			this.label1.Text = "Host Name";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(9, 22);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(114, 28);
			this.label6.TabIndex = 33;
			this.label6.Text = "Script File Name";
			// 
			// textBoxHostName
			// 
			this.textBoxHostName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxHostName.Location = new System.Drawing.Point(131, 47);
			this.textBoxHostName.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxHostName.Name = "textBoxHostName";
			this.textBoxHostName.Size = new System.Drawing.Size(460, 22);
			this.textBoxHostName.TabIndex = 36;
			// 
			// textBoxScriptFileName
			// 
			this.textBoxScriptFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxScriptFileName.Location = new System.Drawing.Point(131, 19);
			this.textBoxScriptFileName.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxScriptFileName.Name = "textBoxScriptFileName";
			this.textBoxScriptFileName.Size = new System.Drawing.Size(460, 22);
			this.textBoxScriptFileName.TabIndex = 37;
			// 
			// buttonBrowseApplicationPath
			// 
			this.buttonBrowseApplicationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonBrowseApplicationPath.Location = new System.Drawing.Point(599, 76);
			this.buttonBrowseApplicationPath.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBrowseApplicationPath.Name = "buttonBrowseApplicationPath";
			this.buttonBrowseApplicationPath.Size = new System.Drawing.Size(43, 27);
			this.buttonBrowseApplicationPath.TabIndex = 39;
			this.buttonBrowseApplicationPath.Text = "...";
			this.buttonBrowseApplicationPath.Click += new System.EventHandler(this.ButtonBrowseApplicationPathClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBoxHostName);
			this.groupBox1.Controls.Add(this.buttonBrowseApplicationPath);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBoxScriptFileName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBoxApplicationPath);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(654, 114);
			this.groupBox1.TabIndex = 40;
			this.groupBox1.TabStop = false;
			// 
			// ApplicationLauncherPane
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonCreate);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ApplicationLauncherPane";
			this.Size = new System.Drawing.Size(669, 176);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button buttonCreate;
		private System.Windows.Forms.Button buttonBrowseApplicationPath;
		private System.Windows.Forms.TextBox textBoxScriptFileName;
		private System.Windows.Forms.TextBox textBoxApplicationPath;
		private System.Windows.Forms.TextBox textBoxHostName;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
	}
}
