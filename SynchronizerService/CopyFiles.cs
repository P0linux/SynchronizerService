using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;


namespace SynchronizerService
{
    class CopyFiles
    {
        Settings settings;
        Massage message;
        string timestamp;
        string finalTargetFolder;
        string[] dirs;
        string[] files;

        private void ClearDirectory(string folder)
        {
            foreach (string file in Directory.GetFiles(folder))
                File.Delete(file);

            foreach (string file in Directory.GetDirectories(folder))
                Directory.Delete(file, true);
        }

        public void CopyAllFiles(string sourceFolder, string targetFolder, string wildcard)
        {
            timestamp = DateTime.Now.ToString();
            finalTargetFolder = targetFolder + String.Format("\\Backup{0}", timestamp.Replace(":", ""));
            Directory.CreateDirectory(finalTargetFolder);
            ClearDirectory(finalTargetFolder);
            dirs = Directory.GetDirectories(sourceFolder, "*", SearchOption.AllDirectories);
            foreach (string dir in dirs)
            {
                try
                {
                    Directory.CreateDirectory(dir.Replace(sourceFolder, finalTargetFolder));
                }
                catch (DirectoryNotFoundException e)
                {
                    
                }
            }

            files = Directory.GetFiles(sourceFolder, wildcard, SearchOption.AllDirectories);
            foreach (string file in files)
            {
                try
                {
                    File.Copy(file, file.Replace(sourceFolder, finalTargetFolder), true);
                }
                catch (FileNotFoundException e)
                {
                    
                }
            }

        }

        public void FullCopy()
        {
            settings = new Settings();
            message = new Massage();
            settings.getSettings();
            Timer timer = new Timer();
            timer.Interval = GetInterval();
            timer.Elapsed += OnTimedEvent;
            timer.Start();
        }

        private int GetInterval()
        {
            return Convert.ToInt32(settings.Interval) * 1000;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            switch (settings.MessageShow)
            {
                case ("show"):
                    CopyAllFiles(settings.SourceFolder, settings.TargetFolder, settings.Wildcard);
                    message.ShowMessage(settings.Wildcard, settings.SourceFolder, settings.TargetFolder);
                    break;
                case ("hide"):
                    CopyAllFiles(settings.SourceFolder, settings.TargetFolder, settings.Wildcard);
                    break;
            }
            throw new NotImplementedException();
        }
    }
}


