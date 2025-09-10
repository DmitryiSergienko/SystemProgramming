using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CalcRunner
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            myProcess = new Process();
            //myProcess.StartInfo = new ProcessStartInfo("calc.exe");
            myProcess.StartInfo = new ProcessStartInfo("D:\\Programs\\7-Zip\\7zFM.exe");
            myProcess.Start();
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            if (myProcess == null || myProcess.HasExited)
            {
                MessageBox.Show("Процесс уже завершён.");
                return;
            }

            myProcess.CloseMainWindow();

            myProcess.WaitForExit();
            MessageBox.Show("Код завершения: " + myProcess.ExitCode.ToString());

            myProcess.Close();
            myProcess = null;
        }
    }
}
