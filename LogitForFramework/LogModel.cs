using System;
using System.Text;

namespace LogitForFramework
{
    internal class LogModel
    {
        public Severity SeverityLevel { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public Exception Exception { get; set; }

        public LogModel(Severity level, string message, DateTime date, Exception exception)
        {
            this.Exception = exception;
            this.SeverityLevel = level;
            this.Message = message;
            this.Time = date;
        }

        public LogModel(Severity level, string message, DateTime date)
        {
            this.Exception = null;
            this.SeverityLevel = level;
            this.Time = date;
            this.Message = message;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            switch (SeverityLevel)
            {
                case Severity.Debug: sb.Append("*Debug*" + Log.LogDelimiter); break;
                case Severity.Information: sb.Append("*Information*" + Log.LogDelimiter); break;
                case Severity.Configuration: sb.Append("*Configuration*" + Log.LogDelimiter); break;
                case Severity.Warning: sb.Append("*Warning*" + Log.LogDelimiter); break;
                case Severity.Critical: sb.Append("*CRITICAL*" + Log.LogDelimiter); break;
            }

            sb.Append(DateTime.Now.ToString() + Log.LogDelimiter);
            sb.Append(Message);
            if (Exception != null) { sb.Append(Log.LogDelimiter + "EXCEPTION THROWN: " + Exception.Message.ToString()); }

            return sb.ToString();
        }

    }
}
