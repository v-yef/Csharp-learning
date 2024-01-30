namespace Task_1
{
    internal abstract class Shape
    {
        protected UpperLeftPointXY upperLeftPointXY;

        public Color Color { get; set; }
        public ScaleFactor ScaleFactor { get; set; }
        public Position Position { get; set; }

        protected Shape(Color color, ScaleFactor scaleFactor, Position position)
        {
            Color = color;
            ScaleFactor = scaleFactor;
            Position = position;
        }

        public virtual void Draw() { }
    }

    internal class Triangle : Shape
    {
        public Triangle(Color color, ScaleFactor scaleFactor, Position position)
            : base(color, scaleFactor, position) { }

        public override void Draw()
        {
            // Set the shape's color.
            Console.ForegroundColor = (ConsoleColor)Color;

            // The number of iterations depends on the ScaleFactor.
            for (int i = 0; i < (int)ScaleFactor; i++)
            {
                Console.SetCursorPosition(upperLeftPointXY.X, upperLeftPointXY.Y + i);

                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
            }
        }
    }

    internal class Rectangle : Shape
    {
        public Rectangle(Color color, ScaleFactor scaleFactor, Position position)
            : base(color, scaleFactor, position) { }

        public override void Draw()
        {
            // Set the shape's color.
            Console.ForegroundColor = (ConsoleColor)Color;

            // The number of iterations depends on the ScaleFactor. 
            for (int i = 0; i < 3 * (int)ScaleFactor; i++)
            {
                Console.SetCursorPosition(upperLeftPointXY.X, upperLeftPointXY.Y + i);

                for (int j = 0; j < 3 * (int)ScaleFactor; j++)
                {
                    Console.Write("*");
                }
            }
        }
    }
}