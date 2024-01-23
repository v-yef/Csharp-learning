namespace Task_1
{
    internal class Money
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
            _fractionalPart = fractionalPart;

            if (fractionalPart > 99)
            {
                NormalizeMoneyParts();
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

                if (_fractionalPart > 99)
                {
                    NormalizeMoneyParts();
                }
            }
        }

        public void ResetAmount()
        {
            WholePart = 0;
            FractionalPart = 0;
        }

        public void PrintAmount() => Console.WriteLine(this.ToString());

        public override string ToString() => $"{_wholePart}.{_fractionalPart}";

        public void NormalizeMoneyParts()
        {
            int totalInFraction = WholePart * 100 + FractionalPart;

            WholePart = totalInFraction / 100;
            FractionalPart = totalInFraction % 100;

            if (WholePart < 0)
            {
                ResetAmount();
            }
        }
    }
}
