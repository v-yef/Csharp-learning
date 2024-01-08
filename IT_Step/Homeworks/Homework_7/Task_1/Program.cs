/*
 ============================================================================
 Name        : Homework_7-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Write an application that will display simple geometric shapes specified by the user in the console.
  The user selects a shape and sets its location on the screen, as well as its size and color using a menu.
  All user-defined shapes are displayed simultaneously on the screen.
  Shapes (rectangle, rhombus, triangle, polygon) are drawn with asterisks or other symbols.
  To implement the program, it is necessary to develop a class hierarchy (consider the possibility of abstraction).
  To store all user-defined shapes, create a “Collection of geometric shapes” class with the “Display all shapes” method.
  To display all the shapes using the specified method, you need to use the foreach operator, for which in the “Collection of geometric shapes” class
  it is necessary to implement the appropriate interfaces.
 ============================================================================
 */

using System.Collections;

namespace Task_1
{
    class Menu
    {
        public static int VerticalMenu(string[] elements)
        {
            int maxLen = 0;

            foreach (var item in elements)
            {
                if (item.Length > maxLen)
                    maxLen = item.Length;
            }

            ConsoleColor bg = Console.BackgroundColor;
            ConsoleColor fg = Console.ForegroundColor;

            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            //Console.CursorVisible = false;

            int pos = 0;

            while (true)
            {

                for (int i = 0; i < elements.Length; i++)
                {
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(x, y + i);

                    if (i == pos)
                    {
                        Console.BackgroundColor = fg;
                        Console.ForegroundColor = bg;
                    }
                    else
                    {
                        Console.BackgroundColor = bg;
                        Console.ForegroundColor = fg;
                    }

                    Console.Write(elements[i].PadRight(maxLen));
                }

                ConsoleKey consoleKey = Console.ReadKey().Key;

                switch (consoleKey)
                {
                    case ConsoleKey.Enter:
                        return pos;
                    //break;

                    case ConsoleKey.Escape:
                        return elements.Length - 1;
                    //break;

                    case ConsoleKey.UpArrow:
                        if (pos > 0)
                            pos--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (pos < elements.Length - 1)
                            pos++;
                        break;

                    default:
                        break;
                }
            }
        }
    }

    // Цвет фигуры
    enum ShapeColor
    {
        Gray = 7 /*Серый*/,
        Blue = 9 /*Синий*/,
        Green = 10 /*Зеленый*/,
        Red = 12 /*Красный*/,
        Yellow = 14 /*Желтый*/,
        White = 15 /*Белый*/
    }
    // Размер фигуры (множитель размера)
    enum ShapeScale
    {
        Small = 1 /*Маленький*/,
        Medium = 2 /*Средний*/,
        Big = 3 /*Большой*/
    }

    // Расположение фигуры
    enum ShapePosition
    {
        UpperLeft = 0 /*Сверху слева*/,
        UpperCentre = 1 /*Сверху по центру*/,
        UpperRight = 2 /*Сверху справа*/,
        CentreLeft = 3 /*Слева по центру*/,
        CentreCentre = 4 /*По центру*/,
        CentreRight = 5 /*Справа по центру*/,
        LowerLeft = 6 /*Снизу слева*/,
        LowerCentre = 7 /*Снизу по центру*/,
        LowerRight = 8 /*Снизу справа*/
    }

    // Класс "Фигура". Базовый для всех фигур
    abstract class Shape
    {
        protected int XCoord;
        protected int YCoord;

        public ShapeColor Color { get; set; }
        public ShapeScale Scale { get; set; }
        public ShapePosition Position { get; set; }

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

            return;
        }

        // Каждый наследник рисуется по-своему
        public virtual void Draw() { }
    }

    // Класс "Треугольник". Наследуется от "Фигуры", переопределяя метод рисования
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

    // Класс "Прямоугольник". Наследуется от "Фигуры", переопределяя метод рисования
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

    // Класс "Коллекция фигур". Реализует интерфейс IEnumerable
    class ShapeCollection : IEnumerable
    {
        // Вектор из фигур
        ArrayList shapes;

        // При создании экземпляра конструктор выделяет память под вектор из фигур
        public ShapeCollection()
        {
            shapes = new ArrayList();
        }

        // Метод выбора типа фигуры. Принимает ссылку на фигуру
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

        // Метод выбора размера фигуры. Принимает ссылку на фигуру
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
                    _shape.Scale = ShapeScale.Small;
                    break;
                case 1:
                    _shape.Scale = ShapeScale.Medium;
                    break;
                case 2:
                    _shape.Scale = ShapeScale.Big;
                    break;
                default:
                    throw new Exception("Размер не выбран!");
            }

            return;
        }

        // Метод выбора цвета фигуры. Принимает ссылку на фигуру 
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
                    _shape.Color = ShapeColor.Gray;
                    break;
                case 1:
                    _shape.Color = ShapeColor.Blue;
                    break;
                case 2:
                    _shape.Color = ShapeColor.Green;
                    break;
                case 3:
                    _shape.Color = ShapeColor.Red;
                    break;
                case 4:
                    _shape.Color = ShapeColor.Yellow;
                    break;
                case 5:
                    _shape.Color = ShapeColor.White;
                    break;
                default:
                    throw new Exception("Цвет не выбран!");
            }

            return;
        }

        // Метод выбора расположения фигуры. Принимает ссылку на фигуру
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
                    _shape.Position = ShapePosition.UpperLeft;
                    break;
                case 1:
                    _shape.Position = ShapePosition.UpperCentre;
                    break;
                case 2:
                    _shape.Position = ShapePosition.UpperRight;
                    break;
                case 3:
                    _shape.Position = ShapePosition.CentreLeft;
                    break;
                case 4:
                    _shape.Position = ShapePosition.CentreCentre;
                    break;
                case 5:
                    _shape.Position = ShapePosition.CentreRight;
                    break;
                case 6:
                    _shape.Position = ShapePosition.LowerLeft;
                    break;
                case 7:
                    _shape.Position = ShapePosition.LowerCentre;
                    break;
                case 8:
                    _shape.Position = ShapePosition.LowerRight;
                    break;
                default:
                    throw new Exception("Позиция не выбрана!");
            }

            // Расчитать координаты
            _shape.ComputePosition();

            return;
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

            return;
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

            return;
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
