/*
 ============================================================================
 Name        : Homework_41-Task_3_Calculator
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : A simple calculator program for using as a child process in
               Homework_41-Task_3.
 ============================================================================
 */

namespace Task_3_Calculator
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 3)
            {
                if (Int32.TryParse(args[0], out int num1) &&
                    Int32.TryParse(args[1], out int num2) &&
                    Char.TryParse(args[2], out char sign))
                {
                    switch (sign)
                    {
                        case '+':
                            Console.WriteLine($"\n{num1} + {num2} = {num1 + num2}");
                            break;
                        case '-':
                            Console.WriteLine($"\n{num1} - {num2} = {num1 - num2}");
                            break;
                        case '*':
                            Console.WriteLine($"\n{num1} * {num2} = {num1 * num2}");
                            break;
                        case '/':
                            if (num2 == 0)
                            {
                                Console.WriteLine("\nDivision by zero is impossible!");
                            }
                            else
                            {
                                Console.WriteLine($"\n{num1} + {num2} = {num1 + num2}");
                            }
                            break;
                        default:
                            Console.WriteLine("\nPassed operation is incorrect!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nPassed arguments are incorrect!");
                }

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
