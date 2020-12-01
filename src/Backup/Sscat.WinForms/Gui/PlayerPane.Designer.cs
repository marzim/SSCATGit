//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

namespace Sscat.Gui
{
	partial class PlayerPane
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerPane));
            this.openFileDialogScripts = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.columnHeaderWarningEventNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWarningEventType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderWarningEventNotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUIValidationEventNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUIValidationEventResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUIValidationEventDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scriptEventListView = new Sscat.Core.Gui.ScriptEventListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnExpectedResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnActualResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBoxScripts = new System.Windows.Forms.GroupBox();
            this.scriptResultListView = new Sscat.Core.Gui.ScriptResultListView();
#if NET40            
            this.warningEventListView = new Sscat.Core.Gui.WarningEventListView();
            this.uiValidationEventListView = new Sscat.Core.Gui.UIValidationEventListView();
#endif
            this.columnHeaderScriptNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnScriptName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNumberOfWarnings = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnScreenshotPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDiagnosticPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonLoadScripts = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonSaveReport = new System.Windows.Forms.Button();
            this.buttonIncreaseRepetitionIndex = new System.Windows.Forms.Button();
            this.textBoxRepetitionIndex = new System.Windows.Forms.TextBox();
            this.buttonDecreaseRepetitionIndex = new System.Windows.Forms.Button();
            this.buttonDisplayTestResult = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxScripts.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialogScripts
            // 
            this.openFileDialogScripts.Filter = "Script Files (*.xml)|*.xml;";
            this.openFileDialogScripts.InitialDirectory = "C:\\SSCAT\\Scripts";
            this.openFileDialogScripts.Multiselect = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(8, 169);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(876, 166);
            this.tabControl1.TabIndex = 120;
            // 
            // tabPage1
            // 
            this.tabPage1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage1.Controls.Add(this.scriptEventListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(868, 140);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Event List";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // scriptEventListView
            // 
            this.scriptEventListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptEventListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnExpectedResult,
            this.columnActualResult,
            this.columnHeader9});
            this.scriptEventListView.FullRowSelect = true;
            this.scriptEventListView.GridLines = true;
            this.scriptEventListView.Location = new System.Drawing.Point(2, 6);
            this.scriptEventListView.Name = "scriptEventListView";
            this.scriptEventListView.ScriptEvents = new Sscat.Core.Models.ScriptModel.IScriptEvent[0];
            this.scriptEventListView.Size = new System.Drawing.Size(860, 131);
            this.scriptEventListView.TabIndex = 119;
            this.scriptEventListView.UseCompatibleStateImageBehavior = false;
            this.scriptEventListView.View = System.Windows.Forms.View.Details;
            this.scriptEventListView.DoubleClick += new System.EventHandler(this.ScriptEventListView1DoubleClick);

#if NET40
            // 
            // warningEventListView
            // 
            this.warningEventListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warningEventListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.columnHeaderWarningEventNum,
                this.columnHeaderWarningEventType,
                this.columnHeaderWarningEventNotes});
            this.warningEventListView.FullRowSelect = true;
            this.warningEventListView.GridLines = true;
            this.warningEventListView.Location = new System.Drawing.Point(2, 6);
            this.warningEventListView.Name = "warningEventListView";
            this.warningEventListView.WarningEvents = new Sscat.Core.Models.ScriptModel.IWarningEvent[0];
            this.warningEventListView.Size = new System.Drawing.Size(860, 131);
            this.warningEventListView.View = System.Windows.Forms.View.Details;

            // 
            // uiValidationEventListView
            // 
            this.uiValidationEventListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiValidationEventListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.columnHeaderUIValidationEventNum,
                this.columnHeaderUIValidationEventResult,
                this.columnHeaderUIValidationEventDetails});
            this.uiValidationEventListView.FullRowSelect = true;
            this.uiValidationEventListView.GridLines = true;
            this.uiValidationEventListView.Location = new System.Drawing.Point(2, 6);
            this.uiValidationEventListView.Name = "uiValidationEventListView";
            this.uiValidationEventListView.ScriptEvents = new Sscat.Core.Models.ScriptModel.IScriptEvent[0];
            this.uiValidationEventListView.Size = new System.Drawing.Size(860, 131);
            this.uiValidationEventListView.View = System.Windows.Forms.View.Details;
#endif
            // 
            // columnHeaderUIValidationEventNum
            // 
            this.columnHeaderUIValidationEventNum.Text = "#";
            this.columnHeaderUIValidationEventNum.Width = 32;
            // 
            // columnHeaderUIValidationEventResult
            // 
            this.columnHeaderUIValidationEventResult.Text = "Result";
            this.columnHeaderUIValidationEventResult.Width = 75;
            // 
            // columnHeaderUIValidationEventDetails
            // 
            this.columnHeaderUIValidationEventDetails.Text = "Type";
            this.columnHeaderUIValidationEventDetails.Width = 600;
            // 
            // columnHeaderWarningEventNum
            // 
            this.columnHeaderWarningEventNum.Text = "#";
            this.columnHeaderWarningEventNum.Width = 32;
            // 
            // columnHeaderWarningEventType
            // 
            this.columnHeaderWarningEventType.Text = "Type";
            this.columnHeaderWarningEventType.Width = 75;
            // 
            // columnHeaderWarningEventNotes
            // 
            this.columnHeaderWarningEventNotes.Text = "Notes";
            this.columnHeaderWarningEventNotes.Width = 600;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 32;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Event Time";
            this.columnHeader6.Width = 75;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Event Details";
            this.columnHeader7.Width = 245;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "General Result";
            this.columnHeader8.Width = 90;
            // 
            // columnExpectedResult
            // 
            this.columnExpectedResult.Text = "Expected Result";
            this.columnExpectedResult.Width = 100;
            // 
            // columnActualResult
            // 
            this.columnActualResult.Text = "Actual Result";
            this.columnActualResult.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Screenshot Link";
            this.columnHeader9.Width = 151;
            // 
            // tabPage2
            // 
            this.tabPage2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(868, 140);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "UIValidation Event List";
            this.tabPage2.UseVisualStyleBackColor = true;
#if NET40
            this.tabPage2.Controls.Add(this.uiValidationEventListView);
#endif
            // 
            // tabPage3
            // 
            this.tabPage3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(868, 140);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Warning List";
            this.tabPage3.UseVisualStyleBackColor = true;
#if NET40
            this.tabPage3.Controls.Add(this.warningEventListView);
#endif
            // 
            // groupBoxScripts
            // 
            this.groupBoxScripts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxScripts.Controls.Add(this.scriptResultListView);
            this.groupBoxScripts.Controls.Add(this.buttonRemoveAll);
            this.groupBoxScripts.Controls.Add(this.buttonRemove);
            this.groupBoxScripts.Controls.Add(this.buttonLoadScripts);
            this.groupBoxScripts.Controls.Add(this.buttonStop);
            this.groupBoxScripts.Controls.Add(this.buttonPlay);
            this.groupBoxScripts.Controls.Add(this.buttonSaveReport);
            this.groupBoxScripts.Location = new System.Drawing.Point(8, 0);
            this.groupBoxScripts.Name = "groupBoxScripts";
            this.groupBoxScripts.Size = new System.Drawing.Size(835, 162);
            this.groupBoxScripts.TabIndex = 117;
            this.groupBoxScripts.TabStop = false;
            // 
            // scriptResultListView
            // 
            this.scriptResultListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderScriptNumber,
            this.columnScriptName,
            this.columnDuration,
            this.columnResult,
            this.columnNotes,
            this.columnNumberOfWarnings,
            this.columnScreenshotPath,
            this.columnDiagnosticPath});
            this.scriptResultListView.FullRowSelect = true;
            this.scriptResultListView.GridLines = true;
            this.scriptResultListView.HideSelection = false;
            this.scriptResultListView.Location = new System.Drawing.Point(47, 20);
            this.scriptResultListView.Name = "scriptResultListView";
            this.scriptResultListView.Size = new System.Drawing.Size(740, 136);
            this.scriptResultListView.TabIndex = 1;
            this.scriptResultListView.UseCompatibleStateImageBehavior = false;
            this.scriptResultListView.View = System.Windows.Forms.View.Details;
            this.scriptResultListView.DoubleClick += new System.EventHandler(this.ScriptResultListView1DoubleClick);
            // 
            // columnHeaderScriptNumber
            // 
            this.columnHeaderScriptNumber.Text = "#";
            this.columnHeaderScriptNumber.Width = 24;
            // 
            // columnScriptName
            // 
            this.columnScriptName.Text = "Scripts/Playlists";
            this.columnScriptName.Width = 196;
            // 
            // columnDuration
            // 
            this.columnDuration.Text = "Duration (s)";
            this.columnDuration.Width = 70;
            // 
            // columnResult
            // 
            this.columnResult.Text = "Result";
            this.columnResult.Width = 58;
            // 
            // columnNotes
            // 
            this.columnNotes.Text = "Notes";
            this.columnNotes.Width = 54;
            // 
            // columnNumberOfWarnings
            // 
            this.columnNumberOfWarnings.Text = "Warning Details";
            this.columnNumberOfWarnings.Width = 87;
            // 
            // columnScreenshotPath
            // 
            this.columnScreenshotPath.Text = "Screenshot Path";
            this.columnScreenshotPath.Width = 106;
            // 
            // columnDiagnosticPath
            // 
            this.columnDiagnosticPath.Text = "Diagnostic Path";
            this.columnDiagnosticPath.Width = 111;
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.BackColor = System.Drawing.Color.Transparent;
            this.buttonRemoveAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRemoveAll.ForeColor = System.Drawing.Color.Black;
            this.buttonRemoveAll.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemoveAll.Image")));
            this.buttonRemoveAll.Location = new System.Drawing.Point(6, 102);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(35, 35);
            this.buttonRemoveAll.TabIndex = 85;
            this.buttonRemoveAll.Tag = "delete";
            this.buttonRemoveAll.UseVisualStyleBackColor = false;
            this.buttonRemoveAll.Click += new System.EventHandler(this.ButtonRemoveAllClick);
            // 
            // buttonRemove
            // 
            this.buttonRemove.BackColor = System.Drawing.Color.Transparent;
            this.buttonRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRemove.ForeColor = System.Drawing.Color.Black;
            this.buttonRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemove.Image")));
            this.buttonRemove.Location = new System.Drawing.Point(5, 61);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(35, 35);
            this.buttonRemove.TabIndex = 81;
            this.buttonRemove.Tag = "delete";
            this.buttonRemove.UseVisualStyleBackColor = false;
            this.buttonRemove.Click += new System.EventHandler(this.ButtonRemoveClick);
            // 
            // buttonLoadScripts
            // 
            this.buttonLoadScripts.BackColor = System.Drawing.Color.Transparent;
            this.buttonLoadScripts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLoadScripts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLoadScripts.ForeColor = System.Drawing.Color.Black;
            this.buttonLoadScripts.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoadScripts.Image")));
            this.buttonLoadScripts.Location = new System.Drawing.Point(5, 20);
            this.buttonLoadScripts.Name = "buttonLoadScripts";
            this.buttonLoadScripts.Size = new System.Drawing.Size(35, 35);
            this.buttonLoadScripts.TabIndex = 78;
            this.buttonLoadScripts.UseVisualStyleBackColor = false;
            this.buttonLoadScripts.Click += new System.EventHandler(this.ButtonLoadScriptsClick);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.BackColor = System.Drawing.Color.Transparent;
            this.buttonStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStop.Enabled = false;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStop.ForeColor = System.Drawing.Color.Black;
            this.buttonStop.Image = ((System.Drawing.Image)(resources.GetObject("buttonStop.Image")));
            this.buttonStop.Location = new System.Drawing.Point(793, 61);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(35, 35);
            this.buttonStop.TabIndex = 76;
            this.buttonStop.Tag = "delete";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStopClick);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlay.BackColor = System.Drawing.Color.Transparent;
            this.buttonPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPlay.ForeColor = System.Drawing.Color.Black;
            this.buttonPlay.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlay.Image")));
            this.buttonPlay.Location = new System.Drawing.Point(793, 20);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(35, 35);
            this.buttonPlay.TabIndex = 86;
            this.buttonPlay.Tag = "delete";
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.ButtonPlayClick);
            // 
            // buttonSaveReport
            // 
            this.buttonSaveReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveReport.BackColor = System.Drawing.Color.Transparent;
            this.buttonSaveReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveReport.Enabled = false;
            this.buttonSaveReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSaveReport.ForeColor = System.Drawing.Color.Black;
            this.buttonSaveReport.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveReport.Image")));
            this.buttonSaveReport.Location = new System.Drawing.Point(793, 102);
            this.buttonSaveReport.Name = "buttonSaveReport";
            this.buttonSaveReport.Size = new System.Drawing.Size(35, 35);
            this.buttonSaveReport.TabIndex = 83;
            this.buttonSaveReport.UseVisualStyleBackColor = false;
            this.buttonSaveReport.Click += new System.EventHandler(this.ButtonSaveReportClick);
            // 
            // buttonIncreaseRepetitionIndex
            // 
            this.buttonIncreaseRepetitionIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonIncreaseRepetitionIndex.BackColor = System.Drawing.Color.Transparent;
            this.buttonIncreaseRepetitionIndex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonIncreaseRepetitionIndex.Enabled = false;
            this.buttonIncreaseRepetitionIndex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonIncreaseRepetitionIndex.ForeColor = System.Drawing.Color.Black;
            this.buttonIncreaseRepetitionIndex.Image = ((System.Drawing.Image)(resources.GetObject("buttonIncreaseRepetitionIndex.Image")));
            this.buttonIncreaseRepetitionIndex.Location = new System.Drawing.Point(849, 127);
            this.buttonIncreaseRepetitionIndex.Name = "buttonIncreaseRepetitionIndex";
            this.buttonIncreaseRepetitionIndex.Size = new System.Drawing.Size(35, 35);
            this.buttonIncreaseRepetitionIndex.TabIndex = 89;
            this.buttonIncreaseRepetitionIndex.Tag = "delete";
            this.buttonIncreaseRepetitionIndex.UseVisualStyleBackColor = false;
            this.buttonIncreaseRepetitionIndex.Click += new System.EventHandler(this.ButtonIncreaseRepetitionIndexClick);
            // 
            // textBoxRepetitionIndex
            // 
            this.textBoxRepetitionIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRepetitionIndex.Enabled = false;
            this.textBoxRepetitionIndex.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRepetitionIndex.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxRepetitionIndex.Location = new System.Drawing.Point(849, 17);
            this.textBoxRepetitionIndex.Name = "textBoxRepetitionIndex";
            this.textBoxRepetitionIndex.Size = new System.Drawing.Size(35, 22);
            this.textBoxRepetitionIndex.TabIndex = 92;
            this.textBoxRepetitionIndex.Text = "0";
            this.textBoxRepetitionIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRepetitionIndex.TextChanged += new System.EventHandler(this.RepetitionIndexChanged);
            // 
            // buttonDecreaseRepetitionIndex
            // 
            this.buttonDecreaseRepetitionIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDecreaseRepetitionIndex.BackColor = System.Drawing.Color.Transparent;
            this.buttonDecreaseRepetitionIndex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDecreaseRepetitionIndex.Enabled = false;
            this.buttonDecreaseRepetitionIndex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDecreaseRepetitionIndex.ForeColor = System.Drawing.Color.Black;
            this.buttonDecreaseRepetitionIndex.Image = ((System.Drawing.Image)(resources.GetObject("buttonDecreaseRepetitionIndex.Image")));
            this.buttonDecreaseRepetitionIndex.Location = new System.Drawing.Point(849, 86);
            this.buttonDecreaseRepetitionIndex.Name = "buttonDecreaseRepetitionIndex";
            this.buttonDecreaseRepetitionIndex.Size = new System.Drawing.Size(35, 35);
            this.buttonDecreaseRepetitionIndex.TabIndex = 87;
            this.buttonDecreaseRepetitionIndex.Tag = "delete";
            this.buttonDecreaseRepetitionIndex.UseVisualStyleBackColor = false;
            this.buttonDecreaseRepetitionIndex.Click += new System.EventHandler(this.ButtonDecreaseRepetitionIndexClick);
            // 
            // buttonDisplayTestResult
            // 
            this.buttonDisplayTestResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDisplayTestResult.BackColor = System.Drawing.Color.Transparent;
            this.buttonDisplayTestResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDisplayTestResult.Enabled = false;
            this.buttonDisplayTestResult.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDisplayTestResult.ForeColor = System.Drawing.Color.Black;
            this.buttonDisplayTestResult.Image = ((System.Drawing.Image)(resources.GetObject("buttonDisplayTestResult.Image")));
            this.buttonDisplayTestResult.Location = new System.Drawing.Point(849, 45);
            this.buttonDisplayTestResult.Name = "buttonDisplayTestResult";
            this.buttonDisplayTestResult.Size = new System.Drawing.Size(35, 35);
            this.buttonDisplayTestResult.TabIndex = 91;
            this.buttonDisplayTestResult.UseVisualStyleBackColor = false;
            this.buttonDisplayTestResult.Click += new System.EventHandler(this.ButtonDisplayTestResultClick);
            // 
            // PlayerPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonIncreaseRepetitionIndex);
            this.Controls.Add(this.textBoxRepetitionIndex);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBoxScripts);
            this.Controls.Add(this.buttonDisplayTestResult);
            this.Controls.Add(this.buttonDecreaseRepetitionIndex);
            this.Name = "PlayerPane";
            this.Size = new System.Drawing.Size(890, 338);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBoxScripts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Button buttonDisplayTestResult;
		private System.Windows.Forms.Button buttonIncreaseRepetitionIndex;
		private System.Windows.Forms.Button buttonDecreaseRepetitionIndex;
        private System.Windows.Forms.TextBox textBoxRepetitionIndex;
		private System.Windows.Forms.Button buttonSaveReport;
		private System.Windows.Forms.ColumnHeader columnHeaderScriptNumber;
		private System.Windows.Forms.ColumnHeader columnScriptName;
		private System.Windows.Forms.ColumnHeader columnResult;
		private System.Windows.Forms.ColumnHeader columnNotes;
		private System.Windows.Forms.ColumnHeader columnScreenshotPath;
		private System.Windows.Forms.ColumnHeader columnDiagnosticPath;
		private System.Windows.Forms.ColumnHeader columnExpectedResult;
		private System.Windows.Forms.ColumnHeader columnActualResult;
		private System.Windows.Forms.ColumnHeader columnNumberOfWarnings;
        private System.Windows.Forms.ColumnHeader columnDuration;
		private System.Windows.Forms.OpenFileDialog openFileDialogScripts;
		private Sscat.Core.Gui.ScriptEventListView scriptEventListView;
		private Sscat.Core.Gui.ScriptResultListView scriptResultListView;
#if NET40
        private Sscat.Core.Gui.WarningEventListView warningEventListView;
        private Sscat.Core.Gui.UIValidationEventListView uiValidationEventListView;
#endif
		private System.Windows.Forms.GroupBox groupBoxScripts;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeaderWarningEventNum;
        private System.Windows.Forms.ColumnHeader columnHeaderWarningEventType;
        private System.Windows.Forms.ColumnHeader columnHeaderWarningEventNotes;
        private System.Windows.Forms.ColumnHeader columnHeaderUIValidationEventNum;
        private System.Windows.Forms.ColumnHeader columnHeaderUIValidationEventResult;
        private System.Windows.Forms.ColumnHeader columnHeaderUIValidationEventDetails;
		private System.Windows.Forms.Button buttonPlay;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonLoadScripts;
		private System.Windows.Forms.Button buttonRemove;
		private System.Windows.Forms.Button buttonRemoveAll;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
	}
}

