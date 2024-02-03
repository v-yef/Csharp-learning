/*
 ============================================================================
 Name        : Homework_11-Task_4
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create an extension method to filter an array of integers using
               an argument (predicate). The method returns a newly created
               array after the filtering. For example, the condition can be a
               predicate for checking elements for parity or oddity. Write a
               program to test the method.
 ============================================================================
 */

namespace Task_4
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            FilterDriver.RunTest();

            Console.ReadLine();
        }
    }
}
