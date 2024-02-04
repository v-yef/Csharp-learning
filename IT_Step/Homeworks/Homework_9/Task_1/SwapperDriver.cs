namespace Task_1
{
    internal static class SwapperDriver
    {
        public static void RunTest()
        {
            Console.Write("Enter first int number : ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second int number : ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine($"First int number before swap : {a}");
            Console.WriteLine($"Second int number before swap : {b}");

            Swapper<int>.Swap(ref a, ref b);

            Console.WriteLine();
            Console.WriteLine($"First int number after swap : {a}");
            Console.WriteLine($"Second int number after swap : {b}");
        }
    }
}
