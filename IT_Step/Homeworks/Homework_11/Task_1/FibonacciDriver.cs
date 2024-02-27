namespace Task_1
{
    internal static class FibonacciDriver
    {
        public static void PrintFibonacciNumbersInNegativeRange()
        {
            int Current = 0;
            int FirstPrevious = 1;
            int SecondPrevious;

            Console.WriteLine("Fibonacci numbers in negative range :");

            for (int i = 0; i > -1000000; i--)
            {
                SecondPrevious = Current;
                Current = FirstPrevious;
                FirstPrevious += SecondPrevious;

                if (Current.IsFibonacci())
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
        }

        public static void PrintFibonacciNumbersInPositiveRange()
        {
            int Current = 0;
            int FirstPrevious = 1;
            int SecondPrevious;

            Console.WriteLine("Fibonacci numbers in positive range :");

            for (int i = 0; i < 1000000; i++)
            {
                SecondPrevious = Current;
                Current = FirstPrevious;
                FirstPrevious += SecondPrevious;

                if (Current.IsFibonacci())
                {
                    Console.WriteLine(Current);
                }
            }
        }
        public static void RunTest()
        {
            PrintFibonacciNumbersInNegativeRange();
            Console.WriteLine();
            PrintFibonacciNumbersInPositiveRange();
        }
    }
}
