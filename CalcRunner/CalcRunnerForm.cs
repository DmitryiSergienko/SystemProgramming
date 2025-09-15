using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace CalcRunner
{
    public partial class CalcRunnerForm : Form
    {
        
        public CalcRunnerForm()
        {
            InitializeComponent();
            myProcess = null;

            UpdateResultButtonState();
            UpdateClearButtonState();
            UpdateSearchButtonState();
            UpdateClearWordButtonState();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (myProcess == null)
            {
                myProcess = new Process();
                //myProcess.StartInfo = new ProcessStartInfo("calc.exe");
                myProcess.StartInfo = new ProcessStartInfo("D:\\Programs\\7-Zip\\7zFM.exe");
                myProcess.Start();
            }
        }
        private void StopWithCodeButton_Click(object sender, EventArgs e)
        {
            if (myProcess == null || myProcess.HasExited)
            {
                MessageBox.Show("Процесс уже завершён.");
                return;
            }

            myProcess.CloseMainWindow();

            if (!myProcess.WaitForExit(5000))
            {
                myProcess.Kill();  
                myProcess.WaitForExit();
            }
            MessageBox.Show("Код завершения: " + myProcess.ExitCode.ToString());

            myProcess.Close();
            myProcess = null;
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            if (myProcess != null && !myProcess.HasExited)
            {
                myProcess.CloseMainWindow();
                if (!myProcess.WaitForExit(3000))
                {
                    myProcess.Kill();
                    myProcess.WaitForExit();
                }
                myProcess?.Close();
                myProcess = null;
            }
        }
        private void ResultButton_Click(object sender, EventArgs e)
        {
            try
            {
                string first = FirstNumTextBox.Text;
                string second = SecondNumTextBox.Text;
                string operation = OperationComboBox.Text;

                if (string.IsNullOrEmpty(operation) || !"+-*/".Contains(operation))
                {
                    MessageBox.Show("Выберите операцию!");
                    return;
                }

                var process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = @"..\..\CustomCulc\bin\Debug\net9.0\CustomCulc.exe",
                    Arguments = $"{first} {second} {operation}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(error))
                {
                    MessageBox.Show("Ошибка: " + error.Trim());
                    return;
                }

                if (!string.IsNullOrWhiteSpace(output))
                {
                    ResultLabel.Text = output.Trim();
                }
                else
                {
                    MessageBox.Show("Процесс не вернул результат.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        private void FirstNumTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и клавишу Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // отменяем ввод этого символа
            }
        }
        private void SecondNumTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и клавишу Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // отменяем ввод этого символа
            }
        }
        private void FirstNumTextBox_TextChanged(object sender, EventArgs e) { 
            UpdateResultButtonState(); 
            UpdateClearButtonState(); 
        }
        private void SecondNumTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateResultButtonState();
            UpdateClearButtonState();
        }
        private void UpdateResultButtonState()
        {
            ResultButton.Enabled = FirstNumTextBox.Text.Length > 0 && SecondNumTextBox.Text.Length > 0;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            FirstNumTextBox.Clear();
            SecondNumTextBox.Clear();
            OperationComboBox.ResetText();
            ResultLabel.ResetText();

            UpdateClearButtonState();
        }
        private void UpdateClearButtonState()
        {
            ClearButton.Enabled = FirstNumTextBox.Text.Length > 0 || 
                SecondNumTextBox.Text.Length > 0 || OperationComboBox.Text.Length > 0;
        }
        private void OperationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateClearButtonState();
        }
        private void OperationComboBox_TextChanged(object sender, EventArgs e)
        {
            UpdateClearButtonState();
        }
        private void UpdateSearchButtonState()
        {
            SearchWordButton.Enabled = AddressFileTextBox.Text.Length > 0 && WordTextBox.Text.Length > 0;
        }
        private void UpdateClearWordButtonState()
        {
            ClearWordButton.Enabled = AddressFileTextBox.Text.Length > 0 || WordTextBox.Text.Length > 0;
        }
        private void AddressFileTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSearchButtonState();
            UpdateClearWordButtonState();
        }
        private void WordTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateSearchButtonState();
            UpdateClearWordButtonState();
        }
        private void SearchWordButton_Click(object sender, EventArgs e)
        {
            try
            {
                string path = AddressFileTextBox.Text;
                string word = WordTextBox.Text;
                if (string.IsNullOrEmpty(path)) 
                {
                    MessageBox.Show("Заполните поля!");
                    return;
                }

                var process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
                    FileName = @"..\..\SearchWord\bin\Debug\net9.0\SearchWord.exe",
                    Arguments = $"{path} {word}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(error))
                {
                    MessageBox.Show("Ошибка: " + error.Trim());
                    return;
                }

                if (!string.IsNullOrWhiteSpace(output))
                {
                    CountLabel.Text = output.Trim();
                }
                else
                {
                    MessageBox.Show("Процесс не вернул результат.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        private void ClearWordButton_Click(object sender, EventArgs e)
        {
            AddressFileTextBox.Clear();
            WordTextBox.Clear();
            CountLabel.ResetText();

            UpdateSearchButtonState();
        }
    }
}