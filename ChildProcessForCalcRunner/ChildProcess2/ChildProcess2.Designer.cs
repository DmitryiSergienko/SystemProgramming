namespace ChildProcess2
{
    partial class ChildProcess2
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
            this.labelProcess2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelProcess2
            // 
            this.labelProcess2.AutoSize = true;
            this.labelProcess2.Location = new System.Drawing.Point(50, 52);
            this.labelProcess2.Name = "labelProcess2";
            this.labelProcess2.Size = new System.Drawing.Size(129, 25);
            this.labelProcess2.TabIndex = 1;
            this.labelProcess2.Text = "Process №2";
            // 
            // ChildProcess2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 129);
            this.Controls.Add(this.labelProcess2);
            this.Name = "ChildProcess2";
            this.Text = "Child Process 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProcess2;
    }
}

