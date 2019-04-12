using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketFTPClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const string CRLF = "\r\n";
        // cmd list
        private const string CMD_LIST = "LIST" + CRLF;
        private const string CMD_PASV = "PASV" + CRLF;
        private const string CMD_ABOR = "ABOR" + CRLF;
        private const string CMD_QUIT = "QUIT" + CRLF;
        // cmd format list
        private const string CMD_FMT_USRNAME = "USER {0}" + CRLF;
        private const string CMD_FMT_PASSWORD = "PASS {0}" + CRLF;
        private const string CMD_FMT_UPLOAD = "STOR {0}" + CRLF;
        private const string CMD_FMT_DOWNLOAD = "RETR {0}" + CRLF;

        private const string CONNECT_STRING = "连接";
        private const string DISCONNECT_STRING = "断开";
        private const string PASSWORD_ERROR = "密码错误：用户名密码不匹配";
        private const string CANNOT_CLOSE = "还有部分在执行，暂不能停止";

        private TcpClient cmdS;  // server cmd channel
        private NetworkStream cmdWriter;
        private StreamReader cmdReader;
        private TcpClient dataS;  // server data channel
        private NetworkStream dataWriter;
        private StreamReader dataReader;

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            // core run paras
            Cursor cr = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            DisableAll();
            // to check the validity of:
            // IP, port
            {

            }

            // core run
            if (ButtonConnect.Text == CONNECT_STRING)
            {
                cmdS = new TcpClient(BoxIP.Text, Convert.ToInt32(BoxIP.Text));
                ListBoxLog.Items.Clear();
                cmdReader = new StreamReader(cmdS.GetStream());
                cmdWriter = cmdS.GetStream();
                fillStatus();

                // Login
                // User Name
                sendAndLog(
                    string.Format(
                        CMD_FMT_USRNAME, BoxUsername.Text));
                // Password
                var ret = sendAndLog(
                    string.Format(
                        CMD_FMT_PASSWORD, BoxPassword.Text)).Substring(0, 3);
                if (ret.Equals("530"))
                {
                    MessageBox.Show(PASSWORD_ERROR);
                    goto brk;
                }
                refreshRight();

                ButtonConnect.Text = DISCONNECT_STRING;
                functionEnable();
                brk:;
            }
            else if (ButtonConnect.Text == DISCONNECT_STRING)
            {
                if (!checkDisconnect())
                {
                    MessageBox.Show(CANNOT_CLOSE);
                    goto brk;
                }

                sendAndLog(CMD_QUIT);
                cmdReader.Close();
                cmdWriter.Close();

                ButtonConnect.Text = CONNECT_STRING;

                setToReadyForLink();
                brk:;
            }
            else throw new InvalidDataException("Not a valid string for this button");
            Cursor.Current = cr;
        }

        private void setToReadyForLink()
        {
            throw new NotImplementedException();
        }

        private void DisableAll()
        {
            throw new NotImplementedException();
        }

        private bool checkDisconnect()
        {
            throw new NotImplementedException();
        }

        private void functionEnable()
        {
            throw new NotImplementedException();
        }

        private void refreshRight()
        {
            throw new NotImplementedException();
        }

        private string sendAndLog(string s)
        {
            var data =
                System.Text.Encoding.ASCII.GetBytes(
                    s.ToCharArray()
                );
            cmdWriter.Write(data, 0, data.Length);
            return fillStatus();
        }

        private string fillStatus()
        {
            throw new NotImplementedException();
        }
    }
}
