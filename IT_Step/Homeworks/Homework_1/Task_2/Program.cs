/*
 ============================================================================
 Name        : Homework_1-Task_2
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : The user enters two double numbers. The first number is the value,
               the second number is the percentage, which must be calculated.
               For example, if 90 and 10 were entered, the program calculates and
               displays 10% of 90 as "The result is: 9".
 ============================================================================
 */

namespace Task_2
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.Write("The number to get a percentage of. ");
            double? number = UserInputProcessor.GetDoubleFromUser();
            if (number is null)
            {
                return;
            }

            Console.Write("The percentage to calculate. ");
            double? percentage = UserInputProcessor.GetDoubleFromUser();
            if (percentage is null)
            {
                return;
            }

            Console.WriteLine("The result is: " +
                UserInputProcessor.CalculatePercentOfNumber(number.Value, percentage.Value));
        }
    }
}
