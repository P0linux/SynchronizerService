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
            settings.getSettings();
            Timer timer = new Timer();
            timer.Interval = 10000;
            timer.Elapsed += OnTimedEvent;
            timer.Start();
            //File.Create(@"D:\file.txt");
            //copyFile.copyFiles();
            //copyFile = new CopyFiles();


            //message = new Massage();
            //copyFile.getSettings();
            //message.showMessage(copyFile.Wildcard, copyFile.SourceFolder, copyFile.TargetFolder);

            //Thread.Sleep(1000);

            //copyFile.getSettings();
            //Thread.Sleep(2000);
            //Thread copyFileThread = new Thread(new ThreadStart(copyFile.copyFiles));
            //copyFileThread.Start();
            //message = new Massage();
            //message.showMessage(copyFile.Wildcard, copyFile.SourceFolder, copyFile.TargetFolder);
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            copy();
            message.showMessage(settings.Wildcard, settings.SourceFolder, settings.TargetFolder);
            //Thread messageThread = new Thread(new ThreadStart(copy));
            //messageThread.Start();
            Debug.WriteLine(1);
        }

        protected override void OnStop()
        {
            Thread.Sleep(1000);
        }

        public void copy()
        {
            copyFile = new CopyFiles();
            copyFile.copyFiles(settings.SourceFolder, settings.TargetFolder, settings.Wildcard);
            //using (StreamWriter wr = new StreamWriter(@"D:\test1.txt", true))
            //{
            //    wr.WriteLine(copyFile.Wildcard, copyFile.SourceFolder, copyFile.TargetFolder);
            //}
            //message.showMessage(copyFile.Wildcard, copyFile.SourceFolder, copyFile.TargetFolder);
            //copyFile = new CopyFiles();
            //copyFile.getSettings();
            //copyFile.copyFiles();

        }
    }
}
