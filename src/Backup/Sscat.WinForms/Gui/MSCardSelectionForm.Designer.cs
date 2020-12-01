/*
 * Created by SharpDevelop.
 * User: scot
 * Date: 7/22/2013
 * Time: 8:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Sscat.Gui
{
	partial class MSCardSelectionForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSCardSelectionForm));
			this.cardDetailGroupBox = new System.Windows.Forms.GroupBox();
			this.btnCloseWindow = new System.Windows.Forms.Button();
			this.buttonSelectMSCard = new System.Windows.Forms.Button();
			this.buttonEditMSCard = new System.Windows.Forms.Button();
			this.buttonAddNewMSCard = new System.Windows.Forms.Button();
			this.listViewMSCards = new System.Windows.Forms.ListView();
			this.colHeaderCardName = new System.Windows.Forms.ColumnHeader();
			this.colHeaderTrack1 = new System.Windows.Forms.ColumnHeader();
			this.colHeaderTrack2 = new System.Windows.Forms.ColumnHeader();
			this.colHeaderTrack3 = new System.Windows.Forms.ColumnHeader();
			this.cardDetailGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// cardDetailGroupBox
			// 
			this.cardDetailGroupBox.Controls.Add(this.btnCloseWindow);
			this.cardDetailGroupBox.Controls.Add(this.buttonSelectMSCard);
			this.cardDetailGroupBox.Controls.Add(this.buttonEditMSCard);
			this.cardDetailGroupBox.Controls.Add(this.buttonAddNewMSCard);
			this.cardDetailGroupBox.Controls.Add(this.listViewMSCards);
			this.cardDetailGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cardDetailGroupBox.Location = new System.Drawing.Point(16, 15);
			this.cardDetailGroupBox.Margin = new System.Windows.Forms.Padding(4);
			this.cardDetailGroupBox.Name = "cardDetailGroupBox";
			this.cardDetailGroupBox.Padding = new System.Windows.Forms.Padding(4);
			this.cardDetailGroupBox.Size = new System.Drawing.Size(797, 346);
			this.cardDetailGroupBox.TabIndex = 3;
			this.cardDetailGroupBox.TabStop = false;
			this.cardDetailGroupBox.Text = "Please select the card you want to use instead";
			// 
			// btnCloseWindow
			// 
			this.btnCloseWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCloseWindow.BackColor = System.Drawing.Color.Transparent;
			this.btnCloseWindow.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCloseWindow.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCloseWindow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCloseWindow.ForeColor = System.Drawing.Color.Black;
			this.btnCloseWindow.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseWindow.Image")));
			this.btnCloseWindow.Location = new System.Drawing.Point(752, 259);
			this.btnCloseWindow.Margin = new System.Windows.Forms.Padding(4);
			this.btnCloseWindow.Name = "btnCloseWindow";
			this.btnCloseWindow.Size = new System.Drawing.Size(35, 35);
			this.btnCloseWindow.TabIndex = 94;
			this.btnCloseWindow.Tag = "delete";
			this.btnCloseWindow.UseVisualStyleBackColor = false;
			this.btnCloseWindow.Click += new System.EventHandler(this.ButtonCloseWindowClick);
			// 
			// buttonSelectMSCard
			// 
			this.buttonSelectMSCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelectMSCard.BackColor = System.Drawing.Color.Transparent;
			this.buttonSelectMSCard.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonSelectMSCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonSelectMSCard.ForeColor = System.Drawing.Color.Black;
			this.buttonSelectMSCard.Image = ((System.Drawing.Image)(resources.GetObject("buttonSelectMSCard.Image")));
			this.buttonSelectMSCard.Location = new System.Drawing.Point(752, 302);
			this.buttonSelectMSCard.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSelectMSCard.Name = "buttonSelectMSCard";
			this.buttonSelectMSCard.Size = new System.Drawing.Size(35, 35);
			this.buttonSelectMSCard.TabIndex = 93;
			this.buttonSelectMSCard.Tag = "delete";
			this.buttonSelectMSCard.UseVisualStyleBackColor = false;
			this.buttonSelectMSCard.Click += new System.EventHandler(this.ButtonSelectMSCardClick);
			// 
			// buttonEditMSCard
			// 
			this.buttonEditMSCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonEditMSCard.BackColor = System.Drawing.Color.Transparent;
			this.buttonEditMSCard.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonEditMSCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonEditMSCard.ForeColor = System.Drawing.Color.Black;
			this.buttonEditMSCard.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditMSCard.Image")));
			this.buttonEditMSCard.Location = new System.Drawing.Point(752, 66);
			this.buttonEditMSCard.Margin = new System.Windows.Forms.Padding(4);
			this.buttonEditMSCard.Name = "buttonEditMSCard";
			this.buttonEditMSCard.Size = new System.Drawing.Size(35, 35);
			this.buttonEditMSCard.TabIndex = 92;
			this.buttonEditMSCard.Tag = "delete";
			this.buttonEditMSCard.UseVisualStyleBackColor = false;
			this.buttonEditMSCard.Click += new System.EventHandler(this.ButtonEditMSCardClick);
			// 
			// buttonAddNewMSCard
			// 
			this.buttonAddNewMSCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddNewMSCard.BackColor = System.Drawing.Color.Transparent;
			this.buttonAddNewMSCard.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonAddNewMSCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonAddNewMSCard.ForeColor = System.Drawing.Color.Black;
			this.buttonAddNewMSCard.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddNewMSCard.Image")));
			this.buttonAddNewMSCard.Location = new System.Drawing.Point(752, 23);
			this.buttonAddNewMSCard.Margin = new System.Windows.Forms.Padding(4);
			this.buttonAddNewMSCard.Name = "buttonAddNewMSCard";
			this.buttonAddNewMSCard.Size = new System.Drawing.Size(35, 35);
			this.buttonAddNewMSCard.TabIndex = 91;
			this.buttonAddNewMSCard.Tag = "delete";
			this.buttonAddNewMSCard.UseVisualStyleBackColor = false;
			this.buttonAddNewMSCard.Click += new System.EventHandler(this.ButtonAddNewMSCardClick);
			// 
			// listViewMSCards
			// 
			this.listViewMSCards.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colHeaderCardName,
									this.colHeaderTrack1,
									this.colHeaderTrack2,
									this.colHeaderTrack3});
			this.listViewMSCards.FullRowSelect = true;
			this.listViewMSCards.GridLines = true;
			this.listViewMSCards.HideSelection = false;
			this.listViewMSCards.Location = new System.Drawing.Point(8, 23);
			this.listViewMSCards.Margin = new System.Windows.Forms.Padding(4);
			this.listViewMSCards.MultiSelect = false;
			this.listViewMSCards.Name = "listViewMSCards";
			this.listViewMSCards.Size = new System.Drawing.Size(736, 314);
			this.listViewMSCards.TabIndex = 0;
			this.listViewMSCards.UseCompatibleStateImageBehavior = false;
			this.listViewMSCards.View = System.Windows.Forms.View.Details;
			this.listViewMSCards.DoubleClick += new System.EventHandler(this.ButtonSelectMSCardClick);
			// 
			// colHeaderCardName
			// 
			this.colHeaderCardName.Text = "Card Name";
			this.colHeaderCardName.Width = 190;
			// 
			// colHeaderTrack1
			// 
			this.colHeaderTrack1.Text = "Track 1";
			this.colHeaderTrack1.Width = 175;
			// 
			// colHeaderTrack2
			// 
			this.colHeaderTrack2.Text = "Track 2";
			this.colHeaderTrack2.Width = 175;
			// 
			// colHeaderTrack3
			// 
			this.colHeaderTrack3.Text = "Track 3";
			this.colHeaderTrack3.Width = 175;
			// 
			// MSCardSelectionForm
			// 
			this.AcceptButton = this.buttonSelectMSCard;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCloseWindow;
			this.ClientSize = new System.Drawing.Size(826, 373);
			this.Controls.Add(this.cardDetailGroupBox);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MSCardSelectionForm";
			this.Text = "MS Card Selection";
			this.cardDetailGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button buttonSelectMSCard;
		private System.Windows.Forms.Button buttonEditMSCard;
		private System.Windows.Forms.Button buttonAddNewMSCard;
		private System.Windows.Forms.Button btnCloseWindow;
		private System.Windows.Forms.ListView listViewMSCards;
		private System.Windows.Forms.ColumnHeader colHeaderTrack3;
		private System.Windows.Forms.ColumnHeader colHeaderTrack2;
		private System.Windows.Forms.ColumnHeader colHeaderTrack1;
		private System.Windows.Forms.ColumnHeader colHeaderCardName;
		private System.Windows.Forms.GroupBox cardDetailGroupBox;
	}
}
