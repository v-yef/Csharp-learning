/*
 ============================================================================
 Name        : Homework_9-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a generic version of the Swap method to exchange the values of two variables.
 ============================================================================
 */

namespace Task_1
{
    class Swapper<T>
    {
        public static void Swap(ref T _Val_1, ref T _Val_2)
        {
            T Temp = _Val_1;
            _Val_1 = _Val_2;
            _Val_2 = Temp;

            return;
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ввод первого числа int : ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ввод второго числа int : ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Первое число int до swap : " + a);
            Console.WriteLine("Второе число int до swap : " + b);

            Swapper<int>.Swap(ref a, ref b);

            Console.WriteLine();
            Console.WriteLine("Первое число int после swap : " + a);
            Console.WriteLine("Второе число int после swap : " + b);

            Console.ReadLine();
        }
    }
}
