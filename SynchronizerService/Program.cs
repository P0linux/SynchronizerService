using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SynchronizerService
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                Service1 service1 = new Service1(args);
                service1.TestStartAndStop(args);
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Service1(args)
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
