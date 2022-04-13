using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LogitForFramework
{
    internal static class Utils
    {
        /// <summary>
        /// Creates updated filepath string and checks to make sure directory and log file exist
        /// </summary>
        internal static void SetFilePath()
        {
            if (Log.DirectoryPath == null) { Utils.SetDirectoryPath(); }
            Log.LogFilePath = Log.DirectoryPath + DateTime.Now.ToShortDateString().Replace("/", "_") + "_log.txt";
            if (!File.Exists(Log.LogFilePath)) { File.CreateText(Log.LogFilePath).Close(); }
        }
        /// <summary>
        /// Creates directory path from passed in string. Creates directory if there isn't one
        /// </summary>
        /// <param name="dirPath">Full path of desired directory</param>
        internal static void SetDirectoryPath(string dirPath)
        {
            Log.DirectoryPath = dirPath;
            if (!Directory.Exists(Log.DirectoryPath)) { Directory.CreateDirectory(Log.DirectoryPath); }
        }
        /// <summary>
        /// Creates directory path from default value. Creates directory if there isn't one
        /// </summary>
        internal static void SetDirectoryPath()
        {
            Log.DirectoryPath = Directory.GetCurrentDirectory() + "\\Log\\";
            if (!Directory.Exists(Log.DirectoryPath)) { Directory.CreateDirectory(Log.DirectoryPath); }
        }
    }
}
