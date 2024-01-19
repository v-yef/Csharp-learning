/*
 ============================================================================
 Name        : Homework_2-Task_4
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : User enters text with a keyboard. The application must display
               the first letter of each sentence uppercased.
               For example, if the user entered:
               today is a good day for walking. i will try to walk near the sea.
               The result must be:
               Today is a good day for walking. I will try to walk near the sea.
 ============================================================================
 */

namespace Task_4
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string: ");

            string? inputStr = Console.ReadLine();

            if (inputStr is null)
            {
                return;
            }

            for (int i = 0; i < inputStr.Length; i++)
            {
                // The first letter is displayed in uppercase.
                if (i == 0)
                {
                    Console.Write(char.ToUpper(inputStr[i]));
                }                 
                // The first letter after whitespace or period is displayed in uppercase, too.
                else if (((i - 1) is > 0) && (inputStr[i - 2] == '.'))
                {
                    Console.Write(char.ToUpper(inputStr[i]));
                }
                // Display letters as they are in all other cases.
                else
                {
                    Console.Write(inputStr[i]);
                }          
            }

            Console.ReadLine();
        }
    }
}
