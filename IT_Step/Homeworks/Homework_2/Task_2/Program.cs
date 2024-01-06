/*
 ============================================================================
 Name        : Homework_2-Task_2
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Given a two-dimensional array of size 5×5, filled with random numbers from the range -100 to 100.
Determine the sum of array elements located between the minimum and maximum elements.
 ============================================================================
 */

namespace Task_2
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[5, 5];

            // Заполнение массива случайными числами
            Random random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = random.Next(-100, 100);

            // Вывод массива
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write(array[i, j] + " ");

                Console.WriteLine();
            }

            // Нахождение минимального элемента массива и его позиции
            int arr_Min = array[0, 0];
            int arr_Min_i = 0;
            int arr_Min_j = 0;

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j].CompareTo(arr_Min) < 0)
                    {
                        arr_Min = array[i, j];
                        arr_Min_i = i;
                        arr_Min_j = j;
                    }

            Console.WriteLine("Минимальный элемент " + arr_Min + " с координатами " + arr_Min_i + ", " + arr_Min_j);

            // Нахождение максимального элемента массива и его позиции
            int arr_Max = array[0, 0];
            int arr_Max_i = 0;
            int arr_Max_j = 0;

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j].CompareTo(arr_Max) > 0)
                    {
                        arr_Max = array[i, j];
                        arr_Max_i = i;
                        arr_Max_j = j;
                    }

            Console.WriteLine("Максимальный элемент " + arr_Max + " с координатами " + arr_Max_i + ", " + arr_Max_j);

            // Нахождение суммы элементов между наименьшим и наибольшим элементами
            int sum = 0;
            // Если минимальный элемент расположен раньше максимального, т.е. на строке с меньшим индексом
            if (arr_Min_i < arr_Max_i)
            {
                // Нахождение суммы элементов от меньшего элемента до конца строки, на которой он расположен
                for (int j = arr_Min_j + 1; j < array.GetLength(1); j++)
                    sum += array[arr_Min_i, j];

                // Нахождение суммы элементов на строках между меньшим и большим элементами
                for (int i = arr_Min_i + 1; i < arr_Max_i; i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        sum += array[i, j];

                // Нахождение суммы элементов от начала строки, на которой расположен больший элемент, до самого элемента
                for (int j = 0; j < arr_Max_j; j++)
                    sum += array[arr_Max_i, j];
            }
            // Если минимальный элемент расположен позже максимального, т.е. на строке с большим индексом
            else if (arr_Min_i > arr_Max_i)
            {
                // Нахождение суммы элементов от большего элемента до конца строки, на которой он расположен
                for (int j = arr_Max_j + 1; j < array.GetLength(1); j++)
                    sum += array[arr_Max_i, j];

                // Нахождение суммы элементов на строках между меньшим и большим элементами
                for (int i = arr_Max_i + 1; i < arr_Min_i; i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        sum += array[i, j];

                // Нахождение суммы элементов от начала строки, на которой расположен меньший элемент, до самого элемента
                for (int j = 0; j < arr_Min_j; j++)
                    sum += array[arr_Min_i, j];
            }
            // Иначе меньший и больший элемент расположены на одной строке arr_Max_i==arr_Min_i
            else
            {
                // Если меньший элемент расположен раньше большего, т.е. в столбце с меньшим индексом
                if (arr_Min_j < arr_Max_j)
                {
                    for (int j = arr_Min_j + 1; j < arr_Max_j; j++)
                        sum += array[arr_Max_i, j];
                }
                // Если меньший элемент расположен позже большего, т.е. в столбце с большим индексом
                else
                {
                    for (int j = arr_Max_j + 1; j < arr_Min_j; j++)
                        sum += array[arr_Max_i, j];
                }
            }

            Console.WriteLine("Сумма элементов между наименьшим и наибольшим элементами : " + sum);

            Console.ReadLine();
        }
    }
}
