namespace ProcessManipulation
{
    partial class ProcessManipulation
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
            this.StartedAssemblies = new System.Windows.Forms.ListBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonCloseWindow = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonRunCalc = new System.Windows.Forms.Button();
            this.groupBoxRunningProcesses = new System.Windows.Forms.GroupBox();
            this.groupBoxAvailableBuilds = new System.Windows.Forms.GroupBox();
            this.AvailableAssemblies = new System.Windows.Forms.ListBox();
            this.groupBoxRunningProcesses.SuspendLayout();
            this.groupBoxAvailableBuilds.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartedAssemblies
            // 
            this.StartedAssemblies.FormattingEnabled = true;
            this.StartedAssemblies.ItemHeight = 25;
            this.StartedAssemblies.Location = new System.Drawing.Point(6, 30);
            this.StartedAssemblies.Name = "StartedAssemblies";
            this.StartedAssemblies.Size = new System.Drawing.Size(284, 354);
            this.StartedAssemblies.TabIndex = 0;
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(314, 84);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(172, 52);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(314, 142);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(172, 52);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            // 
            // buttonCloseWindow
            // 
            this.buttonCloseWindow.Enabled = false;
            this.buttonCloseWindow.Location = new System.Drawing.Point(314, 200);
            this.buttonCloseWindow.Name = "buttonCloseWindow";
            this.buttonCloseWindow.Size = new System.Drawing.Size(172, 52);
            this.buttonCloseWindow.TabIndex = 4;
            this.buttonCloseWindow.Text = "CloseWindow";
            this.buttonCloseWindow.UseVisualStyleBackColor = true;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Enabled = false;
            this.buttonRefresh.Location = new System.Drawing.Point(314, 258);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(172, 52);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            // 
            // buttonRunCalc
            // 
            this.buttonRunCalc.Enabled = false;
            this.buttonRunCalc.Location = new System.Drawing.Point(314, 316);
            this.buttonRunCalc.Name = "buttonRunCalc";
            this.buttonRunCalc.Size = new System.Drawing.Size(172, 52);
            this.buttonRunCalc.TabIndex = 6;
            this.buttonRunCalc.Text = "RunCalc";
            this.buttonRunCalc.UseVisualStyleBackColor = true;
            // 
            // groupBoxRunningProcesses
            // 
            this.groupBoxRunningProcesses.Controls.Add(this.StartedAssemblies);
            this.groupBoxRunningProcesses.Location = new System.Drawing.Point(12, 12);
            this.groupBoxRunningProcesses.Name = "groupBoxRunningProcesses";
            this.groupBoxRunningProcesses.Size = new System.Drawing.Size(296, 405);
            this.groupBoxRunningProcesses.TabIndex = 7;
            this.groupBoxRunningProcesses.TabStop = false;
            this.groupBoxRunningProcesses.Text = "Running processes";
            // 
            // groupBoxAvailableBuilds
            // 
            this.groupBoxAvailableBuilds.Controls.Add(this.AvailableAssemblies);
            this.groupBoxAvailableBuilds.Location = new System.Drawing.Point(492, 12);
            this.groupBoxAvailableBuilds.Name = "groupBoxAvailableBuilds";
            this.groupBoxAvailableBuilds.Size = new System.Drawing.Size(270, 405);
            this.groupBoxAvailableBuilds.TabIndex = 8;
            this.groupBoxAvailableBuilds.TabStop = false;
            this.groupBoxAvailableBuilds.Text = "Available builds";
            // 
            // AvailableAssemblies
            // 
            this.AvailableAssemblies.FormattingEnabled = true;
            this.AvailableAssemblies.ItemHeight = 25;
            this.AvailableAssemblies.Location = new System.Drawing.Point(6, 30);
            this.AvailableAssemblies.Name = "AvailableAssemblies";
            this.AvailableAssemblies.Size = new System.Drawing.Size(258, 354);
            this.AvailableAssemblies.TabIndex = 0;
            // 
            // ProcessManipulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 429);
            this.Controls.Add(this.groupBoxAvailableBuilds);
            this.Controls.Add(this.groupBoxRunningProcesses);
            this.Controls.Add(this.buttonRunCalc);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonCloseWindow);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Name = "ProcessManipulation";
            this.Text = "Process Manipulation";
            this.groupBoxRunningProcesses.ResumeLayout(false);
            this.groupBoxAvailableBuilds.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox StartedAssemblies;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonCloseWindow;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonRunCalc;
        private System.Windows.Forms.GroupBox groupBoxRunningProcesses;
        private System.Windows.Forms.GroupBox groupBoxAvailableBuilds;
        private System.Windows.Forms.ListBox AvailableAssemblies;
    }
}

