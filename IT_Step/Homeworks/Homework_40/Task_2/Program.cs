/*
 ============================================================================
 Name        : Homework_40-Task_2
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Write a program, that uses legacy code. You need to use the
               FindWindow and SendMessage functions from the Windows API. The
               application must search for the window of your application (it
               can be implemented using Windows Forms, etc.). If the window is
               found, the following message must be sent to it depending on the
               user's choice:
                - change the window title to the one entered by user,
                - close the window.
 ============================================================================
 */

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Task_2
{
    internal static class ExternalFunctions
    {
        public const uint WM_SETTEXT = 0x000C;
        public const uint WM_CLOSE = 0x0010;

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(
            IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(
            IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);
    }

    internal class WindowProcessor
    {
        public void DoWork()
        {
            IntPtr windowHandler = this.GetWindowHandler("Test Window");

            if (windowHandler != IntPtr.Zero)
            {
                Console.WriteLine("Window was found. Choose action:");

                int choice = Menu.VerticalMenu(new string[]{"Change window header",
                                                "Close window",
                                                "Exit program" },
                                                ConsoleColor.White, ConsoleColor.Black, 0, 2);
                Console.Clear();

                switch (choice)
                {
                    case 0:
                        sendMessageChangeWindowHeader(windowHandler);
                        break;
                    case 1:
                        sendMessageWindowClose(windowHandler);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Window was not found. Press any key to exit...");
                Console.Read();
            }
        }

        private IntPtr GetWindowHandler(string windowName) =>
            ExternalFunctions.FindWindowByCaption(IntPtr.Zero, windowName);

        private void sendMessageChangeWindowHeader(IntPtr windowHandler)
        {
            Console.Write("Enter header: ");
            string header = Console.ReadLine();

            StringBuilder stringBuilder = new StringBuilder(header);

            IntPtr result = ExternalFunctions.SendMessage(
                windowHandler, ExternalFunctions.WM_SETTEXT, IntPtr.Zero, stringBuilder);

            if (result != IntPtr.Zero)
            {
                Console.WriteLine("The window header was changed. Check the window.");
            }
            else
            {
                Console.WriteLine("Something went wrong. The header was not changed.");
            }
        }

        private void sendMessageWindowClose(IntPtr windowHandler)
        {
            IntPtr result = ExternalFunctions.SendMessage(
                windowHandler, ExternalFunctions.WM_CLOSE, IntPtr.Zero, null);

            if (result == IntPtr.Zero)
            {
                Console.WriteLine("The window was closed. Check the window.");
            }
            else
            {
                Console.WriteLine("Something went wrong. The window was not closed.");
            }
        }
    }

    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var winForm = new WinForm();
            winForm.Show();

            var windowProcessor = new WindowProcessor();
            windowProcessor.DoWork();

            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }
    }
}
