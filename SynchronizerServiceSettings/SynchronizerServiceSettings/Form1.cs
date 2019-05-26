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
        string _folderPath;
        string _folderPath2;
        string line;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            _folderPath = folderBrowserDialog.SelectedPath;
            WriteFile("Source folder:" + _folderPath);
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog2 = new FolderBrowserDialog();
            if (folderBrowserDialog2.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            _folderPath2 = folderBrowserDialog2.SelectedPath;
            WriteFile("Target folder:" + _folderPath2);
        }

        public void WriteFile(string info)
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SynchronizerService"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SynchronizerService");
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SynchronizerService\\settings.cfg";
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
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SynchronizerService\\settings.cfg";
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
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\settings.cfg";
            File.WriteAllText(path, String.Empty);
        }
    }


}
