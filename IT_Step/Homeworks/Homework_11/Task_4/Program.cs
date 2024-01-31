/*
 ============================================================================
 Name        : Homework_11-Task_4
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create an extension method to filter an array of integers using
               a passed-in argument (predicate). The method returns a newly
               created array after the filtering. For example, the condition
               can be a predicate for checking elements for parity or oddity.
 ============================================================================
 */

namespace Task_4
{
    static class Extension
    {
        public static int[] Filter(this int[] _Array, Func<int, bool> Predicate)
        {
            List<int> TempList = new List<int>();

            for (int i = 0; i < _Array.Length; i++)
            {

                if (Predicate(_Array[i]))
                {
                    TempList.Add(_Array[i]);
                }
            }

            return TempList.ToArray();
        }

        internal static class Program
        {
            static void Main(string[] args)
            {
                int[] arr = [1, 33, 47, 3, 4, 121, 150, 0, 8, 14, 54, 22, 43, 10, 100];

                int[] arr1 = arr.Filter(i => i % 2 == 0);

                foreach (var item in arr1)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();

                int[] arr2 = arr.Filter(i => i % 2 != 0);

                foreach (var item in arr2)
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();
            }
        }
    }
}
