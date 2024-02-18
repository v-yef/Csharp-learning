/*
 ============================================================================
 Name        : Homework_15-Task_3
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a “runaway element” application. The idea is as follows:
               a control element is located on the form and the user moves the
               mouse cursor to the element, and if the cursor is close enough
               to it, the element "runs away". Implement the run movement within
               the form only.
 ============================================================================
 */

using System;
using System.Windows.Forms;

namespace Task_3
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
