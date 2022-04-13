using System;
using System.IO;

namespace LogitForFramework
{
    public static class Log
    {
        internal static string DirectoryPath { get; set; }
        internal static string LogFilePath { get; set; }
        internal static char LogDelimiter { get; set; } = ',';

        /// <summary>
        /// Allows for updateing preferences with passed in object
        /// </summary>
        /// <param name="prefs">Object that contains</param>
        public static void SetPreferences(PreferenceBuilder prefs)
        {
            DirectoryPath = prefs.directoryPath;
            LogDelimiter = prefs.logDelimiter;
        }
        /// <summary>
        /// Allows you to set the path of the directory where the Log directory will be stored.
        /// If none is specified, the root folder of the application will be default
        /// </summary>
        /// <param name="folderPath">Full path of the desired Log folder</param>
        public static void ChangeDirectory(string folderPath)
        {
            Utils.SetDirectoryPath(folderPath);
        }
        /// <summary>
        /// Method that is responsible for opening, writing, and closing log file
        /// </summary>
        /// <param name="log"></param>
        internal static void HandleMessage(LogModel log)
        {
            Utils.SetFilePath();
            using (StreamWriter sw = File.AppendText(LogFilePath)) { sw.WriteLine(log.ToString()); }
        }
        /// <summary>
        /// Appends log with passed in parameters
        /// </summary>
        /// <param name="level">Severity enum to specify level of severity</param>
        /// <param name="message">Desired message to be associated with log</param>
        /// <param name="exception">Optional parameter for logging specific exception messages</param>
        public static void Append(Severity level, string message, Exception exception = null)
        {
            HandleMessage(new LogModel(
                level,
                message,
                DateTime.Now,
                exception));
        }

    }
}
