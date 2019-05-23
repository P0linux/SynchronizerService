namespace SynchronizerServiceSettings
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSource = new System.Windows.Forms.Button();
            this.btnTarget = new System.Windows.Forms.Button();
            this.comboBoxWildcard = new System.Windows.Forms.ComboBox();
            this.txbTime = new System.Windows.Forms.TextBox();
            this.lbTime = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSource
            // 
            this.btnSource.Location = new System.Drawing.Point(89, 45);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(154, 23);
            this.btnSource.TabIndex = 0;
            this.btnSource.Text = "Choose Source folder";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // btnTarget
            // 
            this.btnTarget.Location = new System.Drawing.Point(89, 115);
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.Size = new System.Drawing.Size(154, 23);
            this.btnTarget.TabIndex = 1;
            this.btnTarget.Text = "Choose Target folder ";
            this.btnTarget.UseVisualStyleBackColor = true;
            this.btnTarget.Click += new System.EventHandler(this.btnTarget_Click);
            // 
            // comboBoxWildcard
            // 
            this.comboBoxWildcard.FormattingEnabled = true;
            this.comboBoxWildcard.Items.AddRange(new object[] {
            "*.txt",
            "*.png",
            "*.jpg",
            "*.*"});
            this.comboBoxWildcard.Location = new System.Drawing.Point(337, 47);
            this.comboBoxWildcard.Name = "comboBoxWildcard";
            this.comboBoxWildcard.Size = new System.Drawing.Size(121, 21);
            this.comboBoxWildcard.TabIndex = 2;
            this.comboBoxWildcard.Text = "Choose wild card";
            this.comboBoxWildcard.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txbTime
            // 
            this.txbTime.Location = new System.Drawing.Point(409, 118);
            this.txbTime.Name = "txbTime";
            this.txbTime.Size = new System.Drawing.Size(100, 20);
            this.txbTime.TabIndex = 3;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(334, 125);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(68, 13);
            this.lbTime.TabIndex = 4;
            this.lbTime.Text = "Input interval";
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = true;
            this.btnStart.Location = new System.Drawing.Point(614, 115);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(78, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start Service";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(238, 211);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(220, 158);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(89, 267);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.txbTime);
            this.Controls.Add(this.comboBoxWildcard);
            this.Controls.Add(this.btnTarget);
            this.Controls.Add(this.btnSource);
            this.Name = "Form1";
            this.Text = "ServiceSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.Button btnTarget;
        private System.Windows.Forms.ComboBox comboBoxWildcard;
        private System.Windows.Forms.TextBox txbTime;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnReset;
    }
}

