
namespace Sscat.Core.Gui
{
	partial class CardEventEditor
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
//			this.cardConfigListView.SelectedIndexChanged -= new System.EventHandler(this.CardSelectedIndexChanged);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardEventEditor));
			this.CardEventsGroupBox = new System.Windows.Forms.GroupBox();
			this.scriptEventListView = new Sscat.Core.Gui.ScriptCardEventListView();
			this.colHeaderScriptEventNo = new System.Windows.Forms.ColumnHeader();
			this.colHeaderScriptEventDetail = new System.Windows.Forms.ColumnHeader();
			this.scriptResultListView = new Sscat.Core.Gui.ScriptResultListView();
			this.colHeaderScriptNo = new System.Windows.Forms.ColumnHeader();
			this.colHeaderScriptName = new System.Windows.Forms.ColumnHeader();
			this.cardEventListView = new Sscat.Core.Gui.CardEventListView();
			this.colHeaderCardEventNo = new System.Windows.Forms.ColumnHeader();
			this.colHeaderCardEventCurrentValue = new System.Windows.Forms.ColumnHeader();
			this.colHeaderChangeCardTo = new System.Windows.Forms.ColumnHeader();
			this._labelInformation = new System.Windows.Forms.Label();
			this.cardDetailGroupBox = new System.Windows.Forms.GroupBox();
			this.buttonRestoreDefaultMSRCard = new System.Windows.Forms.Button();
			this.buttonDeleteAllMSRCard = new System.Windows.Forms.Button();
			this.buttonDeleteMSRCard = new System.Windows.Forms.Button();
			this.buttonEditMSRCard = new System.Windows.Forms.Button();
			this.buttonAddMSRCard = new System.Windows.Forms.Button();
			this.cardConfigListView = new System.Windows.Forms.ListView();
			this.colHeaderCardName = new System.Windows.Forms.ColumnHeader();
			this.colHeaderTrack1 = new System.Windows.Forms.ColumnHeader();
			this.colHeaderTrack2 = new System.Windows.Forms.ColumnHeader();
			this.colHeaderTrack3 = new System.Windows.Forms.ColumnHeader();
			this.buttonDone = new System.Windows.Forms.Button();
			this._buttonUndoAllChanges = new System.Windows.Forms.Button();
			this._buttonUndoChange = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.CardEventsGroupBox.SuspendLayout();
			this.cardDetailGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// CardEventsGroupBox
			// 
			this.CardEventsGroupBox.Controls.Add(this.scriptEventListView);
			this.CardEventsGroupBox.Controls.Add(this.scriptResultListView);
			this.CardEventsGroupBox.Controls.Add(this.cardEventListView);
			this.CardEventsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CardEventsGroupBox.Location = new System.Drawing.Point(15, 54);
			this.CardEventsGroupBox.Name = "CardEventsGroupBox";
			this.CardEventsGroupBox.Size = new System.Drawing.Size(851, 281);
			this.CardEventsGroupBox.TabIndex = 0;
			this.CardEventsGroupBox.TabStop = false;
			this.CardEventsGroupBox.Text = "STEP 1: Select the card you want to change";
			// 
			// scriptEventListView
			// 
			this.scriptEventListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.scriptEventListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colHeaderScriptEventNo,
									this.colHeaderScriptEventDetail});
			this.scriptEventListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.scriptEventListView.FullRowSelect = true;
			this.scriptEventListView.GridLines = true;
			this.scriptEventListView.Location = new System.Drawing.Point(600, 19);
			this.scriptEventListView.MultiSelect = false;
			this.scriptEventListView.Name = "scriptEventListView";
			this.scriptEventListView.ScriptEvents = new Sscat.Core.Models.ScriptModel.IScriptEvent[0];
			this.scriptEventListView.Size = new System.Drawing.Size(242, 256);
			this.scriptEventListView.TabIndex = 6;
			this.scriptEventListView.UseCompatibleStateImageBehavior = false;
			this.scriptEventListView.View = System.Windows.Forms.View.Details;
			// 
			// colHeaderScriptEventNo
			// 
			this.colHeaderScriptEventNo.Text = "#";
			this.colHeaderScriptEventNo.Width = 30;
			// 
			// colHeaderScriptEventDetail
			// 
			this.colHeaderScriptEventDetail.Text = "Script\'s Event Details";
			this.colHeaderScriptEventDetail.Width = 208;
			// 
			// scriptResultListView
			// 
			this.scriptResultListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.scriptResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colHeaderScriptNo,
									this.colHeaderScriptName});
			this.scriptResultListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.scriptResultListView.FullRowSelect = true;
			this.scriptResultListView.GridLines = true;
			this.scriptResultListView.HideSelection = false;
			this.scriptResultListView.Location = new System.Drawing.Point(380, 19);
			this.scriptResultListView.MultiSelect = false;
			this.scriptResultListView.Name = "scriptResultListView";
			this.scriptResultListView.Size = new System.Drawing.Size(214, 256);
			this.scriptResultListView.TabIndex = 5;
			this.scriptResultListView.UseCompatibleStateImageBehavior = false;
			this.scriptResultListView.View = System.Windows.Forms.View.Details;
			// 
			// colHeaderScriptNo
			// 
			this.colHeaderScriptNo.Text = "#";
			this.colHeaderScriptNo.Width = 30;
			// 
			// colHeaderScriptName
			// 
			this.colHeaderScriptName.Text = "Script Name";
			this.colHeaderScriptName.Width = 179;
			// 
			// cardEventListView
			// 
			this.cardEventListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colHeaderCardEventNo,
									this.colHeaderCardEventCurrentValue,
									this.colHeaderChangeCardTo});
			this.cardEventListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cardEventListView.FullRowSelect = true;
			this.cardEventListView.GridLines = true;
			this.cardEventListView.HideSelection = false;
			this.cardEventListView.Location = new System.Drawing.Point(6, 19);
			this.cardEventListView.MultiSelect = false;
			this.cardEventListView.Name = "cardEventListView";
			this.cardEventListView.ScriptEvents = ((System.Collections.Generic.List<Sscat.Core.Models.ScriptModel.IScriptEvent>)(resources.GetObject("cardEventListView.ScriptEvents")));
			this.cardEventListView.Size = new System.Drawing.Size(368, 256);
			this.cardEventListView.TabIndex = 3;
			this.cardEventListView.UseCompatibleStateImageBehavior = false;
			this.cardEventListView.View = System.Windows.Forms.View.Details;
			// 
			// colHeaderCardEventNo
			// 
			this.colHeaderCardEventNo.Text = "#";
			this.colHeaderCardEventNo.Width = 30;
			// 
			// colHeaderCardEventCurrentValue
			// 
			this.colHeaderCardEventCurrentValue.Text = "Current Card";
			this.colHeaderCardEventCurrentValue.Width = 160;
			// 
			// colHeaderChangeCardTo
			// 
			this.colHeaderChangeCardTo.Text = "Change Card To";
			this.colHeaderChangeCardTo.Width = 172;
			// 
			// labelInformation
			// 
			this._labelInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._labelInformation.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this._labelInformation.Location = new System.Drawing.Point(65, 10);
			this._labelInformation.Name = "labelInformation";
			this._labelInformation.Size = new System.Drawing.Size(787, 43);
			this._labelInformation.TabIndex = 1;
			this._labelInformation.Text = "It seems you are using MS Card(s) in your testing. To complete the generation of " +
			"your automation scripts, you need to introduce the details of this/these card(s)" +
			".";
			// 
			// cardDetailGroupBox
			// 
			this.cardDetailGroupBox.Controls.Add(this.buttonRestoreDefaultMSRCard);
			this.cardDetailGroupBox.Controls.Add(this.buttonDeleteAllMSRCard);
			this.cardDetailGroupBox.Controls.Add(this.buttonDeleteMSRCard);
			this.cardDetailGroupBox.Controls.Add(this.buttonEditMSRCard);
			this.cardDetailGroupBox.Controls.Add(this.buttonAddMSRCard);
			this.cardDetailGroupBox.Controls.Add(this.cardConfigListView);
			this.cardDetailGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cardDetailGroupBox.Location = new System.Drawing.Point(15, 350);
			this.cardDetailGroupBox.Name = "cardDetailGroupBox";
			this.cardDetailGroupBox.Size = new System.Drawing.Size(851, 281);
			this.cardDetailGroupBox.TabIndex = 2;
			this.cardDetailGroupBox.TabStop = false;
			this.cardDetailGroupBox.Text = "STEP 2: Select a card you want to use instead";
			// 
			// buttonRestoreDefaultMSRCard
			// 
			this.buttonRestoreDefaultMSRCard.Location = new System.Drawing.Point(742, 235);
			this.buttonRestoreDefaultMSRCard.Name = "buttonRestoreDefaultMSRCard";
			this.buttonRestoreDefaultMSRCard.Size = new System.Drawing.Size(100, 40);
			this.buttonRestoreDefaultMSRCard.TabIndex = 5;
			this.buttonRestoreDefaultMSRCard.Text = "Load Default";
			this.buttonRestoreDefaultMSRCard.UseVisualStyleBackColor = true;
			this.buttonRestoreDefaultMSRCard.Visible = false;
			// 
			// buttonDeleteAllMSRCard
			// 
			this.buttonDeleteAllMSRCard.Location = new System.Drawing.Point(742, 157);
			this.buttonDeleteAllMSRCard.Name = "buttonDeleteAllMSRCard";
			this.buttonDeleteAllMSRCard.Size = new System.Drawing.Size(100, 40);
			this.buttonDeleteAllMSRCard.TabIndex = 4;
			this.buttonDeleteAllMSRCard.Text = "Delete All";
			this.buttonDeleteAllMSRCard.UseVisualStyleBackColor = true;
			this.buttonDeleteAllMSRCard.Visible = false;
			// 
			// buttonDeleteMSRCard
			// 
			this.buttonDeleteMSRCard.Location = new System.Drawing.Point(742, 111);
			this.buttonDeleteMSRCard.Name = "buttonDeleteMSRCard";
			this.buttonDeleteMSRCard.Size = new System.Drawing.Size(100, 40);
			this.buttonDeleteMSRCard.TabIndex = 3;
			this.buttonDeleteMSRCard.Text = "Delete";
			this.buttonDeleteMSRCard.UseVisualStyleBackColor = true;
			this.buttonDeleteMSRCard.Visible = false;
			// 
			// buttonEditMSRCard
			// 
			this.buttonEditMSRCard.Location = new System.Drawing.Point(742, 65);
			this.buttonEditMSRCard.Name = "buttonEditMSRCard";
			this.buttonEditMSRCard.Size = new System.Drawing.Size(100, 40);
			this.buttonEditMSRCard.TabIndex = 2;
			this.buttonEditMSRCard.Text = "Edit";
			this.buttonEditMSRCard.UseVisualStyleBackColor = true;
			this.buttonEditMSRCard.Click += new System.EventHandler(this.ButtonEditMSRCardClick);
			// 
			// buttonAddMSRCard
			// 
			this.buttonAddMSRCard.Location = new System.Drawing.Point(742, 19);
			this.buttonAddMSRCard.Name = "buttonAddMSRCard";
			this.buttonAddMSRCard.Size = new System.Drawing.Size(100, 40);
			this.buttonAddMSRCard.TabIndex = 1;
			this.buttonAddMSRCard.Text = "Add";
			this.buttonAddMSRCard.UseVisualStyleBackColor = true;
			this.buttonAddMSRCard.Click += new System.EventHandler(this.ButtonAddMSRCardClick);
			// 
			// cardConfigListView
			// 
			this.cardConfigListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colHeaderCardName,
									this.colHeaderTrack1,
									this.colHeaderTrack2,
									this.colHeaderTrack3});
			this.cardConfigListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cardConfigListView.FullRowSelect = true;
			this.cardConfigListView.GridLines = true;
			this.cardConfigListView.HideSelection = false;
			this.cardConfigListView.Location = new System.Drawing.Point(6, 19);
			this.cardConfigListView.MultiSelect = false;
			this.cardConfigListView.Name = "cardConfigListView";
			this.cardConfigListView.Size = new System.Drawing.Size(730, 256);
			this.cardConfigListView.TabIndex = 0;
			this.cardConfigListView.UseCompatibleStateImageBehavior = false;
			this.cardConfigListView.View = System.Windows.Forms.View.Details;
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
			// buttonDone
			// 
			this.buttonDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonDone.Location = new System.Drawing.Point(451, 637);
			this.buttonDone.Name = "buttonDone";
			this.buttonDone.Size = new System.Drawing.Size(100, 40);
			this.buttonDone.TabIndex = 3;
			this.buttonDone.Text = "Done";
			this.buttonDone.UseVisualStyleBackColor = true;
			this.buttonDone.Click += new System.EventHandler(this.ButtonDoneClick);
			// 
			// buttonUndoAllChanges
			// 
			this._buttonUndoAllChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._buttonUndoAllChanges.Location = new System.Drawing.Point(345, 637);
			this._buttonUndoAllChanges.Name = "buttonUndoAllChanges";
			this._buttonUndoAllChanges.Size = new System.Drawing.Size(100, 40);
			this._buttonUndoAllChanges.TabIndex = 4;
			this._buttonUndoAllChanges.Text = "Undo All";
			this._buttonUndoAllChanges.UseVisualStyleBackColor = true;
			this._buttonUndoAllChanges.Click += new System.EventHandler(this.ButtonUndoAllChangesClick);
			// 
			// buttonUndoChange
			// 
			this._buttonUndoChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._buttonUndoChange.Location = new System.Drawing.Point(239, 637);
			this._buttonUndoChange.Name = "buttonUndoChange";
			this._buttonUndoChange.Size = new System.Drawing.Size(100, 40);
			this._buttonUndoChange.TabIndex = 5;
			this._buttonUndoChange.Text = "Undo Change";
			this._buttonUndoChange.UseVisualStyleBackColor = true;
			this._buttonUndoChange.Click += new System.EventHandler(this.ButtonUndoChangeClick);
			// 
			// label1
			// 
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.Location = new System.Drawing.Point(7, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 37);
			this.label1.TabIndex = 6;
			// 
			// CardEventEditor
			// 
			this.AcceptButton = this.buttonDone;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(878, 680);
			this.Controls.Add(this.label1);
			this.Controls.Add(this._buttonUndoChange);
			this.Controls.Add(this._buttonUndoAllChanges);
			this.Controls.Add(this.buttonDone);
			this.Controls.Add(this.cardDetailGroupBox);
			this.Controls.Add(this._labelInformation);
			this.Controls.Add(this.CardEventsGroupBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "CardEventEditor";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MS Card Editor";
			this.CardEventsGroupBox.ResumeLayout(false);
			this.cardDetailGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _buttonUndoChange;
		private System.Windows.Forms.Label _labelInformation;
		private System.Windows.Forms.Button _buttonUndoAllChanges;
		private System.Windows.Forms.ColumnHeader colHeaderScriptEventDetail;
		private System.Windows.Forms.ColumnHeader colHeaderScriptEventNo;
		private Sscat.Core.Gui.ScriptCardEventListView scriptEventListView;
		private System.Windows.Forms.GroupBox CardEventsGroupBox;
		private System.Windows.Forms.GroupBox cardDetailGroupBox;
		private System.Windows.Forms.ColumnHeader colHeaderTrack3;
		private System.Windows.Forms.ColumnHeader colHeaderTrack2;
		private System.Windows.Forms.ColumnHeader colHeaderTrack1;
		private System.Windows.Forms.ColumnHeader colHeaderScriptNo;
		private System.Windows.Forms.ColumnHeader colHeaderScriptName;
		private System.Windows.Forms.ColumnHeader colHeaderChangeCardTo;
		private System.Windows.Forms.ColumnHeader colHeaderCardEventNo;
		private System.Windows.Forms.ColumnHeader colHeaderCardName;
		private System.Windows.Forms.ColumnHeader colHeaderCardEventCurrentValue;
		private System.Windows.Forms.Button buttonDone;
		private System.Windows.Forms.Button buttonRestoreDefaultMSRCard;
		private System.Windows.Forms.Button buttonEditMSRCard;
		private System.Windows.Forms.Button buttonDeleteMSRCard;
		private System.Windows.Forms.Button buttonDeleteAllMSRCard;
		private System.Windows.Forms.ListView cardConfigListView;
		private Sscat.Core.Gui.ScriptResultListView scriptResultListView;
		private Sscat.Core.Gui.CardEventListView cardEventListView;
		private System.Windows.Forms.Button buttonAddMSRCard;
		
	}
}
