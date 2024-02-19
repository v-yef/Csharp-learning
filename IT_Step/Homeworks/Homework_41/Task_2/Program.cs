/*
 ============================================================================
 Name        : Homework_41-Task_2
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create an application that starts a child process. Depending on 
               user's choice the application must wait untill the child process
               is complete or terminate the child process. The exit code must
               be displayed afterwards.
 ============================================================================
 */

namespace Task_2
{
    internal static class Program
    {
        static void Main()
        {
            var processManager = new ProcessManager();
            processManager.Work();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
