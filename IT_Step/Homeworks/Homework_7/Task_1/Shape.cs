namespace Task_1
{
    internal abstract class Shape
    {
        protected int XCoord;
        protected int YCoord;

        public Color Color { get; set; }
        public ScaleFactor Scale { get; set; }
        public Position Position { get; set; }

        // Метод перевода Расположения в координаты x y
        public void ComputePosition()
        {
            switch ((int)Position)
            {
                case 0:
                    XCoord = 1; YCoord = 1;
                    break;
                case 1:
                    XCoord = 31; YCoord = 1;
                    break;
                case 2:
                    XCoord = 61; YCoord = 1;
                    break;
                case 3:
                    XCoord = 1; YCoord = 11;
                    break;
                case 4:
                    XCoord = 31; YCoord = 11;
                    break;
                case 5:
                    XCoord = 61; YCoord = 11;
                    break;
                case 6:
                    XCoord = 1; YCoord = 21;
                    break;
                case 7:
                    XCoord = 31; YCoord = 21;
                    break;
                case 8:
                    XCoord = 61; YCoord = 21;
                    break;
                default:
                    break;
            }
        }

        public virtual void Draw() { }
    }

    internal class Triangle : Shape
    {
        public override void Draw()
        {
            // Set the shape's color.
            Console.ForegroundColor = (ConsoleColor)Color;

            // The number of iterations depends on the ScaleFactor.
            for (int i = 0; i < (int)Scale; i++)
            {
                Console.SetCursorPosition(XCoord, YCoord + i);

                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
            }
        }
    }

    internal class Rectangle : Shape
    {
        public override void Draw()
        {
            // Set the shape's color.
            Console.ForegroundColor = (ConsoleColor)Color;

            // The number of iterations depends on the ScaleFactor. 
            for (int i = 0; i < 3 * (int)Scale; i++)
            {
                Console.SetCursorPosition(XCoord, YCoord + i);

                for (int j = 0; j < 3 * (int)Scale; j++)
                {
                    Console.Write("*");
                }
            }
        }
    }

    enum Color
    {
        Gray = 7,
        Blue = 9,
        Green = 10,
        Red = 12,
        Yellow = 14,
        White = 15
    }

    enum ScaleFactor
    {
        Small = 3,
        Medium = 6,
        Big = 9
    }

    enum Position
    {
        UpperLeft = 0,
        UpperCentre = 1,
        UpperRight = 2,
        CentreLeft = 3,
        CentreCentre = 4,
        CentreRight = 5,
        LowerLeft = 6,
        LowerCentre = 7,
        LowerRight = 8
    }
}