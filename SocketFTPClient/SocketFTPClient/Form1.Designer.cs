namespace SocketFTPClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.BoxIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BoxPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BoxUsername = new System.Windows.Forms.TextBox();
            this.BoxPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CBVisible = new System.Windows.Forms.CheckBox();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BoxLocalAddress = new System.Windows.Forms.TextBox();
            this.ButtonPath = new System.Windows.Forms.Button();
            this.LabelFtpPath = new System.Windows.Forms.Label();
            this.ListBoxLog = new System.Windows.Forms.ListBox();
            this.BoxFtpPath = new System.Windows.Forms.TextBox();
            this.LVLocal = new System.Windows.Forms.ListView();
            this.LocalFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LocalFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LVFtp = new System.Windows.Forms.ListView();
            this.FtpFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FtpFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonUpload = new System.Windows.Forms.Button();
            this.ButtonDownload = new System.Windows.Forms.Button();
            this.PBRunning = new System.Windows.Forms.ProgressBar();
            this.ButtonPause = new System.Windows.Forms.Button();
            this.LabelTask = new System.Windows.Forms.Label();
            this.ButtonRefreshLocal = new System.Windows.Forms.Button();
            this.ButtonRefreshFtp = new System.Windows.Forms.Button();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.skinEngine = new Sunisoft.IrisSkin.SkinEngine();
            this.buttonLog = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // BoxIP
            // 
            this.BoxIP.Location = new System.Drawing.Point(84, 20);
            this.BoxIP.Margin = new System.Windows.Forms.Padding(6);
            this.BoxIP.Name = "BoxIP";
            this.BoxIP.Size = new System.Drawing.Size(200, 35);
            this.BoxIP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // BoxPort
            // 
            this.BoxPort.Location = new System.Drawing.Point(364, 20);
            this.BoxPort.Margin = new System.Windows.Forms.Padding(6);
            this.BoxPort.Name = "BoxPort";
            this.BoxPort.Size = new System.Drawing.Size(70, 35);
            this.BoxPort.TabIndex = 3;
            this.BoxPort.Text = "21";
            this.BoxPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BoxPort_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户名：";
            // 
            // BoxUsername
            // 
            this.BoxUsername.Location = new System.Drawing.Point(568, 20);
            this.BoxUsername.Margin = new System.Windows.Forms.Padding(6);
            this.BoxUsername.Name = "BoxUsername";
            this.BoxUsername.Size = new System.Drawing.Size(312, 35);
            this.BoxUsername.TabIndex = 5;
            // 
            // BoxPassword
            // 
            this.BoxPassword.Location = new System.Drawing.Point(990, 20);
            this.BoxPassword.Margin = new System.Windows.Forms.Padding(6);
            this.BoxPassword.Name = "BoxPassword";
            this.BoxPassword.PasswordChar = '*';
            this.BoxPassword.Size = new System.Drawing.Size(236, 35);
            this.BoxPassword.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(896, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码：";
            // 
            // CBVisible
            // 
            this.CBVisible.AutoSize = true;
            this.CBVisible.Location = new System.Drawing.Point(1242, 26);
            this.CBVisible.Margin = new System.Windows.Forms.Padding(6);
            this.CBVisible.Name = "CBVisible";
            this.CBVisible.Size = new System.Drawing.Size(138, 28);
            this.CBVisible.TabIndex = 8;
            this.CBVisible.Text = "密码可见";
            this.CBVisible.UseVisualStyleBackColor = true;
            this.CBVisible.CheckedChanged += new System.EventHandler(this.CBVisible_CheckedChanged);
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(1476, 20);
            this.ButtonConnect.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(112, 42);
            this.ButtonConnect.TabIndex = 9;
            this.ButtonConnect.Text = "连接";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "本地路径：";
            // 
            // BoxLocalAddress
            // 
            this.BoxLocalAddress.Enabled = false;
            this.BoxLocalAddress.Location = new System.Drawing.Point(166, 88);
            this.BoxLocalAddress.Margin = new System.Windows.Forms.Padding(4);
            this.BoxLocalAddress.Name = "BoxLocalAddress";
            this.BoxLocalAddress.Size = new System.Drawing.Size(444, 35);
            this.BoxLocalAddress.TabIndex = 11;
            // 
            // ButtonPath
            // 
            this.ButtonPath.Location = new System.Drawing.Point(618, 87);
            this.ButtonPath.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonPath.Name = "ButtonPath";
            this.ButtonPath.Size = new System.Drawing.Size(64, 42);
            this.ButtonPath.TabIndex = 12;
            this.ButtonPath.Text = "...";
            this.ButtonPath.UseVisualStyleBackColor = true;
            this.ButtonPath.Click += new System.EventHandler(this.ButtonPath_Click);
            // 
            // LabelFtpPath
            // 
            this.LabelFtpPath.AutoSize = true;
            this.LabelFtpPath.Location = new System.Drawing.Point(818, 96);
            this.LabelFtpPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelFtpPath.Name = "LabelFtpPath";
            this.LabelFtpPath.Size = new System.Drawing.Size(118, 24);
            this.LabelFtpPath.TabIndex = 13;
            this.LabelFtpPath.Text = "FTP地址：";
            // 
            // ListBoxLog
            // 
            this.ListBoxLog.FormattingEnabled = true;
            this.ListBoxLog.ItemHeight = 24;
            this.ListBoxLog.Location = new System.Drawing.Point(34, 642);
            this.ListBoxLog.Margin = new System.Windows.Forms.Padding(4);
            this.ListBoxLog.Name = "ListBoxLog";
            this.ListBoxLog.Size = new System.Drawing.Size(1552, 244);
            this.ListBoxLog.TabIndex = 14;
            // 
            // BoxFtpPath
            // 
            this.BoxFtpPath.Enabled = false;
            this.BoxFtpPath.Location = new System.Drawing.Point(944, 88);
            this.BoxFtpPath.Margin = new System.Windows.Forms.Padding(4);
            this.BoxFtpPath.Name = "BoxFtpPath";
            this.BoxFtpPath.Size = new System.Drawing.Size(640, 35);
            this.BoxFtpPath.TabIndex = 16;
            // 
            // LVLocal
            // 
            this.LVLocal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LocalFileName,
            this.LocalFileSize});
            this.LVLocal.FullRowSelect = true;
            this.LVLocal.GridLines = true;
            this.LVLocal.Location = new System.Drawing.Point(30, 158);
            this.LVLocal.Margin = new System.Windows.Forms.Padding(6);
            this.LVLocal.MultiSelect = false;
            this.LVLocal.Name = "LVLocal";
            this.LVLocal.Size = new System.Drawing.Size(736, 322);
            this.LVLocal.TabIndex = 17;
            this.LVLocal.UseCompatibleStateImageBehavior = false;
            this.LVLocal.View = System.Windows.Forms.View.Details;
            this.LVLocal.DoubleClick += new System.EventHandler(this.LVLocal_DoubleClick);
            // 
            // LocalFileName
            // 
            this.LocalFileName.Text = "文件名";
            this.LocalFileName.Width = 260;
            // 
            // LocalFileSize
            // 
            this.LocalFileSize.Text = "文件大小";
            this.LocalFileSize.Width = 100;
            // 
            // LVFtp
            // 
            this.LVFtp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FtpFileName,
            this.FtpFileSize});
            this.LVFtp.FullRowSelect = true;
            this.LVFtp.GridLines = true;
            this.LVFtp.Location = new System.Drawing.Point(822, 158);
            this.LVFtp.Margin = new System.Windows.Forms.Padding(6);
            this.LVFtp.MultiSelect = false;
            this.LVFtp.Name = "LVFtp";
            this.LVFtp.Size = new System.Drawing.Size(762, 322);
            this.LVFtp.TabIndex = 18;
            this.LVFtp.UseCompatibleStateImageBehavior = false;
            this.LVFtp.View = System.Windows.Forms.View.Details;
            this.LVFtp.DoubleClick += new System.EventHandler(this.LVFtp_DoubleClick);
            // 
            // FtpFileName
            // 
            this.FtpFileName.Text = "文件名";
            this.FtpFileName.Width = 260;
            // 
            // FtpFileSize
            // 
            this.FtpFileSize.Text = "文件大小";
            this.FtpFileSize.Width = 100;
            // 
            // ButtonUpload
            // 
            this.ButtonUpload.Location = new System.Drawing.Point(180, 502);
            this.ButtonUpload.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonUpload.Name = "ButtonUpload";
            this.ButtonUpload.Size = new System.Drawing.Size(140, 46);
            this.ButtonUpload.TabIndex = 19;
            this.ButtonUpload.Text = "上传";
            this.ButtonUpload.UseVisualStyleBackColor = true;
            this.ButtonUpload.Click += new System.EventHandler(this.ButtonUpload_Click);
            // 
            // ButtonDownload
            // 
            this.ButtonDownload.Location = new System.Drawing.Point(1436, 504);
            this.ButtonDownload.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonDownload.Name = "ButtonDownload";
            this.ButtonDownload.Size = new System.Drawing.Size(150, 46);
            this.ButtonDownload.TabIndex = 20;
            this.ButtonDownload.Text = "下载";
            this.ButtonDownload.UseVisualStyleBackColor = true;
            this.ButtonDownload.Click += new System.EventHandler(this.ButtonDownload_Click);
            // 
            // PBRunning
            // 
            this.PBRunning.Location = new System.Drawing.Point(822, 502);
            this.PBRunning.Margin = new System.Windows.Forms.Padding(6);
            this.PBRunning.Name = "PBRunning";
            this.PBRunning.Size = new System.Drawing.Size(440, 46);
            this.PBRunning.TabIndex = 21;
            // 
            // ButtonPause
            // 
            this.ButtonPause.Location = new System.Drawing.Point(630, 502);
            this.ButtonPause.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonPause.Name = "ButtonPause";
            this.ButtonPause.Size = new System.Drawing.Size(140, 46);
            this.ButtonPause.TabIndex = 22;
            this.ButtonPause.Text = "暂停";
            this.ButtonPause.UseVisualStyleBackColor = true;
            this.ButtonPause.Click += new System.EventHandler(this.ButtonPause_Click);
            // 
            // LabelTask
            // 
            this.LabelTask.BackColor = System.Drawing.Color.Transparent;
            this.LabelTask.Location = new System.Drawing.Point(30, 570);
            this.LabelTask.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LabelTask.Name = "LabelTask";
            this.LabelTask.Size = new System.Drawing.Size(1558, 42);
            this.LabelTask.TabIndex = 23;
            this.LabelTask.Text = "无任务";
            // 
            // ButtonRefreshLocal
            // 
            this.ButtonRefreshLocal.Location = new System.Drawing.Point(330, 502);
            this.ButtonRefreshLocal.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonRefreshLocal.Name = "ButtonRefreshLocal";
            this.ButtonRefreshLocal.Size = new System.Drawing.Size(140, 46);
            this.ButtonRefreshLocal.TabIndex = 24;
            this.ButtonRefreshLocal.Text = "刷新";
            this.ButtonRefreshLocal.UseVisualStyleBackColor = true;
            this.ButtonRefreshLocal.Click += new System.EventHandler(this.ButtonRefreshLocal_Click);
            // 
            // ButtonRefreshFtp
            // 
            this.ButtonRefreshFtp.Location = new System.Drawing.Point(1274, 502);
            this.ButtonRefreshFtp.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonRefreshFtp.Name = "ButtonRefreshFtp";
            this.ButtonRefreshFtp.Size = new System.Drawing.Size(150, 46);
            this.ButtonRefreshFtp.TabIndex = 25;
            this.ButtonRefreshFtp.Text = "刷新";
            this.ButtonRefreshFtp.UseVisualStyleBackColor = true;
            this.ButtonRefreshFtp.Click += new System.EventHandler(this.ButtonRefreshFtp_Click);
            // 
            // ButtonStop
            // 
            this.ButtonStop.Location = new System.Drawing.Point(480, 502);
            this.ButtonStop.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(140, 46);
            this.ButtonStop.TabIndex = 26;
            this.ButtonStop.Text = "中止";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // skinEngine
            // 
            this.skinEngine.@__DrawButtonFocusRectangle = true;
            this.skinEngine.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine.SerialNumber = "";
            this.skinEngine.SkinFile = null;
            // 
            // buttonLog
            // 
            this.buttonLog.Location = new System.Drawing.Point(30, 502);
            this.buttonLog.Margin = new System.Windows.Forms.Padding(6);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Size = new System.Drawing.Size(130, 46);
            this.buttonLog.TabIndex = 27;
            this.buttonLog.Text = "LOG ↓";
            this.buttonLog.UseVisualStyleBackColor = true;
            this.buttonLog.Click += new System.EventHandler(this.buttonLog_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(689, 88);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(82, 42);
            this.buttonOpen.TabIndex = 28;
            this.buttonOpen.Text = "打开";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1608, 626);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonLog);
            this.Controls.Add(this.ButtonStop);
            this.Controls.Add(this.ButtonRefreshFtp);
            this.Controls.Add(this.ButtonRefreshLocal);
            this.Controls.Add(this.LabelTask);
            this.Controls.Add(this.ButtonPause);
            this.Controls.Add(this.PBRunning);
            this.Controls.Add(this.ButtonDownload);
            this.Controls.Add(this.ButtonUpload);
            this.Controls.Add(this.LVFtp);
            this.Controls.Add(this.LVLocal);
            this.Controls.Add(this.BoxFtpPath);
            this.Controls.Add(this.ListBoxLog);
            this.Controls.Add(this.LabelFtpPath);
            this.Controls.Add(this.ButtonPath);
            this.Controls.Add(this.BoxLocalAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ButtonConnect);
            this.Controls.Add(this.CBVisible);
            this.Controls.Add(this.BoxPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BoxUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BoxPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BoxIP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "简易FTP客户端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox BoxIP;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox BoxPort;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox BoxUsername;
        public System.Windows.Forms.TextBox BoxPassword;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox CBVisible;
        public System.Windows.Forms.Button ButtonConnect;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox BoxLocalAddress;
        public System.Windows.Forms.Button ButtonPath;
        public System.Windows.Forms.Label LabelFtpPath;
        public System.Windows.Forms.ListBox ListBoxLog;
        public System.Windows.Forms.TextBox BoxFtpPath;
        public System.Windows.Forms.ListView LVLocal;
        public System.Windows.Forms.ListView LVFtp;
        public System.Windows.Forms.Button ButtonUpload;
        public System.Windows.Forms.Button ButtonDownload;
        public System.Windows.Forms.ProgressBar PBRunning;
        public System.Windows.Forms.Button ButtonPause;
        public System.Windows.Forms.Label LabelTask;
        public System.Windows.Forms.Button ButtonRefreshLocal;
        public System.Windows.Forms.Button ButtonRefreshFtp;
        public System.Windows.Forms.ColumnHeader LocalFileName;
        public System.Windows.Forms.ColumnHeader LocalFileSize;
        public System.Windows.Forms.ColumnHeader FtpFileName;
        public System.Windows.Forms.ColumnHeader FtpFileSize;
        public System.Windows.Forms.Button ButtonStop;
        private Sunisoft.IrisSkin.SkinEngine skinEngine;
        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.Button buttonOpen;
    }
}

