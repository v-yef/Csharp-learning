/*
 ============================================================================
 Name        : Homework_40-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Write a program, that uses legacy code. You need to use the
               MessageBox function from the Windows API. Use MessageBox to
               display information about you. This data should be displayed in
               multiple MessageBoxes.
 ============================================================================
 */

using System.Runtime.InteropServices;

namespace Task_1
{
    internal static class ExternalFunctions
    {
        public const uint MB_OK = 0x00000000;
        public const uint MB_ICONINFO = 0x00000040;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);
    }

    internal static class MessageBox
    {
        public static int Show(string message, string title, uint type) =>
            ExternalFunctions.MessageBox(IntPtr.Zero, message, title, type);
    }

    internal static class Program
    {
        static void Main()
        {
            MessageBox.Show(
                "My Surname", "Information", ExternalFunctions.MB_OK | ExternalFunctions.MB_ICONINFO);
            MessageBox.Show(
                "My Name", "Information", ExternalFunctions.MB_OK | ExternalFunctions.MB_ICONINFO);
            MessageBox.Show(
                "My Patronim", "Information", ExternalFunctions.MB_OK | ExternalFunctions.MB_ICONINFO);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
