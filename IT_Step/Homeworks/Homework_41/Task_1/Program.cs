/*
 ============================================================================
 Name        : Homework_41-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create an application that starts a child process and waits
               untill it is complete. When the child process is complete, the
               parent application must display the exit code.
 ============================================================================
 */

namespace Task_1
{
    internal static class Program
    {
        static void Main()
        {
            ProcessManager.Work();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
