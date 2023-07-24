namespace MethodBox.MBLog
{
    /// <summary>
    /// 用于表示MBLogger运行时中的公共数据类型。
    /// </summary>
    public static class DataType
    {
        /// <summary>
        /// 用于表示日志存储或来自的文件类型。
        /// </summary>
        public enum LogFileType
        {
            /// <summary>
            /// 表示文本文件（*.txt）
            /// </summary>
            TextFile,
            /// <summary>
            /// 表示Json文件（*.json）
            /// </summary>
            Json,
            /// <summary>
            /// 表示数据库文件（*.db）
            /// </summary>
            DataBase
        }

        /// <summary>
        /// 用于表示日志的等级。
        /// </summary>
        public enum LogType
        {
            /// <summary>
            /// 表示日志等级为信息
            /// </summary>
            Information,
            /// <summary>
            /// 表示日志等级为提示
            /// </summary>
            Caution,
            /// <summary>
            /// 表示日志等级为警告
            /// </summary>
            Warning,
            /// <summary>
            /// 表示日志等级为错误
            /// </summary>
            Error
        }

        /// <summary>
        /// 用于表示日志类型的结构体。
        /// </summary>
        public struct LogStruct
        {
            /// <summary>
            /// 提供含有默认值的公开构造函数。
            /// </summary>
            /// <param name="callerInfoStrings">对日志的调起者</param>
            /// <param name="logInfo">日志内容</param>
            /// <param name="print">是否打印到控制台</param>
            /// <param name="save">是否保存到文件</param>
            /// <see cref="LogType"/>
            public LogStruct(string[] callerInfoStrings, string logInfo, 
                bool print = true, bool save = true)
            {
                this.CallerInfoStrings = callerInfoStrings;
                this.LogInfo = logInfo;
                this.Print = print;
                this.Save = save;
            }

            /// <summary>
            /// 表示对日志的调起者
            /// </summary>
            public string[] CallerInfoStrings;
            /// <summary>
            /// 表示日志的具体内容
            /// </summary>
            public string LogInfo;
            /// <summary>
            /// 表示是否将日志内容打印至控制台上
            /// </summary>
            public bool Print;
            /// <summary>
            /// 表示是否将日志内容保存至文件
            /// </summary>
            public bool Save;
        }

        /// <summary>
        /// 表示用于序列化/反序列化的<c>Log</c>实体类。
        /// </summary>
        public class Log
        {
            /// <summary>
            /// 表示日志的内容
            /// </summary>
            public string? LogContent { get;set; }

            /// <summary>
            /// 表示日志的等级
            /// </summary>
            public string? LogLevel { get; set; }

            /// <summary>
            /// 表示日志的生成时间
            /// </summary>
            public string? DateTime { get; set; }
        }

        /// <summary>
        /// 用于表示日志系统的使用事件的事件参数。
        /// </summary>
        public class EventArgs
        {
            /// <summary>
            /// 用于表示当日志字符串发送完毕回调事件的事件参数。
            /// </summary>
            public class SendStringFinishedEventArgs:System.EventArgs
            {
                /// <summary>
                /// 表示发送完毕后服务器的响应。
                /// </summary>
                public string? Response { get; set; }
            }
        }
    }
}
