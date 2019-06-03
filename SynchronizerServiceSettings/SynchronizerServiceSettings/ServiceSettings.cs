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
    public partial class ServiceSettings : Form
    {
        string _folderSourcePath;
        string _folderTargetPath;
        string _settingsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\SynchronizerService";
        string line;
        FolderBrowserDialog folderBrowserDialogSource = new FolderBrowserDialog();
        FolderBrowserDialog folderBrowserDialogTarget = new FolderBrowserDialog();
        System.Threading.Thread thread;

        public ServiceSettings()
        {
            InitializeComponent();
            btnStart.Enabled = false;
            txbTime.TextChanged += TxbTime_TextChanged;
            //checkBoxMessage.Checked = false;
        }

        private void TxbTime_TextChanged(object sender, EventArgs e)
        {
            ButtonEnabled();
        }

        private void CreateDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        private void WriteFile(string info)
        {
            CreateDirectory(_settingsFolderPath);
            string path = _settingsFolderPath + "\\settings.cfg";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(info);
            }
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            folderBrowserDialogSource = new FolderBrowserDialog();
            if (folderBrowserDialogSource.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            _folderSourcePath = folderBrowserDialogSource.SelectedPath;
            WriteFile("Source folder:" + _folderSourcePath);
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            string timestamp = DateTime.Now.ToString();
            folderBrowserDialogTarget = new FolderBrowserDialog();
            if (folderBrowserDialogTarget.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            _folderTargetPath = folderBrowserDialogTarget.SelectedPath;
            WriteFile("Target folder:" + _folderTargetPath);
        }

        

        private void comboBoxWildcard_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wildcard = comboBoxWildcard.SelectedItem.ToString();
            WriteFile("Wildcard:" + wildcard);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (checkBoxMessage.Checked == true) WriteFile("Message:show");
            else WriteFile("Message:hide");
            int time = Convert.ToInt32(txbTime.Text);
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
        }

        
        private void btnTest_Click(object sender, EventArgs e)
        {
            string path = _settingsFolderPath + "\\settings.cfg";
            int count = File.ReadAllLines(path).Length;
            dataGridViewTest.RowCount = count;
            dataGridViewTest.ColumnCount = 2;
            dataGridViewTest.Columns[0].HeaderText = "Setting name";
            dataGridViewTest.Columns[1].HeaderText = "Setting";
            List<string> settingNames = new List<string>(count);
            List<string> settings = new List<string>(count);
            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string settingName = line.Remove(line.IndexOf(":"));
                    string setting = line.Remove(0, line.IndexOf(":") + 1);
                    settingNames.Add(settingName);
                    settings.Add(setting);
                   
                    //switch (settingName)
                    //{
                    //    case ("Source folder"):
                    //        string sourceFolder = settingName + ": " + setting;
                    //        richTextBoxTest.Text += sourceFolder + Environment.NewLine;
                    //        break;
                    //    case ("Target folder"):
                    //        string targetFolder = settingName + ": " + setting;
                    //        richTextBoxTest.Text += targetFolder + Environment.NewLine;
                    //        break;
                    //    case ("Wildcard"):
                    //        string wildcard = settingName + ": " + setting;
                    //        richTextBoxTest.Text += wildcard + Environment.NewLine;
                    //        break;
                    //    case ("Interval"):
                    //        string interval = settingName + ": " + setting;
                    //        richTextBoxTest.Text += interval + Environment.NewLine;
                    //        break;
                    //    case ("CheckBox"):
                    //        string checkBox = settingName + ": " + setting;
                    //        richTextBoxTest.Text += checkBox + Environment.NewLine;
                    //        break;
                    //}

                    //if (line.Contains("Source folder:"))
                    //{
                    //    string sourceFolder = line.Remove(0, line.IndexOf(":") + 1);
                    //    richTextBox1.Text += sourceFolder + Environment.NewLine;
                    //    //Console.WriteLine(sourceFolder);
                    //}
                    //else if (line.Contains("Target folder:"))
                    //{
                    //    string targetFolder = line.Remove(0, line.IndexOf(":") + 1);
                    //    richTextBox1.Text += targetFolder + Environment.NewLine;
                    //}
                    //else if (line.Contains("Wildcard:"))
                    //{
                    //    string wildcard = line.Remove(0, line.IndexOf(":") + 1);
                    //    richTextBox1.Text += wildcard + Environment.NewLine;
                    //}
                    //else if (line.Contains("Interval:"))
                    //{
                    //    string interval = line.Remove(0, line.IndexOf(":") + 1);
                    //    richTextBox1.Text += interval + Environment.NewLine;
                    //}
                }
                int i = 0;
                foreach (DataGridViewRow row in dataGridViewTest.Rows)
                {
                    row.Cells[0].Value = settingNames[i];
                    row.Cells[1].Value = settings[i];
                    i++;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string path = _settingsFolderPath + "\\settings.cfg";
            File.WriteAllText(path, String.Empty);
        }

        //public void Form1_Load(object sender, EventArgs e)
        //{
        //    thread = new System.Threading.Thread(ButtonEnabled);
        //    thread.Start();
        //}

        
        private void ButtonEnabled()
        {
            if (folderBrowserDialogSource.SelectedPath != null &&
                folderBrowserDialogTarget.SelectedPath != null &&
                txbTime.Text != null &&
                comboBoxWildcard.SelectedItem != null) btnStart.Enabled = true;
        }

        private void ServiceSettings_Load(object sender, EventArgs e)
        {
            dataGridViewTest.ColumnCount = 2;
            dataGridViewTest.Columns[0].HeaderText = "Setting name";
            dataGridViewTest.Columns[1].HeaderText = "Setting";
        }

        //private void checkBoxMessage_CheckedChanged(object sender, EventArgs e)
        //{

        //}
    }


}
