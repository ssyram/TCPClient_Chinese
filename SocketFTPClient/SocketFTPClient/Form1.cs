using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SocketFTPClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const string IPv4Match =
            @"^((2[0-4]\d|25[0-5]|[1]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[1]?\d\d?)$";
        private const string IPv6Match =
            @"^([0-9A-Fa-f]{1, 4}:){7}([0-9A-Fa-f]{1, 4})$";

        private FtpSupportTcpClient cmd;
        private bool can_continue;  // mark whether the server support the command of break point and continue

        // batch tackling all of the box above as well as the check box
        private void inputBatch(bool act)
        {
            BoxIP.Enabled = act;
            BoxPassword.Enabled = act;
            BoxPort.Enabled = act;
            BoxUsername.Enabled = act;

            CBVisible.Enabled = act;
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            // core run paras
            Cursor cr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            // disable all
            {
                inputBatch(false);
                actionBatch(false);
            }

            // core run
            if (ButtonConnect.Text == LanguageConstant.CONNECT_STRING)
            {
                BoxUsername.Text = BoxUsername.Text.Trim();
                if (BoxPort.Text.Equals("")) BoxPort.Text = "21";
                cmd = createClient(BoxIP.Text, Convert.ToUInt16(BoxPort.Text));
                if (cmd == null)
                {
                    MessageBox.Show(LanguageConstant.INVALID_IP_ERROR);
                    goto brk;
                }
                ListBoxLog.Items.Clear();

                // Login
                // User Name
                string rets = cmd.login(BoxUsername.Text, BoxPassword.Text).Substring(0, 3);
                if (!rets.Equals("230"))
                {
                    MessageBox.Show(LanguageConstant.PASSWORD_ERROR);
                    goto brk;
                }

                ButtonConnect.Text = LanguageConstant.DISCONNECT_STRING;
                functionEnable();
                goto ret;
            // means to keep the original disconnection mode
            brk:
                inputBatch(true);
            }
            else if (ButtonConnect.Text == LanguageConstant.DISCONNECT_STRING)
            {
                if (!checkDisconnect())
                {
                    MessageBox.Show(LanguageConstant.CANNOT_CLOSE);
                    goto brk;  // keep connect
                }

                cmd.quitThis();
                cmd.closeStreams();

                ButtonConnect.Text = LanguageConstant.CONNECT_STRING;

                setToReadyForLink();
                goto ret;
            brk:
                actionBatch(true);
            }
            else throw new InvalidDataException("Not a valid string for this button");

        ret:
            Cursor.Current = cr;
            ButtonConnect.Enabled = true;
        }

        // create a client for this Form
        private FtpSupportTcpClient createClient(string ip, ushort port)
        {
            if (!Regex.IsMatch(BoxIP.Text, IPv4Match) && !Regex.IsMatch(BoxIP.Text, IPv6Match))
                return null;
            try
            {
                var r = new FtpSupportTcpClient(ip, port, s =>
                {
                    ListBoxLog.Items.Add(s);
                    ListBoxLog.SelectedIndex = ListBoxLog.Items.Count - 1;
                });  // for port is "ushort", no need to check
                return r;
            }
            catch (Exception)
            {
                return null;
            }
        }        

        // disconnect and recover the UI
        private void setToReadyForLink()
        {
            inputBatch(true);
            actionBatch(false);
        }

        // check whether it's safe for disconnection
        private bool checkDisconnect()
        {
            return task == null;
        }

        // enable all components and for the boxes, initialize them if needed.
        private void functionEnable()
        {
            if (cmd.sendCommand(string.Format(CommandConstant.CMD_FMT_BREAKPOINT, 100)).Substring(0, 3).Equals("503")) can_continue = false;
            else can_continue = true;

            actionBatch(true);
            BoxFtpPath.Text = "\\";
            refreshFtp();
            refreshLocal();
        }

        // $"cd {d}"
        private void changeFtpDirectory(string d)
        {
            if (d == "..")
            {
                if (BoxFtpPath.Text.Equals("\\")) throw new FormatException("It's impossible to return to the uppoer layer of root.");
            }
            if (!cmd.sendCommand($"CWD {d}\r\n").Substring(0, 3).Equals("250"))
            {
                MessageBox.Show(LanguageConstant.CANNOT_CHANGE_DIRECTORY);
                return;
            }
            if (d == "..") BoxFtpPath.Text = BoxFtpPath.Text.Substring(0, 
                    BoxFtpPath.Text.Substring(0, BoxFtpPath.Text.LastIndexOf("\\")).LastIndexOf("\\") + 1);
            else BoxFtpPath.Text += d + "\\";
            refreshFtp();
        }

        // reload the server box of file
        private void refreshFtp()
        {
            LVFtp.Items.Clear();
            if (!BoxFtpPath.Text.Equals("\\"))
            {
                ListViewItem it = new ListViewItem();
                it.Text = "..";
                it.SubItems.Add("directory");
                LVFtp.Items.Add(it);
            }
            cmd.passiveDataAction(CommandConstant.CMD_LIST, (send, data) =>
            {
                StreamReader reader = new StreamReader(data.GetStream(), Encoding.Default);
                string s;
                while ((s = reader.ReadLine()) != null)
                {
                    var size = Convert.ToUInt64(Regex.Match(s.Substring(24), @"\d+").ToString());
                    ListViewItem it = new ListViewItem();
                    it.Text = s.Substring(52);
                    if (s[0] == 'd') it.SubItems.Add("directory");
                    else it.SubItems.Add(size.ToString());
                    LVFtp.Items.Add(it);
                }
            });
        }

        // reload the local list of file
        private void refreshLocal()
        {
            LVLocal.Items.Clear();
            string[] filenames = Directory.GetFiles(BoxLocalAddress.Text, "*.*");
            foreach (string file in filenames)
            {
                var size = new FileInfo(file).Length;
                ListViewItem it = new ListViewItem();
                var tmp = Regex.Split(file, @"\\");
                it.Text = tmp[tmp.Length - 1];
                it.SubItems.Add(size.ToString());
                LVLocal.Items.Add(it);
            }
        }

        // the batch enable operation for action part of the UI.
        // the UI is generally divided into two parts: 
        // the first one is input part which should only be used before connection
        // the second is action part which, on the opposite, should only be used after connection
        private void actionBatch(bool act)
        {
            ButtonUpload.Enabled = act;
            ButtonDownload.Enabled = act;
            ButtonPath.Enabled = act;
            ButtonPause.Enabled = act;
            ButtonRefreshLocal.Enabled = act;
            ButtonRefreshFtp.Enabled = act;
            ButtonStop.Enabled = act;

            LVLocal.Enabled = act;
            LVFtp.Enabled = act;

            if (task == null) runningPartBatch(true);
            else runningPartBatch(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            actionBatch(false);
            BoxLocalAddress.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            refreshLocal();
            CheckForIllegalCrossThreadCalls = false;
            // just for test
            //BoxIP.Text = "192.168.56.1";
            //BoxUsername.Text = "aaaaa";
            //BoxPassword.Text = "123";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        // input restriction
        private void BoxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                //if (e.KeyChar == '0' && BoxPort.Text == "") return;
                BoxPort.Text += e.KeyChar;
                BoxPort.Select(BoxPort.Text.Length, 0);  // focus on the last one
                if (Convert.ToInt32(BoxPort.Text) > 65535)
                {
                    BoxPort.Text = "65535";
                    BoxPort.Select(BoxPort.Text.Length, 0);
                }
            }
            else if (e.KeyChar == (char)8) return;
            else e.Handled = true;
        }

        private void CBVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (BoxPassword.PasswordChar == '*')
                BoxPassword.PasswordChar = '\0';
            else
                BoxPassword.PasswordChar = '*';
        }

        TransferTask task = null;

        // create a new task to run
        private void startRunning(string fileName, TransferTask.TaskType type, long size)
        {
            PBRunning.Value = 0;
            LabelTask.Text = string.Format(
                type == TransferTask.TaskType.upload ? LanguageConstant.UPLOADING_FMT : LanguageConstant.DOWNLOADING_FMT,
                fileName);
            runningPartBatch(false);
            task = new TransferTask(
                cmd, nsize => 
                    PBRunning.Value = (int)(100 * nsize / size), () =>
                {
                    task = null;
                    PBRunning.Value = 100;
                    LabelTask.Text = LanguageConstant.FINISHED_STRING;
                    runningPartBatch(true);
                    if (type == TransferTask.TaskType.upload) refreshFtp();
                    else refreshLocal();
                }, s=>
                {
                    MessageBox.Show(s);
                    task = null;
                    LabelTask.Text = s;
                    runningPartBatch(true);
                }, BoxLocalAddress.Text, BoxFtpPath.Text, fileName, type);
            task.run();
        }

        //List<TransferTask> taskDelegate = new List<TransferTask>();

        //private TransferTask createTask(string fileName, bool isUpload, long size)
        //{
            
        //    var r = new TransferTask(
        //        cmd,
        //        LVTask, taskDelegate.Count, LabelTask, ButtonPause, taskDelegate,
        //        BoxLocalAddress.Text, BoxFtpPath.Text, fileName, 
        //        isUpload ? TransferTask.TaskType.upload : TransferTask.TaskType.download, size
        //    );
        //    taskDelegate.Add(r);
        //    ListViewItem it = new ListViewItem();
        //    it.Text = fileName;
        //    Action<string> add = s => it.SubItems.Add(s);
        //    add(isUpload ? LanguageConstant.UPLOAD_STRING : LanguageConstant.DOWNLOAD_STRING);
        //    add("0");
        //    add(size.ToString());
        //    add(LanguageConstant.RUNNING_STRING);
        //    LVTask.Items.Add(it);
        //    r.run();
        //    return r;
        //}

        //private void selectTask(int index)
        //{

        //}

        private void ButtonRefreshLocal_Click(object sender, EventArgs e)
        {
            refreshLocal();
        }

        private void ButtonRefreshFtp_Click(object sender, EventArgs e)
        {
            refreshFtp();
        }

        private void ButtonPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                ListBoxLog.Items.Add("Change Local Directory to: " + fb.SelectedPath);
                ListBoxLog.SelectedIndex = ListBoxLog.Items.Count - 1;
                BoxLocalAddress.Text = fb.SelectedPath;
                refreshLocal();
            }
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
            if (!can_continue)
            {
                MessageBox.Show(LanguageConstant.PAUSE_NOT_SUPPORT_ERROR);
                return;
            }
            if (ButtonPause.Text.Equals(LanguageConstant.PAUSE_STRING))
            {
                if (task == null) throw new FormatException("No Task is Running");
                task.stop();
                LabelTask.Text = string.Format(
                    task.Type == TransferTask.TaskType.upload ? LanguageConstant.PAUSE_UPLOAD_FMT : LanguageConstant.PAUSE_DOWNLOAD_FMT,
                    task.FileName);
            }
            else
            {
                if (task == null) throw new FormatException("No Task is Running");
                task.continueRunning();
                LabelTask.Text = string.Format(
                    task.Type == TransferTask.TaskType.upload ? LanguageConstant.UPLOADING_FMT : LanguageConstant.DOWNLOADING_FMT,
                    task.FileName);
            }
        }

        // enter the mode of running downloading
        // the influence is focused in UI
        // when running, some part of the "Action UI" should be disabled
        // after which they should function as usual.
        private void runningPartBatch(bool act)
        {
            ButtonPath.Enabled = act;
            LVLocal.Enabled = act;
            LVFtp.Enabled = act;
            ButtonUpload.Enabled = act;
            ButtonDownload.Enabled = act;
            ButtonRefreshLocal.Enabled = act;
            ButtonRefreshFtp.Enabled = act;

            ButtonStop.Enabled = !act;
            ButtonPause.Enabled = !act;
        }

        // Just stop but not ready to continue the task
        private void ButtonStop_Click(object sender, EventArgs e)
        {
            if (task == null) throw new FormatException("No Task Is Running");
            task.stop();
            task = null;
            runningPartBatch(true);
        }

        private void uploadItem()
        {
            if (LVLocal.SelectedIndices.Count != 1) return;
            startRunning(LVLocal.SelectedItems[0].Text, TransferTask.TaskType.upload, Convert.ToInt64(LVLocal.SelectedItems[0].SubItems[1].Text));
        }

        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            uploadItem();
        }

        private void downloadItem()
        {
            if (LVFtp.SelectedIndices.Count != 1) return;
            if (LVFtp.SelectedItems[0].SubItems[1].Text == "directory")
            {
                changeFtpDirectory(LVFtp.SelectedItems[0].Text);
            }
            else startRunning(LVFtp.SelectedItems[0].Text, TransferTask.TaskType.download, Convert.ToInt64(LVFtp.SelectedItems[0].SubItems[1].Text));
        }

        private void ButtonDownload_Click(object sender, EventArgs e)
        {
            downloadItem();
        }

        private void LVFtp_DoubleClick(object sender, EventArgs e)
        {
            downloadItem();
        }

        private void LVLocal_DoubleClick(object sender, EventArgs e)
        {
            uploadItem();
        }
    }
}
