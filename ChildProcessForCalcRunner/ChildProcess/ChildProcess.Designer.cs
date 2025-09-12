namespace ChildProcess
{
    partial class ChildProcess
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
            this.labelProcess1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelProcess1
            // 
            this.labelProcess1.AutoSize = true;
            this.labelProcess1.Location = new System.Drawing.Point(40, 49);
            this.labelProcess1.Name = "labelProcess1";
            this.labelProcess1.Size = new System.Drawing.Size(129, 25);
            this.labelProcess1.TabIndex = 0;
            this.labelProcess1.Text = "Process №1";
            // 
            // ChildProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 129);
            this.Controls.Add(this.labelProcess1);
            this.Name = "ChildProcess";
            this.Text = "Child Process";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProcess1;
    }
}

