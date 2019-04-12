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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // BoxIP
            // 
            this.BoxIP.Location = new System.Drawing.Point(42, 10);
            this.BoxIP.Name = "BoxIP";
            this.BoxIP.Size = new System.Drawing.Size(102, 21);
            this.BoxIP.TabIndex = 1;
            this.BoxIP.Text = "192.168.200.154";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // BoxPort
            // 
            this.BoxPort.Location = new System.Drawing.Point(191, 10);
            this.BoxPort.Name = "BoxPort";
            this.BoxPort.Size = new System.Drawing.Size(22, 21);
            this.BoxPort.TabIndex = 3;
            this.BoxPort.Text = "21";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户名：";
            // 
            // BoxUsername
            // 
            this.BoxUsername.Location = new System.Drawing.Point(278, 10);
            this.BoxUsername.Name = "BoxUsername";
            this.BoxUsername.Size = new System.Drawing.Size(158, 21);
            this.BoxUsername.TabIndex = 5;
            // 
            // BoxPassword
            // 
            this.BoxPassword.Location = new System.Drawing.Point(495, 10);
            this.BoxPassword.Name = "BoxPassword";
            this.BoxPassword.PasswordChar = '*';
            this.BoxPassword.Size = new System.Drawing.Size(120, 21);
            this.BoxPassword.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "密码：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(621, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "密码可见";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(719, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "连接";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.BoxPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BoxUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BoxPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BoxIP);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button button1;
    }
}

