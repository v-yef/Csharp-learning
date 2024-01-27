namespace Task_1
{
    internal class House
    {
        public Part[] parts;

        public int Length
        {
            get => parts.Length;
        }

        public House()
        {
            parts = [new Basement(),
                new Wall(),
                new Wall(),
                new Wall(),
                new Wall(),
                new Door(),
                new Window(),
                new Window(),
                new Window(),
                new Window(),
                new Roof()];
        }

        // Индексатор Дома
        public Part this[int _Index]
        {
            get
            {
                if (_Index >= 0 && _Index < parts.Length)
                {
                    return parts[_Index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (_Index >= 0 && _Index < parts.Length)
                {
                    parts[_Index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public bool IsBuilt()
        {
            foreach (var part in parts)
            {
                if (!part.IsBuilt)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
