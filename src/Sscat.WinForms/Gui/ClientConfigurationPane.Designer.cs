//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

namespace Sscat.Gui
{
	partial class ClientConfigurationPane
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientConfigurationPane));
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonAddMSRCard = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonDeleteAll = new System.Windows.Forms.Button();
            this.buttonDeleteAllMSRCard = new System.Windows.Forms.Button();
            this.buttonDeleteMSRCard = new System.Windows.Forms.Button();
            this.buttonDiagTempPath = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonEditMSRCard = new System.Windows.Forms.Button();
            this.buttonScotConfigOutputDirectory = new System.Windows.Forms.Button();
            this.buttonScriptsOutputDirectory = new System.Windows.Forms.Button();
            this.checkBoxCaptureScreenShot = new System.Windows.Forms.CheckBox();
            this.checkBoxGetDiagFilesOnError = new System.Windows.Forms.CheckBox();
            this.checkBoxLoadConfiguration = new System.Windows.Forms.CheckBox();
            this.checkBoxLockScreenshot = new System.Windows.Forms.CheckBox();
            this.checkBoxMultipleShots = new System.Windows.Forms.CheckBox();
            this.checkBoxOverrideLogin = new System.Windows.Forms.CheckBox();
            this.checkBoxOverrideRapName = new System.Windows.Forms.CheckBox();
            this.checkBoxOverrideSecurityServer = new System.Windows.Forms.CheckBox();
            this.checkBoxSimulateUserTime = new System.Windows.Forms.CheckBox();
            this.checkBoxSkipForgivableEvents = new System.Windows.Forms.CheckBox();
            this.checkBoxStopOnError = new System.Windows.Forms.CheckBox();
            this.checkBoxUseSmartExit = new System.Windows.Forms.CheckBox();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBoxMSRCards = new System.Windows.Forms.GroupBox();
            this.groupBoxScreenCaptureOptions = new System.Windows.Forms.GroupBox();
            this.groupBoxScreenCaptureOptions.SuspendLayout();
            this.labelGetDiagPath = new System.Windows.Forms.Label();
            this.labelLogHookTimeout = new System.Windows.Forms.Label();
            this.labelLoginID = new System.Windows.Forms.Label();
            this.labelMultipleShots = new System.Windows.Forms.Label();
            this.labelOperatorBarcode = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelPlaybackRepetition = new System.Windows.Forms.Label();
            this.labelScotConfigOutputDirectory = new System.Windows.Forms.Label();
            this.labelScreenCaptureDelay = new System.Windows.Forms.Label();
            this.labelScreenCaptureIntervalDelay = new System.Windows.Forms.Label();
            this.labelScriptsOutputDirectory = new System.Windows.Forms.Label();
            this.labelWarningTimeout = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listViewConfigFiles = new System.Windows.Forms.ListView();
            this.numericUpDownLogHookTimeout = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRepetition = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownScreenCaptureDelay = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownScreenCaptureIntervalDelay = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownShots = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWarningTimeout = new System.Windows.Forms.NumericUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textBoxDiagTempPath = new System.Windows.Forms.TextBox();
            this.textBoxLoginId = new System.Windows.Forms.TextBox();
            this.textBoxOperatorBarcode = new System.Windows.Forms.TextBox();
            this.textBoxOverrideRapName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxScotConfigOutputDirectory = new System.Windows.Forms.TextBox();
            this.textBoxScriptOutputDirectory = new System.Windows.Forms.TextBox();
            this.textBoxSecurityServer = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRestoreDefault = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLogHookTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepetition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScreenCaptureDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScreenCaptureIntervalDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWarningTimeout)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBoxMSRCards.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripButtonSave,
									this.toolStripButtonRestoreDefault});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(709, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(60, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.ToolStripButtonSaveClick);
            // 
            // toolStripButtonRestoreDefault
            // 
            this.toolStripButtonRestoreDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.toolStripButtonRestoreDefault.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRestoreDefault.Image")));
            this.toolStripButtonRestoreDefault.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRestoreDefault.Name = "toolStripButtonRestoreDefault";
            this.toolStripButtonRestoreDefault.Size = new System.Drawing.Size(121, 22);
            this.toolStripButtonRestoreDefault.Text = "Restore Default";
            this.toolStripButtonRestoreDefault.Click += new System.EventHandler(this.ToolStripButtonRestoreDefaultClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(709, 307);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(701, 278);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Script Generator";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxScotConfigOutputDirectory);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.buttonScotConfigOutputDirectory);
            this.groupBox4.Controls.Add(this.labelScotConfigOutputDirectory);
            this.groupBox4.Controls.Add(this.labelScriptsOutputDirectory);
            this.groupBox4.Controls.Add(this.buttonScriptsOutputDirectory);
            this.groupBox4.Controls.Add(this.textBoxScriptOutputDirectory);
            this.groupBox4.Location = new System.Drawing.Point(7, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(574, 264);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Output Directory";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(701, 278);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Player";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.numericUpDownWarningTimeout);
            this.groupBox1.Controls.Add(this.labelWarningTimeout);
            this.groupBox1.Controls.Add(this.numericUpDownRepetition);
            this.groupBox1.Controls.Add(this.checkBoxStopOnError);
            this.groupBox1.Controls.Add(this.labelPlaybackRepetition);
            this.groupBox1.Controls.Add(this.numericUpDownLogHookTimeout);
            this.groupBox1.Controls.Add(this.checkBoxOverrideSecurityServer);
            this.groupBox1.Controls.Add(this.textBoxSecurityServer);
            this.groupBox1.Controls.Add(this.checkBoxSimulateUserTime);
            this.groupBox1.Controls.Add(this.checkBoxLoadConfiguration);
            this.groupBox1.Controls.Add(this.textBoxOverrideRapName);
            this.groupBox1.Controls.Add(this.checkBoxOverrideRapName);
            this.groupBox1.Controls.Add(this.checkBoxGetDiagFilesOnError);
            this.groupBox1.Controls.Add(this.labelLogHookTimeout);
            this.groupBox1.Controls.Add(this.checkBoxUseSmartExit);
            this.groupBox1.Controls.Add(this.checkBoxSkipForgivableEvents);
            this.groupBox1.Controls.Add(this.checkBoxCaptureScreenShot);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 264);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxOperatorBarcode);
            this.groupBox3.Controls.Add(this.checkBoxOverrideLogin);
            this.groupBox3.Controls.Add(this.labelLoginID);
            this.groupBox3.Controls.Add(this.labelOperatorBarcode);
            this.groupBox3.Controls.Add(this.textBoxLoginId);
            this.groupBox3.Controls.Add(this.labelPassword);
            this.groupBox3.Controls.Add(this.textBoxPassword);
            this.groupBox3.Location = new System.Drawing.Point(376, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(319, 134);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Valid Login Credentials";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonDiagTempPath);
            this.groupBox5.Controls.Add(this.textBoxDiagTempPath);
            this.groupBox5.Controls.Add(this.labelGetDiagPath);
            this.groupBox5.Location = new System.Drawing.Point(376, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(319, 47);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tools";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBoxScreenCaptureOptions);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(701, 278);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Screen Capture Options";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBoxScreenCaptureOptions
            // 
            this.groupBoxScreenCaptureOptions.Controls.Add(this.checkBoxCaptureScreenShot);
            this.groupBoxScreenCaptureOptions.Controls.Add(this.checkBoxLockScreenshot);
            this.groupBoxScreenCaptureOptions.Controls.Add(this.checkBoxMultipleShots);
            this.groupBoxScreenCaptureOptions.Controls.Add(this.labelMultipleShots);
            this.groupBoxScreenCaptureOptions.Controls.Add(this.numericUpDownShots);
            this.groupBoxScreenCaptureOptions.Controls.Add(this.labelScreenCaptureDelay);
            this.groupBoxScreenCaptureOptions.Controls.Add(this.numericUpDownScreenCaptureDelay);
            this.groupBoxScreenCaptureOptions.Controls.Add(this.labelScreenCaptureIntervalDelay);
            this.groupBoxScreenCaptureOptions.Controls.Add(this.numericUpDownScreenCaptureIntervalDelay);
            this.groupBoxScreenCaptureOptions.Location = new System.Drawing.Point(7, 8);
            this.groupBoxScreenCaptureOptions.Name = "groupBoxScreenCaptureOptions";
            this.groupBoxScreenCaptureOptions.Size = new System.Drawing.Size(362, 264);
            this.groupBoxScreenCaptureOptions.TabIndex = 1;
            this.groupBoxScreenCaptureOptions.TabStop = false;
            this.groupBoxScreenCaptureOptions.Text = "Screen Capture Option";
            // 
            // checkBoxCaptureScreenShot
            // 
            this.checkBoxCaptureScreenShot.Location = new System.Drawing.Point(6, 18);
            this.checkBoxCaptureScreenShot.Name = "checkBoxCaptureScreenShot";
            this.checkBoxCaptureScreenShot.Size = new System.Drawing.Size(176, 24);
            this.checkBoxCaptureScreenShot.TabIndex = 2;
            this.checkBoxCaptureScreenShot.Text = "Capture Screenshot";
            this.checkBoxCaptureScreenShot.UseVisualStyleBackColor = true;
            this.checkBoxCaptureScreenShot.CheckedChanged += new System.EventHandler(this.CheckBoxCaptureScreenshotChanged);
            // 
            // checkBoxLockScreenshot
            // 
            this.checkBoxLockScreenshot.Location = new System.Drawing.Point(6, 48);
            this.checkBoxLockScreenshot.Name = "checkBoxLockScreenshot";
            this.checkBoxLockScreenshot.Size = new System.Drawing.Size(250, 20);
            this.checkBoxLockScreenshot.TabIndex = 3;
            this.checkBoxLockScreenshot.Text = "Lock Screenshot to ScotApp";
            this.checkBoxLockScreenshot.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.checkBoxLockScreenshot.UseVisualStyleBackColor = true;
            // 
            // checkBoxMultipleShots
            // 
            this.checkBoxMultipleShots.Location = new System.Drawing.Point(6, 78);
            this.checkBoxMultipleShots.Name = "checkBoxMultipleShots";
            this.checkBoxMultipleShots.Size = new System.Drawing.Size(250, 20);
            this.checkBoxMultipleShots.TabIndex = 4;
            this.checkBoxMultipleShots.Text = "Multiple Shots";
            this.checkBoxMultipleShots.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.checkBoxMultipleShots.UseVisualStyleBackColor = true;
            // 
            // labelMultipleShots
            // 
            this.labelMultipleShots.Location = new System.Drawing.Point(6, 108);
            this.labelMultipleShots.Name = "labelMultipleShots";
            this.labelMultipleShots.Size = new System.Drawing.Size(240, 23);
            this.labelMultipleShots.TabIndex = 5;
            this.labelMultipleShots.Text = "Number of Shots";
            // 
            // numericUpDownRepetition
            // 
            this.numericUpDownShots.Location = new System.Drawing.Point(250, 108);
            this.numericUpDownShots.Maximum = new decimal(new int[] {
									10,
									0,
									0,
									0});
            this.numericUpDownShots.Name = "numericUpDownShots";
            this.numericUpDownShots.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownShots.TabIndex = 6;
            this.numericUpDownShots.Value = new decimal(new int[] {
									3,
									0,
									0,
									0});
            // 
            // labelScreenCaptureDelay
            // 
            this.labelScreenCaptureDelay.Location = new System.Drawing.Point(6, 138);
            this.labelScreenCaptureDelay.Name = "labelScreenCaptureDelay";
            this.labelScreenCaptureDelay.Size = new System.Drawing.Size(240, 23);
            this.labelScreenCaptureDelay.TabIndex = 7;
            this.labelScreenCaptureDelay.Text = "Screen Capture Delay (ms)";
            // 
            // numericUpDownRepetition
            // 
            this.numericUpDownScreenCaptureDelay.Location = new System.Drawing.Point(250, 138);
            this.numericUpDownScreenCaptureDelay.Maximum = new decimal(new int[] {
									10000,
									0,
									0,
									0});
            this.numericUpDownScreenCaptureDelay.Name = "numericUpDownScreenCaptureDelay";
            this.numericUpDownScreenCaptureDelay.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownScreenCaptureDelay.TabIndex = 8;
            this.numericUpDownScreenCaptureDelay.Value = new decimal(new int[] {
									10,
									0,
									0,
									0});
            // 
            // labelScreenCaptureIntervalDelay
            // 
            this.labelScreenCaptureIntervalDelay.Location = new System.Drawing.Point(6, 168);
            this.labelScreenCaptureIntervalDelay.Name = "labelScreenCaptureIntervalDelay";
            this.labelScreenCaptureIntervalDelay.Size = new System.Drawing.Size(240, 23);
            this.labelScreenCaptureIntervalDelay.TabIndex = 9;
            this.labelScreenCaptureIntervalDelay.Text = "Screen Capture Interval Delay (ms)";
            // 
            // numericUpDownScreenCaptureIntervalDelay
            // 
            this.numericUpDownScreenCaptureIntervalDelay.Location = new System.Drawing.Point(250, 168);
            this.numericUpDownScreenCaptureIntervalDelay.Maximum = new decimal(new int[] {
									80,
									0,
									0,
									0});
            this.numericUpDownScreenCaptureIntervalDelay.Name = "numericUpDownScreenCaptureIntervalDelay";
            this.numericUpDownScreenCaptureIntervalDelay.Size = new System.Drawing.Size(60, 20);
            this.numericUpDownScreenCaptureIntervalDelay.TabIndex = 10;
            this.numericUpDownScreenCaptureIntervalDelay.Value = new decimal(new int[] {
									80,
									0,
									0,
									0});
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBoxMSRCards);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(701, 278);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "MSR Cards";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBoxMSRCards
            // 
            this.groupBoxMSRCards.Controls.Add(this.buttonDeleteAllMSRCard);
            this.groupBoxMSRCards.Controls.Add(this.buttonDeleteMSRCard);
            this.groupBoxMSRCards.Controls.Add(this.buttonEditMSRCard);
            this.groupBoxMSRCards.Controls.Add(this.buttonAddMSRCard);
            this.groupBoxMSRCards.Controls.Add(this.listView1);
            this.groupBoxMSRCards.Location = new System.Drawing.Point(8, 8);
            this.groupBoxMSRCards.Name = "groupBoxMSRCards";
            this.groupBoxMSRCards.Size = new System.Drawing.Size(555, 235);
            this.groupBoxMSRCards.TabIndex = 5;
            this.groupBoxMSRCards.TabStop = false;
            this.groupBoxMSRCards.Text = "MSR Cards";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Track 3";
			this.columnHeader7.Width = 100;
			// 
			// textBoxDiagTempPath
			// 
			this.textBoxDiagTempPath.Location = new System.Drawing.Point(129, 17);
			this.textBoxDiagTempPath.Name = "textBoxDiagTempPath";
			this.textBoxDiagTempPath.ReadOnly = true;
			this.textBoxDiagTempPath.Size = new System.Drawing.Size(146, 22);
			this.textBoxDiagTempPath.TabIndex = 0;
			// 
			// label2
			// 
			this.labelGetDiagPath.Location = new System.Drawing.Point(6, 17);
			this.labelGetDiagPath.Name = "label2";
			this.labelGetDiagPath.Size = new System.Drawing.Size(96, 23);
			this.labelGetDiagPath.TabIndex = 21;
			this.labelGetDiagPath.Text = "GetDiag Path";
			this.labelGetDiagPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericUpDownWarningTimeout
			// 
			this.numericUpDownWarningTimeout.Location = new System.Drawing.Point(182, 42);
			this.numericUpDownWarningTimeout.Maximum = new decimal(new int[] {
									99999,
									0,
									0,
									0});
			this.numericUpDownWarningTimeout.Name = "numericUpDownWarningTimeout";
			this.numericUpDownWarningTimeout.Size = new System.Drawing.Size(104, 22);
			this.numericUpDownWarningTimeout.TabIndex = 11;
			this.numericUpDownWarningTimeout.Value = new decimal(new int[] {
									10000,
									0,
									0,
									0});
			// 
			// labelWarningTimeout
			// 
			this.labelWarningTimeout.Location = new System.Drawing.Point(6, 42);
			this.labelWarningTimeout.Name = "labelWarningTimeout";
			this.labelWarningTimeout.Size = new System.Drawing.Size(128, 23);
			this.labelWarningTimeout.TabIndex = 12;
			this.labelWarningTimeout.Text = "Warning Timeout (ms)";
			this.labelWarningTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkBoxStopOnError
			// 
            this.checkBoxStopOnError.Location = new System.Drawing.Point(6, 217);
			this.checkBoxStopOnError.Name = "checkBoxStopOnError";
			this.checkBoxStopOnError.Size = new System.Drawing.Size(137, 24);
			this.checkBoxStopOnError.TabIndex = 10;
			this.checkBoxStopOnError.Text = "Stop on Error";
			this.checkBoxStopOnError.UseVisualStyleBackColor = true;
			this.checkBoxStopOnError.CheckedChanged += new System.EventHandler(this.CheckBoxStopOnErrorCheckedChanged);

			// 
			// textBoxOperatorBarcode
			// 
			this.textBoxOperatorBarcode.Location = new System.Drawing.Point(129, 102);
			this.textBoxOperatorBarcode.Name = "textBoxOperatorBarcode";
			this.textBoxOperatorBarcode.Size = new System.Drawing.Size(184, 22);
			this.textBoxOperatorBarcode.TabIndex = 1;
            // 
			// checkBoxOverrideLogin
			// 
			this.checkBoxOverrideLogin.Location = new System.Drawing.Point(6, 18);
			this.checkBoxOverrideLogin.Name = "checkBoxOverrideLogin";
			this.checkBoxOverrideLogin.Size = new System.Drawing.Size(117, 25);
			this.checkBoxOverrideLogin.TabIndex = 1;
			this.checkBoxOverrideLogin.Text = "Override Login";
			this.checkBoxOverrideLogin.UseVisualStyleBackColor = true;
			this.checkBoxOverrideLogin.CheckedChanged += new System.EventHandler(this.CheckBoxUseSmartExitCheckedChanged);
			// 
			// label3
			// 
			this.labelLoginID.Location = new System.Drawing.Point(6, 46);
			this.labelLoginID.Name = "label3";
			this.labelLoginID.Size = new System.Drawing.Size(90, 23);
			this.labelLoginID.TabIndex = 0;
			this.labelLoginID.Text = "Login ID";
			this.labelLoginID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.labelOperatorBarcode.Location = new System.Drawing.Point(6, 102);
			this.labelOperatorBarcode.Name = "label7";
			this.labelOperatorBarcode.Size = new System.Drawing.Size(120, 20);
			this.labelOperatorBarcode.TabIndex = 0;
			this.labelOperatorBarcode.Text = "Operator Barcode";
			this.labelOperatorBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxLoginId
			// 
			this.textBoxLoginId.Location = new System.Drawing.Point(129, 46);
			this.textBoxLoginId.Name = "textBoxLoginId";
			this.textBoxLoginId.Size = new System.Drawing.Size(184, 22);
			this.textBoxLoginId.TabIndex = 1;
			// 
            // labelPassword
			// 
			this.labelPassword.Location = new System.Drawing.Point(6, 74);
			this.labelPassword.Name = "label4";
			this.labelPassword.Size = new System.Drawing.Size(101, 23);
			this.labelPassword.TabIndex = 2;
			this.labelPassword.Text = "Password";
			this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(129, 74);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(184, 22);
			this.textBoxPassword.TabIndex = 2;
			// 
			// numericUpDownLogHookTimeout
			// 
			this.numericUpDownLogHookTimeout.Location = new System.Drawing.Point(182, 17);
			this.numericUpDownLogHookTimeout.Name = "numericUpDownLogHookTimeout";
			this.numericUpDownLogHookTimeout.Size = new System.Drawing.Size(104, 22);
			this.numericUpDownLogHookTimeout.TabIndex = 0;
			// 
			// checkBoxOverrideSecurityServer
			// 
			this.checkBoxOverrideSecurityServer.Location = new System.Drawing.Point(6, 92);
			this.checkBoxOverrideSecurityServer.Name = "checkBoxOverrideSecurityServer";
			this.checkBoxOverrideSecurityServer.Size = new System.Drawing.Size(176, 24);
			this.checkBoxOverrideSecurityServer.TabIndex = 1;
			this.checkBoxOverrideSecurityServer.Text = "Override Security Server";
			this.checkBoxOverrideSecurityServer.UseVisualStyleBackColor = true;
			this.checkBoxOverrideSecurityServer.CheckedChanged += new System.EventHandler(this.CheckBoxOverrideSecurityServerCheckedChanged);
			// 
			// textBoxSecurityServer
			// 
			this.textBoxSecurityServer.Location = new System.Drawing.Point(182, 92);
			this.textBoxSecurityServer.Name = "textBoxSecurityServer";
			this.textBoxSecurityServer.Size = new System.Drawing.Size(105, 22);
			this.textBoxSecurityServer.TabIndex = 2;
			// 
			// checkBoxSimulateUserTime
			// 
			this.checkBoxSimulateUserTime.Location = new System.Drawing.Point(6, 167);
			this.checkBoxSimulateUserTime.Name = "checkBoxSimulateUserTime";
			this.checkBoxSimulateUserTime.Size = new System.Drawing.Size(150, 24);
			this.checkBoxSimulateUserTime.TabIndex = 8;
			this.checkBoxSimulateUserTime.Text = "Simulate User Time";
			this.checkBoxSimulateUserTime.UseVisualStyleBackColor = true;
			// 
			// checkBoxLoadConfiguration
			// 
			this.checkBoxLoadConfiguration.Location = new System.Drawing.Point(6, 142);
			this.checkBoxLoadConfiguration.Name = "checkBoxLoadConfiguration";
			this.checkBoxLoadConfiguration.Size = new System.Drawing.Size(152, 24);
			this.checkBoxLoadConfiguration.TabIndex = 7;
			this.checkBoxLoadConfiguration.Text = "Load Configuration";
			this.checkBoxLoadConfiguration.UseVisualStyleBackColor = true;
			// 
			// buttonDiagTempPath
			// 
			this.buttonDiagTempPath.Location = new System.Drawing.Point(281, 16);
			this.buttonDiagTempPath.Name = "buttonDiagTempPath";
			this.buttonDiagTempPath.Size = new System.Drawing.Size(32, 23);
			this.buttonDiagTempPath.TabIndex = 1;
			this.buttonDiagTempPath.Text = "...";
			this.buttonDiagTempPath.UseVisualStyleBackColor = true;
			// 
			// textBoxOverrideRapName
			// 
			this.textBoxOverrideRapName.Location = new System.Drawing.Point(182, 117);
			this.textBoxOverrideRapName.Name = "textBoxOverrideRapName";
			this.textBoxOverrideRapName.Size = new System.Drawing.Size(105, 22);
			this.textBoxOverrideRapName.TabIndex = 4;
            // 
            // labelLogHookTimeout
            // 
            this.labelLogHookTimeout.Location = new System.Drawing.Point(6, 17);
            this.labelLogHookTimeout.Name = "label8";
            this.labelLogHookTimeout.Size = new System.Drawing.Size(128, 23);
            this.labelLogHookTimeout.TabIndex = 8;
            this.labelLogHookTimeout.Text = "LogHook Timeout (ms)";
            this.labelLogHookTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkBoxGetDiagFilesOnError
			// 
			this.checkBoxGetDiagFilesOnError.Location = new System.Drawing.Point(182, 142);
			this.checkBoxGetDiagFilesOnError.Name = "checkBoxGetDiagFilesOnError";
			this.checkBoxGetDiagFilesOnError.Size = new System.Drawing.Size(176, 24);
			this.checkBoxGetDiagFilesOnError.TabIndex = 6;
			this.checkBoxGetDiagFilesOnError.Text = "Get Diag Files on Error";
			this.checkBoxGetDiagFilesOnError.UseVisualStyleBackColor = true;
            // 
            // checkBoxSkipForgivableEvents
            // 
            this.checkBoxSkipForgivableEvents.Location = new System.Drawing.Point(182, 167);
            this.checkBoxSkipForgivableEvents.Name = "checkBoxSkipForgivableEvents";
            this.checkBoxSkipForgivableEvents.Size = new System.Drawing.Size(178, 24);
            this.checkBoxSkipForgivableEvents.TabIndex = 10;
            this.checkBoxSkipForgivableEvents.Text = "Skip Tri-Light and Audio";
            this.checkBoxSkipForgivableEvents.UseVisualStyleBackColor = true;

			// 
			// buttonDeleteAllMSRCard
			// 
			this.buttonDeleteAllMSRCard.Location = new System.Drawing.Point(474, 108);
			this.buttonDeleteAllMSRCard.Name = "buttonDeleteAllMSRCard";
			this.buttonDeleteAllMSRCard.Size = new System.Drawing.Size(75, 23);
			this.buttonDeleteAllMSRCard.TabIndex = 4;
			this.buttonDeleteAllMSRCard.Text = "Delete All";
			this.buttonDeleteAllMSRCard.UseVisualStyleBackColor = true;
			this.buttonDeleteAllMSRCard.Click += new System.EventHandler(this.ButtonDeleteAllMSRCardClick);
			// 
			// buttonDeleteMSRCard
			// 
			this.buttonDeleteMSRCard.Location = new System.Drawing.Point(474, 84);
			this.buttonDeleteMSRCard.Name = "buttonDeleteMSRCard";
			this.buttonDeleteMSRCard.Size = new System.Drawing.Size(75, 23);
			this.buttonDeleteMSRCard.TabIndex = 3;
			this.buttonDeleteMSRCard.Text = "Delete";
			this.buttonDeleteMSRCard.UseVisualStyleBackColor = true;
			this.buttonDeleteMSRCard.Click += new System.EventHandler(this.ButtonDeleteMSRCardClick);
			// 
			// buttonEditMSRCard
			// 
			this.buttonEditMSRCard.Location = new System.Drawing.Point(474, 44);
			this.buttonEditMSRCard.Name = "buttonEditMSRCard";
			this.buttonEditMSRCard.Size = new System.Drawing.Size(75, 23);
			this.buttonEditMSRCard.TabIndex = 2;
			this.buttonEditMSRCard.Text = "Edit";
			this.buttonEditMSRCard.UseVisualStyleBackColor = true;
			this.buttonEditMSRCard.Click += new System.EventHandler(this.ButtonEditMSRCardClick);
			// 
			// buttonAddMSRCard
			// 
			this.buttonAddMSRCard.Location = new System.Drawing.Point(474, 20);
			this.buttonAddMSRCard.Name = "buttonAddMSRCard";
			this.buttonAddMSRCard.Size = new System.Drawing.Size(75, 23);
			this.buttonAddMSRCard.TabIndex = 1;
			this.buttonAddMSRCard.Text = "Add";
			this.buttonAddMSRCard.UseVisualStyleBackColor = true;
			this.buttonAddMSRCard.Click += new System.EventHandler(this.ButtonAddMSRCardClick);
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader4,
									this.columnHeader5,
									this.columnHeader6,
									this.columnHeader7});
			this.listView1.FullRowSelect = true;
			this.listView1.Location = new System.Drawing.Point(8, 16);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(460, 214);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Card Name";
			this.columnHeader4.Width = 145;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Track 1";
			this.columnHeader5.Width = 100;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Track 2";
			this.columnHeader6.Width = 100;
			// 
			// checkBoxOverrideRapName
			// 
			this.checkBoxOverrideRapName.Location = new System.Drawing.Point(6, 117);
			this.checkBoxOverrideRapName.Name = "checkBoxOverrideRapName";
			this.checkBoxOverrideRapName.Size = new System.Drawing.Size(152, 24);
			this.checkBoxOverrideRapName.TabIndex = 3;
			this.checkBoxOverrideRapName.Text = "Override RAP Name";
			this.checkBoxOverrideRapName.UseVisualStyleBackColor = true;
			this.checkBoxOverrideRapName.CheckedChanged += new System.EventHandler(this.CheckBoxOverrideRapNameCheckedChanged);
			// 
			// textBoxScotConfigOutputDirectory
			// 
			this.textBoxScotConfigOutputDirectory.Enabled = false;
			this.textBoxScotConfigOutputDirectory.Location = new System.Drawing.Point(206, 45);
			this.textBoxScotConfigOutputDirectory.Name = "textBoxScotConfigOutputDirectory";
			this.textBoxScotConfigOutputDirectory.Size = new System.Drawing.Size(178, 22);
			this.textBoxScotConfigOutputDirectory.TabIndex = 2;
			this.textBoxScotConfigOutputDirectory.Visible = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.buttonDeleteAll);
			this.groupBox2.Controls.Add(this.buttonDelete);
			this.groupBox2.Controls.Add(this.buttonEdit);
			this.groupBox2.Controls.Add(this.buttonAdd);
			this.groupBox2.Controls.Add(this.listViewConfigFiles);
			this.groupBox2.Location = new System.Drawing.Point(6, 77);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(555, 180);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Configuration Files";
			// 
			// buttonDeleteAll
			// 
			this.buttonDeleteAll.Location = new System.Drawing.Point(474, 111);
			this.buttonDeleteAll.Name = "buttonDeleteAll";
			this.buttonDeleteAll.Size = new System.Drawing.Size(75, 23);
			this.buttonDeleteAll.TabIndex = 4;
			this.buttonDeleteAll.Text = "Delete All";
			this.buttonDeleteAll.UseVisualStyleBackColor = true;
			this.buttonDeleteAll.Click += new System.EventHandler(this.ButtonDeleteAllClick);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(474, 87);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(75, 23);
			this.buttonDelete.TabIndex = 3;
			this.buttonDelete.Text = "Delete";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			// 
			// buttonEdit
			// 
			this.buttonEdit.Location = new System.Drawing.Point(474, 47);
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Size = new System.Drawing.Size(75, 23);
			this.buttonEdit.TabIndex = 2;
			this.buttonEdit.Text = "Edit";
			this.buttonEdit.UseVisualStyleBackColor = true;
			this.buttonEdit.Click += new System.EventHandler(this.ButtonEditClick);
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(474, 23);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(75, 23);
			this.buttonAdd.TabIndex = 1;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			// 
			// listViewConfigFiles
			// 
			this.listViewConfigFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.listViewConfigFiles.FullRowSelect = true;
			this.listViewConfigFiles.Location = new System.Drawing.Point(8, 23);
			this.listViewConfigFiles.Name = "listViewConfigFiles";
			this.listViewConfigFiles.Size = new System.Drawing.Size(460, 147);
			this.listViewConfigFiles.TabIndex = 0;
			this.listViewConfigFiles.UseCompatibleStateImageBehavior = false;
			this.listViewConfigFiles.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "File Name";
			this.columnHeader1.Width = 145;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Host";
			this.columnHeader2.Width = 90;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Path";
			this.columnHeader3.Width = 206;
			// 
			// buttonScotConfigOutputDirectory
			// 
			this.buttonScotConfigOutputDirectory.Enabled = false;
			this.buttonScotConfigOutputDirectory.Location = new System.Drawing.Point(392, 45);
			this.buttonScotConfigOutputDirectory.Name = "buttonScotConfigOutputDirectory";
			this.buttonScotConfigOutputDirectory.Size = new System.Drawing.Size(32, 23);
			this.buttonScotConfigOutputDirectory.TabIndex = 3;
			this.buttonScotConfigOutputDirectory.Text = "...";
			this.buttonScotConfigOutputDirectory.UseVisualStyleBackColor = true;
			this.buttonScotConfigOutputDirectory.Visible = false;
			// 
            // labelScotConfigOutputDirectory
			// 
			this.labelScotConfigOutputDirectory.Location = new System.Drawing.Point(206, 21);
			this.labelScotConfigOutputDirectory.Name = "label15";
			this.labelScotConfigOutputDirectory.Size = new System.Drawing.Size(144, 23);
			this.labelScotConfigOutputDirectory.TabIndex = 14;
			this.labelScotConfigOutputDirectory.Text = "Scot Config Output Directory";
			this.labelScotConfigOutputDirectory.Visible = false;
			// 
            // labelScriptsOutputDirectory
			// 
			this.labelScriptsOutputDirectory.Location = new System.Drawing.Point(6, 21);
			this.labelScriptsOutputDirectory.Name = "label1";
			this.labelScriptsOutputDirectory.Size = new System.Drawing.Size(144, 23);
			this.labelScriptsOutputDirectory.TabIndex = 0;
			this.labelScriptsOutputDirectory.Text = "Scripts Output Directory";
			// 
			// buttonScriptsOutputDirectory
			// 
			this.buttonScriptsOutputDirectory.Location = new System.Drawing.Point(168, 45);
			this.buttonScriptsOutputDirectory.Name = "buttonScriptsOutputDirectory";
			this.buttonScriptsOutputDirectory.Size = new System.Drawing.Size(32, 23);
			this.buttonScriptsOutputDirectory.TabIndex = 1;
			this.buttonScriptsOutputDirectory.Text = "...";
			this.buttonScriptsOutputDirectory.UseVisualStyleBackColor = true;
			// 
			// textBoxScriptOutputDirectory
			// 
			this.textBoxScriptOutputDirectory.Location = new System.Drawing.Point(6, 45);
			this.textBoxScriptOutputDirectory.Name = "textBoxScriptOutputDirectory";
			this.textBoxScriptOutputDirectory.ReadOnly = true;
			this.textBoxScriptOutputDirectory.Size = new System.Drawing.Size(154, 22);
			this.textBoxScriptOutputDirectory.TabIndex = 0;
            // 
            // checkBoxUseSmartExit
            // 
            this.checkBoxUseSmartExit.Location = new System.Drawing.Point(6, 192);
            this.checkBoxUseSmartExit.Name = "checkBoxUseSmartExit";
            this.checkBoxUseSmartExit.Size = new System.Drawing.Size(135, 24);
            this.checkBoxUseSmartExit.TabIndex = 1;
            this.checkBoxUseSmartExit.Text = "Use Smart Exit";
            this.checkBoxUseSmartExit.UseVisualStyleBackColor = true;
            this.checkBoxUseSmartExit.CheckedChanged += new System.EventHandler(this.CheckBoxUseSmartExitCheckedChanged);
			// 
			// numericUpDownRepetition
			// 
			this.numericUpDownRepetition.Location = new System.Drawing.Point(182, 67);
			this.numericUpDownRepetition.Maximum = new decimal(new int[] {
									10000,
									0,
									0,
									0});
			this.numericUpDownRepetition.Name = "numericUpDownRepetition";
			this.numericUpDownRepetition.Size = new System.Drawing.Size(104, 22);
			this.numericUpDownRepetition.TabIndex = 4;
			this.numericUpDownRepetition.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.numericUpDownRepetition.Leave += new System.EventHandler(this.NumericUpDownRepetitionLeave);
			// 
			// label5
			// 
			this.labelPlaybackRepetition.Location = new System.Drawing.Point(6, 67);
			this.labelPlaybackRepetition.Name = "label5";
			this.labelPlaybackRepetition.Size = new System.Drawing.Size(136, 23);
			this.labelPlaybackRepetition.TabIndex = 14;
			this.labelPlaybackRepetition.Text = "Playback Repetition";
			this.labelPlaybackRepetition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ClientConfigurationPane
			// 
            this.Name = "ClientConfigurationPane";
            this.Size = new System.Drawing.Size(709, 332);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.toolStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBoxMSRCards.ResumeLayout(false);
            this.groupBoxScreenCaptureOptions.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.PerformLayout();
            this.groupBox3.PerformLayout();
            this.groupBox4.PerformLayout();
            this.groupBox5.PerformLayout();
            this.groupBoxMSRCards.PerformLayout();
            this.groupBoxScreenCaptureOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLogHookTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepetition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScreenCaptureDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScreenCaptureIntervalDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWarningTimeout)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
        }

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonAddMSRCard;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonDeleteAll;
        private System.Windows.Forms.Button buttonDeleteAllMSRCard;
        private System.Windows.Forms.Button buttonDeleteMSRCard;
        private System.Windows.Forms.Button buttonDiagTempPath;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonEditMSRCard;
        private System.Windows.Forms.Button buttonScotConfigOutputDirectory;
        private System.Windows.Forms.Button buttonScriptsOutputDirectory;
        private System.Windows.Forms.CheckBox checkBoxCaptureScreenShot;
        private System.Windows.Forms.CheckBox checkBoxGetDiagFilesOnError;
        private System.Windows.Forms.CheckBox checkBoxLoadConfiguration;
        private System.Windows.Forms.CheckBox checkBoxLockScreenshot;
        private System.Windows.Forms.CheckBox checkBoxMultipleShots;
        private System.Windows.Forms.CheckBox checkBoxOverrideLogin;
        private System.Windows.Forms.CheckBox checkBoxOverrideRapName;
        private System.Windows.Forms.CheckBox checkBoxOverrideSecurityServer;
        private System.Windows.Forms.CheckBox checkBoxSimulateUserTime;
        private System.Windows.Forms.CheckBox checkBoxSkipForgivableEvents;
        private System.Windows.Forms.CheckBox checkBoxStopOnError;
        private System.Windows.Forms.CheckBox checkBoxUseSmartExit;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBoxMSRCards;
        private System.Windows.Forms.GroupBox groupBoxScreenCaptureOptions;
        private System.Windows.Forms.Label labelGetDiagPath;
        private System.Windows.Forms.Label labelLogHookTimeout;
        private System.Windows.Forms.Label labelLoginID;
        private System.Windows.Forms.Label labelMultipleShots;
        private System.Windows.Forms.Label labelOperatorBarcode;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelPlaybackRepetition;
        private System.Windows.Forms.Label labelScotConfigOutputDirectory;
        private System.Windows.Forms.Label labelScreenCaptureDelay;
        private System.Windows.Forms.Label labelScreenCaptureIntervalDelay;
        private System.Windows.Forms.Label labelScriptsOutputDirectory;
        private System.Windows.Forms.Label labelWarningTimeout;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listViewConfigFiles;
        private System.Windows.Forms.NumericUpDown numericUpDownLogHookTimeout;
        private System.Windows.Forms.NumericUpDown numericUpDownRepetition;
        private System.Windows.Forms.NumericUpDown numericUpDownScreenCaptureDelay;
        private System.Windows.Forms.NumericUpDown numericUpDownScreenCaptureIntervalDelay;
        private System.Windows.Forms.NumericUpDown numericUpDownShots;
        private System.Windows.Forms.NumericUpDown numericUpDownWarningTimeout;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBoxDiagTempPath;
        private System.Windows.Forms.TextBox textBoxLoginId;
        private System.Windows.Forms.TextBox textBoxOperatorBarcode;
        private System.Windows.Forms.TextBox textBoxOverrideRapName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxScotConfigOutputDirectory;
        private System.Windows.Forms.TextBox textBoxScriptOutputDirectory;
        private System.Windows.Forms.TextBox textBoxSecurityServer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRestoreDefault;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
	}
}
