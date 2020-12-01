// <copyright file="FileWatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// Initializes a new instance of the FileWatcher class
    /// </summary>
    public class FileWatcher : ITextWatcher
    {
        /// <summary>
        /// Changes locker
        /// </summary>
        private readonly object _changesLocker = new object();
        
        /// <summary>
        /// Watcher locker
        /// </summary>
        private readonly object _watcherLocker = new object();

        /// <summary>
        /// File to watch
        /// </summary>
        private string _file;

        /// <summary>
        /// Backup file
        /// </summary>
        private string _backUpFile;

        /// <summary>
        /// Is Watcher Busy?
        /// </summary>
        private bool _isWatcherBusy = false;

        /// <summary>
        /// Is Watcher Queue?
        /// </summary>
        private bool _isWatcherQueue = false;

        /// <summary>
        /// File system watcher
        /// </summary>
        private FileSystemWatcher _watcher;

        /// <summary>
        /// File changes
        /// </summary>
        private StringBuilder _changes = new StringBuilder();

        /// <summary>
        /// File encoding
        /// </summary>
        private Encoding _encoding;

        /// <summary>
        /// File offset
        /// </summary>
        private long _offset;

        /// <summary>
        /// File Length
        /// </summary>
        private long _filelength = 0;

        /// <summary>
        /// Whether or not file has changes
        /// </summary>
        private bool _hasChanges;
        
        /// <summary>
        /// Whether or not to keep the file buffer
        /// </summary>
        private bool _keepBuffer;

        /// <summary>
        /// Initializes a new instance of the FileWatcher class
        /// </summary>
        /// <param name="file">file to watch</param>
        /// <param name="encoding">file encoding</param>
        /// <param name="backUpFile">backup file</param>
        /// <param name="keepBuffer">whether or not to keep the file buffer</param>
        public FileWatcher(string file, Encoding encoding, string backUpFile, bool keepBuffer)
        {
            _file = file;
            _encoding = encoding;
            _backUpFile = backUpFile;
            _keepBuffer = keepBuffer;

            using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    _offset = reader.BaseStream.Length;
                }
            }

            _watcher = new FileSystemWatcher();
            _watcher.Filter = Path.GetFileName(file);
            _watcher.Path = Path.GetDirectoryName(file);
            _watcher.Changed += new FileSystemEventHandler(WatcherChanged);
            _watcher.Created += new FileSystemEventHandler(WatcherChanged);
            _watcher.Deleted += new FileSystemEventHandler(WatcherChanged);
            _watcher.Renamed += new RenamedEventHandler(WatcherRenamed);
            _watcher.Error += new ErrorEventHandler(WatcherError);
            _watcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Finalizes an instance of the FileWatcher class
        /// </summary>
        ~FileWatcher()
        {
            _watcher.Changed -= new FileSystemEventHandler(WatcherChanged);
            _watcher.Created -= new FileSystemEventHandler(WatcherChanged);
            _watcher.Deleted -= new FileSystemEventHandler(WatcherChanged);
            _watcher.Renamed -= new RenamedEventHandler(WatcherRenamed);
            _watcher.Error -= new ErrorEventHandler(WatcherError);
            Dispose();
        }

        /// <summary>
        /// Event handler for file changed
        /// </summary>
        public event EventHandler<LogHookEventArgs> Changed;

        /// <summary>
        /// Dispose of the file watcher
        /// </summary>
        public virtual void Dispose()
        {
            ClearChanges();
            _watcher.Dispose();
        }

        /// <summary>
        /// Clear changes
        /// </summary>
        public void ClearChanges()
        {
            lock (_changesLocker)
            {
                if (_changes.Length > 0)
                {
                    _changes.Remove(0, _changes.Length - 1);
                }
            }
        }

        /// <summary>
        /// Append the log
        /// </summary>
        /// <param name="text">Text to append</param>
        public void AppendLog(string text)
        {
            PerformChanged();
        }

        /// <summary>
        /// Perform the change
        /// </summary>
        public void PerformChanged()
        {
            WatcherChanged(this, new FileSystemEventArgs(WatcherChangeTypes.Changed, string.Empty, string.Empty));
        }

        /// <summary>
        /// Event for on changed
        /// </summary>
        /// <param name="e">log hook event arguments</param>
        protected virtual void OnChanged(LogHookEventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }

        /// <summary>
        /// Event for watcher error
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">error event arguments</param>
        private void WatcherError(object sender, ErrorEventArgs e)
        {
            LoggingService.Info("FileSystemWatcher: Event=Exception in {0}; ExceptionMessage={1}", _file, e.GetException().ToString());
        }

        /// <summary>
        /// Event for watcher renamed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">renamed event arguments</param>
        private void WatcherRenamed(object sender, RenamedEventArgs e)
        {
            LoggingService.Info("FileSystemWatcher: [{0}] in {1}", e.ChangeType.ToString(), _file);
        }

        /// <summary>
        /// Event for watcher changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">file system event arguments</param>
        private void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            if (!_isWatcherBusy)
            {
                long fileLength = 0;
                long offset = _offset;
                bool readBackLog = false;

                try
                {
                    this.SetWatcherBusy(true);
                    _hasChanges = false;
                    fileLength = new FileInfo(_file).Length;

                    try
                    {
                        Monitor.Enter(_changesLocker);
                        if ((_filelength == 0) || (_filelength < fileLength))
                        {
                            fileLength = new FileInfo(_file).Length;

                            if ((fileLength < _offset) || (_offset == 0))
                            {
                                readBackLog = true;
                                ReadLog(_backUpFile);
                                _offset = 0;
                            }

                            ReadLog(_file);
                        }
                    }
                    finally
                    {
                        Monitor.Exit(_changesLocker);
                    }

                    if (_hasChanges)
                    {
                        OnChanged(new LogHookEventArgs(_changes.ToString()));
                        if (!_keepBuffer)
                        {
                            ClearChanges();
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    LoggingService.Error(ex.ToString()); // HACK: This triggers if Lane is currently backing up the log file hence the file is renamed so it's currenlty not found.
                    ThreadHelper.Sleep(50);
                    WatcherChanged(sender, e);
                }
                catch (IOException ex)
                {
                    LoggingService.Error(ex.ToString()); // HACK: Sometimes another process is shitting off with logs so need to catch
                    ThreadHelper.Sleep(50);
                    WatcherChanged(sender, e);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    LoggingService.Error(ex.ToString());
                    LoggingService.Error(ex.StackTrace);
                    LoggingService.Error(string.Format("filename: {0}", e.Name));
                }
                finally
                {
                    if (e.ChangeType != WatcherChangeTypes.Changed)
                    {
                        LoggingService.Info("FileSystemWatcher: Event={0};  File= {1}; ReadBacklog={2} -> (Length={3} < FileOffset={4})", e.ChangeType.ToString(), Path.GetFileName(_file), readBackLog.ToString(), fileLength.ToString(), offset.ToString());
                    }

                    this.SetWatcherBusy(false);
                }
            }
            else
            {
                LoggingService.Info("[{0}]: LogHookData: WatcherChanged. Watcher is Busy", Path.GetFileNameWithoutExtension(_file));
                try
                {
                    if (!_isWatcherQueue)
                    {
                        this.SetWatcherQueue(true);
                        int cnt = 0;
                        while (_isWatcherBusy)
                        {
                            cnt++;
                            LoggingService.Info("[{0}]: LogHookData: WatcherChanged. Watcher is Busy. Queueing WatcherChanged.", Path.GetFileNameWithoutExtension(_file));
                            ThreadHelper.Sleep(50);
                            if (cnt > 20)
                            {
                                this.SetWatcherQueue(false);
                                return;
                            }
                        }

                        WatcherChanged(sender, e);
                    }
                }
                finally
                {
                    this.SetWatcherQueue(false);
                }
            }
        }

        /// <summary>
        /// Read log. Note: Please use this method inside lock (changesLocker) {...}.
        /// </summary>
        /// <param name="path">path name</param>
        private void ReadLog(string path)
        {
            long length = 0;
            char[] lines = new char[0];
            long count = 0;
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    count = 0;
                    using (StreamReader reader = new StreamReader(stream, _encoding))
                    {
                        reader.BaseStream.Seek(_offset, SeekOrigin.Begin);
                        length = reader.BaseStream.Length;
                        if (length < _offset)
                        {
                            _offset = 0;
                        }

                        count = length - _offset;
                        count = (_encoding == Encoding.Unicode) ? count / 2 : count;
                        lines = new char[count];
                        reader.Read(lines, 0, (int)count);
                    }
                    
                    string logChanges = new string(lines).Trim('\0');

                    if (logChanges.Length > 0) 
                    {
                        _changes.Append(logChanges);
                        _hasChanges = true;
                        _offset = length;
                    }
                }
            }
            catch (OverflowException ex)
            {
                LoggingService.Error(string.Format("OverflowException: File: {0}, Length: {1}, Offset: {2}, Count: {3}, Error: {4}", _file, length, _offset, count, ex.ToString()));
            }
            catch (OutOfMemoryException ex)
            {
                LoggingService.Error(string.Format("OutOfMemoryException: File: {0}, Length: {1}, Offset: {2}, Count: {3}, Error: {4}", _file, length, _offset, count, ex.ToString()));
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
            }
        }

        /// <summary>
        /// SetWatcherBusy. Sets _isWatcherBusy inside _watcherLocker
        /// </summary>
        /// <param name="isBusy">whether watcher is busy</param>
        private void SetWatcherBusy(bool isBusy)
        {
            try
            {
                Monitor.Enter(_watcherLocker);
                _isWatcherBusy = isBusy;
            }
            finally
            {
                Monitor.Exit(_watcherLocker);
            }
        }

        /// <summary>
        /// SetWatcherQueue. Sets _isWatcherQueue inside _watcherLocker
        /// </summary>
        /// <param name="isWatcherQueue">whether watcher has a queue</param>
        private void SetWatcherQueue(bool isWatcherQueue)
        {
            try
            {
                Monitor.Enter(_watcherLocker);
                _isWatcherQueue = isWatcherQueue;
            }
            finally
            {
                Monitor.Exit(_watcherLocker);
            }
        }

        /// <summary>
        /// IsWatcherBusy. Gets _isWatcherBusy inside _watcherLocker
        /// </summary>
        /// <returns name="watcherQueueValue">value of _isWatcherQueue</returns>
        private bool IsWatcherBusy()
        {
            bool watcherBusyValue = false; 

            try
            {
                Monitor.Enter(_watcherLocker);
                watcherBusyValue = _isWatcherBusy;
            }
            finally
            {
                Monitor.Exit(_watcherLocker);
            }

            return watcherBusyValue;
        }
    }
}
