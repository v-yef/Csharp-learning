/*
 ==============================================================================
 Name        : Homework_3-Task_2
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a "Shop" class storing the following data in its fields:
               name, address, description, phone number, email. Implement class
               methods for data input and output. Implement access to individual
               fields.
 ==============================================================================
 */

namespace Task_2
{
    internal static class Program
    {
        static void Main()
        {
            var shop_1 = new MyShop();

            Console.WriteLine("Shop №1 (initial data) :");
            shop_1.DisplayInfo();
            Console.WriteLine();

            shop_1.Name = "New name";
            shop_1.Address = "New address";
            shop_1.Description = "New description";
            shop_1.PhoneNumber = "123-456-789";
            shop_1.Email = "New email";

            Console.WriteLine("Shop №1 (updated data) :");
            shop_1.DisplayInfo();
            Console.WriteLine();

            //=================================================================

            var shop_2 = new MyShop(
                "My shop", "Address", "Description", "987-654-321", "Email");

            Console.WriteLine("Shop №2 (initial data) :");
            shop_2.DisplayInfo();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
