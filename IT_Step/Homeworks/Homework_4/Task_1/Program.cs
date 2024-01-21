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
    class Money
    {
        private int _wholePart;
        private int _fractionalPart;

        public Money() : this(0, 0) { }

        public Money(int wholePart, int fractionalPart)
        {
            if (wholePart < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(wholePart), wholePart, "Currency values cannot be negative!");
            }

            if (fractionalPart < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(fractionalPart), fractionalPart, "Currency values cannot be negative!");
            }

            _wholePart = wholePart;

            if (fractionalPart <= 99)
            {
                _fractionalPart = fractionalPart;
            }
            else
            {
                // If the number of change coins is > 99, convert it to a whole part
                normalizeParts();
            }
        }

        public int WholePart
        {
            get => _wholePart;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                         nameof(value), value, "Currency values cannot be negative!");
                }

                _wholePart = value;
            }
        }

        public int FractionalPart
        {
            get => _fractionalPart;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                         nameof(value), value, "Currency values cannot be negative!");
                }

                _fractionalPart = value;

                // If the number of change coins became > 99, convert it to a whole part
                if (_fractionalPart > 99)
                {
                    normalizeParts();
                }
            }
        }

        public void PrintAmount() => Console.WriteLine(_wholePart + "." + _fractionalPart);

        private void normalizeParts()
        {
            _wholePart += _fractionalPart / 100;
            _fractionalPart %= 100;
        }
    }

    class Product : Money
    {
        private readonly string _productName;

        public Product()
           : base(0, 0)
        {
            _productName = "Default product name";
        }

        public Product(string name, int wholePart, int fractionalPart)
            : base(wholePart, fractionalPart)
        {
            _productName = name;
        }

        ///////////////////////////////////////////////////////////////////////

        public void SetStartPrice()
        {
            int wholePart, fractionalPart;

            Console.WriteLine("INITIAL PRODUCT PRICE :");

            Console.WriteLine("Whole part :");

            int.TryParse(Console.ReadLine(), out wholePart);

            Console.WriteLine("Fractional part :");

            int.TryParse(Console.ReadLine(), out fractionalPart);

            SetPrice(wholePart, fractionalPart);
        }

        public void SetPrice(int wholePart, int fractionalPart)
        {
            base.WholePart = wholePart;
            base.FractionalPart = fractionalPart;
        }

        public void IncreasePrice()
        {
            Console.WriteLine("На сколько увеличить цену ?");

            Console.WriteLine("Целые единицы :");
            int WholePart = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Разменные единицы :");
            int FractionPart = Convert.ToInt32(Console.ReadLine());

            IncreasePrice(WholePart, FractionPart);
        }

        public void IncreasePrice(int _iWholePart, int _iFractionPart)
        {
            base.WholePart += _iWholePart;
            base.FractionalPart += _iFractionPart;
        }

        public void DecreasePrice()
        {
            Console.WriteLine("На сколько уменьшить цену ?");

            Console.WriteLine("Целые единицы :");
            int WholePart = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Разменные единицы :");
            int FractionPart = Convert.ToInt32(Console.ReadLine());

            DecreasePrice(WholePart, FractionPart);
        }

        public void DecreasePrice(int _iWholePart, int _iFractionPart)
        {
            base.WholePart -= _iWholePart;
            base.FractionalPart -= _iFractionPart;
        }

        public string GetCurrentPrice()
        {
            return Convert.ToString(base.WholePart) + "." + Convert.ToString(base.FractionalPart);
        }

        public string GetName() => _productName;
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            Product myProduct_1 = new Product("Новый продукт", 10, 200);
            Console.WriteLine("Текущая цена продукта " + myProduct_1.GetName() + " :" + myProduct_1.GetCurrentPrice());

            myProduct_1.SetStartPrice();
            Console.WriteLine("Текущая цена продукта :" + myProduct_1.GetCurrentPrice());

            myProduct_1.IncreasePrice();
            Console.WriteLine("Текущая цена продукта :" + myProduct_1.GetCurrentPrice());

            myProduct_1.DecreasePrice();
            Console.WriteLine("Текущая цена продукта :" + myProduct_1.GetCurrentPrice());

            Console.ReadLine();

            Product myProduct_2 = new Product();
            Console.WriteLine("Текущая цена продукта " + myProduct_2.GetName() + " :" + myProduct_2.GetCurrentPrice());

            myProduct_2.SetStartPrice();
            Console.WriteLine("Текущая цена продукта :" + myProduct_2.GetCurrentPrice());

            myProduct_2.IncreasePrice();
            Console.WriteLine("Текущая цена продукта :" + myProduct_2.GetCurrentPrice());

            myProduct_2.DecreasePrice();
            Console.WriteLine("Текущая цена продукта :" + myProduct_2.GetCurrentPrice());

            Console.ReadLine();
        }
    }
}
