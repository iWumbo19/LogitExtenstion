using System;
using System.Collections.Generic;
using System.Text;

namespace Logit
{
    public class PreferenceBuilder
    {
        public string _DirectoryPath { get; set; }

        public PreferenceBuilder(string DirectoryPath)
        {
            this._DirectoryPath = DirectoryPath;
        }
    }
}
