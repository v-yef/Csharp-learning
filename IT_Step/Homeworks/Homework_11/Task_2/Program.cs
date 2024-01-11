/*
 ============================================================================
 Name        : Homework_11-Task_2
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create an extension method to count the number of words in a line.
               Write the code to test the method.
 ============================================================================
 */

namespace Task_2
{
    static class Extension
    {
        public static int WordNumber(this string _String)
        {
            string[] Words = _String.Split(" ,.!?'\";:@#$%^&*()+=<>/1234567890".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return Words.Length;
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку :");

            string InputString = Console.ReadLine();

            Console.WriteLine($"Количество слов в строке : {InputString.WordNumber()}");

            Console.ReadLine();
        }
    }
}
