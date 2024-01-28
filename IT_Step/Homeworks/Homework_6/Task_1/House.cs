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

        public Part this[int index]
        {
            get
            {
                if (index >= 0 && index < parts.Length)
                {
                    return parts[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(index), index, "The index value is outside the bounds of the \"Parts\" array.");
                }
            }

            set
            {
                if (index >= 0 && index < parts.Length)
                {
                    parts[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(index), index, "The index value is outside the bounds of the \"Parts\" array.");
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
