/*
 ============================================================================
 Name        : Homework_4-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a Money class, which object will work on a single currency.
               The class must have: a field for storing a whole part of currency
               (dollars, euros, etc.) and a field for storing pennies (cents, 
               pennies, etc.). Make it possible to display the total value and
               values of parts. After that create a derived Product class to work
               with a product. Implement a method that allows to reduce the price
               by a given value. For each of the classes, implement the necessary
               methods and fields.
 ============================================================================
 */

namespace Task_1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Special #1", 10, 200);
            Console.WriteLine(product.ToString());

            product.IncreasePrice();
            Console.WriteLine(product.ToString());

            product.DecreasePrice();
            Console.WriteLine(product.ToString());

            Console.ReadLine();
        }
    }
}
