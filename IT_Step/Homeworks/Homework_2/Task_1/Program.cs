/*
 ============================================================================
 Name        : Homework_2-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Declare a one-dimensional (5 elements) array named A and a two-dimensional array (3 rows, 4 columns) of fractional numbers named B.
Fill one-dimensional array A with numbers entered from the keyboard by the user, and two-dimensional array B with random numbers using
cycles Display the values of arrays on the screen: array A — in one line, array B — in the form of a matrix. Find the common in these arrays
maximum element, minimum element, total sum of all elements, total product of all elements, sum of even elements
array A, the sum of odd columns of array B.
 ============================================================================
 */

namespace Task_1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            // Одномерный массив А
            int[] A = new int[5];

            // Заполнение массива А с клавиатуры
            for (int i = 0; i < A.Length; i++)
            {
                Console.WriteLine("Введите " + (i + 1) + "-й элемент массива: ");

                A[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Вывод массива А
            Console.WriteLine("Массив A :");

            foreach (var item in A)
                Console.Write(item + " ");

            Console.WriteLine();

            Console.WriteLine("Макс. элемент массива A : " + A.Max());

            Console.WriteLine("Мин. элемент массива A : " + A.Min());

            Console.WriteLine("Сумма элементов массива A : " + A.Sum());

            // Нахождение произведения всех элеметов массива А
            int multi_res = 1;

            foreach (var item in A)
                multi_res *= item;

            Console.WriteLine("Произведение элементов массива A : " + multi_res);

            Console.WriteLine("Сумма четных элементов массива A : " + A.Where(i => A[i - 1] % 2 == 0).Sum());

            Console.WriteLine();

            //======================================================================================

            // Двумерный массив В
            float[,] B = new float[3, 4];

            // Заполнение массива B случайными числами
            Random random = new Random();

            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    // NextDouble() - случайное число от 0 до 1 типа double
                    // Для удобства отображения округляется до 3 знаков после запятой
                    // при помощи Math.Round() и умножается на 100 
                    B[i, j] = Convert.ToSingle(Math.Round(random.NextDouble(), 3) * 100);

            // Вывод массива В
            Console.WriteLine("Массив В :");

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                    Console.Write(B[i, j] + " ");

                Console.WriteLine();
            }

            // Нахождение максимального элемета массива В
            float max_B = B[0, 0];

            foreach (var item in B)
                if (item.CompareTo(max_B) > 0)
                    max_B = item;

            Console.WriteLine("Макс. элемент массива B : " + max_B);

            // Нахождение минимального элемета массива В
            float min_B = B[0, 0];

            foreach (var item in B)
                if (item.CompareTo(min_B) < 0)
                    min_B = item;

            Console.WriteLine("Мин. элемент массива B : " + min_B);

            // Нахождение суммы элеметов массива В
            float sum_B = 0;

            foreach (var item in B)
                sum_B += item;

            Console.WriteLine("Сумма элементов массива B : " + sum_B);

            // Нахождение произведения элеметов массива В
            float multi_B = 1;

            foreach (var item in B)
                multi_B *= item;

            Console.WriteLine("Произведение элементов массива B : " + multi_B);

            // Нахождение суммы нечетных столбцов массива В
            float sum_B_spec = 0;

            for (int i = 0; i < B.GetLength(0); i++)
                for (int j = 0; j < B.GetLength(1); j++)
                    if (j % 2 == 0)
                        sum_B_spec += B[i, j];

            Console.WriteLine("Сумма нечетных столбцов массива B : " + sum_B_spec);

            Console.ReadLine();
        }
    }
}
