/*
 ============================================================================
 Name        : Homework_3-Task_2
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a "Shop" class storing the following data in its fields:
               name, address, description, phone number, email. Implement class
               methods for data input and output. Implement access to individual
               fields.
 ============================================================================
 */

namespace Task_2
{
    class MyShop
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public MyShop()
        {
            Name = "No name";
            Address = "No address";
            Description = "No description";
            PhoneNumber = "000-000-000";
            Email = "No email";
        }

        public MyShop(string name, string address, string description, string phoneNumber, string email)
        {
            Name = name;
            Address = address;
            Description = description;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Name:        " + Name);
            Console.WriteLine("Address:     " + Address);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("PhoneNumber: " + PhoneNumber);
            Console.WriteLine("Email:       " + Email);
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            MyShop shop_1 = new MyShop();

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

            MyShop shop_2 = new MyShop("My shop", "Address", "Description", "987-654-321", "Email");

            Console.WriteLine("Shop №2 (initial data) :");
            shop_2.DisplayInfo();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
