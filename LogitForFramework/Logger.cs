using System;
using System.IO;

namespace LogitForFramework
{
    public class Logger
    {
        internal string DirectoryPath { get; set; }
        internal string LogFilePath { get; set; }


        /// <summary>
        /// Default constructor that will put log folder in root directory of application
        /// </summary>
        public Logger()
        {
            DirectoryPath = Directory.GetCurrentDirectory() + "\\Log\\";
            if (!Directory.Exists(DirectoryPath)) { Directory.CreateDirectory(DirectoryPath); }
        }
        /// <summary>
        /// Takes in an object with preset parameters that make Logit functions in specific ways (BETA)
        /// </summary>
        /// <param name="preferences">PreferenceBuilder obj that contains customization parameters
        /// for Logit functions (BETA)</param>
        public Logger(PreferenceBuilder preferences)
        {
            DirectoryPath = preferences._DirectoryPath;
            LogFilePath = DirectoryPath + DateTime.Now.ToShortDateString().Replace("/", "_") + "_log.txt";
            if (!Directory.Exists(DirectoryPath)) { Directory.CreateDirectory(DirectoryPath); }
            if (!File.Exists(LogFilePath)) { File.CreateText(LogFilePath).Close(); }
        }
        /// <summary>
        /// Takes in 1 parameter to determine Log folder location
        /// </summary>
        /// <param name="dirPath">Full path of desired Logit Log folder where logs will be logged</param>
        public Logger(string dirPath)
        {
            DirectoryPath = dirPath;
            LogFilePath = DirectoryPath + DateTime.Now.ToShortDateString().Replace("/", "_") + "_log.txt";
            if (!Directory.Exists(DirectoryPath)) { Directory.CreateDirectory(DirectoryPath); }
            if (!File.Exists(LogFilePath)) { File.CreateText(LogFilePath).Close(); }
        }
        /// <summary>
        /// Opens up stream writer and appends a formatted string to end of file
        /// </summary>
        /// <param name="log">Object created by Log method from LogQueue</param>
        internal void HandleMessage(Log log)
        {
            LogFilePath = DirectoryPath + DateTime.Now.ToShortDateString().Replace("/", "_") + "_log.txt";
            if (!File.Exists(LogFilePath)) { File.CreateText(LogFilePath).Close(); }
            try
            {                
                using (StreamWriter sw = File.AppendText(LogFilePath))
                {
                    sw.WriteLine(log.ToString());
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = File.AppendText(LogFilePath))
                {
                    Log errorLog = new Log(
                        Severity.Critical,
                        "STREAM WRITER CRASHED UNEXPECTADLY. LOGS MAY BE MISSING",
                        DateTime.Now,
                        e);
                    sw.WriteLine(errorLog.ToString());
                }
            }
        }
        /// <summary>
        /// Creates log that handed straight to MessageHandler
        /// </summary>
        /// <param name="level">Enum with multiple levels of severity</param>
        /// <param name="message">Information you want logged at that particular call</param>
        /// <param name="exception">Optional paramter for passing in thrown exceptions</param>
        public void Log(Severity level, string message, Exception exception = null)
        {
            HandleMessage(new Log(
                level,
                message,
                DateTime.Now,
                exception));
        }



        #region Depreceated Control Flow
        ///// <summary>
        ///// Logs passed in message with the *Information* tag. 
        ///// Includes exception parameter
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        ///// <param name="exception">Thrown exception</param>
        //public void Information(string message, Exception exception)
        //{
        //    HandleMessage(new Log(
        //        Severity.Information,
        //        message,
        //        DateTime.Now,
        //        exception));
        //}
        ///// <summary>
        ///// Logs passed in message with the *Information* tag. 
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        //public void Information(string message)
        //{
        //    HandleMessage(new Log(
        //        Severity.Information,
        //        message,
        //        DateTime.Now));
        //}
        ///// <summary>
        ///// Logs passed in message with the *Warning* tag. 
        ///// Includes exception parameter
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        ///// <param name="exception">Thrown exception</param>
        //public void Warning(string message, Exception exception)
        //{
        //    HandleMessage(new Log(
        //        Severity.Warning,
        //        message,
        //        DateTime.Now,
        //        exception));
        //}
        ///// <summary>
        ///// Logs passed in message with the *Warning* tag. 
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        //public void Warning(string message)
        //{
        //    HandleMessage(new Log(
        //        Severity.Warning,
        //        message,
        //        DateTime.Now));
        //}
        ///// <summary>
        ///// Logs passed in message with the *CRITICAL* tag. 
        ///// Includes exception parameter
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        ///// <param name="exception">Thrown exception</param>
        //public void Critical(string message, Exception exception)
        //{
        //    HandleMessage(new Log(
        //        Severity.Critical,
        //        message,
        //        DateTime.Now,
        //        exception));
        //}
        ///// <summary>
        ///// Logs passed in message with the *CRITICAL* tag. 
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        //public void Critical(string message)
        //{
        //    HandleMessage(new Log(
        //        Severity.Critical,
        //        message,
        //        DateTime.Now));
        //}
        ///// <summary>
        ///// Logs passed in message with the *Configuration* tag. 
        ///// Includes exception parameter
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        ///// <param name="exception">Thrown exception</param>
        //public void Configuration(string message, Exception exception)
        //{
        //    HandleMessage(new Log(
        //        Severity.Configuration,
        //        message,
        //        DateTime.Now,
        //        exception));
        //}
        ///// <summary>
        ///// Logs passed in message with the *Configuration* tag. 
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        //public void Configuration(string message)
        //{
        //    HandleMessage(new Log(
        //        Severity.Configuration,
        //        message,
        //        DateTime.Now));
        //}
        ///// <summary>
        ///// Logs passed in message with the *Debug* tag. 
        ///// Includes exception parameter
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        ///// <param name="exception">Thrown exception</param>
        //public void Debug(string message, Exception exception)
        //{
        //    HandleMessage(new Log(
        //        Severity.Debug,
        //        message,
        //        DateTime.Now,
        //        exception));
        //}
        ///// <summary>
        ///// Logs passed in message with the *Debug* tag. 
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        //public void Debug(string message)
        //{
        //    HandleMessage(new Log(
        //        Severity.Debug,
        //        message,
        //        DateTime.Now));
        //}
        ///// <summary>
        ///// Asyncronously logs passed in message with the *Information* tag. 
        ///// Includes exception parameter
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        ///// <param name="exception">Thrown exception</param>
        //public async Task InformationAsync(string message, Exception exception)
        //{
        //    await Task.Run(() => HandleMessage(new Log(
        //        Severity.Information,
        //        message,
        //        DateTime.Now,
        //        exception)));
        //}
        ///// <summary>
        ///// Asyncronously logs passed in message with the *Information* tag. 
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        //public async Task InformationAsync(string message)
        //{
        //    await Task.Run(() => HandleMessage(new Log(
        //        Severity.Information,
        //        message,
        //        DateTime.Now)));
        //}
        ///// <summary>
        ///// Asyncronously logs passed in message with the *Warning* tag. 
        ///// Includes exception parameter
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        ///// <param name="exception">Thrown exception</param>
        //public async Task WarningAsync(string message, Exception exception)
        //{
        //    await Task.Run (() => HandleMessage(new Log(
        //        Severity.Warning,
        //        message,
        //        DateTime.Now,
        //        exception)));
        //}
        ///// <summary>
        ///// Asyncronously logs passed in message with the *Warning* tag. 
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        //public async Task WarningAsync(string message)
        //{
        //    await Task.Run(() => HandleMessage(new Log(
        //        Severity.Warning,
        //        message,
        //        DateTime.Now)));
        //}
        ///// <summary>
        ///// Asyncronously logs passed in message with the *CRITICAL* tag. 
        ///// Includes exception parameter
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        ///// <param name="exception">Thrown exception</param>
        //public async Task CriticalAsync(string message, Exception exception)
        //{
        //    await Task.Run(() => HandleMessage(new Log(
        //        Severity.Critical,
        //        message,
        //        DateTime.Now,
        //        exception)));
        //}
        ///// <summary>
        ///// Asyncronously logs passed in message with the *CRITICAL* tag. 
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        //public async Task CriticalAsync(string message)
        //{
        //    await Task.Run(() => HandleMessage(new Log(
        //        Severity.Critical,
        //        message,
        //        DateTime.Now)));
        //}
        ///// <summary>
        ///// Asyncronously logs passed in message with the *Configuration* tag. 
        ///// Includes exception parameter
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        ///// <param name="exception">Thrown exception</param>
        //public async Task ConfigurationAsync(string message, Exception exception)
        //{
        //    await Task.Run(() => HandleMessage(new Log(
        //        Severity.Configuration,
        //        message,
        //        DateTime.Now,
        //        exception)));
        //}
        ///// <summary>
        ///// Asyncronously logs passed in message with the *Configuration* tag. 
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        //public async Task ConfigurationAsync(string message)
        //{
        //    await Task.Run(() => HandleMessage(new Log(
        //        Severity.Configuration,
        //        message,
        //        DateTime.Now)));
        //}
        ///// <summary>
        ///// Asyncronously logs passed in message with the *Debug* tag. 
        ///// Includes exception parameter
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        ///// <param name="exception">Thrown exception</param>
        //public async Task DebugAsync(string message, Exception exception)
        //{
        //    await Task.Run(() => HandleMessage(new Log(
        //        Severity.Debug,
        //        message,
        //        DateTime.Now,
        //        exception)));
        //}
        ///// <summary>
        ///// Asyncronously logs passed in message with the *Debug* tag. 
        ///// </summary>
        ///// <param name="message">Message to be logged</param>
        //public async Task DebugAsync(string message)
        //{
        //    await Task.Run(() => HandleMessage(new Log(
        //        Severity.Debug,
        //        message,
        //        DateTime.Now)));
        //}
        #endregion


    }
}
