namespace Task_1
{
    internal class Product : Money
    {
        private readonly string _productName;

        public Product(string name, int priceWholePart, int priceFractionalPart)
            : base(priceWholePart, priceFractionalPart)
        {
            _productName = name;
        }

        public void SetPrice(int priceWholePart, int priceFractionalPart)
        {
            base.WholePart = priceWholePart;
            base.FractionalPart = priceFractionalPart;
            base.NormalizeMoneyParts();
        }

        public string GetCurrentPrice() => base.ToString();

        public string GetName() => _productName;

        public override string ToString() =>
            $"Product: {_productName}. Price: {base.ToString()}";

        ///////////////////////////////////////////////////////////////////////

        public void IncreasePrice()
        {
            Console.WriteLine("INCREASE PRICE BY :");
            Console.WriteLine("Whole part :");
            int wholePart = Convert.ToInt32(Console.ReadLine());
            if (wholePart < 0)
            {
                Console.WriteLine("Currency values cannot be negative!");
                return;
            }

            Console.WriteLine("Fractional part :");
            int fractionalPart = Convert.ToInt32(Console.ReadLine());
            if (fractionalPart < 0)
            {
                Console.WriteLine("Currency values cannot be negative!");
                return;
            }
            SetPrice(base.WholePart + wholePart, base.FractionalPart + fractionalPart);
        }

        public void DecreasePrice()
        {
            Console.WriteLine("DECREASE PRICE BY :");
            Console.WriteLine("Whole part :");
            int wholePart = Convert.ToInt32(Console.ReadLine());
            if (wholePart < 0)
            {
                Console.WriteLine("Currency values cannot be negative!");
                return;
            }
            Console.WriteLine("Fractional part :");
            int fractionalPart = Convert.ToInt32(Console.ReadLine());
            if (fractionalPart < 0)
            {
                Console.WriteLine("Currency values cannot be negative!");
                return;
            }
            SetPrice(base.WholePart - wholePart, base.FractionalPart - fractionalPart);
        }


    }
}
