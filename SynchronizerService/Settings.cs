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
        string messageShow;

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

        public string MessageShow
        {
            get
            {
                return messageShow;
            }
            set
            {
                messageShow = value;
            }
        }

        public void getSettings()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\SynchronizerService\\settings.cfg";
            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string settingName = line.Remove(line.IndexOf(":"));
                    string setting = line.Remove(0, line.IndexOf(":") + 1);
                    switch (settingName)
                    {
                        case ("Source folder"):
                            sourceFolder = setting;
                            break;
                        case ("Target folder"):
                            targetFolder = setting;
                            break;
                        case ("Wildcard"):
                            wildcard = setting;
                            break;
                        case ("Interval"):
                            interval = setting;
                            break;
                        case ("Message"):
                            messageShow = setting;
                            break;
                    }
                }
                //while ((line = reader.ReadLine()) != null)
                //{
                //    if (line.Contains("Source folder:"))
                //    {
                //        sourceFolder = line.Remove(0, line.IndexOf(":") + 1);
                //        Debug.WriteLine(sourceFolder);
                //    }
                //    else if (line.Contains("Target folder:"))
                //    {
                //        targetFolder = line.Remove(0, line.IndexOf(":") + 1);
                //        Debug.WriteLine(targetFolder);
                //    }
                //    else if (line.Contains("Wildcard:"))
                //    {
                //        wildcard = line.Remove(0, line.IndexOf(":") + 1);
                //        Debug.WriteLine(wildcard);
                //    }
                //    else if (line.Contains("Interval:"))
                //    {
                //        interval = line.Remove(0, line.IndexOf(":") + 1);
                //        Debug.WriteLine(interval);
                //    }
                //}
            }
        }
    }
}
