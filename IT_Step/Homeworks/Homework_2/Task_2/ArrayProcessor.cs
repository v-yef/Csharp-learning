namespace Task_2
{
    public static class ArrayProcessor
    {
        public static void PopulateArrayWithRandomNumbers(int[,] array)
        {
            int firstDimLen = array.GetLength(0);
            int secondDimLen = array.GetLength(1);

            Random random = new();

            for (int i = 0; i < firstDimLen; i++)
            {
                for (int j = 0; j < secondDimLen; j++)
                {
                    array[i, j] = random.Next();
                }
            }
        }

        public static void DisplayArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        public static void DisplayArray(int[,] array)
        {
            int firstDimLen = array.GetLength(0);
            int secondDimLen = array.GetLength(1);

            for (int i = 0; i < firstDimLen; i++)
            {
                for (int j = 0; j < secondDimLen; j++)
                {
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
