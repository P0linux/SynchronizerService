using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronizerService
{
    class Settings
    {
        string line;
        string sourceFolder;
        string targetFolder;
        string wildcard;
        string interval;

        public string Wildcard
        {
            get
            {
                return wildcard;
            }
            set
            {
                wildcard = value;
            }
        }

        public string SourceFolder
        {
            get
            {
                return sourceFolder;
            }
            set
            {
                sourceFolder = value;
            }
        }

        public string TargetFolder
        {
            get
            {
                return targetFolder;
            }
            set
            {
                targetFolder = value;
            }
        }

        public string Interval
        {
            get
            {
                return interval;
            }
            set
            {
                interval = value;
            }
        }

        public void getSettings()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\SynchronizerService\\settings.cfg";
            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("Source folder:"))
                    {
                        sourceFolder = line.Remove(0, line.IndexOf(":") + 1);
                        Debug.WriteLine(sourceFolder);
                    }
                    else if (line.Contains("Target folder:"))
                    {
                        targetFolder = line.Remove(0, line.IndexOf(":") + 1);
                        Debug.WriteLine(targetFolder);
                    }
                    else if (line.Contains("Wildcard:"))
                    {
                        wildcard = line.Remove(0, line.IndexOf(":") + 1);
                        Debug.WriteLine(wildcard);
                    }
                    else if (line.Contains("Interval:"))
                    {
                        interval = line.Remove(0, line.IndexOf(":") + 1);
                        Debug.WriteLine(interval);
                    }
                }
            }
        }
    }
}
