using System;
using System.IO;

namespace Lec04LibN
{
    public partial class Logger : ILogger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();

        private readonly string _logFileName;
        private readonly StreamWriter _writer;

        private readonly Stack<string> _contextStack = new();
        private int _logNumber = 1;

        private Logger()
        {
            _logFileName = Path.Combine(Directory.GetCurrentDirectory(),
                $"LOG{DateTime.Now:yyyyMMdd-HH-mm-ss}.txt");
            _writer = new StreamWriter(_logFileName) { AutoFlush = true };
            WriteLog("INIT", ""); 
        }
        public static ILogger create()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new Logger();
                }
            }
            return _instance;
        }

        public void start(string title)
        {
            _contextStack.Push(title);
            WriteLog("STRT", GetCurrentContext());
        }

        public void log(string message)
        {
            WriteLog("INFO", $"{GetCurrentContext()} {message}");
        }

        public void stop()
        {
            if (_contextStack.Count > 0)
            {
                _contextStack.Pop();
                WriteLog("STOP", GetCurrentContext());
            }
            else
            {
                WriteLog("WARN", "Попытка завершить несуществующее пространство!");
            }
        }

        private void WriteLog(string type, string message)
        {
            string timestamp = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            string logEntry = $"{_logNumber:D6}-{timestamp}-{type} {message}";
            _writer.WriteLine(logEntry);
            _logNumber++;
        }

        private string GetCurrentContext()
        {
            return string.Join(":", _contextStack.ToArray().Reverse()) + (_contextStack.Count > 0 ? ":" : "");
        }
    }
}
