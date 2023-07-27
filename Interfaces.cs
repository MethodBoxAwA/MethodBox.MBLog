using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodBox.MBLog.DataType;

namespace MethodBox.MBLog
{
    /// <summary>
    /// MBLog的公共成员接口类。
    /// </summary>
    public class Interfaces
    {
        /// <summary>
        /// 用于定义Logger数据类型的接口。
        /// </summary>
        public interface ILogger
        {
        }

        /// <summary>
        /// 用于表示含有日志类型和结构体的事件参数的公共继承接口。
        /// </summary>
        public interface IDoubledAttribute
        {        /// <summary>
            /// 表示日志的结构体
            /// </summary>
            public LogStruct EventLogStruct { get; set; }

            /// <summary>
            /// 表示日志的等级
            /// </summary>
            public LogType EventLogType { get; set; }
        }
    }

}
