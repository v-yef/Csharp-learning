/*
 ============================================================================
 Name        : Homework_3-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a "Website" classstoring the following data in its fields:
               name, web-adress, description, ip-address. Implement class methods
               for data input and output. Implement access to individual fields.
 ============================================================================
 */

namespace Task_1
{
    class MyWebSite
    {
        public string Name { get; set; }
        public string WebAddress { get; set; }
        public string IpAddress { get; set; }
        public string Description { get; set; }

        public MyWebSite()
        {
            Name = "No name";
            WebAddress = "No web-address";
            IpAddress = "No ip-address";
            Description = "No description";
        }

        public MyWebSite(string name, string webAddress, string ipAddress, string description)
        {
            Name = name;
            WebAddress = webAddress;
            IpAddress = ipAddress;
            Description = description;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Name:        " + Name);
            Console.WriteLine("WebAddress:  " + WebAddress);
            Console.WriteLine("IpAddress:   " + IpAddress);
            Console.WriteLine("Description: " + Description);
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            MyWebSite site_1 = new MyWebSite();

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

            MyWebSite site_2 = new MyWebSite("My website", "https://mywebsite.com", "192.168.0.1", "Interesting website");

            Console.WriteLine("Website №2 (initial data) :");
            site_2.DisplayInfo();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
