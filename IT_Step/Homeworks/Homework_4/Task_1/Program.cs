/*
 ============================================================================
 Name        : Homework_4-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Program the Money class (class object operates with one currency) to work with money.
  The classroom should have: a field for storing a whole part of money (dollars, euros, hryvnias, etc.) and a field
  for storing pennies (cents, eurocents, pennies, etc.). Implement methods of displaying the amount on the screen, tasks
  values of parts. Based on the Money class, create a Product class to work with a product or commodity. Implement a method that allows
  reduce the price by a given number. For each of the classes, implement the necessary methods and fields.
 ============================================================================
 */

namespace Task_1
{
    class Money
    {
        private int m_iWholePart_;
        private int m_iFractionPart_;

        public Money() : this(0, 0) { }

        public Money(int _WholePart, int _FractionPart)
        {
            if (_WholePart < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (_FractionPart < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            m_iWholePart_ += _WholePart;

            if (_FractionPart <= 99)
            {
                m_iFractionPart_ = _FractionPart;
            }
            else
            {
                // Если кол-во разменных монет > 99, то перевести его в целую часть
                int iTemp = _FractionPart / 100;
                m_iWholePart_ += iTemp;
                m_iFractionPart_ += _FractionPart - iTemp * 100;
            }

        }

        public int WholePart
        {
            get { return m_iWholePart_; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                m_iWholePart_ = value;
            }
        }

        public int FractionPart
        {
            get { return m_iFractionPart_; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                // Добавить кол-во разменных монет к имеющемуся
                m_iFractionPart_ = value;

                // Если кол-во разменных монет стало > 99, то перевести его в целую часть
                if (m_iFractionPart_ > 99)
                {
                    int iTemp = m_iFractionPart_ / 100;
                    m_iWholePart_ += iTemp;
                    m_iFractionPart_ += value - iTemp * 100;

                }
            }
        }

        public void Print()
        {
            Console.WriteLine(WholePart + "." + FractionPart);

            return;
        }
    }

    class Product : Money
    {
        private string m_sName_;

        public Product()
           : base(0, 0)
        {
            m_sName_ = "Название не указано";
        }

        public Product(string _Name, int _WholePart, int _FractionPart)
            : base(_WholePart, _FractionPart)
        {
            m_sName_ = _Name;
        }

        public void SetStartPrice()
        {
            Console.WriteLine("Начальная цена продукта :");

            Console.WriteLine("Целые единицы :");
            int WholePart = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Разменные единицы :");
            int FractionPart = Convert.ToInt32(Console.ReadLine());

            SetStartPrice(WholePart, FractionPart);

            return;
        }

        public void SetStartPrice(int _iWholePart, int _iFractionPart)
        {
            base.WholePart = _iWholePart;
            base.FractionPart = _iFractionPart;
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
            base.FractionPart += _iFractionPart;
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
            base.FractionPart -= _iFractionPart;
        }

        public string GetCurrentPrice()
        {
            return Convert.ToString(base.WholePart) + "." + Convert.ToString(base.FractionPart);
        }

        public string GetName()
        {
            return m_sName_;
        }
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
