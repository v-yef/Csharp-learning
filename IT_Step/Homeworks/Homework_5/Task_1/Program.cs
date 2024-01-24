/*
 ============================================================================
 Name        : Homework_5-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : In one of the previous tasks, you created the "Shop" class. Now add
               the information about the shop's area to this class. Overload the 
               "+" and "—" operators (to increase and reduce the area of ​​the store
               by the specified size), "==", "!=", "<" and ">" operators (to check
               the relations of the areas of two stores). Use the property mechanism
               of class fields.
 ============================================================================
 */

namespace Task_1
{
    class MyShop
    {
        public string Name { get; set; } = "No name";
        public string Address { get; set; } = "No address";
        public string Description { get; set; } = "No description";
        public string PhoneNumber { get; set; } = "000-000-000";
        public string Email { get; set; } = "No email";
        public float Area { get; set; } = 0.0f;

        public MyShop() { }

        public MyShop(string name, string address, string description, string phoneNumber,
            string email, float area)
        {
            Name = name;
            Address = address;
            Description = description;
            PhoneNumber = phoneNumber;
            Email = email;
            Area = area;
        }

        public static MyShop operator +(MyShop shop, float area)
        {
            return new MyShop
            {
                Area = shop.Area + area
            };
        }

        public static MyShop operator -(MyShop _Shop, float _Square)
        {
            if (_Shop.Area - _Square < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new MyShop
            {
                Area = _Shop.Area - _Square
            };
        }

        public static bool operator ==(MyShop shop_1, MyShop shop_2) =>
            shop_1.Area == shop_2.Area;

        public static bool operator !=(MyShop shop_1, MyShop shop_2) =>
            shop_1.Area != shop_2.Area;

        public static bool operator >(MyShop shop_1, MyShop shop_2) =>
            shop_1.Area > shop_2.Area;

        public static bool operator <(MyShop shop_1, MyShop shop_2) =>
            shop_1.Area < shop_2.Area;

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            MyShop? shop = obj as MyShop;

            if (shop is null)
            {
                return false;
            }

            return this.ToString() == obj.ToString();
        }

        public override int GetHashCode() =>
            this.ToString().GetHashCode();

        public void Print() =>
            Console.WriteLine($"{Name}\r" +
                        $"{Address}\r" +
                        $"{Description}\r" +
                        $"{PhoneNumber}\r " +
                        $" {Email}\r " +
                        $" {Area} \r");
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            MyShop Shop_1 = new MyShop(
                "Shop_1",
                "Address_1",
                "Description_1",
                "000-000-001",
                "Email_1",
                10.0f);
            MyShop Shop_2 = new MyShop(
                "Shop_2",
                "Address_2",
                "Description_2",
                "000-000-002",
                "Email_2",
                10.0f);

            Shop_1.Print();
            Shop_2.Print();

            Console.WriteLine(
                $"{Shop_1.Name} == {Shop_2.Name} : {Shop_1 == Shop_2}.");
            Console.WriteLine(
                $"{Shop_1.Name} != {Shop_2.Name} : {Shop_1 == Shop_2}.");
            Console.WriteLine(
                $"{Shop_1.Name} > {Shop_2.Name} : {Shop_1 == Shop_2}.");
            Console.WriteLine(
                $"{Shop_1.Name} < {Shop_2.Name} : {Shop_1 == Shop_2}.");
            Console.WriteLine(
                $"{Shop_1.Name} equals {Shop_2.Name} : {Shop_1.Equals(Shop_2)}.");
            Console.WriteLine();

            MyShop Shop_3 = Shop_2 + 5.0f;

            Shop_3.Name = "Магазин_3";
            Shop_3.Address = "Адрес_3";
            Shop_3.Description = "Описание_3";
            Shop_3.PhoneNumber = "000-000-003";
            Shop_3.Email = "Email_3";

            Shop_3.Print();

            Console.WriteLine(Shop_3.Name + " == " + Shop_2.Name + " : " + Convert.ToString(Shop_3 == Shop_2));
            Console.WriteLine(Shop_3.Name + " != " + Shop_2.Name + " : " + Convert.ToString(Shop_3 == Shop_2));
            Console.WriteLine(Shop_3.Name + " > " + Shop_2.Name + " : " + Convert.ToString(Shop_3 == Shop_2));
            Console.WriteLine(Shop_3.Name + " < " + Shop_2.Name + " : " + Convert.ToString(Shop_3 == Shop_2));
            Console.WriteLine(Shop_3.Name + " equals " + Shop_2.Name + " : " + Convert.ToString(Shop_3.Equals(Shop_2)));
            Console.WriteLine();

            MyShop Shop_4 = Shop_3 - 5.0f;

            Shop_4.Name = "Магазин_4";
            Shop_4.Address = "Адрес_4";
            Shop_4.Description = "Описание_4";
            Shop_4.PhoneNumber = "000-000-004";
            Shop_4.Email = "Email_4";

            Shop_4.Print();

            Console.WriteLine(Shop_4.Name + " == " + Shop_2.Name + " : " + Convert.ToString(Shop_4 == Shop_2));
            Console.WriteLine(Shop_4.Name + " != " + Shop_2.Name + " : " + Convert.ToString(Shop_4 == Shop_2));
            Console.WriteLine(Shop_4.Name + " > " + Shop_2.Name + " : " + Convert.ToString(Shop_4 == Shop_2));
            Console.WriteLine(Shop_4.Name + " < " + Shop_2.Name + " : " + Convert.ToString(Shop_4 == Shop_2));
            Console.WriteLine(Shop_4.Name + " equals " + Shop_2.Name + " : " + Convert.ToString(Shop_4.Equals(Shop_2)));
            Console.WriteLine();

            // Проверка генерации исключения при Square < 0
            try
            {
                MyShop Shop_5 = Shop_3 - 100.0f;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }
    }
}
