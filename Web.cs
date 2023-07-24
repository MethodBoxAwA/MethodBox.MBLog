using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MethodBox.MBLog
{
    /// <summary>
    /// 表示向网络服务器发送日志或从网络服务器接收日志的执行类。
    /// </summary>
    public class Web
    {
        private Uri _sendLogUrl;

        /// <summary>
        /// 用于定义对于异步化字符串发送方法完成事件的委托签名
        /// </summary>
        /// <returns></returns>
        public delegate string SendStringFinishedEventHandler();

        /// <summary>
        /// 构造一个日志网络服务的实例化对象。
        /// </summary>
        /// <param name="sendLogUrl">将日志发送的Uri地址</param>
        public Web(Uri sendLogUrl)
        {
            this._sendLogUrl = sendLogUrl;
        }

        /// <summary>
        /// 以<c>Post</c>模式发送指定的日志内容。
        /// </summary>
        /// <param name="key">发起请求的参数名</param>
        /// <param name="content">发起请求的参数内容</param>
        /// <example>
        /// 以下示例将生成一条等级为Warning的日志并发送到服务器。
        /// <code>
        /// Interfaces.ILogger loggerInstance = Logger.GetLoggerInstance
        /// (DataType.LogFileType.TextFile, @"D:\Log\Log.txt");
        /// Logger logger = (Logger)loggerInstance;
        /// DataType.LogStruct logStruct = new DataType.LogStruct();
        /// logStruct.LogInfo = "用户删除备份数据";
        /// logStruct.CallerInfoStrings = new[] { "Console", "Server" };
        /// logStruct.Print = true;
        /// logStruct.Save = true;
        /// string sendLogString = logger.BuildLogString(DataType.LogType.Warning,logStruct);
        /// Web logSender = new Web(new Uri("https:icalloptions.top/data"));
        /// logSender.SendLogString("log",sendLogString);
        /// </code>
        /// <exception cref="ArgumentNullException">当传入的参数为<c>null</c>时引发此异常。</exception>
        /// <returns>服务器的响应字符串</returns>
        /// </example>
        public string SendLogString(string key, string content)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(key);
            ArgumentNullException.ThrowIfNull(content);
#endif
            Dictionary<string, string> postDictionary = new Dictionary<string, string>
                {
                    { key, content }
                };
            string response = WebHelper.Post(_sendLogUrl.ToString(), postDictionary);
            return response;
        }

    }
}
