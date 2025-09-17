namespace ThreadAndCanceledToken
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
            this.SquareCubeWindow = new System.Windows.Forms.RichTextBox();
            this.FactorialWindow = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartButton1 = new System.Windows.Forms.Button();
            this.PauseButton1 = new System.Windows.Forms.Button();
            this.StopButton1 = new System.Windows.Forms.Button();
            this.RestartButton1 = new System.Windows.Forms.Button();
            this.RestartButton2 = new System.Windows.Forms.Button();
            this.StopButton2 = new System.Windows.Forms.Button();
            this.PauseButton2 = new System.Windows.Forms.Button();
            this.StartButton2 = new System.Windows.Forms.Button();
            this.SquareCubeRangeFrom = new System.Windows.Forms.TextBox();
            this.SquareCubeRangeTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FactorialRangeTo = new System.Windows.Forms.TextBox();
            this.FactorialRangeFrom = new System.Windows.Forms.TextBox();
            this.SquareRadioButton = new System.Windows.Forms.RadioButton();
            this.CubeRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // SquareCubeWindow
            // 
            this.SquareCubeWindow.Enabled = false;
            this.SquareCubeWindow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SquareCubeWindow.Location = new System.Drawing.Point(12, 66);
            this.SquareCubeWindow.Name = "SquareCubeWindow";
            this.SquareCubeWindow.Size = new System.Drawing.Size(700, 600);
            this.SquareCubeWindow.TabIndex = 0;
            this.SquareCubeWindow.Text = "";
            // 
            // FactorialWindow
            // 
            this.FactorialWindow.Enabled = false;
            this.FactorialWindow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FactorialWindow.Location = new System.Drawing.Point(810, 66);
            this.FactorialWindow.Name = "FactorialWindow";
            this.FactorialWindow.Size = new System.Drawing.Size(700, 600);
            this.FactorialWindow.TabIndex = 1;
            this.FactorialWindow.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(111, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Генерация квадратов/кубов чисел";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(950, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(453, 45);
            this.label2.TabIndex = 3;
            this.label2.Text = "Генерация факториала чисел";
            // 
            // StartButton1
            // 
            this.StartButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton1.Location = new System.Drawing.Point(12, 683);
            this.StartButton1.Name = "StartButton1";
            this.StartButton1.Size = new System.Drawing.Size(170, 65);
            this.StartButton1.TabIndex = 4;
            this.StartButton1.Text = "Старт";
            this.StartButton1.UseVisualStyleBackColor = true;
            this.StartButton1.Click += new System.EventHandler(this.StartButton1_Click);
            // 
            // PauseButton1
            // 
            this.PauseButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PauseButton1.Location = new System.Drawing.Point(188, 683);
            this.PauseButton1.Name = "PauseButton1";
            this.PauseButton1.Size = new System.Drawing.Size(170, 65);
            this.PauseButton1.TabIndex = 5;
            this.PauseButton1.Text = "Пауза";
            this.PauseButton1.UseVisualStyleBackColor = true;
            this.PauseButton1.Click += new System.EventHandler(this.PauseButton1_Click);
            // 
            // StopButton1
            // 
            this.StopButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopButton1.Location = new System.Drawing.Point(364, 683);
            this.StopButton1.Name = "StopButton1";
            this.StopButton1.Size = new System.Drawing.Size(170, 65);
            this.StopButton1.TabIndex = 6;
            this.StopButton1.Text = "Стоп";
            this.StopButton1.UseVisualStyleBackColor = true;
            this.StopButton1.Click += new System.EventHandler(this.StopButton1_Click);
            // 
            // RestartButton1
            // 
            this.RestartButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RestartButton1.Location = new System.Drawing.Point(540, 683);
            this.RestartButton1.Name = "RestartButton1";
            this.RestartButton1.Size = new System.Drawing.Size(170, 65);
            this.RestartButton1.TabIndex = 7;
            this.RestartButton1.Text = "Рестарт";
            this.RestartButton1.UseVisualStyleBackColor = true;
            this.RestartButton1.Click += new System.EventHandler(this.RestartButton1_Click);
            // 
            // RestartButton2
            // 
            this.RestartButton2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RestartButton2.Location = new System.Drawing.Point(1338, 683);
            this.RestartButton2.Name = "RestartButton2";
            this.RestartButton2.Size = new System.Drawing.Size(170, 65);
            this.RestartButton2.TabIndex = 11;
            this.RestartButton2.Text = "Рестарт";
            this.RestartButton2.UseVisualStyleBackColor = true;
            this.RestartButton2.Click += new System.EventHandler(this.RestartButton2_Click);
            // 
            // StopButton2
            // 
            this.StopButton2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopButton2.Location = new System.Drawing.Point(1162, 683);
            this.StopButton2.Name = "StopButton2";
            this.StopButton2.Size = new System.Drawing.Size(170, 65);
            this.StopButton2.TabIndex = 10;
            this.StopButton2.Text = "Стоп";
            this.StopButton2.UseVisualStyleBackColor = true;
            this.StopButton2.Click += new System.EventHandler(this.StopButton2_Click);
            // 
            // PauseButton2
            // 
            this.PauseButton2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PauseButton2.Location = new System.Drawing.Point(986, 683);
            this.PauseButton2.Name = "PauseButton2";
            this.PauseButton2.Size = new System.Drawing.Size(170, 65);
            this.PauseButton2.TabIndex = 9;
            this.PauseButton2.Text = "Пауза";
            this.PauseButton2.UseVisualStyleBackColor = true;
            this.PauseButton2.Click += new System.EventHandler(this.PauseButton2_Click);
            // 
            // StartButton2
            // 
            this.StartButton2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton2.Location = new System.Drawing.Point(810, 683);
            this.StartButton2.Name = "StartButton2";
            this.StartButton2.Size = new System.Drawing.Size(170, 65);
            this.StartButton2.TabIndex = 8;
            this.StartButton2.Text = "Старт";
            this.StartButton2.UseVisualStyleBackColor = true;
            this.StartButton2.Click += new System.EventHandler(this.StartButton2_Click);
            // 
            // SquareCubeRangeFrom
            // 
            this.SquareCubeRangeFrom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SquareCubeRangeFrom.Location = new System.Drawing.Point(82, 773);
            this.SquareCubeRangeFrom.Name = "SquareCubeRangeFrom";
            this.SquareCubeRangeFrom.Size = new System.Drawing.Size(100, 50);
            this.SquareCubeRangeFrom.TabIndex = 12;
            this.SquareCubeRangeFrom.TextChanged += new System.EventHandler(this.SquareCubeRangeFrom_TextChanged);
            this.SquareCubeRangeFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SquareCubeRangeFrom_KeyPress);
            // 
            // SquareCubeRangeTo
            // 
            this.SquareCubeRangeTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SquareCubeRangeTo.Location = new System.Drawing.Point(82, 829);
            this.SquareCubeRangeTo.Name = "SquareCubeRangeTo";
            this.SquareCubeRangeTo.Size = new System.Drawing.Size(100, 50);
            this.SquareCubeRangeTo.TabIndex = 13;
            this.SquareCubeRangeTo.TextChanged += new System.EventHandler(this.SquareCubeRangeTo_TextChanged);
            this.SquareCubeRangeTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SquareCubeRangeTo_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(5, 776);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 45);
            this.label3.TabIndex = 14;
            this.label3.Text = "От:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(5, 836);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 45);
            this.label4.TabIndex = 15;
            this.label4.Text = "До:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(803, 833);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 45);
            this.label5.TabIndex = 19;
            this.label5.Text = "До:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(803, 773);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 45);
            this.label6.TabIndex = 18;
            this.label6.Text = "От:";
            // 
            // FactorialRangeTo
            // 
            this.FactorialRangeTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FactorialRangeTo.Location = new System.Drawing.Point(880, 826);
            this.FactorialRangeTo.Name = "FactorialRangeTo";
            this.FactorialRangeTo.Size = new System.Drawing.Size(100, 50);
            this.FactorialRangeTo.TabIndex = 17;
            this.FactorialRangeTo.TextChanged += new System.EventHandler(this.FactorialRangeTo_TextChanged);
            this.FactorialRangeTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FactorialRangeTo_KeyPress);
            // 
            // FactorialRangeFrom
            // 
            this.FactorialRangeFrom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FactorialRangeFrom.Location = new System.Drawing.Point(880, 770);
            this.FactorialRangeFrom.Name = "FactorialRangeFrom";
            this.FactorialRangeFrom.Size = new System.Drawing.Size(100, 50);
            this.FactorialRangeFrom.TabIndex = 16;
            this.FactorialRangeFrom.TextChanged += new System.EventHandler(this.FactorialRangeFrom_TextChanged);
            this.FactorialRangeFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FactorialRangeFrom_KeyPress);
            // 
            // SquareRadioButton
            // 
            this.SquareRadioButton.AutoSize = true;
            this.SquareRadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SquareRadioButton.Location = new System.Drawing.Point(364, 774);
            this.SquareRadioButton.Name = "SquareRadioButton";
            this.SquareRadioButton.Size = new System.Drawing.Size(264, 49);
            this.SquareRadioButton.TabIndex = 20;
            this.SquareRadioButton.TabStop = true;
            this.SquareRadioButton.Text = "Квадрат чисел";
            this.SquareRadioButton.UseVisualStyleBackColor = true;
            this.SquareRadioButton.CheckedChanged += new System.EventHandler(this.SquareRadioButton_CheckedChanged);
            // 
            // CubeRadioButton
            // 
            this.CubeRadioButton.AutoSize = true;
            this.CubeRadioButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CubeRadioButton.Location = new System.Drawing.Point(364, 834);
            this.CubeRadioButton.Name = "CubeRadioButton";
            this.CubeRadioButton.Size = new System.Drawing.Size(199, 49);
            this.CubeRadioButton.TabIndex = 21;
            this.CubeRadioButton.TabStop = true;
            this.CubeRadioButton.Text = "Куб чисел";
            this.CubeRadioButton.UseVisualStyleBackColor = true;
            this.CubeRadioButton.CheckedChanged += new System.EventHandler(this.CubeRadioButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1529, 899);
            this.Controls.Add(this.CubeRadioButton);
            this.Controls.Add(this.SquareRadioButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FactorialRangeTo);
            this.Controls.Add(this.FactorialRangeFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SquareCubeRangeTo);
            this.Controls.Add(this.SquareCubeRangeFrom);
            this.Controls.Add(this.RestartButton2);
            this.Controls.Add(this.StopButton2);
            this.Controls.Add(this.PauseButton2);
            this.Controls.Add(this.StartButton2);
            this.Controls.Add(this.RestartButton1);
            this.Controls.Add(this.StopButton1);
            this.Controls.Add(this.PauseButton1);
            this.Controls.Add(this.StartButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FactorialWindow);
            this.Controls.Add(this.SquareCubeWindow);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox SquareCubeWindow;
        private System.Windows.Forms.RichTextBox FactorialWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartButton1;
        private System.Windows.Forms.Button PauseButton1;
        private System.Windows.Forms.Button StopButton1;
        private System.Windows.Forms.Button RestartButton1;
        private System.Windows.Forms.Button RestartButton2;
        private System.Windows.Forms.Button StopButton2;
        private System.Windows.Forms.Button PauseButton2;
        private System.Windows.Forms.Button StartButton2;
        private System.Windows.Forms.TextBox SquareCubeRangeFrom;
        private System.Windows.Forms.TextBox SquareCubeRangeTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FactorialRangeTo;
        private System.Windows.Forms.TextBox FactorialRangeFrom;
        private System.Windows.Forms.RadioButton SquareRadioButton;
        private System.Windows.Forms.RadioButton CubeRadioButton;
    }
}

