//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

namespace Sscat.Gui
{
	partial class ClientPane
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientPane));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonGenerateScripts = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonRunScripts = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonSettings = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.outputPane1 = new Sscat.Gui.OutputPane();
			this.toolStrip1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripButtonGenerateScripts,
									this.toolStripButtonRunScripts,
									this.toolStripSeparator1,
									this.toolStripButtonSettings});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(600, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButtonGenerateScripts
			// 
			this.toolStripButtonGenerateScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.toolStripButtonGenerateScripts.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonGenerateScripts.Image")));
			this.toolStripButtonGenerateScripts.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonGenerateScripts.Name = "toolStripButtonGenerateScripts";
			this.toolStripButtonGenerateScripts.Size = new System.Drawing.Size(128, 22);
			this.toolStripButtonGenerateScripts.Text = "Generate Scripts";
			this.toolStripButtonGenerateScripts.Click += new System.EventHandler(this.ToolStripButtonGenerateScriptsClick);
			// 
			// toolStripButtonRunScripts
			// 
			this.toolStripButtonRunScripts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.toolStripButtonRunScripts.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRunScripts.Image")));
			this.toolStripButtonRunScripts.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonRunScripts.Name = "toolStripButtonRunScripts";
			this.toolStripButtonRunScripts.Size = new System.Drawing.Size(96, 22);
			this.toolStripButtonRunScripts.Text = "Run Scripts";
			this.toolStripButtonRunScripts.Click += new System.EventHandler(this.ToolStripButtonRunScriptsClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButtonSettings
			// 
			this.toolStripButtonSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.toolStripButtonSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSettings.Image")));
			this.toolStripButtonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonSettings.Name = "toolStripButtonSettings";
			this.toolStripButtonSettings.Size = new System.Drawing.Size(76, 22);
			this.toolStripButtonSettings.Text = "Settings";
			this.toolStripButtonSettings.Click += new System.EventHandler(this.ToolStripButtonSettingsClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.outputPane1);
			this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainer1.Size = new System.Drawing.Size(600, 425);
			this.splitContainer1.SplitterDistance = 336;
			this.splitContainer1.TabIndex = 1;
			// 
			// outputPane1
			// 
			this.outputPane1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputPane1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.outputPane1.Location = new System.Drawing.Point(0, 0);
			this.outputPane1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.outputPane1.Name = "outputPane1";
			this.outputPane1.Size = new System.Drawing.Size(600, 85);
			this.outputPane1.TabIndex = 0;
			// 
			// ClientPane
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "ClientPane";
			this.Size = new System.Drawing.Size(600, 450);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripButton toolStripButtonSettings;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButtonRunScripts;
		private System.Windows.Forms.ToolStripButton toolStripButtonGenerateScripts;
		private Sscat.Gui.OutputPane outputPane1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStrip toolStrip1;
	}
}
