using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SynchronizerServiceSettings
{
    public partial class Form1 : Form
    {
        string _folderSourcePath;
        string _folderTargetPath;
        string _settingsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\SynchronizerService";
        string line;

        public Form1()
        {
            InitializeComponent();
        }

        public void CreateDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            _folderSourcePath = folderBrowserDialog.SelectedPath;
            WriteFile("Source folder:" + _folderSourcePath);
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog2 = new FolderBrowserDialog();
            if (folderBrowserDialog2.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            _folderTargetPath = folderBrowserDialog2.SelectedPath + "\\copiedFiles";
            WriteFile("Target folder:" + _folderTargetPath);
        }

        public void WriteFile(string info)
        {
            CreateDirectory(_settingsFolderPath);
            string path = _settingsFolderPath + "\\settings.cfg";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(info);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wildcard = comboBoxWildcard.SelectedItem.ToString();
            WriteFile("Wildcard:" + wildcard);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            CreateDirectory(_folderTargetPath);
            string time = txbTime.Text;
            WriteFile("Interval:" + time);
            string cmdCommand = "/C net start SynchronizerService";
            using (Process cmd = new Process())
            {
                cmd.StartInfo.UseShellExecute = true;
                cmd.StartInfo.Arguments = cmdCommand;
                cmd.StartInfo.WorkingDirectory = @"C:\Windows\System32";
                cmd.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.Start();
            }
            //System.Diagnostics.Process.Start("CMD.exe", cmdCommand);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = _settingsFolderPath + "\\settings.cfg";
            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("Source folder:"))
                    {
                        string sourceFolder = line.Remove(0, line.IndexOf(":") + 1);
                        richTextBox1.Text += sourceFolder + Environment.NewLine;
                        //Console.WriteLine(sourceFolder);
                    }
                    else if (line.Contains("Target folder:"))
                    {
                        string targetFolder = line.Remove(0, line.IndexOf(":") + 1);
                        richTextBox1.Text += targetFolder + Environment.NewLine;
                    }
                    else if (line.Contains("Wildcard:"))
                    {
                        string wildcard = line.Remove(0, line.IndexOf(":") + 1);
                        richTextBox1.Text += wildcard + Environment.NewLine;
                    }
                    else if (line.Contains("Interval:"))
                    {
                        string interval = line.Remove(0, line.IndexOf(":") + 1);
                        richTextBox1.Text += interval + Environment.NewLine;
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string path = _settingsFolderPath + "\\settings.cfg";
            File.WriteAllText(path, String.Empty);
        }
    }


}
