using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace SynchronizerService
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;

        public Installer1()
        {
            InitializeComponent();
            serviceInstaller = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "SynchronizerService";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);

            //RegistryKey ckey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\SynchronizerService", true);
            //if (ckey != null)
            //{
            //    if (ckey.GetValue("Type") != null)
            //    {
            //        ckey.SetValue("Type", ((int)ckey.GetValue("Type") | 256));
            //    }
            //}
        }
    }
}
