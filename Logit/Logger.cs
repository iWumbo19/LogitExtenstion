using System;
using System.IO;

namespace Logit
{
    public class Logger
    {
        public string DirectoryPath { get; set; }
        public string LogFilePath { get; set; }

        public Logger()
        {
            DirectoryPath = Directory.GetCurrentDirectory() + "\\Log\\";
            LogFilePath = DirectoryPath + DateTime.Now.ToShortDateString().Replace("/", "_") + "_log.txt";
            if (!Directory.Exists(DirectoryPath)) { Directory.CreateDirectory(DirectoryPath); }
            if (!File.Exists(LogFilePath)) { File.CreateText(LogFilePath).Close(); }
        }

        private void LogMessage(Log log)
        {
            using (StreamWriter sw = File.AppendText(LogFilePath)) { sw.WriteLine(log.ToString()); }            
        }
        public void Information(string message, Exception exception)
        {
            LogMessage(new Log(
                SeverityLevel.Information,
                message,
                DateTime.Now,
                exception));
        }
        public void Information(string message)
        {
            LogMessage(new Log(
                SeverityLevel.Information,
                message,
                DateTime.Now));
        }
        public void Warning(string message, Exception exception)
        {
            LogMessage(new Log(
                SeverityLevel.Warning,
                message,
                DateTime.Now,
                exception));
        }
        public void Warning(string message)
        {
            LogMessage(new Log(
                SeverityLevel.Warning,
                message,
                DateTime.Now));
        }
        public void Critical(string message, Exception exception)
        {
            LogMessage(new Log(
                SeverityLevel.Critical,
                message,
                DateTime.Now,
                exception));
        }
        public void Critical(string message)
        {
            LogMessage(new Log(
                SeverityLevel.Critical,
                message,
                DateTime.Now));
        }
        public void Configuration(string message, Exception exception)
        {
            LogMessage(new Log(
                SeverityLevel.Configuration,
                message,
                DateTime.Now,
                exception));
        }
        public void Configuration(string message)
        {
            LogMessage(new Log(
                SeverityLevel.Configuration,
                message,
                DateTime.Now));
        }
        public void Debug(string message, Exception exception)
        {
            LogMessage(new Log(
                SeverityLevel.Debug,
                message,
                DateTime.Now,
                exception));
        }
        public void Debug(string message)
        {
            LogMessage(new Log(
                SeverityLevel.Debug,
                message,
                DateTime.Now));
        }
    }
}
