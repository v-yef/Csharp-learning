/*
 ============================================================================
 Name        : Homework_41-Task_4
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create an application that starts a child process and passes
               command line arguments to it. The arguments are the path to the
               file and the word to search for inside it, as follows:
               E:\someFolder\someFile.txt word. The child process must display
               the number of times the word 'word' occurs in the file.
 ============================================================================
 */

namespace Task_4
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
