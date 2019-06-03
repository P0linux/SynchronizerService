using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SynchronizerService
{
    public partial class Service1 : ServiceBase
    {
        CopyFiles copyFile;
        Settings settings;
        Massage message;

        public Service1(string[] args)
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        internal void TestStartAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }

        protected override void OnStart(string[] args)
        {
            settings = new Settings();
            message = new Massage();
            Debugger.Launch();
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
                    Сopy();
                    message.ShowMessage(settings.Wildcard, settings.SourceFolder, settings.TargetFolder);
                    break;
                case ("hide"):
                    Сopy();
                    break;
            }
            
        }

        protected override void OnStop()
        {
            Thread.Sleep(1000);
        }

        public void Сopy()
        {
            copyFile = new CopyFiles();
            copyFile.CopyAllFiles(settings.SourceFolder, settings.TargetFolder, settings.Wildcard);
            //Thread thread = new Thread(new ThreadStart(ShowMessage));
        }

        public void ShowMessage()
        {
            message.ShowMessage(settings.Wildcard, settings.SourceFolder, settings.TargetFolder);
        }
    }
}
