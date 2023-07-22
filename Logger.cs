using System.Text;
using MethodBox.MBLog.Interfaces;
using static MethodBox.MBLog.DataType;

namespace MethodBox.MBLog
{
    public class Logger:ILogger
    {
        private static ILogger? _logger = null;
        private static readonly object ThreadLocker = new();
        private string _logFileName;
        private DataType.LogFileType _logFileType;
        private StringBuilder _dataBuffer;
        
        private Logger(DataType.LogFileType logFileType,string logFileName)
        {
            this._logFileName = logFileName;
            this._logFileType = logFileType;
        }

        /// <summary>
        /// Return singleton pattern of instance
        /// </summary>
        /// <returns>Assigned Logger instance</returns>
        public static ILogger GetLoggerInstance(DataType.LogFileType logFileType, string logFileName)
        {
            if (_logger is null)
            {
                lock (ThreadLocker)
                {
                    if (_logger is null)
                    {
                        _logger = new Logger(logFileType,logFileName);
                        return _logger;
                    }

                }
            }
            return _logger;
        }

        public void Log(LogType logType,LogStruct logStruct)
        {
            // Change console font color
            switch (logType)
            {
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogType.Caution:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case LogType.Information:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }

            // Weight：(2,1)
            // Get status in order to switch what
            int statusType = (logStruct.Print,logStruct.Save) switch
            {0
                (true,true) => 3,
                (true,false) => 2,
                (false,true) => 1,
                (false,false) => 0
            };

            // Get content which want to writing
            string logTypeTrivia = GetTypeString(logType);
            
            // Work
            switch (statusType)
            {
                case 0:
                    return;
                case 1:
                    WriteToFile(BuildLogString(logStruct.LogInfo));

            }
        }

        /// <summary>
        /// Convert LogType to System.String
        /// </summary>
        /// <param name="_">LogType instance</param>
        /// <returns>string result</returns>
        /// <exception cref="NotImplementedException">If an incorrect LogType enumeration value is
        /// passed in, this exception will be thrown</exception>
        private string GetTypeString(LogType _)
        {
            return _ switch
            {
                LogType.Error => "Error",
                LogType.Warning => "Warning",
                LogType.Caution => "Caution",
                LogType.Information => "Information",
                _ => throw new NotImplementedException("This type is not implemented now")
            };
        }

        /// <summary>
        /// Write specific content to file
        /// </summary>
        /// <param name="content">Content which want to write to file</param>
        private void WriteToFile(string content)
        {
            _dataBuffer.AppendLine(content);
        }

        /// <summary>
        /// Write buffer to file and clear the buffer
        /// </summary>
        private void FlushBuffer()
        {
            using FileStream fileStream = 
                new(_logFileName,FileMode.Append);
            // Write to specific file
            byte[] buffer = Encoding.Default.GetBytes(
                _dataBuffer.ToString()); 
            fileStream.Write(buffer, 0, buffer.Length);
            // Clear data buffer
            _dataBuffer.Clear();
        }

        /// <summary>
        /// Print specific content to console and reset the color
        /// </summary>
        /// <param name="content"></param>
        private void Print(string content)
        {
            Console.WriteLine(content);
            Console.ResetColor();
        }

        /// <summary>
        /// Using specific format to format log string
        /// </summary>
        /// <param name="logStruct">Input log struct</param>
        /// <returns></returns>
        private string BuildLogString(LogStruct logStruct)
        {
            // Init fields
            string[] callerInfoStrings = logStruct.CallerInfoStrings;
            string logInfo = logStruct.LogInfo;
            StringBuilder logBuilder = new();
            // Using specific format to format log string
            foreach (var callerInfoString in callerInfoStrings)
            {
                logBuilder.Append($@"[{callerInfoString}]");
            }
            logBuilder.Append(logInfo);
            // Return formatted string result
            return logBuilder.ToString();
        }
    }
}