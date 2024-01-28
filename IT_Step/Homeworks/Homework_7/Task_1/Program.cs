/*
 ============================================================================
 Name        : Homework_7-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Write a program to display user-specified geometric shapes in the
               console. The user selects a shape's type, position, size and color
               using a menu. All user-defined shapes must be displayed on the
               screen simultaneously. Shapes (rectangle, rhombus, triangle,
               polygon) are drawn with asterisks or other symbols. To write the
               program, it is necessary to build a class hierarchy (consider the
               possibility of abstraction). To store user-defined shapes create
               a “Collection of geometric shapes” class with the “Display all
               shapes” method. To display all shapes using the specified method,
               you need to use the foreach operator, for which you must implement
               the appropriate interfaces.
 ============================================================================
 */

using System.Collections;

namespace Task_1
{
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
        Small = 1,
        Medium = 2,
        Big = 3
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

    abstract class Shape
    {
        protected int XCoord;
        protected int YCoord;

        public Color Color { get; set; }
        public ScaleFactor Scale { get; set; }
        public Position Position { get; set; }

        // Метод перевода Расположения в координаты x y
        public void ComputePosition()
        {
            switch ((int)this.Position)
            {
                case 0:
                    this.XCoord = 1; this.YCoord = 1;
                    break;
                case 1:
                    this.XCoord = 31; this.YCoord = 1;
                    break;
                case 2:
                    this.XCoord = 61; this.YCoord = 1;
                    break;
                case 3:
                    this.XCoord = 1; this.YCoord = 11;
                    break;
                case 4:
                    this.XCoord = 31; this.YCoord = 11;
                    break;
                case 5:
                    this.XCoord = 61; this.YCoord = 11;
                    break;
                case 6:
                    this.XCoord = 1; this.YCoord = 21;
                    break;
                case 7:
                    this.XCoord = 31; this.YCoord = 21;
                    break;
                case 8:
                    this.XCoord = 61; this.YCoord = 21;
                    break;
                default:
                    break;
            }
        }

        public virtual void Draw() { }
    }

    class Triangle : Shape
    {
        public override void Draw()
        {
            // Установить цвет вывода
            Console.ForegroundColor = (ConsoleColor)Color;

            // Длина цикла зависит от множителя размера. 3 - просто подходящее число для видимой области консоли
            for (int i = 0; i < 3 * (int)Scale; i++)
            {
                // Перевод курсора в нужную позицию
                Console.SetCursorPosition(XCoord, YCoord + i);

                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
            }

            return;
        }
    }

    class Rectangle : Shape
    {
        public override void Draw()
        {
            // Установить цвет вывода
            Console.ForegroundColor = (ConsoleColor)Color;

            // Длина цикла зависит от множителя размера. 3 - просто подходящее число для видимой области консоли
            for (int i = 0; i < 3 * (int)Scale; i++)
            {
                // Перевод курсора в нужную позицию
                Console.SetCursorPosition(XCoord, YCoord + i);

                for (int j = 0; j < 3 * (int)Scale; j++)
                {
                    Console.Write("*");
                }
            }

            return;
        }
    }

    class ShapeCollection : IEnumerable
    {
        // Вектор из фигур
        ArrayList shapes;

        public ShapeCollection()
        {
            shapes = new ArrayList();
        }

        private void ShapeChoice(ref Shape _shape)
        {
            Console.Clear();

            Console.WriteLine("Тип создаваемой фигуры :");

            int Type = Menu.VerticalMenu(new string[]
            {
                "Прямоугольник",
                "Треугольник",
                "Выход"
            });

            switch (Type)
            {
                case 0:
                    _shape = new Rectangle();
                    break;
                case 1:
                    _shape = new Triangle();
                    break;
                default:
                    throw new Exception("Тип не выбран!");
            }

            return;
        }

        private void ScaleChoice(ref Shape _shape)
        {
            Console.Clear();

            Console.WriteLine("Размер создаваемой фигуры :");

            int Scale = Menu.VerticalMenu(new string[]
            {
                "Маленький",
                "Средний",
                "Большой",
                "Выход"
            });

            switch (Scale)
            {
                case 0:
                    _shape.Scale = ScaleFactor.Small;
                    break;
                case 1:
                    _shape.Scale = ScaleFactor.Medium;
                    break;
                case 2:
                    _shape.Scale = ScaleFactor.Big;
                    break;
                default:
                    throw new Exception("Размер не выбран!");
            }
        }

        private void ColorChoice(ref Shape _shape)
        {
            Console.Clear();

            Console.WriteLine("Цвет создаваемой фигуры :");

            int Color = Menu.VerticalMenu(new string[]
            {
                "Серый",
                "Синий",
                "Зеленый",
                "Красный",
                "Желтый",
                "Белый",
                "Выход",

            });

            switch (Color)
            {
                case 0:
                    _shape.Color = Task_1.Color.Gray;
                    break;
                case 1:
                    _shape.Color = Task_1.Color.Blue;
                    break;
                case 2:
                    _shape.Color = Task_1.Color.Green;
                    break;
                case 3:
                    _shape.Color = Task_1.Color.Red;
                    break;
                case 4:
                    _shape.Color = Task_1.Color.Yellow;
                    break;
                case 5:
                    _shape.Color = Task_1.Color.White;
                    break;
                default:
                    throw new Exception("Цвет не выбран!");
            }
        }

        private void PositionChoice(ref Shape _shape)
        {
            Console.Clear();

            Console.WriteLine("Позиция создаваемой фигуры :");

            int Position = Menu.VerticalMenu(new string[]
            {
                "Сверху слева",
                "Сверху по центру",
                "Сверху справа",
                "Слева по центру",
                "По центру",
                "Справа по центру",
                "Снизу слева",
                "Снизу по центру",
                "Снизу справа",
                "Выход",

            });

            switch (Position)
            {
                case 0:
                    _shape.Position = Task_1.Position.UpperLeft;
                    break;
                case 1:
                    _shape.Position = Task_1.Position.UpperCentre;
                    break;
                case 2:
                    _shape.Position = Task_1.Position.UpperRight;
                    break;
                case 3:
                    _shape.Position = Task_1.Position.CentreLeft;
                    break;
                case 4:
                    _shape.Position = Task_1.Position.CentreCentre;
                    break;
                case 5:
                    _shape.Position = Task_1.Position.CentreRight;
                    break;
                case 6:
                    _shape.Position = Task_1.Position.LowerLeft;
                    break;
                case 7:
                    _shape.Position = Task_1.Position.LowerCentre;
                    break;
                case 8:
                    _shape.Position = Task_1.Position.LowerRight;
                    break;
                default:
                    throw new Exception("Позиция не выбрана!");
            }

            // Расчитать координаты
            _shape.ComputePosition();
        }

        // Метод добавления фигуры в коллекцию
        public void AddShape()
        {
            Console.Clear();

            // На видимой области консоли помещается 9 фигур
            if (shapes.Count == 9)
            {
                Console.WriteLine("Коллекция фигур заполнена!");

                Console.ReadLine();

                return;
            }

            // Создать экземпляр фигуры
            Shape NewShape = null;

            // Заполнить экземпляр фигуры, передавая его в методы
            this.ShapeChoice(ref NewShape);

            this.ScaleChoice(ref NewShape);

            this.ColorChoice(ref NewShape);

            this.PositionChoice(ref NewShape);

            // Добавить заполненный экземпляр в коллекцию
            this.shapes.Add(NewShape);

            Console.Clear();

            Console.WriteLine("Фигура добавлена в коллекцию.");

            Console.ReadLine();
        }

        // Метод вывода коллекции на экран
        void PrintCollection()
        {
            Console.Clear();

            foreach (Shape shape in shapes)
            {
                shape.Draw();
            }

            Console.ReadLine();
        }

        public void MenuStart()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Gray;

                int Choice = Menu.VerticalMenu(new string[]
                {
                "Добавить фигуру",
                "Распечатать фигуры",
                "Выход из программы"
                });

                switch (Choice)
                {
                    case 0:
                        this.AddShape();
                        break;
                    case 1:
                        this.PrintCollection();
                        break;
                    default:
                        return;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return shapes.GetEnumerator();
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            ShapeCollection collection = new ShapeCollection();
            collection.MenuStart();

            //Console.ReadLine();
        }
    }
}
