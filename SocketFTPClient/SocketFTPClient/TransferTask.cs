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
        bool finish = false;

        // stop the task, there is some chance for continue
        public void stop()
        {
            _stop = true;
            toRun.Join();
        }

        public void continueRunning()
        {
            if (toRun != null) throw new InvalidOperationException("The task is still running.");
            createTask();
            toRun.Start();
        }

        // go round and read write, as well as accumulating offset
        private void rounder(Stream reader, Stream writer)
        {
            byte[] tf = new byte[1030];
            int cnt = 0;
            while ((cnt = reader.Read(tf, 0, 1024)) > 0)
            {
                if (_stop) return;
                writer.Write(tf, 0, cnt);
                offset += cnt;
                updateCall(offset);
            }
            finish = true;
            finishCall();
        }

        // the thread structure for running
        private void threadCreate(Action<Func<string, string>, TcpClient> act) 
        {
            toRun = new Thread(() =>
            {
                cmd.passiveDataAction(string.Format(CommandConstant.CMD_FMT_BREAKPOINT, offset), act);
            });
        }

        // create an upload task that ready for but not actually run
        private void createUpload(string file)
        {
            threadCreate((send, data) =>
            {
                if (!send(string.Format(CommandConstant.CMD_FMT_UPLOAD, file)).Substring(0, 3).Equals("150"))
                {
                    failCall(LanguageConstant.UPLOAD_NOT_SUPPORT_ERROR);
                    goto ret;
                }
                FileStream fs;
                try
                {
                    fs = new FileStream(Path.Combine(LocalPath, file), FileMode.Open);
                }
                catch (Exception)
                {
                    failCall(LanguageConstant.CANNOT_OPEN_FILE);
                    goto ret;
                }

                rounder(fs, data.GetStream());
            ret:
                cmd.sendCommand(CommandConstant.CMD_ABOR);
            });
        }
        // create an download task that ready for but not actually run
        private void createDownload(string fileName)
        {
            threadCreate((send, data) =>
            {
                if (!send(string.Format(CommandConstant.CMD_FMT_DOWNLOAD, fileName)).Substring(0, 3).Equals("150"))
                {
                    failCall(LanguageConstant.DOWNLOAD_NOT_SUPPORT_ERROR);
                    return;
                }
                FileStream fs;
                try
                {
                    fs = new FileStream(Path.Combine(LocalPath, fileName), FileMode.OpenOrCreate, FileAccess.Write);
                }
                catch (Exception)
                {
                    failCall(LanguageConstant.CANNOT_OPEN_FILE);
                    return;
                }

                rounder(data.GetStream(), fs);
            });
        }

        public void run()
        {
            toRun.Start();
        }
    }
}
