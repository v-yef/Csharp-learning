/*
 ============================================================================
 Name        : Homework_15-Task_2
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a winform application with following functionality:
                - The user clicks on the form with the left mouse button and
                moves the mouse over the form holding the button. When the
                button is released a rectangle must be drawn, according to the
                start and final coordinates of such movement. The rectangle must
                contain a serial number (the order of its appearance on the form).
                - The minimal rectangle size is 10×10. If user tries to create
                an element of smaller size, a corresponding warning is shown.
                - When user right-clicks over the rectangle surface, the program
                displays the information about the rectangle (its area and
                coordinates) in the window title. If there are several rectangles,
                then the preference is given to the one with the highest serial
                number.
                - When user double-clicks the left mouse button over the rectangle
                surface, it must disappear from the form. If there are several
                rectangles at the click point, then the preference is given to
                the one with the lowest serial number.
 ============================================================================
 */

using System;
using System.Windows.Forms;

namespace Task_2
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
