// <copyright file="PlayerPane.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Sscat.Gui
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using Ncr.Core.Gui;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;
    using Sscat.Core.Gui;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the PlayerPane class
    /// </summary>
    public partial class PlayerPane : BaseUserControl, IPlayerView
    {
        /// <summary>
        /// Update lock
        /// </summary>
        private readonly object updateLock = new object();

        /// <summary>
        /// Playback repetition
        /// </summary>
        private int _playbackRepetition;

        /// <summary>
        /// Passed scripts
        /// </summary>
        private int _passedScripts;

        /// <summary>
        /// Failed scripts
        /// </summary>
        private int _failedScripts;

        /// <summary>
        /// Last valid repetition value
        /// </summary>
        private int _lastValidRepetitionValue;

        /// <summary>
        /// Last script index
        /// </summary>
        private int _lastScriptIndex = 0;

        /// <summary>
        /// Last event index
        /// </summary>
        private int _lastEventIndex = 0;

        /// <summary>
        /// Script cache file
        /// </summary>
        private string _scriptCacheFile;

        /// <summary>
        /// Cache script
        /// </summary>
        private SSCATScript _cacheScript;
        
        /// <summary>
        /// warning events
        /// </summary>
        private List<IWarningEvent> _warningEvents;
        
        /// <summary>
        /// Initializes a new instance of the PlayerPane class
        /// </summary>
        public PlayerPane()
        {
            InitializeComponent();
            SetTitle("Player");

            _warningEvents = new List<IWarningEvent>();
            scriptResultListView.SelectedScriptChanged += new EventHandler<ScriptEventArgs>(ScriptResultListViewSelectedScriptChanged);
            scriptResultListView.ScriptsChanged += delegate
            {
                groupBoxScripts.Text = string.Format("{0} Scripts", ScriptFiles.Count);
                UpdateReportButton();
            };

            scriptResultListView.ScriptAdded += delegate
            {
                groupBoxScripts.Text = string.Format("{0} Scripts", ScriptFiles.Count);
            };

            Stopping += new EventHandler(PlayerStopping);
            Disable += new EventHandler(PlayerDisable);

            scriptResultListView.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == Keys.A)
                {
                    foreach (ListViewItem li in scriptResultListView.Items)
                    {
                        li.Selected = true;
                    }
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    buttonRemove.PerformClick();
                }
            };
        }

        /// <summary>
        /// Finalizes an instance of the PlayerPane class
        /// </summary>
        ~PlayerPane()
        {
            scriptResultListView.SelectedScriptChanged -= new EventHandler<ScriptEventArgs>(ScriptResultListViewSelectedScriptChanged);
            Stopping -= new EventHandler(PlayerStopping);
            Disable -= new EventHandler(PlayerDisable);
        }

        /// <summary>
        /// Delegate for result event handler
        /// </summary>
        /// <param name="s">script interface</param>
        private delegate void ResultEventHandler(IScript s);

        /// <summary>
        /// Event handler for play
        /// </summary>
        public event EventHandler<SscatLaneEventArgs> Play;

        /// <summary>
        /// Event handler for stopping
        /// </summary>
        public event EventHandler Stopping;

        /// <summary>
        /// Event handler for stop
        /// </summary>
        public event EventHandler Stop;

        /// <summary>
        /// Event handler for disable
        /// </summary>
        public event EventHandler Disable;

        /// <summary>
        /// Gets or sets the playback repetition
        /// </summary>
        public int PlaybackRepetition
        {
            get { return _playbackRepetition; }
            set { _playbackRepetition = value; }
        }

        /// <summary>
        /// Gets the script files
        /// </summary>
        public List<ScriptFile> ScriptFiles
        {
            get { return scriptResultListView.Scripts; }
        }

        /// <summary>
        /// Remove all scripts
        /// </summary>
        public void RemoveAllScripts()
        {
            ButtonRemoveAllClick(this, null);
        }

        /// <summary>
        /// Remove the selected script
        /// </summary>
        public void RemoveSelectedScript()
        {
            ButtonRemoveClick(this, null);
        }

        /// <summary>
        /// Perform a stop
        /// </summary>
        public void PerformStop()
        {
            OnStop(null);
        }

        /// <summary>
        /// Clear the results
        /// </summary>
        public void ClearResults()
        {
            _passedScripts = 0;
            _failedScripts = 0;
            _playbackRepetition = 0;
            _lastValidRepetitionValue = 0;
            _warningEvents.Clear();
            scriptResultListView.ClearResults();
            scriptEventListView.Items.Clear();
            warningEventListView.Items.Clear();
            
            FileHelper.DeleteAll(ApplicationUtility.CacheDirectory);
        }

        /// <summary>
        /// Add the scripts
        /// </summary>
        /// <param name="scripts">scripts to add</param>
        public void AddScript(List<string> scripts)
        {
            scriptResultListView.AddScript(scripts);
        }

        /// <summary>
        /// Perform the playing
        /// </summary>
        public void PerformPlaying()
        {
            PlayerPlaying(this, null);
        }

        /// <summary>
        /// Perform the stopping
        /// </summary>
        public void PerformStopping()
        {
            OnStopping(null);
        }

        /// <summary>
        /// Perform the play
        /// </summary>
        public void PerformPlay()
        {
            ButtonPlayClick(this, null);
        }

        /// <summary>
        /// Perform the disable
        /// </summary>
        public void PerformDisable()
        {
            OnDisable(null);
        }

        /// <summary>
        /// Stop the player
        /// </summary>
        public void StopPlayer()
        {
            ButtonStopClick(this, null);
        }

        /// <summary>
        /// Select the given script
        /// </summary>
        /// <param name="script">selected script</param>
        public void SelectScript(ScriptFile script)
        {
            // PRECONDITION 1: Make sure the script file to be selected exists
            if (script.HasCacheFile == false)
            {
                LoggingService.Error(string.Format("PlayerPane->SelectScript(): {0} doesn't exist! Cannot Select the current script.", script.File));
                return;
            }

            // PROCESS 1: Select the file by updating it result value - UNDONE: needs to be refactored
            scriptResultListView.Scripts[script.Index].Result = new Result(ResultType.Running, "Running...");
        }

        /// <summary>
        /// Update the event result
        /// </summary>
        /// <param name="e">script event</param>
        public void UpdateEventResult(IScriptEvent e)
        {
            //// SSCAT-1865 Causes crash in Linux
            scriptResultListView.Scripts[e.ScriptIndex].Result = new Result(ResultType.Running, "Running...", e.Result.NumberOfWarnings);

            lock (updateLock)
            {
                //// SSCAT-1865 Causes crash in Linux
                scriptEventListView.ScriptEvents[e.Index].Result = e.Result;

                _lastEventIndex = e.Index;
                _cacheScript.Serialize(_scriptCacheFile);
            }
        }

        /// <summary>
        /// Update the event result
        /// </summary>
        /// <param name="e">warning event</param>
        public void UpdateWarningEventResult(IWarningEvent e)
        {
            //// SSCAT-1865 Causes crash in Linux
            _warningEvents.Add(e);
            warningEventListView.WarningEvents = _warningEvents.ToArray();
        }

        /// <summary>
        /// Update the script result
        /// </summary>
        /// <param name="s">script interface</param>
        public void UpdateScriptResult(IScript s)
        {
            if (InvokeRequired)
            {
                Invoke(new ResultEventHandler(UpdateScriptResult), new object[] { s });
            }
            else
            {
                scriptResultListView.Scripts[s.Index].Result = s.Result;
                _lastScriptIndex = s.Index;
                ////TODO: SSCAT-1719
                ////_cacheScript.RefreshScriptEvents(new List<IScriptEvent>(s.Events.Events));
                _cacheScript.Result = s.Result;
                _cacheScript.Serialize(_scriptCacheFile);

                if (s.Result.Type == ResultType.Passed)
                {
                    _passedScripts++;
                }
                else if (s.Result.Type == ResultType.Failed || s.Result.Type == ResultType.Exception)
                {
                    _failedScripts++;
                }

                _playbackRepetition = s.Result.RepetitionIndex;
                groupBoxScripts.Text = string.Format("{0} Scripts (Passed: {1}, Failed: {2}) (Playback Repetition: {3})", ScriptFiles.Count, _passedScripts, _failedScripts, _playbackRepetition);
                if (!GetRepetitionIndex().Equals(s.Result.RepetitionIndex))
                {
                    this.textBoxRepetitionIndex.Text = s.Result.RepetitionIndex.ToString();
                }

                PerformStopping();
            }
        }

        /// <summary>
        /// Update view on connection timeout
        /// </summary>
        /// <param name="error">error message</param>
        public void UpdateViewOnConnectionTimeout(string error)
        {
            if (ScriptFiles.Count > 0)
            {
                scriptResultListView.Scripts[_lastScriptIndex].Result = new Result(ResultType.Failed, error);
                scriptEventListView.ScriptEvents[_lastEventIndex].Result = new Result(ResultType.Failed, error);
            }
        }

        /// <summary>
        /// initiate cache
        /// </summary>
        /// <param name="e">script event arguments</param>
        public void InitiateCache(ScriptEventArgs e)
        {
            _scriptCacheFile = e.ScriptFile.CacheFile;
            e.ScriptFile.ClearCache();
            _cacheScript = SSCATScript.Deserialize(e.ScriptFile.File);
            _cacheScript.Index = e.ScriptFile.Index;
            _cacheScript.Serialize(e.ScriptFile.CacheFile);
        }

        /// <summary>
        /// Clears the script results
        /// </summary>
        public void ClearView()
        {
            scriptResultListView.ClearResults();
        }

        /// <summary>
        /// Adds the scripts
        /// </summary>
        /// <param name="scripts">scripts to add</param>
        public void AddScript(string[] scripts)
        {
            scriptResultListView.AddScript(scripts);
        }

        /// <summary>
        /// Display test results
        /// </summary>
        public void DisplayTestResult()
        {
            try
            {
                if ((GetRepetitionIndex() > _playbackRepetition) || (GetRepetitionIndex() < 1))
                {
                    throw new InvalidOperationException("Playback Repetition value does not have a representation. Please Enter a valid value.");
                }

                ClearView();
                foreach (ScriptFile s in scriptResultListView.Scripts)
                {
                    s.RepetitionIndex = Convert.ToInt32(this.textBoxRepetitionIndex.Text);
                    if (FileHelper.Exists(s.CacheFile))
                    {
                        DisplayScriptResult(SSCATScript.Deserialize(s.CacheFile));
                    }
                }

                _lastValidRepetitionValue = GetRepetitionIndex();
            }
            catch (FormatException ex)
            {
                MessageService.ShowError(ex.Message);
                LoggingService.Info(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageService.ShowError(ex.Message);
                LoggingService.Info(ex.Message);
            }
            catch (Exception ex)
            {
                MessageService.ShowError(ex.Message);
                LoggingService.Info(ex.ToString());
            }
            finally
            {
                textBoxRepetitionIndex.Text = _lastValidRepetitionValue.ToString();
            }
        }

        /// <summary>
        /// Update increase button
        /// </summary>
        public void UpdateIncreaseButton()
        {
            if (GetRepetitionIndex() < _playbackRepetition)
            {
                textBoxRepetitionIndex.Text = (GetRepetitionIndex() + 1).ToString();
            }
        }

        /// <summary>
        /// Update decrease button
        /// </summary>
        public void UpdateDecreaseButton()
        {
            if (GetRepetitionIndex() > 1)
            {
                textBoxRepetitionIndex.Text = (GetRepetitionIndex() - 1).ToString();
            }
        }

        /// <summary>
        /// Update the repetition buttons
        /// </summary>
        public void UpdateRepetitionButtons()
        {
            try
            {
                if (GetRepetitionIndex() >= _playbackRepetition)
                {
                    buttonIncreaseRepetitionIndex.Enabled = false;
                }
                else
                {
                    buttonIncreaseRepetitionIndex.Enabled = true;
                }

                if (GetRepetitionIndex() <= 1)
                {
                    buttonDecreaseRepetitionIndex.Enabled = false;
                }
                else
                {
                    buttonDecreaseRepetitionIndex.Enabled = true;
                }

                if ((GetRepetitionIndex() > _playbackRepetition) || (GetRepetitionIndex() < 1))
                {
                    throw new InvalidOperationException("Playback Repetition value does not have a representation.");
                }

                _lastValidRepetitionValue = GetRepetitionIndex();
            }
            catch (FormatException ex)
            {
                LoggingService.Info(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                LoggingService.Info(ex.Message);
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
            }
        }

        /// <summary>
        /// Get the repetition index
        /// </summary>
        /// <returns>Returns the repetition index</returns>
        public virtual int GetRepetitionIndex()
        {
            return Convert.ToInt32(this.textBoxRepetitionIndex.Text);
        }

        /// <summary>
        /// Event for on play
        /// </summary>
        /// <param name="e">sscat lane event arguments</param>
        protected virtual void OnPlay(SscatLaneEventArgs e)
        {
            if (Play != null)
            {
                Play(this, e);
            }
        }

        /// <summary>
        /// Event for on disable
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnDisable(EventArgs e)
        {
            if (Disable != null)
            {
                Disable(this, e);
            }
        }

        /// <summary>
        /// Event for on stopping
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStopping(EventArgs e)
        {
            if (Stopping != null)
            {
                Stopping(this, e);
            }
        }

        /// <summary>
        /// Event for on stop
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStop(EventArgs e)
        {
            if (Stop != null)
            {
                Stop(this, e);
            }
        }

        /// <summary>
        /// Event for on player disable
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void PlayerDisable(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EventHandler(PlayerDisable), new object[] { sender, e });
            }
            else
            {
                buttonPlay.Enabled = buttonLoadScripts.Enabled = buttonRemove.Enabled = buttonRemoveAll.Enabled = buttonSaveReport.Enabled = false;
                buttonDecreaseRepetitionIndex.Enabled = buttonIncreaseRepetitionIndex.Enabled = buttonDisplayTestResult.Enabled = textBoxRepetitionIndex.Enabled = false;
                buttonStop.Enabled = false;
            }
        }

        /// <summary>
        /// Event for on player stopping
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void PlayerStopping(object sender, EventArgs e)
        {
            if (buttonPlay.InvokeRequired)
            {
                this.Invoke(new EventHandler(PlayerStopping), new object[] { sender, e });
            }
            else
            {
                buttonPlay.Enabled = buttonLoadScripts.Enabled = buttonRemove.Enabled = buttonRemoveAll.Enabled = buttonSaveReport.Enabled = true;
                buttonStop.Enabled = false;
                if (GetRepetitionIndex() > 1)
                {
                    buttonDecreaseRepetitionIndex.Enabled = true;
                }

                if (GetRepetitionIndex() > 0)
                {
                    buttonDisplayTestResult.Enabled = textBoxRepetitionIndex.Enabled = true;
                }
            }

            UpdateReportButton();
        }

        /// <summary>
        /// Event for on player playing
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void PlayerPlaying(object sender, EventArgs e)
        {
            if (buttonPlay.InvokeRequired)
            {
                this.Invoke(new EventHandler<SscatLaneEventArgs>(PlayerPlaying), new object[] { sender, e });
            }
            else
            {
                buttonPlay.Enabled = buttonLoadScripts.Enabled = buttonRemove.Enabled = buttonRemoveAll.Enabled = buttonSaveReport.Enabled = false;
                buttonDecreaseRepetitionIndex.Enabled = buttonIncreaseRepetitionIndex.Enabled = buttonDisplayTestResult.Enabled = textBoxRepetitionIndex.Enabled = false;
                buttonStop.Enabled = true;
            }
        }

        /// <summary>
        /// Event for on script result list view selected script changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">script event arguments</param>
        private void ScriptResultListViewSelectedScriptChanged(object sender, ScriptEventArgs e)
        {
            lock (updateLock)
            {
                try
                {
                    if (e.ScriptFile.HasCacheFile)
                    {
                        _cacheScript = SSCATScript.Deserialize(e.ScriptFile.CacheFile);
                    }
                    else
                    {
                        _cacheScript = SSCATScript.Deserialize(e.ScriptFile.File);
                        _cacheScript.Serialize(e.ScriptFile.CacheFile);
                    }

                    scriptEventListView.ScriptEvents = _cacheScript.ScriptEvents;

#if NET40
                    ////TODO: SSCAT-1719
                    ////uiValidationEventListView.WarningEvents = _cacheScript.GetUIValidationEvents();
#endif
                }
                catch (InvalidOperationException ex)
                {
                    string[] lineNumber = Regex.Split(ex.Message, @"\D+");
                    string message = string.Format("Error Message: {0}Syntax error found in {3} at line {1} & column {2}{0}{0}Troubleshooting Tips: {0}In SSCAT Client, go to PlayerPane and remove {4} in Script List View{0}Go to  C:\\SSCAT\\scripts and modify {4} at line {1} & column {2}{0}Correct XML syntax error{0}{0}", Environment.NewLine, lineNumber[1], lineNumber[2], e.ScriptFile.File.ToString(), Path.GetFileNameWithoutExtension(e.ScriptFile.File));
                    LoggingService.Error(message + ex.ToString());
                    MessageService.ShowError(message);
                    buttonRemove.PerformClick();
                    scriptEventListView.Items.Clear();
                    warningEventListView.Items.Clear();
                }
                catch (Exception ex)
                {
                    LoggingService.Error("PlayerPane->ScriptResultListViewSelectedScriptChanged(): " + ex.ToString());
                    MessageService.ShowErrorOnTop(ex.Message);
                    buttonRemove.PerformClick();
                    scriptEventListView.Items.Clear();
                    warningEventListView.Items.Clear();
                }
            }
        }

        /// <summary>
        /// Event for click the load scripts button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonLoadScriptsClick(object sender, EventArgs e)
        {
            if (openFileDialogScripts.ShowDialog() == DialogResult.OK)
            {
                AddScript(openFileDialogScripts.FileNames);
                DisableRepetitionControls();
            }
        }

        /// <summary>
        /// Event for click the remove all button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonRemoveAllClick(object sender, EventArgs e)
        {
            scriptResultListView.ClearScripts();
            UpdateReportButton();
            DisableRepetitionControls();
        }

        /// <summary>
        /// Event for click the remove button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonRemoveClick(object sender, EventArgs e)
        {
            scriptResultListView.RemoveSelectedScripts();
            DisableRepetitionControls();
        }

        /// <summary>
        /// Event for click the play button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonPlayClick(object sender, EventArgs e)
        {
            DisableRepetitionControls();
            PlayerPlaying(this, e);
            OnPlay(new SscatLaneEventArgs(ScriptFiles));
        }

        /// <summary>
        /// Event for click the stop button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonStopClick(object sender, EventArgs e)
        {
            OnStop(null);
        }

        /// <summary>
        /// Event for click the save report button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonSaveReportClick(object sender, EventArgs e)
        {
            try
            {
                using (SaveReportForm r = new SaveReportForm(new SaveReport()))
                {
                    r.ReportSave += new EventHandler<SaveReportEventArgs>(SaveReportFormReportSave);
                    r.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LoggingService.Error(string.Format("Error Saving Reports: {0}", ex.ToString()));
            }
        }

        /// <summary>
        /// Event for save the report form
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">save report event arguments</param>
        private void SaveReportFormReportSave(object sender, SaveReportEventArgs e)
        {
            LoadingFormThread loadingForm = new LoadingFormThread("Save Report", "Please wait while SSCAT is saving Report");
            try
            {
                loadingForm.Start();
                ReportPlayback reportPlayback = new ReportPlayback();
                reportPlayback.CreateCompressReportFiles(e.SaveReportInfo, new DirectoryInfo(ApplicationUtility.CacheDirectory));
                (sender as Form).Close();
                loadingForm.Kill();
                MessageService.ShowInfo(string.Format("Done saving {0}.zip in {1}.", e.SaveReportInfo.ReportFilename, e.SaveReportInfo.ReportOutputDirectory));
            }
            catch
            {
                throw;
            }
            finally
            {
                loadingForm.Kill();
            }
        }

        /// <summary>
        /// Event for script result list view double clicked
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ScriptResultListView1DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.scriptResultListView.SelectedItems[0].SubItems[6].Text != null)
                {
                    Process.Start(this.scriptResultListView.SelectedItems[0].SubItems[6].Text);
                }
            }
            catch (Exception)
            {
            }

            try
            {
                if (this.scriptResultListView.SelectedItems[0].SubItems[5].Text != null)
                {
                    Process.Start(this.scriptResultListView.SelectedItems[0].SubItems[5].Text);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Event for script event list view double clicked
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ScriptEventListView1DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.scriptEventListView.SelectedItems[0].SubItems[6].Text != null)
                {
                    Process.Start(this.scriptEventListView.SelectedItems[0].SubItems[6].Text);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Event for clicking the display test result button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonDisplayTestResultClick(object sender, EventArgs e)
        {
            DisplayTestResult();
        }

        /// <summary>
        /// Event for clicking increase repetition index button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonIncreaseRepetitionIndexClick(object sender, EventArgs e)
        {
            UpdateIncreaseButton();
        }

        /// <summary>
        /// Event for clicking decrease repetition index button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonDecreaseRepetitionIndexClick(object sender, EventArgs e)
        {
            UpdateDecreaseButton();
        }

        /// <summary>
        /// Event for repetition index changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void RepetitionIndexChanged(object sender, EventArgs e)
        {
            UpdateRepetitionButtons();
        }

        /// <summary>
        /// Update report button
        /// </summary>
        private void UpdateReportButton()
        {
            if (ScriptFiles.Count == 0)
            {
                buttonSaveReport.Enabled = false;
            }
        }

        /// <summary>
        /// Disable repetition controls
        /// </summary>
        private void DisableRepetitionControls()
        {
            textBoxRepetitionIndex.Text = "0";
            buttonDecreaseRepetitionIndex.Enabled = buttonIncreaseRepetitionIndex.Enabled = buttonDisplayTestResult.Enabled = textBoxRepetitionIndex.Enabled = false;
            ClearResults();
        }

        /// <summary>
        /// Display script result
        /// </summary>
        /// <param name="script">script to display</param>
        private void DisplayScriptResult(IScript script)
        {
            if (InvokeRequired)
            {
                Invoke(new ResultEventHandler(DisplayScriptResult), new object[] { script });
            }
            else
            {
                scriptResultListView.Scripts[script.Index].Result = script.Result;
            }
        }
    }
}