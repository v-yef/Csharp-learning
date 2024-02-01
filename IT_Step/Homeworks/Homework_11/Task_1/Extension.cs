namespace Task_1
{
    internal static class Extension
    {
        public static bool IsFibonacci(this int number) =>
            Math.Sqrt(5 * Math.Pow(number, 2.0) + 4) % 1 == 0 ||
            Math.Sqrt(5 * Math.Pow(number, 2.0) - 4) % 1 == 0;

        // Wikipedia: A natural number N is a Fibonacci number if and only if
        // at least one of (5*N)^2 + 4 or (5*N)^2 - 4 is a perfect square. And
        // if the number is a square, then the root of this number will be an
        // integer and the remainder from division it by 1 will be 0.
    }
}
