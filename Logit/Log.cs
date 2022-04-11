using System;
using System.Text;

namespace Logit
{
    internal class Log
    {
        public Severity SeverityLevel { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public Exception Exception { get; set; }

        public Log(Severity level, string message, DateTime date, Exception exception)
        {
            this.Exception = exception;
            this.SeverityLevel = level;
            this.Message = message;
            this.Time = date;
        }

        public Log(Severity level, string message, DateTime date)
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
                case Severity.Debug: sb.Append("*Debug*,"); break;
                case Severity.Information: sb.Append("*Information*,"); break;
                case Severity.Configuration: sb.Append("*Configuration*,"); break;
                case Severity.Warning: sb.Append("*Warning*,"); break;
                case Severity.Critical: sb.Append("*CRITICAL*,"); break;
            }

            sb.Append(DateTime.Now.ToString() + ",");
            sb.Append(Message);
            if (Exception != null) { sb.Append(",EXCEPTION THROWN: " + Exception.Message.ToString()); }

            return sb.ToString();
        }

    }
}
