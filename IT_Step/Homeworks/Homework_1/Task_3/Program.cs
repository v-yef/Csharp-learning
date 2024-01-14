/*
 ============================================================================
 Name        : Homework_1-Task_3
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : The user enters four digits. The program must create a number
               containing these digits. For example, if 1, 5, 7, 8 were entered,
               the number 1578 must be formed.
 ============================================================================
 */

namespace Task_3
{
    public static class NumberCreator
    {
        public static int CreateNumberOfFourDigits(sbyte num1, sbyte num2, sbyte num3, sbyte num4)
        {
            bool isSigned = num1 < 0;

            int number = Math.Abs(num1);
            number = number * 10 + Math.Abs(num2);
            number = number * 10 + Math.Abs(num3);
            number = number * 10 + Math.Abs(num4);

            return isSigned ? (-number) : number;
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1st digit to form a number:");
            bool isNum1 = sbyte.TryParse(Console.ReadLine(), out sbyte digit1);

            Console.WriteLine("Enter 2nd digit to form a number:");
            bool isNum2 = sbyte.TryParse(Console.ReadLine(), out sbyte digit2);

            Console.WriteLine("Enter 3rd digit to form a number:");
            bool isNum3 = sbyte.TryParse(Console.ReadLine(), out sbyte digit3);

            Console.WriteLine("Enter 4th digit to form a number:");
            bool isNum4 = sbyte.TryParse(Console.ReadLine(), out sbyte digit4);

            if (isNum1 && isNum2 && isNum3 && isNum4)
            {
                Console.WriteLine(
                $"The result is: {NumberCreator.CreateNumberOfFourDigits(digit1, digit2, digit3, digit4)}");
            }
            else
            {
                if (!isNum1)
                {
                    Console.WriteLine("1st digit was not a number!");
                }

                if (!isNum2)
                {
                    Console.WriteLine("2nd digit was not a number!");
                }

                if (!isNum3)
                {
                    Console.WriteLine("3rd digit was not a number!");
                }

                if (!isNum4)
                {
                    Console.WriteLine("4th digit was not a number!");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}
