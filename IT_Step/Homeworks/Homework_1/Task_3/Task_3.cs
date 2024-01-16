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
    internal static class Task_3
    {
        static void Main(string[] args)
        {
            Console.Write("1st digit to form a number. ");
            sbyte? digit1 = UserInputProcessor.GetDigitFromUser();
            if (digit1 is null)
            {
                return;
            }

            Console.Write("2nd digit to form a number. ");
            sbyte? digit2 = UserInputProcessor.GetDigitFromUser();
            if (digit2 is null)
            {
                return;
            }

            Console.Write("3rd digit to form a number. ");
            sbyte? digit3 = UserInputProcessor.GetDigitFromUser();
            if (digit3 is null)
            {
                return;
            }

            Console.Write("4th digit to form a number. ");
            sbyte? digit4 = UserInputProcessor.GetDigitFromUser();
            if (digit4 is null)
            {
                return;
            }

            Console.WriteLine(
                $"The result is: {NumberMaker.MakeNumberOfFourDigits(
                    digit1.Value,
                    digit2.Value,
                    digit3.Value,
                    digit4.Value)}");
        }
    }
}
