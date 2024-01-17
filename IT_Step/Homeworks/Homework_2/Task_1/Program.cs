/*
 ============================================================================
 Name        : Homework_2-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Declare a one-dimensional (5 elements) array A and a two-dimensional
               (3 rows, 4 columns) array B. Both arrays must store fractional
               numbers. Fill array A with numbers entered by the user, and
               array B - with random numbers using cycles. Display values of
               the arrays on the screen: A — in one line, B — in the matrix form.
               Also for each array :
                - find the maximal element,
                - find the minimal element,
                - calculate sum of all elements,
                - calculate product of all elements,
                - calculate sum of even-index elements in array A,
                - calculate sum of odd-index columns in array B.
 ============================================================================
 */

namespace Task_1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            float[]? A = ArrayProcessor.MakeOneDimensionalArrayOfFloatsWithUserInput(5);
            if (A is null)
            {
                return;
            }

            Console.WriteLine("Array A :");
            ArrayProcessor.DisplayOneDimensionalArray(A);
            Console.WriteLine();

            Console.WriteLine("Maximal element in array A : " + A.Max());
            Console.WriteLine("Minimal element in array A : " + A.Min());
            Console.WriteLine("Sum of elements in array A : " + A.Sum());
            Console.WriteLine("Product of elements in array A : " + A.Product());
            Console.WriteLine("Sum of even-index elements in array A : " + A.EvenIndexSum());
            Console.WriteLine();

            //=================================================================

            float[,] B = ArrayProcessor.MakeTwoDimensionalArrayOfFloatsWithRandomNumbers(3, 4);

            Console.WriteLine("Array В :");
            ArrayProcessor.DisplayTwoDimensionalArray(B);
            Console.WriteLine();

            Console.WriteLine("Maximal element in array B : " + B.MaxTwoDim());
            Console.WriteLine("Minimal element in array B : " + B.MinTwoDim());
            Console.WriteLine("Sum of elements in array B : " + B.SumTwoDim());
            Console.WriteLine("Product of elements in array B : " + B.ProductTwoDim());
            Console.WriteLine("Sum of odd-index columns in array B : " + B.OddColumnSum());
            Console.WriteLine();
        }
    }
}
