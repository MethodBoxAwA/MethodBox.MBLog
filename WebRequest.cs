using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MethodBox.MBLog.Web
{
    /// <summary>
    /// 表示向网络服务器发送日志或从网络服务器接收日志的执行类。
    /// </summary>
    public class WebRequest
    {
        private Uri _sendLogUrl;
        /// <summary>
        /// 用于定义对于异步化字符串发送方法完成事件的委托签名。
        /// </summary>
        /// <param name="sender">调用该委托定义事件的主调方</param>
        /// <param name="e">返回的结果所对应的事件参数</param>
        public delegate void SendStringFinishedEventHandler
            (object sender,DataType.EventArgs.SendStringFinishedEventArgs e);

        /// <summary>
        /// 表示于异步化字符串发送方法完成后引发的事件。
        /// </summary>
        public event SendStringFinishedEventHandler? OnDataSendFinished;

        /// <summary>
        /// 构造一个日志网络服务的实例化对象。
        /// </summary>
        /// <param name="sendLogUrl">将日志发送的Uri地址</param>
        public WebRequest(Uri sendLogUrl)
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
        /// WebRequest logSender = new WebRequest(new Uri("https:icalloptions.top/data"));
        /// logSender.SendLogString("log",sendLogString);
        /// </code>
        /// <exception cref="ArgumentNullException">（仅限于.Net6.0及以上SDK版本）当传入的参数为<c>null</c>时引发此异常。</exception>
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

        /// <summary>
        /// 以异步<c>Post</c>模式发送指定的日志内容。
        /// </summary>
        /// <param name="key">发起请求的参数名</param>
        /// <param name="content">发起请求的参数内容</param>
        /// <example>
        /// 以下示例将日志内容异步上传至服务器，并以日志的形式通知上传结果。
        /// <code>
        /// // 构建日志字符串
        /// Interfaces.ILogger loggerInstance =
        /// MBLog.Logger.GetLoggerInstance(DataType.LogFileType.TextFile,@"D:\Log");
        /// Logger Logger = (MBLog.Logger)loggerInstance;
        /// string logResult =
        /// Logger.BuildLogString(DataType.LogType.Warning, new DataType.LogStruct(
        ///     new[] { "Console" }, "nm$l", true, true
        /// ));
        /// // 建立网络实例化对象
        /// WebRequest WebSender = new WebRequest(new Uri(@"https:icalloptions.top/data"));
        /// // 订阅相关事件
        /// WebSender.OnDataSendFinished += (s, e) =>
        /// {
        /// #if NET6_0_OR_GREATER
        ///     ArgumentNullException.ThrowIfNull(e.Response);
        /// #else
        ///     if (e.Response is null)
        ///     {
        ///         throw new ArgumentException("服务器未返回");
        ///     }
        /// #endif
        ///     DataType.LogStruct webLogStruct = new DataType.LogStruct();
        ///     webLogStruct.LogInfo = e.Response;
        ///     webLogStruct.CallerInfoStrings = new[] { "Console", "WebRequest" };
        ///     webLogStruct.Print = true;
        ///     webLogStruct.Save = true;
        ///     // 作为演示，假设成功返回OK，失败返回FAILED
        ///     DataType.LogType logType = e.Response switch
        ///     {
        ///         "OK" => DataType.LogType.Information,
        ///         "FAILED" => DataType.LogType.Warning,
        ///         _ => throw new NotImplementedException("未实现对该返回值的处理！")
        ///     };
        ///     Logger.Log(logType, webLogStruct);
        /// };
        /// // 发送信息
        /// WebSender.SendLogStringAsync("LogContent",logResult);
        /// </code>
        /// </example>
        /// <exception cref="ArgumentNullException">（仅限于.Net6.0及以上SDK版本）当传入的参数为<c>null</c>时引发此异常。</exception>
        public async void SendLogStringAsync(string key, string content)
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(key);
            ArgumentNullException.ThrowIfNull(content);
#endif
            var values = new[]
            {
                new KeyValuePair<string, string>(key, content)

            };
            using FormUrlEncodedContent multipartFormDataContent = new FormUrlEncodedContent(values);
            HttpResponseMessage httpResponse = await
                new HttpClient().PostAsync(
                    _sendLogUrl, 
                    multipartFormDataContent);
            // Send to event
            if (httpResponse.IsSuccessStatusCode)
            {
                string result = await httpResponse.Content.ReadAsStringAsync();
                DataType.EventArgs.SendStringFinishedEventArgs e = new()
                {
                    Response = result
                };
                OnDataSendFinished?.Invoke(this, e);
            }
        }
            

    }
}
