using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        public static extern IntPtr SendMessage(IntPtr hwnd, uint Msg, int wParam,
        [MarshalAs(UnmanagedType.LPStr)] string lParam);
        //список, в котором будут храниться объекты, описывающие дочерние процессы приложения
        List<Process> Processes = new List<Process>();
        //счётчик запущенных процессов
        int Counter = 0;

        public ProcessManipulation()
        {
            InitializeComponent();
            LoadAvailableAssemblies();
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
                //если имя файла не содержит имени исполняемого файла проекта,
                //то оно добавляется в список
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
            //проверяем, стал ли созданный процесс дочерним, по отношению к текущему и,
            //если стал, выводим MessageBox
            if (Process.GetCurrentProcess().Id == GetParentProcessId(proc.Id))
            {
                MessageBox.Show(proc.ProcessName + " действительно дочерний процесс текущего процесса!");
            }
            //указываем, что процесс должен генерировать события
            proc.EnableRaisingEvents = true;
            //добавляем обработчик на событие завершения процесса
            proc.Exited += proc.Exited;
            //устанавливаем новый текст главному окну дочернего процесса
            SetChildWindowText(proc.MainWindowHandle, "Child process #" + (++Counter));
            //проверяем, запускали ли мы экземпляр такого приложения и, если нет,
            //то добавляем в список запущенных приложений
            if (!StartedAssemblies.Items.Contains(proc.ProcessName))
            {
                StartedAssemblies.Items.Add(proc.ProcessName);
            }
            //убираем приложение из списка доступных приложений
            AvailableAssemblies.Items.
            Remove(AvailableAssemblies.SelectedItem);
        }
    }
}