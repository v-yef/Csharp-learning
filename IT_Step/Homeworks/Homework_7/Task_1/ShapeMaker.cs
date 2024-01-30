namespace Task_1
{
    internal static class ShapeMaker
    {
        private struct UpperLeftPointXY
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        private enum Color
        {
            Gray = 7,
            Blue = 9,
            Green = 10,
            Red = 12,
            Yellow = 14,
            White = 15
        }
        private enum Position
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
        private enum ScaleFactor
        {
            Small = 3,
            Medium = 6,
            Big = 9
        }

        public static Shape CreateShape()
        {
            Shape shape;

            int type = GetTypeFromUser();
            ScaleFactor scale = GetScaleFromUser();
            Color color = GetColorFromUser();
            Position position = GetPositionFromUser();

            switch (type)
            {
                case 0:
                    shape = new Rectangle(color, scale, position);
                    break;
                case 1:
                    shape = new Triangle(color, scale, position);
                    break;
                default:
                    throw new Exception("Тип не выбран!");
            }





            return shape;
        }

        private static int GetTypeFromUser()
        {
            Console.Clear();

            Console.WriteLine("Тип создаваемой фигуры :");

            return Menu.VerticalMenu([
                "Rectangle",
                "Triangle",
                "Exit"]);
        }

        private static Shape SetType(int type)
        {
            Shape shape;



            return shape;
        }

        private static int GetScaleFromUser()
        {

        }

        private static void ChooseScale(ref Shape shape)
        {
            Console.Clear();

            Console.WriteLine("Размер создаваемой фигуры :");

            int Scale = Menu.VerticalMenu([
                "Small",
                "Medium",
                "Big",
                "Exit"]);

            switch (Scale)
            {
                case 0:
                    shape.Scale = ScaleFactor.Small;
                    break;
                case 1:
                    shape.Scale = ScaleFactor.Medium;
                    break;
                case 2:
                    shape.Scale = ScaleFactor.Big;
                    break;
                default:
                    throw new Exception("Размер не выбран!");
            }
        }

        private static int GetColorFromUser()
        {

        }

        private static void ChooseColor(ref Shape shape)
        {
            Console.Clear();

            Console.WriteLine("Цвет создаваемой фигуры :");

            int Color = Menu.VerticalMenu(new string[]
            {
                "Gray",
                "Blue",
                "Green",
                "Red",
                "Yellow",
                "White",
                "Exit",

            });

            switch (Color)
            {
                case 0:
                    shape.Color = Task_1.Color.Gray;
                    break;
                case 1:
                    shape.Color = Task_1.Color.Blue;
                    break;
                case 2:
                    shape.Color = Task_1.Color.Green;
                    break;
                case 3:
                    shape.Color = Task_1.Color.Red;
                    break;
                case 4:
                    shape.Color = Task_1.Color.Yellow;
                    break;
                case 5:
                    shape.Color = Task_1.Color.White;
                    break;
                default:
                    throw new Exception("Цвет не выбран!");
            }
        }

        private static int GetPositionFromUser()
        {

        }

        private static void ChoosPosition(ref Shape shape)
        {
            Console.Clear();

            Console.WriteLine("Позиция создаваемой фигуры :");

            int Position = Menu.VerticalMenu([
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

            switch (Position)
            {
                case 0:
                    shape.Position = Task_1.Position.UpperLeft;
                    break;
                case 1:
                    shape.Position = Task_1.Position.UpperCentre;
                    break;
                case 2:
                    shape.Position = Task_1.Position.UpperRight;
                    break;
                case 3:
                    shape.Position = Task_1.Position.CentreLeft;
                    break;
                case 4:
                    shape.Position = Task_1.Position.CentreCentre;
                    break;
                case 5:
                    shape.Position = Task_1.Position.CentreRight;
                    break;
                case 6:
                    shape.Position = Task_1.Position.LowerLeft;
                    break;
                case 7:
                    shape.Position = Task_1.Position.LowerCentre;
                    break;
                case 8:
                    shape.Position = Task_1.Position.LowerRight;
                    break;
                default:
                    throw new Exception("Позиция не выбрана!");
            }

            shape.ComputePosition();
        }

        public static UpperLeftPointXY ConvertPositionToCoordinates(Position position)
        {
            var pointXY = new UpperLeftPointXY();

            switch ((int)position)
            {
                case 0:
                    pointXY.X = 1; pointXY.Y = 1;
                    break;
                case 1:
                    pointXY.X = 31; pointXY.Y = 1;
                    break;
                case 2:
                    pointXY.X = 61; pointXY.Y = 1;
                    break;
                case 3:
                    pointXY.X = 1; pointXY.Y = 11;
                    break;
                case 4:
                    pointXY.X = 31; pointXY.Y = 11;
                    break;
                case 5:
                    pointXY.X = 61; pointXY.Y = 11;
                    break;
                case 6:
                    pointXY.X = 1; pointXY.Y = 21;
                    break;
                case 7:
                    pointXY.X = 31; pointXY.Y = 21;
                    break;
                case 8:
                    pointXY.X = 61; pointXY.Y = 21;
                    break;
                default:
                    break;
            }

            return pointXY;
        }



    }


}
