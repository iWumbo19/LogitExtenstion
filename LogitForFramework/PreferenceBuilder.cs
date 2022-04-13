using System;
using System.Collections.Generic;
using System.Text;

namespace LogitForFramework
{
    public class PreferenceBuilder
    {
        public string directoryPath { get; set; }
        public char logDelimiter { get; set; }

        public PreferenceBuilder(string directoryPath = " ", char logDelimiter = ',')
        {
            if (directoryPath == " ") { Utils.SetDirectoryPath(); }
            else { this.directoryPath = directoryPath; }

            this.logDelimiter = logDelimiter;
        }
    }
}
