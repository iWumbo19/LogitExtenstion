using System;
using System.Text;

namespace Logit
{
    internal class Log
    {
        public SeverityLevel SeverityLevel { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public Exception Exception { get; set; }

        public Log(SeverityLevel level, string message, DateTime date, Exception exception)
        {
            this.Exception = exception;
            this.SeverityLevel = level;
            this.Message = message;
            this.Time = date;
        }

        public Log(SeverityLevel level, string message, DateTime date)
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
                case SeverityLevel.Debug: sb.Append("*Debug*,"); break;
                case SeverityLevel.Information: sb.Append("*Information*,"); break;
                case SeverityLevel.Configuration: sb.Append("*Configuration*,"); break;
                case SeverityLevel.Warning: sb.Append("*Warning*,"); break;
                case SeverityLevel.Critical: sb.Append("*CRITICAL*,"); break;
            }

            sb.Append(DateTime.Now.ToString() + ",");
            sb.Append(Message);
            if (Exception != null) { sb.Append(",EXCEPTION THROWN: " + Exception.Message.ToString()); }

            return sb.ToString();
        }

    }
}
