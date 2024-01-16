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
    internal static class Program
    {
        static void Main(string[] args)
        {
            int? userNum = UserInputProcessor.GetIntegerFromUserInRange(0, 100);
            if (userNum is null)
            {
                return;
            }

            Console.WriteLine(UserInputProcessor.MakeMessageBasedOnIntegerInput(userNum.Value));
        }
    }
}
