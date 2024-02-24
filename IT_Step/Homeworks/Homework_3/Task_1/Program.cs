/*
 ==============================================================================
 Name        : Homework_3-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a "Website" class storing the following data in its fields:
               name, web-adress, description, ip-address. Implement class methods
               for data input and output. Implement access to individual fields.
 ==============================================================================
 */

namespace Task_1
{
    internal static class Program
    {
        static void Main()
        {
            var site_1 = new MyWebSite();

            Console.WriteLine("Website №1 (initial data) :");
            site_1.DisplayInfo();
            Console.WriteLine();

            site_1.Name = "New name";
            site_1.WebAddress = "New web-address";
            site_1.IpAddress = "New ip-address";
            site_1.Description = "New description";

            Console.WriteLine("Website №1 (updated data) :");
            site_1.DisplayInfo();
            Console.WriteLine();

            //=================================================================

            var site_2 = new MyWebSite(
                "My website", "https://mywebsite.com", "192.168.0.1", "Some website");

            Console.WriteLine("Website №2 (initial data) :");
            site_2.DisplayInfo();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
