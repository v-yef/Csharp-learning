/*
 ==============================================================================
 Name        : Homework_15-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Imagine that you have a rectangle on your form, the borders of
               which are 10 pixels away from the borders of the form. You must
               create handlers for:
               - left mouse button click, that displays a message about where
               the current point is: inside the rectangle, outside, on the
               border of the rectangle. If the left mouse button was pressed
               with a Control (Ctrl) key, the application should close.
               - right mouse button click, which displays information about the
               size of the working area in the window title: Width = x,
               Height = y, where x and y are the corresponding parameters of
               the window.
               - moving a mouse pointer within the working area, which should
               output current mouse coordinates x and y to the window title.
 ==============================================================================
 */

using System;
using System.Windows.Forms;

namespace Task_1
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
