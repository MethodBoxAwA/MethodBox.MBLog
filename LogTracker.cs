using System.Text.RegularExpressions;
using MethodBox.MBLog.DataType;
using MethodBox.MBLog.Web;
using EventArgs = MethodBox.MBLog.DataType.EventArgs;

namespace MethodBox.MBLog.Logging
{
    /// <summary>
    /// 用于进行日志跟踪的跟踪器类。
    /// </summary>
    public class LogTracker
    {
#pragma warning disable IDE0044
        private TrackType _trackType;
        private object _trackParam;
        private Logger _sender;
#pragma warning restore IDE0044

        /// <summary>
        /// 当指定事件被跟踪器捕获后执行的事件。
        /// </summary>
        public event Logger.DataTrackHandler? OnSpecificEventCaught;

        /// <summary>
        /// 创建一个用于日志跟踪的新实例。
        /// </summary>
        /// <param name="trackType">表示跟踪所使用的方法类型</param>
        /// <param name="additionalParam">表示跟踪所使用的方法参数</param>
        /// <param name="sender">发起调用的主调方，一般传入发起调用的<c>Logger</c>对象本身</param>
        public LogTracker(TrackType trackType, object additionalParam, ref Logger sender)
        {
            _trackType = trackType;
            _trackParam = additionalParam;
            _sender = sender;
        }

        /// <summary>
        /// 开始对指定事件进行追踪和筛选。
        /// </summary>
        /// <example>
        /// 以下示例将捕获所有日志内容中含有“User”的日志，并将日志内容发送至指定网络服务器。
        /// <code>
        /// // 准备相应的事件对象
        /// // 该事件对象应被公开供别处产生日志
        /// Logger loggerInstance = (Logger)Logger.GetLoggerInstance(
        /// LogFileType.TextFile,@"D:\Log\Log.txt");
        /// // 声明事件追踪器对象
        /// LogTracker tracker = new LogTracker(TrackType.KeyWord, "User", ref loggerInstance);
        /// // 订阅有关事件并开始追踪
        /// tracker.OnSpecificEventCaught += (_, e) =>
        /// {
        ///     // 建立网络实例化对象
        ///     WebRequest WebSender = new WebRequest(new Uri(@"https:icalloptions.top/data"));
        ///     // 发送信息
        ///     WebSender.SendLogString("LogContent", e.EventLogStruct.LogInfo);
        /// };
        /// </code>
        /// </example>
        public void StartTrack()
        {
            _sender.OnCatchSpecificEvent += TrackStatement;
        }

        private void TrackStatement(object s, EventArgs.LogTrackEventArgs e)
        {
            // Match specific pattern
            // ReSharper disable RedundantJumpStatement
            switch (_trackType)
            {
                case TrackType.Regex:
                    int count = (((Regex)_trackParam).Matches(e.EventLogStruct.LogInfo)).Count;
                    if (count !=0) goto AddInvoke;
                    break;
                case TrackType.KeyWord:
                    count = (Regex.Matches(e.EventLogStruct.LogInfo, (string)_trackParam)).Count;
                    if (count !=0) goto AddInvoke;
                    break;
                case TrackType.Call:
                    count = (from specificPattern in e.EventLogStruct.CallerInfoStrings
                             where specificPattern == (string)_trackParam
                             select specificPattern).Count();
                    if (count !=0) goto AddInvoke;
                    break;
                case TrackType.Level:
                    if (e.EventLogType == (LogType)_trackParam) goto AddInvoke;
                    break;
            }
        AddInvoke:
            OnSpecificEventCaught?.Invoke(s, e);
        }

        /// <summary>
        /// 终止对指定事件进行追踪和筛选。
        /// </summary>
        public void EndTrack()
        {
            _sender.OnCatchSpecificEvent -= TrackStatement;
        }
    }
}
