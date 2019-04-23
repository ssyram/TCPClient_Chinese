using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketFTPClient
{
    class TransferTask
    {
        public enum TaskType
        {
            upload,
            download
        }
        // task progress
        long offset = 0;
        FtpSupportTcpClient cmd;
        private Action<long> updateCall;
        private Action finishCall;
        private Action<string> failCall;
        Thread toRun;

        public string LocalPath { get; set; }
        public string FtpPath { get; set; }
        public string FileName { get; set; }
        public TaskType Type { get; set; }

        public TransferTask(
            FtpSupportTcpClient cmd,
            Action<long> updateCall,  // call when sent a new data, para stands for total transmitted size 
            Action finishCall,  // call when finish all the task
            Action<string> failCall,  // call when the task fail to run, para stands for the message
            string localPath, string ftpPath, string file,
            TaskType type
        )
        {
            this.cmd = cmd;
            this.updateCall = updateCall;
            this.finishCall = finishCall;
            this.failCall = failCall;
            Type = type;
            LocalPath = localPath;
            FtpPath = ftpPath;
            FileName = file;
            createTask();
        }

        private void createTask()
        {
            if (Type == TaskType.upload)
                createUpload(FileName);
            else
                createDownload(FileName);
        }

        bool _stop = false;

        // stop the task, there is some chance for continue
        public void stop()
        {
            if (toRun == null) return;
            _stop = true;
            toRun.Join();
            toRun = null;
        }

        public void continueRunning()
        {
            if (toRun != null)
                throw new InvalidOperationException(
                    "The task is still running.");
            _stop = false;
            createTask();
            toRun.Start();
        }

        // go round and read write, as well as accumulating offset
        private bool rounder(Stream reader, Stream writer)
        {
            byte[] tf = new byte[1030];
            int cnt = 0;
            while ((cnt = reader.Read(tf, 0, 1024)) > 0)
            {
                if (_stop)
                    return false;
                writer.Write(tf, 0, cnt);
                offset += cnt;
                updateCall(offset);
            }
            finishCall();
            return true;
        }

        // the thread structure for running
        private void threadCreate(Func<Func<string, string>, TcpClient, bool> act, bool needWait) 
        {
            toRun = new Thread(() =>
            {
                cmd.passiveDataAction(string.Format(CommandConstant.CMD_FMT_BREAKPOINT, offset), act, needWait);
            });
        }

        // create an upload task that ready for but not actually run
        private void createUpload(string file)
        {
            threadCreate((send, data) =>
            {
                FileStream fs;
                try
                {
                    fs = new FileStream(Path.Combine(LocalPath, file), FileMode.Open);
                    fs.Seek(offset, SeekOrigin.Begin);
                }
                catch (Exception)
                {
                    failCall(LanguageConstant.CANNOT_OPEN_FILE);
                    goto ret;
                }
                // position changed: in order not to waste transfering
                if (!send(string.Format(CommandConstant.CMD_FMT_UPLOAD, file)).StartsWith("150"))
                {
                    failCall(LanguageConstant.UPLOAD_NOT_SUPPORT_ERROR);
                    goto ret;
                }

                var r = rounder(fs, data.GetStream());
                fs.Close();
                if (!r) return r;
                ret:
                cmd.abor();
                return true;
            }, false);
        }
        // create an download task that ready for but not actually run
        private void createDownload(string fileName)
        {
            threadCreate((send, data) =>
            {
                FileStream fs;
                try
                {
                    fs = new FileStream(Path.Combine(LocalPath, fileName), FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Seek(offset, SeekOrigin.Begin);
                }
                catch (Exception)
                {
                    failCall(LanguageConstant.CANNOT_OPEN_FILE);
                    return true;
                }
                if (!send(string.Format(CommandConstant.CMD_FMT_DOWNLOAD, fileName)).StartsWith("150"))
                {
                    failCall(LanguageConstant.DOWNLOAD_NOT_SUPPORT_ERROR);
                    return true;
                }

                var r = rounder(data.GetStream(), fs);
                fs.Close();
                return r;
            }, true);
        }

        public void run()
        {
            toRun.Start();
        }
    }
}
