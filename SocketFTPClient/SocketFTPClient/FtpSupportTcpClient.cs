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
        public Action<string> log;
        string ip;

        public string waitForResponse()
        {
            string s = "";
            try
            {
                s = reader.ReadLine();
            }
            catch (System.ObjectDisposedException)
            {
                MessageBox.Show("TCP connection has been closed.");
                tcp.GetStream().Close();
                tcp.Close();
            }
            log(s);
            return s;
        }

        public FtpSupportTcpClient(string ip, ushort port, Action<string> log)
        {
            this.ip = ip;
            this.log = log;
            tcp = new TcpClient(ip, port);
            reader = new StreamReader(tcp.GetStream(), Encoding.Default);
            writer = tcp.GetStream();
            writer.ReadTimeout = 10000;
            if (waitForResponse().Substring(0, 3) != "220") throw new SocketException();
        }

        public string sendCommand(string cmd)
        {
            var data = Encoding.ASCII.GetBytes(cmd.ToCharArray());
            writer.Write(data, 0, data.Length);
            return waitForResponse();
        }

        public void readAllFromCommand(string cmd, Action<string> act)
        {
            var data = Encoding.ASCII.GetBytes(cmd.ToCharArray());
            writer.Write(data, 0, data.Length);
            string s;
            while ((s = reader.ReadLine()) != null)
                act(s);
        }

        public string login(string username, string password)
        {
            sendCommand("USER " + username + "\r\n");
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

        public void passiveDataAction(string cmd, Action<Func<string, string>, TcpClient> act)
        {
            TcpClient data = createPassiveDataChannel();
            sendCommand(cmd);
            act(s => sendCommand(s), data);
            // wait for all to complete transferation
            waitForResponse();
            data.GetStream().Close();
            sendCommand("ABOR\r\n");
        }

        public void closeStreams()
        {
            reader.Close();
            writer.Close();
        }

        public void quitThis()
        {
            sendCommand("QUIT\r\n");
        }
    }
}
