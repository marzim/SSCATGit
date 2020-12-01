//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

namespace Sscat.Gui
{
	partial class OutputPane
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputPane));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonWordWrap = new System.Windows.Forms.ToolStripButton();
			this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 10F);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripButtonClear,
									this.toolStripButtonWordWrap});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(370, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButtonClear
			// 
			this.toolStripButtonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.toolStripButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClear.Image")));
			this.toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonClear.Name = "toolStripButtonClear";
			this.toolStripButtonClear.Size = new System.Drawing.Size(60, 22);
			this.toolStripButtonClear.Text = "Clear";
			this.toolStripButtonClear.Click += new System.EventHandler(this.ToolStripButtonClearClick);
			// 
			// toolStripButtonWordWrap
			// 
			this.toolStripButtonWordWrap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonWordWrap.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWordWrap.Image")));
			this.toolStripButtonWordWrap.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonWordWrap.Name = "toolStripButtonWordWrap";
			this.toolStripButtonWordWrap.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonWordWrap.Text = "Word Wrap";
			this.toolStripButtonWordWrap.Click += new System.EventHandler(this.ToolStripButtonWordWrapClick);
			// 
			// richTextBoxOutput
			// 
			this.richTextBoxOutput.BackColor = System.Drawing.Color.White;
			this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBoxOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxOutput.Location = new System.Drawing.Point(0, 25);
			this.richTextBoxOutput.Name = "richTextBoxOutput";
			this.richTextBoxOutput.ReadOnly = true;
			this.richTextBoxOutput.Size = new System.Drawing.Size(370, 138);
			this.richTextBoxOutput.TabIndex = 1;
			this.richTextBoxOutput.Text = "";
			this.richTextBoxOutput.WordWrap = false;
			// 
			// OutputPane
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.richTextBoxOutput);
			this.Controls.Add(this.toolStrip1);
			this.Name = "OutputPane";
			this.Size = new System.Drawing.Size(370, 163);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.RichTextBox richTextBoxOutput;
		private System.Windows.Forms.ToolStripButton toolStripButtonClear;
		private System.Windows.Forms.ToolStripButton toolStripButtonWordWrap;
		private System.Windows.Forms.ToolStrip toolStrip1;
	}
}
