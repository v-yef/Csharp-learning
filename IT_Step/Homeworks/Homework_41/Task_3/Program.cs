/*
 ============================================================================
 Name        : Homework_41-Task_3
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create an application that starts a child process and passes
               command line arguments to it. The arguments are two numbers and
               a math operation sign, as follows: 7 3 +. The child process must
               display the arguments and the result of operation '10'.
 ============================================================================
 */

namespace Task_3
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
