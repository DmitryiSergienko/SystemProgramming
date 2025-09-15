namespace CalcRunner
{
    partial class CalcRunnerForm
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
            this.StartButton = new System.Windows.Forms.Button();
            this.StopWithCodeButton = new System.Windows.Forms.Button();
            this.myProcess = new System.Diagnostics.Process();
            this.StopButton = new System.Windows.Forms.Button();
            this.FirstNumTextBox = new System.Windows.Forms.TextBox();
            this.SecondNumTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.ResultButton = new System.Windows.Forms.Button();
            this.OperationComboBox = new System.Windows.Forms.ComboBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.AddressFileTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.WordTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SearchWordButton = new System.Windows.Forms.Button();
            this.CountLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ClearWordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(35, 80);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(203, 80);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopWithCodeButton
            // 
            this.StopWithCodeButton.Location = new System.Drawing.Point(35, 211);
            this.StopWithCodeButton.Name = "StopWithCodeButton";
            this.StopWithCodeButton.Size = new System.Drawing.Size(203, 80);
            this.StopWithCodeButton.TabIndex = 1;
            this.StopWithCodeButton.Text = "Stop with code";
            this.StopWithCodeButton.UseVisualStyleBackColor = true;
            this.StopWithCodeButton.Click += new System.EventHandler(this.StopWithCodeButton_Click);
            // 
            // myProcess
            // 
            this.myProcess.StartInfo.Domain = "";
            this.myProcess.StartInfo.LoadUserProfile = false;
            this.myProcess.StartInfo.Password = null;
            this.myProcess.StartInfo.StandardErrorEncoding = null;
            this.myProcess.StartInfo.StandardOutputEncoding = null;
            this.myProcess.StartInfo.UserName = "";
            this.myProcess.SynchronizingObject = this;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(35, 349);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(203, 80);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // FirstNumTextBox
            // 
            this.FirstNumTextBox.Location = new System.Drawing.Point(441, 80);
            this.FirstNumTextBox.Name = "FirstNumTextBox";
            this.FirstNumTextBox.Size = new System.Drawing.Size(103, 31);
            this.FirstNumTextBox.TabIndex = 3;
            this.FirstNumTextBox.TextChanged += new System.EventHandler(this.FirstNumTextBox_TextChanged);
            this.FirstNumTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FirstNumTextBox_KeyPress);
            // 
            // SecondNumTextBox
            // 
            this.SecondNumTextBox.Location = new System.Drawing.Point(441, 178);
            this.SecondNumTextBox.Name = "SecondNumTextBox";
            this.SecondNumTextBox.Size = new System.Drawing.Size(103, 31);
            this.SecondNumTextBox.TabIndex = 4;
            this.SecondNumTextBox.TextChanged += new System.EventHandler(this.SecondNumTextBox_TextChanged);
            this.SecondNumTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SecondNumTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(480, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "=";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ResultLabel.Location = new System.Drawing.Point(444, 285);
            this.ResultLabel.MinimumSize = new System.Drawing.Size(100, 0);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(100, 27);
            this.ResultLabel.TabIndex = 8;
            // 
            // ResultButton
            // 
            this.ResultButton.Location = new System.Drawing.Point(396, 349);
            this.ResultButton.Name = "ResultButton";
            this.ResultButton.Size = new System.Drawing.Size(203, 56);
            this.ResultButton.TabIndex = 9;
            this.ResultButton.Text = "Rusult";
            this.ResultButton.UseVisualStyleBackColor = true;
            this.ResultButton.Click += new System.EventHandler(this.ResultButton_Click);
            // 
            // OperationComboBox
            // 
            this.OperationComboBox.FormattingEnabled = true;
            this.OperationComboBox.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.OperationComboBox.Location = new System.Drawing.Point(470, 126);
            this.OperationComboBox.Name = "OperationComboBox";
            this.OperationComboBox.Size = new System.Drawing.Size(61, 33);
            this.OperationComboBox.TabIndex = 10;
            this.OperationComboBox.SelectedIndexChanged += new System.EventHandler(this.OperationComboBox_SelectedIndexChanged);
            this.OperationComboBox.TextChanged += new System.EventHandler(this.OperationComboBox_TextChanged);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(396, 411);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(203, 56);
            this.ClearButton.TabIndex = 11;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // AddressFileTextBox
            // 
            this.AddressFileTextBox.Location = new System.Drawing.Point(832, 80);
            this.AddressFileTextBox.Name = "AddressFileTextBox";
            this.AddressFileTextBox.Size = new System.Drawing.Size(372, 31);
            this.AddressFileTextBox.TabIndex = 12;
            this.AddressFileTextBox.TextChanged += new System.EventHandler(this.AddressFileTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Задание 1-2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Задание 3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(827, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Задание 4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Число 1:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(328, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Число 2:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "Оператор:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(656, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "Путь к файлу:";
            // 
            // WordTextBox
            // 
            this.WordTextBox.Location = new System.Drawing.Point(832, 138);
            this.WordTextBox.Name = "WordTextBox";
            this.WordTextBox.Size = new System.Drawing.Size(372, 31);
            this.WordTextBox.TabIndex = 20;
            this.WordTextBox.TextChanged += new System.EventHandler(this.WordTextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(656, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 25);
            this.label9.TabIndex = 21;
            this.label9.Text = "Искомое слово:";
            // 
            // SearchWordButton
            // 
            this.SearchWordButton.Location = new System.Drawing.Point(1019, 197);
            this.SearchWordButton.Name = "SearchWordButton";
            this.SearchWordButton.Size = new System.Drawing.Size(185, 56);
            this.SearchWordButton.TabIndex = 22;
            this.SearchWordButton.Text = "Search";
            this.SearchWordButton.UseVisualStyleBackColor = true;
            this.SearchWordButton.Click += new System.EventHandler(this.SearchWordButton_Click);
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CountLabel.Location = new System.Drawing.Point(895, 211);
            this.CountLabel.MinimumSize = new System.Drawing.Size(100, 0);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(100, 27);
            this.CountLabel.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(328, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 25);
            this.label11.TabIndex = 24;
            this.label11.Text = "Ответ:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(656, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(233, 25);
            this.label12.TabIndex = 25;
            this.label12.Text = "Встречается в тексте:";
            // 
            // ClearWordButton
            // 
            this.ClearWordButton.Location = new System.Drawing.Point(1019, 269);
            this.ClearWordButton.Name = "ClearWordButton";
            this.ClearWordButton.Size = new System.Drawing.Size(185, 56);
            this.ClearWordButton.TabIndex = 26;
            this.ClearWordButton.Text = "Clear";
            this.ClearWordButton.UseVisualStyleBackColor = true;
            this.ClearWordButton.Click += new System.EventHandler(this.ClearWordButton_Click);
            // 
            // CalcRunnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 527);
            this.Controls.Add(this.ClearWordButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.SearchWordButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.WordTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddressFileTextBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.OperationComboBox);
            this.Controls.Add(this.ResultButton);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SecondNumTextBox);
            this.Controls.Add(this.FirstNumTextBox);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StopWithCodeButton);
            this.Controls.Add(this.StartButton);
            this.Name = "CalcRunnerForm";
            this.Text = "Calc Runner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopWithCodeButton;
        private System.Diagnostics.Process myProcess;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.TextBox SecondNumTextBox;
        private System.Windows.Forms.TextBox FirstNumTextBox;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ResultButton;
        private System.Windows.Forms.ComboBox OperationComboBox;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AddressFileTextBox;
        private System.Windows.Forms.TextBox WordTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Button SearchWordButton;
        private System.Windows.Forms.Button ClearWordButton;
    }
}

