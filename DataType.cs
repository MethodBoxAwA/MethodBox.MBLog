using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodBox.MBLog
{
    public static class DataType
    {
        public enum LogFileType
        {
            TextFile,
            Json,
            DataBase
        }

        public enum LogType
        {
            Information,
            Caution,
            Warning,
            Error
        }

        public struct LogStruct
        {
            public LogStruct(string[] callerInfoStrings, string logInfo, 
                bool print = true, bool save = true)
            {
                this.CallerInfoStrings = callerInfoStrings;
                this.LogInfo = logInfo;
                this.Print = print;
                this.Save = save;
            }

            public string[] CallerInfoStrings;
            public string LogInfo;
            public bool Print;
            public bool Save;
        }
    }
}
