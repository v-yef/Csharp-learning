/*
 ============================================================================
 Name        : Homework_1-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : The user enters an int number in the [1..100] range. If the number
               is a multiple of 3 (divided by 3 with no remainder), the program
               outputs the word "Fizz". If the number is a multiple of 5, the
               output is "Buzz". If the number is a multiple of 3 and 5, the
               output is "Fizz Buzz". If the number is neither a multiple of
               3 nor 5, only the number is displayed. If the user enters a value
               not in the [1..100] range, an error message is displayed.
 ============================================================================
 */

namespace Task_1
{
    public static class UserInputProcessor
    {
        public static string CreateMessageBasedOnIntegerInput(int input)
        {
            string result;

            if (input < 1 || input > 100)
            {
                result = "Error! The number must be in the [1..100] range!";
            }
            else if (input % 3 == 0 && input % 5 == 0)
            {
                result = "Fizz Buzz";
            }
            else if (input % 5 == 0)
            {
                result = "Buzz";
            }
            else if (input % 3 == 0)
            {
                result = "Fizz";
            }
            else
            {
                result = input.ToString();
            }

            return result;
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter int number in the [1..100] range:");

            if (int.TryParse(Console.ReadLine(), out int inputNum))
            {
                Console.WriteLine(UserInputProcessor.CreateMessageBasedOnIntegerInput(inputNum));
            }
            else
            {
                Console.WriteLine("Entered data was not an int number!");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
