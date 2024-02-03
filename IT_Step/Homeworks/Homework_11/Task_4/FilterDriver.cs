namespace Task_4
{
    internal static class FilterDriver
    {
        public static void RunTest()
        {
            int[] testArr = [1, 33, 47, 3, 4, 121, 150, 0, 8, 14, 54, 22, 43, 10, 100];
            Console.Write("Initial array : ");
            DisplayArray(testArr);

            int[] resArr1 = testArr.Filter(i => i % 2 == 0);
            Console.Write("Even numbers : ");
            DisplayArray(resArr1);

            int[] resArr2 = testArr.Filter(i => i % 2 != 0);
            Console.Write("Odd numbers : ");
            DisplayArray(resArr2);
        }

        public static void DisplayArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }
    }
}
