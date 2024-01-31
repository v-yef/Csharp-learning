namespace Task_1
{
    enum Type
    {
        Undefined, Rectangle, Triangle
    }
    enum Color
    {
        Undefined,
        Gray = 7,
        Blue = 9,
        Green = 10,
        Red = 12,
        Yellow = 14,
        White = 15
    }
    enum Position
    {
        Undefined = 0,
        UpperLeft = 1,
        UpperCentre = 2,
        UpperRight = 3,
        CentreLeft = 4,
        CentreCentre = 5,
        CentreRight = 6,
        LowerLeft = 7,
        LowerCentre = 8,
        LowerRight = 9
    }
    enum Scale
    {
        Undefined,
        Small = 3,
        Medium = 6,
        Big = 9
    }
    struct UpperLeftPointXY
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    internal static class ShapeMaker
    {
        public static Shape? CreateShape()
        {
            Shape? shape = null;

            Type type = ConvertIntToTypeEnum(GetTypeFromUser());
            if (type == Type.Undefined)
            {

            }

            Color color = ConvertIntToColorEnum(GetColorFromUser());
            if (color == Color.Undefined)
            {

            }

            Scale scale = ConvertIntToScaleEnum(GetScaleFromUser());
            if (scale == Scale.Undefined)
            {

            }

            Position position = ConvertIntToPositionEnum(GetPositionFromUser());
            if (position == Position.Undefined)
            {

            }

            switch (type)
            {
                case Type.Rectangle:
                    shape = new Rectangle(color, scale, position);
                    break;
                case Type.Triangle:
                    shape = new Triangle(color, scale, position);
                    break;
                case Type.Undefined:
                    break;
            }

            return shape;
        }

        private static int? GetTypeFromUser()
        {
            Console.Clear();

            Console.WriteLine("Select type of the shape :");

            return Menu.VerticalMenu([
                "Rectangle",
                "Triangle",
                "Exit"]);
        }

        private static Type ConvertIntToTypeEnum(int? type)
        {
            switch (type)
            {
                case 1:
                    return Type.Rectangle;
                case 2:
                    return Type.Triangle;
                default:
                    return Type.Undefined;
            }
        }

        private static int? GetScaleFromUser()
        {
            Console.Clear();

            Console.WriteLine("Select size of the shape :");

            return Menu.VerticalMenu([
                "Small",
                "Medium",
                "Big",
                "Exit"]);
        }

        private static Scale ConvertIntToScaleEnum(int? scale)
        {
            switch (scale)
            {
                case 1:
                    return Scale.Small;
                case 2:
                    return Scale.Medium;
                case 3:
                    return Scale.Big;
                default:
                    return Scale.Undefined;
            }
        }

        private static int? GetColorFromUser()
        {
            Console.Clear();

            Console.WriteLine("Select color of the shape:");

            return Menu.VerticalMenu([
                "Gray",
                "Blue",
                "Green",
                "Red",
                "Yellow",
                "White",
                "Exit"]);
        }

        private static Color ConvertIntToColorEnum(int? color)
        {
            switch (color)
            {
                case 1:
                    return Color.Gray;
                case 2:
                    return Color.Blue;
                case 3:
                    return Color.Green;
                case 4:
                    return Color.Red;
                case 5:
                    return Color.Yellow;
                case 6:
                    return Color.White;
                default:
                    return Color.Undefined;
            }
        }

        private static int? GetPositionFromUser()
        {
            Console.Clear();

            Console.WriteLine("Select position of the shape :");

            return Menu.VerticalMenu([
                "Сверху слева",
                "Сверху по центру",
                "Сверху справа",
                "Слева по центру",
                "По центру",
                "Справа по центру",
                "Снизу слева",
                "Снизу по центру",
                "Снизу справа",
                "Выход"]);
        }

        private static Position ConvertIntToPositionEnum(int? position)
        {
            switch (position)
            {
                case 1:
                    return Position.UpperLeft;
                case 2:
                    return Position.UpperCentre;
                case 3:
                    return Position.UpperRight;
                case 4:
                    return Position.CentreLeft;
                case 5:
                    return Position.CentreCentre;
                case 6:
                    return Position.CentreRight;
                case 7:
                    return Position.LowerLeft;
                case 8:
                    return Position.LowerCentre;
                case 9:
                    return Position.LowerRight;
                default:
                    return Position.Undefined;
            }
        }

        public static UpperLeftPointXY ConvertPositionToCoordinates(Position position)
        {
            var pointXY = new UpperLeftPointXY();

            switch ((int)position)
            {
                case 1:
                    pointXY.X = 1; pointXY.Y = 1;
                    break;
                case 2:
                    pointXY.X = 31; pointXY.Y = 1;
                    break;
                case 3:
                    pointXY.X = 61; pointXY.Y = 1;
                    break;
                case 4:
                    pointXY.X = 1; pointXY.Y = 11;
                    break;
                case 5:
                    pointXY.X = 31; pointXY.Y = 11;
                    break;
                case 6:
                    pointXY.X = 61; pointXY.Y = 11;
                    break;
                case 7:
                    pointXY.X = 1; pointXY.Y = 21;
                    break;
                case 8:
                    pointXY.X = 31; pointXY.Y = 21;
                    break;
                case 9:
                    pointXY.X = 61; pointXY.Y = 21;
                    break;
                default:
                    break;
            }

            return pointXY;
        }



    }
}
