/*
 ============================================================================
 Name        : Homework_11-Task_3
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create an extension method to calculate the length of the last
               word in a string. Write a program to test the method.
 ============================================================================
 */

namespace Task_3
{
    static class Extension
    {
        public static int LastWordLength(this string _String)
        {
            string[] Words = _String.Split(
                " ,.!?'\";:@#$%^&*()+=<>/1234567890".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);

            string LastWord = Words.Last();

            return LastWord.Length;
        }

        internal static class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Введите строку :");

                string InputString = Console.ReadLine();

                Console.WriteLine($"Длина последнего слова : {InputString.LastWordLength()}");

                Console.ReadLine();
            }
        }
    }
}
