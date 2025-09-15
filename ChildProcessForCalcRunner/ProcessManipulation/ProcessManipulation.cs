using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProcessManipulation
{
    public partial class ProcessManipulation : Form
    {
        //константа, идентифицирующая сообщение WM_SETTEXT
        const uint WM_SETTEXT = 0x0C;
        //импортируем функцию SendMEssage из библиотеки user32.dll
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, uint Msg, int wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);
        //список, в котором будут храниться объекты, описывающие дочерние процессы приложения
        List<Process> Processes = new List<Process>();
        //счётчик запущенных процессов
        int Counter = 0;

        public ProcessManipulation()
        {
            InitializeComponent();
            LoadAvailableAssemblies();
            this.FormClosing += ProcessManipulation_FormClosing;
        }

        //метод, загружающий доступные исполняемые файлы из домашней директории проекта
        void LoadAvailableAssemblies()
        {
            //название файла сборки текущего приложения
            string except = new FileInfo(Application.ExecutablePath).Name;
            //получаем название файла без расширения
            except = except.Substring(0, except.IndexOf("."));
            //получаем все *.exe файлы из домашней директории
            string[] files = Directory.GetFiles(Application.StartupPath, "*.exe");
            foreach (var file in files)
            {
                //получаем имя файла
                string fileName = new FileInfo(file).Name;
                //если имя файла не содержит имени исполняемого файла проекта, то оно добавляется в список
                if (fileName.IndexOf(except) == -1)
                {
                    AvailableAssemblies.Items.Add(fileName);
                }
            }
        }

        //метод, запускающий процесс на исполнение и сохраняющий объект, который его описывает
        void RunProcess(string AssamblyName)
        {
            //запускаем процесс на соновании исполняемого файла
            Process proc = Process.Start(AssamblyName);
            //добавляем процесс в список
            Processes.Add(proc);
            //проверяем, стал ли созданный процесс дочерним, по отношению к текущему и, если стал, выводим MessageBox
            if (Process.GetCurrentProcess().Id == GetParentProcessId(proc.Id))
            {
                MessageBox.Show(proc.ProcessName + " действительно дочерний процесс текущего процесса!");
            }
            //указываем, что процесс должен генерировать события
            proc.EnableRaisingEvents = true;
            //добавляем обработчик на событие завершения процесса
            proc.Exited += proc_Exited;
            //устанавливаем новый текст главному окну дочернего процесса
            SetChildWindowText(proc.MainWindowHandle, "Child process #" + (++Counter));
            //проверяем, запускали ли мы экземпляр такого приложения и, если нет, то добавляем в список запущенных приложений
            if (!StartedAssemblies.Items.Contains(proc.ProcessName))
            {
                StartedAssemblies.Items.Add(proc.ProcessName);
            }
            //убираем приложение из списка доступных приложений
            AvailableAssemblies.Items.
            Remove(AvailableAssemblies.SelectedItem);
        }
        //метод обёртывания для отправки сообщения WM _ SETTEXT
        void SetChildWindowText(IntPtr Handle, string text)
        {
            SendMessage(Handle, WM_SETTEXT, 0, text);
        }
        //метод, получающий PID родительского процесса (использует WMI)
        int GetParentProcessId(int Id)
        {
            int parentId = 0;
            using (ManagementObject obj = new ManagementObject("win32_process.handle=" + Id.ToString()))
            {
                obj.Get();
                parentId = Convert.
                 ToInt32(obj["ParentProcessId"]);
            }
            return parentId;
        }
        //обработчик события Exited класса Process
        void proc_Exited(object sender, EventArgs e)
        {
            Process proc = sender as Process;
            if (proc == null || string.IsNullOrEmpty(proc.ProcessName)) return;

            // Переключаемся в UI-поток
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => proc_Exited(sender, e)));
                return;
            }

            // Убираем из списка запущенных
            if (StartedAssemblies.Items.Contains(proc.ProcessName))
            {
                StartedAssemblies.Items.Remove(proc.ProcessName);
            }

            // Добавляем в список доступных
            if (!AvailableAssemblies.Items.Contains(proc.ProcessName))
            {
                AvailableAssemblies.Items.Add(proc.ProcessName);
            }

            // Удаляем из списка отслеживаемых процессов
            Processes.Remove(proc);
            Counter = Math.Max(0, Counter - 1); // защита от отрицательных значений

            // Обновляем заголовки оставшихся процессов
            int index = 0;
            foreach (var p in Processes)
            {
                if (p != null && p.MainWindowHandle != IntPtr.Zero)
                {
                    SetChildWindowText(p.MainWindowHandle, "Child process #" + (++index));
                }
            }
        }
        //объявление делегата, принимающего параметр типа Process
        delegate void ProcessDelegate(Process proc);
        //метод, который выполняет проход по всем дочерним процессам с заданым именем и выполняющий для этих процессов заданый делегатом метод
        void ExecuteOnProcessesByName(string ProcessName, ProcessDelegate func)
        {
            //получаем список, запущенных в операционной системе процессов
            Process[] processes = Process.GetProcessesByName(ProcessName);
            foreach (var process in processes)
            {
                //если PID родительского процесса равен PID текущего процесса
                if (Process.GetCurrentProcess().Id == GetParentProcessId(process.Id))
                {
                    func(process); //запускаем метод
                }
            }
        }
        //обработчик события нажатия на кнопку Start основного диалога
        private void buttonStart_Click(object sender, EventArgs e)
        {
            RunProcess(AvailableAssemblies.SelectedItem.ToString());
        }
        void Kill(Process proc)
        {
            proc.Kill();
        }
        //обработчик события нажатия на кнопку Stop основного диалога
        private void buttonStop_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(StartedAssemblies.SelectedItem.ToString(), Kill);
            StartedAssemblies.Items.Remove(StartedAssemblies.SelectedItem);
        }
        void CloseMainWindow(Process proc)
        {
            proc.CloseMainWindow();
        }
        //обработчик события нажатия на кнопку Close основного диалога
        private void buttonCloseWindow_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(StartedAssemblies.SelectedItem.ToString(), CloseMainWindow);
            StartedAssemblies.Items.Remove(StartedAssemblies.SelectedItem);
        }
        void Refresh(Process proc)
        {
            proc.Refresh();
        }
        //обработчик события нажатия на кнопку Refresh основного диалога
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(StartedAssemblies.SelectedItem.ToString(), Refresh);
        }
        //обработчик события изменения индекса выделенного элемента в списке доступных приложений
        private void AvailableAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AvailableAssemblies.SelectedItems.Count == 0)
                buttonStart.Enabled = false;
            else
                buttonStart.Enabled = true;
        }
        //обработчик события изменения индекса выделенного элемента в списке запущенных приложений
        private void StartedAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StartedAssemblies.SelectedItems.Count == 0)
            {
                buttonStop.Enabled = false;
                buttonRefresh.Enabled = false;
                buttonCloseWindow.Enabled = false;
            }
            else
            {
                buttonStop.Enabled = true;
                buttonRefresh.Enabled = true;
                buttonCloseWindow.Enabled = true;
            }
        }
        //обработчик события закрытия основного окна приложения
        private void ProcessManipulation_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var proc in Processes)
            {
                proc.Kill();
            }
        }
        //обработчик события нажатия на кнопку "Run Calc"
        private void buttonRunCalc_Click(object sender, EventArgs e)
        {
            RunProcess("calc.exe");
        }
    }
}