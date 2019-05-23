using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronizerService
{
    class CopyFiles
    {
        public void copyFiles(string sourceFolder, string targetFolder, string wildcard)
        {
            string[] dirs = Directory.GetDirectories(sourceFolder, "*", SearchOption.AllDirectories);
            foreach (string dir in dirs)
            {
                try
                {
                    Directory.CreateDirectory(dir.Replace(sourceFolder, targetFolder));
                }
                catch (DirectoryNotFoundException e)
                {
                    
                }
            }

            string[] files = Directory.GetFiles(sourceFolder, wildcard, SearchOption.AllDirectories);
            foreach (string file in files)
            {
                try
                {
                    File.Copy(file, file.Replace(sourceFolder, targetFolder), true);
                }
                catch (FileNotFoundException e)
                {
                    
                }
            }
        }

        //public void copyFiles()
        //{
        //    copyFiles(sourceFolder, targetFolder, wildcard);
        //}
    }
}


