namespace SocketFTPClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.BoxIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BoxPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BoxUsername = new System.Windows.Forms.TextBox();
            this.BoxPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BoxLocalAddress = new System.Windows.Forms.TextBox();
            this.ButtonPath = new System.Windows.Forms.Button();
            this.LabelFtpPath = new System.Windows.Forms.Label();
            this.ListBoxLog = new System.Windows.Forms.ListBox();
            this.LabelLog = new System.Windows.Forms.Label();
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
            this.BoxIP.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            this.BoxPort.Location = new System.Drawing.Point(382, 20);
            this.BoxPort.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BoxPort.Name = "BoxPort";
            this.BoxPort.Size = new System.Drawing.Size(40, 35);
            this.BoxPort.TabIndex = 3;
            this.BoxPort.Text = "21";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(438, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户名：";
            // 
            // BoxUsername
            // 
            this.BoxUsername.Location = new System.Drawing.Point(556, 20);
            this.BoxUsername.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BoxUsername.Name = "BoxUsername";
            this.BoxUsername.Size = new System.Drawing.Size(312, 35);
            this.BoxUsername.TabIndex = 5;
            // 
            // BoxPassword
            // 
            this.BoxPassword.Location = new System.Drawing.Point(990, 20);
            this.BoxPassword.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1242, 26);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 28);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "密码可见";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(1438, 20);
            this.ButtonConnect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(150, 46);
            this.ButtonConnect.TabIndex = 9;
            this.ButtonConnect.Text = "连接";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "本地路径：";
            // 
            // BoxLocalAddress
            // 
            this.BoxLocalAddress.Enabled = false;
            this.BoxLocalAddress.Location = new System.Drawing.Point(166, 89);
            this.BoxLocalAddress.Name = "BoxLocalAddress";
            this.BoxLocalAddress.Size = new System.Drawing.Size(594, 35);
            this.BoxLocalAddress.TabIndex = 11;
            // 
            // ButtonPath
            // 
            this.ButtonPath.Location = new System.Drawing.Point(766, 89);
            this.ButtonPath.Name = "ButtonPath";
            this.ButtonPath.Size = new System.Drawing.Size(64, 35);
            this.ButtonPath.TabIndex = 12;
            this.ButtonPath.Text = "...";
            this.ButtonPath.UseVisualStyleBackColor = true;
            // 
            // LabelFtpPath
            // 
            this.LabelFtpPath.AutoSize = true;
            this.LabelFtpPath.Location = new System.Drawing.Point(887, 92);
            this.LabelFtpPath.Name = "LabelFtpPath";
            this.LabelFtpPath.Size = new System.Drawing.Size(118, 24);
            this.LabelFtpPath.TabIndex = 13;
            this.LabelFtpPath.Text = "FTP地址：";
            // 
            // ListBoxLog
            // 
            this.ListBoxLog.FormattingEnabled = true;
            this.ListBoxLog.ItemHeight = 24;
            this.ListBoxLog.Location = new System.Drawing.Point(30, 628);
            this.ListBoxLog.Name = "ListBoxLog";
            this.ListBoxLog.Size = new System.Drawing.Size(1558, 244);
            this.ListBoxLog.TabIndex = 14;
            // 
            // LabelLog
            // 
            this.LabelLog.AutoSize = true;
            this.LabelLog.Location = new System.Drawing.Point(26, 582);
            this.LabelLog.Name = "LabelLog";
            this.LabelLog.Size = new System.Drawing.Size(58, 24);
            this.LabelLog.TabIndex = 15;
            this.LabelLog.Text = "日志";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1612, 900);
            this.Controls.Add(this.LabelLog);
            this.Controls.Add(this.ListBoxLog);
            this.Controls.Add(this.LabelFtpPath);
            this.Controls.Add(this.ButtonPath);
            this.Controls.Add(this.BoxLocalAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ButtonConnect);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.BoxPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BoxUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BoxPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BoxIP);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Z";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BoxIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BoxPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BoxUsername;
        private System.Windows.Forms.TextBox BoxPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox BoxLocalAddress;
        private System.Windows.Forms.Button ButtonPath;
        private System.Windows.Forms.Label LabelFtpPath;
        private System.Windows.Forms.ListBox ListBoxLog;
        private System.Windows.Forms.Label LabelLog;
    }
}

