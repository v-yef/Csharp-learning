/*
 ============================================================================
 Name        : Homework_41-Task_4_WordCounter
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : A simple word counter program for using as a child process in
               Homework_41-Task_4.
 ============================================================================
 */

using System.Text.RegularExpressions;

namespace Task_4_WordCounter
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                string filePath = args[0];
                string word = args[1];

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("\nFile doesn't exist!");
                    return;
                }

                string buffer = File.ReadAllText(filePath);
                int count = Regex.Matches(buffer, $@"{word}").Count;

                Console.WriteLine($"\nThe word {word} was found {count} times.");
            }
            else
            {
                Console.WriteLine("\nIncorrect number of arguments!");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
