﻿using System;
using System.Windows.Forms;

namespace ChildProcess2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChildProcess2());
        }
    }
}