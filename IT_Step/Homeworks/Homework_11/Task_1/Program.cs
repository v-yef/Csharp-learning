/*
 ============================================================================
 Name        : Homework_11-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create an extension method to check whether an integer is a Fibonacci number.
               Write the code to test the method.
 ============================================================================
 */

namespace Task_1
{
    static class Extension
    {
        public static bool IsFibonacci(this int _Number)
        {
            // Википедия: Натуральное число N является числом Фибоначчи тогда и только тогда,
            // когда (5*N)^2 + 4 или (5*N)^2 - 4 является квадратом.

            // Если число является квадратом, то корень от такого числа будет целым числом и остаток от деления его на 1 будет 0.
            // Согласно формуле должно сработать одно из условий
            return (Math.Sqrt(5 * Math.Pow(_Number, 2.0) + 4) % 1 == 0) ||
                    (Math.Sqrt(5 * Math.Pow(_Number, 2.0) - 4) % 1 == 0);
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Числа Фибоначчи для отрицательного поддиапазона :");

            int Current = 0;
            int FirstPrevious = 1;
            int SecondPrevious = 0;

            for (int i = 0; i > -1000000; i--)
            {
                SecondPrevious = Current;
                Current = FirstPrevious;
                FirstPrevious += SecondPrevious;

                if (Current.IsFibonacci() == true)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(Current);
                    }
                    else
                    {
                        Console.WriteLine(-Current);
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Числа Фибоначчи для положительного поддиапазона :");

            Current = 0;
            FirstPrevious = 1;
            SecondPrevious = 0;

            for (int i = 0; i < 1000000; i++)
            {
                SecondPrevious = Current;
                Current = FirstPrevious;
                FirstPrevious += SecondPrevious;

                if (Current.IsFibonacci() == true)
                {
                    Console.WriteLine(Current);
                }
            }

            Console.ReadLine();
        }
    }
}
