using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketFTPClient
{
    class CommandConstant
    {
        public const string CRLF = "\r\n";
        // cmd list
        public const string CMD_LIST = "LIST" + CRLF;
        public const string CMD_PASV = "PASV" + CRLF;
        public const string CMD_ABOR = "ABOR" + CRLF;
        public const string CMD_QUIT = "QUIT" + CRLF;
        public const string CMD_FEAT = "FEAT" + CRLF;
        // cmd format list
        public const string CMD_FMT_USRNAME = "USER {0}" + CRLF;
        public const string CMD_FMT_PASSWORD = "PASS {0}" + CRLF;
        public const string CMD_FMT_UPLOAD = "STOR {0}" + CRLF;
        public const string CMD_FMT_DOWNLOAD = "RETR {0}" + CRLF;
        public const string CMD_FMT_BREAKPOINT = "REST {0}" + CRLF;
        public const string CMD_FMT_CD = "CWD {0}" + CRLF;
    }
}
