/*
 ============================================================================
 Name        : Homework_5-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : In one of the previous practical tasks, you created the "Shop" class. Add to an already created class
  information about the store area. Perform load + (to increase the area of ​​the store by the specified size),
  — (to reduce the area of the store by the specified size), == (check for the equality of the areas of the stores),
  < and > (checking stores smaller or larger in area), != and Equals. Use the property mechanism
  class fields.
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
        public float Square { get; set; } = 0.0f;

        public MyShop() { }

        public MyShop(string _Name, string _Address, string _Description, string _PhoneNumber, string _Email, float _Square)
        {
            Name = _Name;
            Address = _Address;
            Description = _Description;
            PhoneNumber = _PhoneNumber;
            Email = _Email;
            Square = _Square;
        }

        // Оператор + (увеличивает площадь на указанный размер)
        public static MyShop operator +(MyShop _Shop, float _Square)
        {
            return new MyShop
            {
                Square = _Shop.Square + _Square
            };
        }

        // Оператор - (уменьшает площадь на указанный размер)
        public static MyShop operator -(MyShop _Shop, float _Square)
        {
            if (_Shop.Square - _Square < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new MyShop
            {
                Square = _Shop.Square - _Square
            };
        }

        // Оператор == (сравнивает магазины по площади)
        public static bool operator ==(MyShop _Shop_1, MyShop _Shop_2)
        {
            return _Shop_1.Square == _Shop_2.Square;
        }

        // Оператор != (сравнивает магазины по площади)
        public static bool operator !=(MyShop _Shop_1, MyShop _Shop_2)
        {
            return _Shop_1.Square != _Shop_2.Square;
        }

        // Оператор > (сравнивает магазины по площади)
        public static bool operator >(MyShop _Shop_1, MyShop _Shop_2)
        {
            return _Shop_1.Square > _Shop_2.Square;
        }

        // Оператор < (сравнивает магазины по площади)
        public static bool operator <(MyShop _Shop_1, MyShop _Shop_2)
        {
            return _Shop_1.Square < _Shop_2.Square;
        }

        public override bool Equals(object _Shop)
        {
            return this.ToString() == _Shop.ToString();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public void Print()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Address);
            Console.WriteLine(Description);
            Console.WriteLine(PhoneNumber);
            Console.WriteLine(Email);
            Console.WriteLine(Square);
            Console.WriteLine();
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            MyShop Shop_1 = new MyShop("Магазин_1", "Адрес_1", "Описание_1", "000-000-001", "Email_1", 10.0f);
            MyShop Shop_2 = new MyShop("Магазин_2", "Адрес_2", "Описание_2", "000-000-002", "Email_2", 10.0f);

            Shop_1.Print();
            Shop_2.Print();

            Console.WriteLine(Shop_1.Name + " == " + Shop_2.Name + " : " + Convert.ToString(Shop_1 == Shop_2));
            Console.WriteLine(Shop_1.Name + " != " + Shop_2.Name + " : " + Convert.ToString(Shop_1 == Shop_2));
            Console.WriteLine(Shop_1.Name + " > " + Shop_2.Name + " : " + Convert.ToString(Shop_1 == Shop_2));
            Console.WriteLine(Shop_1.Name + " < " + Shop_2.Name + " : " + Convert.ToString(Shop_1 == Shop_2));
            Console.WriteLine(Shop_1.Name + " equals " + Shop_2.Name + " : " + Convert.ToString(Shop_1.Equals(Shop_2)));
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
