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

using System.Globalization;

namespace Task_2
{
    public static class UserInputProcessor
    {
        public static double CalculatePercentPartOfNumber(double number, double percent) =>
            Math.Abs(Math.Round(number * percent / 100, 6));
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number to get a percentage of:");
            bool isNumberGood = double.TryParse(
                Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double number);

            Console.WriteLine("Enter the percentage to calculate:");
            bool isPercentGood = double.TryParse(
                Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out double percent);

            if (isNumberGood && isPercentGood)
            {
                Console.WriteLine(
                    $"The result is: {UserInputProcessor.CalculatePercentPartOfNumber(number, percent)}");
            }
            else
            {
                Console.WriteLine("Entered data was not valid!");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}
