namespace Task_1
{
    public static class ArrayProcessor
    {
        public static float[]? MakeOneDimensionalArrayOfFloatsWithUserInput(
                                int elemCount)
        {
            float[]? array = new float[elemCount];

            for (int i = 0; i < elemCount; i++)
            {
                Console.WriteLine($"Enter array element #{i + 1}: ");
                float? curNum = UserInputProcessor.GetFloatFromUser();
                if (curNum is null)
                {
                    return null;
                }

                array[i] = curNum.Value;
            }

            return array;
        }

        public static float[,] MakeTwoDimensionalArrayOfFloatsWithRandomNumbers(
                                int firstDimLen, int secondDimLen)
        {
            float[,] array = new float[firstDimLen, secondDimLen];

            Random random = new();

            for (int i = 0; i < firstDimLen; i++)
            {
                for (int j = 0; j < secondDimLen; j++)
                {
                    array[i, j] = 
                        Convert.ToSingle(Math.Round(random.NextDouble(), 3) * 100);
                }                
            }

            return array;
        }

        public static void DisplayOneDimensionalArray(float[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        public static void DisplayTwoDimensionalArray(float[,] array)
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
