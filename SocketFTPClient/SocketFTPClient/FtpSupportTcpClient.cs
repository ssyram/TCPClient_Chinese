using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SocketFTPClient
{
    class FtpSupportTcpClient
    {
        public TcpClient tcp;
        public StreamReader reader;
        public NetworkStream writer;
        public Encoding encoder = Encoding.Default;
        public Action<string> log;
        string ip;

        public string readAndLog()
        {

            string s;
            s = reader.ReadLine();
            log(s);
            return s;
        }

        // to wait for the whole response
        // and log each line
        // returns: the whole string
        public string waitForResponse()
        {
            string s = "";
            string startCode = "";
            try
            {
                s = readAndLog();
                int i = 0;
                for (; s[i] >= '0' && s[i] <= '9'; ++i)
                    startCode += s[i];
                if (s[i] == ' ')
                    goto ret;
                while (true)
                {
                    string line = readAndLog();
                    s += "\n" + line;
                    if (line.StartsWith(startCode) && line[i] == ' ')
                        goto ret;
                }
            }
            catch (System.ObjectDisposedException)
            {
                MessageBox.Show("TCP connection has been closed.");
                tcp.GetStream().Close();
                tcp.Close();
            }
        ret:
            return s;
        }

        public FtpSupportTcpClient(string ip, ushort port, Action<string> log)
        {
            this.ip = ip;
            this.log = log;
            tcp = new TcpClient(ip, port);
            reader = new StreamReader(tcp.GetStream(), encoder);
            writer = tcp.GetStream();
            writer.ReadTimeout = 10000;
            if (!waitForResponse().StartsWith("220"))
                throw new SocketException();
            string s = sendCommand(CommandConstant.CMD_FEAT);
            if (Regex.IsMatch(s, "UTF8\n")) encoder = Encoding.UTF8;
        }

        private void send(string cmd)
        {
            var data = encoder.GetBytes(cmd.ToCharArray());
            writer.Write(data, 0, data.Length);
        }

        // to send message to the server
        // returns: the whole return string
        public string sendCommand(string cmd)
        {
            send(cmd);
            return waitForResponse();
        }

        public void readAllFromCommand(string cmd, Action<string> act)
        {
            var data = encoder.GetBytes(cmd.ToCharArray());
            writer.Write(data, 0, data.Length);
            string s;
            while ((s = reader.ReadLine()) != null)
                act(s);
        }

        // 
        public string login(string username, string password)
        {
            var r = sendCommand("USER " + username + "\r\n");
            if (password == null || password.Equals("")) return r;
            return sendCommand("PASS " + password + "\r\n");
        }

        public TcpClient createPassiveDataChannel()
        {
            var arr = Regex.Split(sendCommand("PASV\r\n"), ",");
            ushort port = (ushort)(
                (Convert.ToInt32(arr[4]) << 8)
                | Convert.ToInt32(Regex.Match(arr[5], @"^\d*").ToString()));
            return new TcpClient(ip, port);
        }

        // act returns whether it's out normally
        public void passiveDataAction(string cmd, Func<Func<string, string>, TcpClient, bool> act, bool needWait)
        {
            TcpClient data = createPassiveDataChannel();
            sendCommand(cmd);
            // wait for all to complete transferation
            if (act(s => sendCommand(s), data) && needWait)
                waitForResponse();
            data.GetStream().Close();
            abor();
        }

        public void closeStreams()
        {
            reader.Close();
            writer.Close();
        }

        public void abor()
        {
            send(CommandConstant.CMD_ABOR);
            while (!waitForResponse().StartsWith("226")) ;
        }

        public void quitThis()
        {
            sendCommand("QUIT\r\n");
        }
    }
}
