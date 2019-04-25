using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketFTPClient
{
    class LanguageConstant
    {
        public const string CONNECT_STRING = "连接";
        public const string DISCONNECT_STRING = "断开";
        public const string UPLOAD_STRING = "上传";
        public const string DOWNLOAD_STRING = "下载";
        public const string NO_TASK_STRING = "无任务";
        public const string PAUSE_STRING = "暂停";
        public const string CONTINUE_STRING = "继续";
        public const string ENTER_STRING = "浏览";
        public const string DOWNLOADING_FMT = "正在下载：{0}";
        public const string PAUSE_DOWNLOAD_FMT = "暂停下载：{0}";
        public const string UPLOADING_FMT = "正在上传：{0}";
        public const string PAUSE_UPLOAD_FMT = "暂停下载：{0}";
        //public const string RUNNING_STRING = "正在运行";
        public const string FINISHED_STRING = "已完成";
        //public const string PAUSE_STRING = "已暂停";
        public const string INVALID_IP_ERROR = "IP 地址格式不正确";
        public const string ACCESS_DENY_ERROR = "目标服务器拒绝访问";
        public const string CANNOT_OPEN_FILE = "本地文件拒绝访问";
        public const string PAUSE_NOT_SUPPORT_ERROR = "目标服务器不支持暂停续传";
        public const string UPLOAD_NOT_SUPPORT_ERROR = "上传失败（原因猜测：目标服务器不支持上传或目标服务器有同名文件）";
        public const string DOWNLOAD_NOT_SUPPORT_ERROR = "下载失败（原因猜测：目标服务器不支持下载）";
        public const string PASSWORD_ERROR = "密码错误：用户名密码不匹配";
        public const string CANNOT_CLOSE = "还有部分在执行，暂不能停止";
        public const string CANNOT_CHANGE_DIRECTORY = "不能改变路径（原因可能是服务器端不支持非ASCII的字符串读取）";

        public const string SHOW_LOG = "LOG ↓";
        public const string HIDE_LOG = "LOG ↑";

        /* evan_choo: this const string is added to show a connection error*/
        public const string CONNECTION_ERROR = "连接超时或者出错";
    }
}
