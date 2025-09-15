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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessManipulation));
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
            resources.ApplyResources(this.StartedAssemblies, "StartedAssemblies");
            this.StartedAssemblies.Name = "StartedAssemblies";
            this.StartedAssemblies.SelectedIndexChanged += new System.EventHandler(this.StartedAssemblies_SelectedIndexChanged);
            // 
            // buttonStart
            // 
            resources.ApplyResources(this.buttonStart, "buttonStart");
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            resources.ApplyResources(this.buttonStop, "buttonStop");
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonCloseWindow
            // 
            this.buttonCloseWindow.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonCloseWindow, "buttonCloseWindow");
            this.buttonCloseWindow.Name = "buttonCloseWindow";
            this.buttonCloseWindow.UseVisualStyleBackColor = true;
            this.buttonCloseWindow.Click += new System.EventHandler(this.buttonCloseWindow_Click);
            // 
            // buttonRefresh
            // 
            resources.ApplyResources(this.buttonRefresh, "buttonRefresh");
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonRunCalc
            // 
            resources.ApplyResources(this.buttonRunCalc, "buttonRunCalc");
            this.buttonRunCalc.Name = "buttonRunCalc";
            this.buttonRunCalc.UseVisualStyleBackColor = true;
            this.buttonRunCalc.Click += new System.EventHandler(this.buttonRunCalc_Click);
            // 
            // groupBoxRunningProcesses
            // 
            this.groupBoxRunningProcesses.Controls.Add(this.StartedAssemblies);
            resources.ApplyResources(this.groupBoxRunningProcesses, "groupBoxRunningProcesses");
            this.groupBoxRunningProcesses.Name = "groupBoxRunningProcesses";
            this.groupBoxRunningProcesses.TabStop = false;
            // 
            // groupBoxAvailableBuilds
            // 
            this.groupBoxAvailableBuilds.Controls.Add(this.AvailableAssemblies);
            resources.ApplyResources(this.groupBoxAvailableBuilds, "groupBoxAvailableBuilds");
            this.groupBoxAvailableBuilds.Name = "groupBoxAvailableBuilds";
            this.groupBoxAvailableBuilds.TabStop = false;
            // 
            // AvailableAssemblies
            // 
            this.AvailableAssemblies.FormattingEnabled = true;
            resources.ApplyResources(this.AvailableAssemblies, "AvailableAssemblies");
            this.AvailableAssemblies.Name = "AvailableAssemblies";
            this.AvailableAssemblies.SelectedIndexChanged += new System.EventHandler(this.AvailableAssemblies_SelectedIndexChanged);
            // 
            // ProcessManipulation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxAvailableBuilds);
            this.Controls.Add(this.groupBoxRunningProcesses);
            this.Controls.Add(this.buttonRunCalc);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonCloseWindow);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Name = "ProcessManipulation";
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

