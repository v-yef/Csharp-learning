using System.Collections;

namespace Task_1
{
    internal class ShapeCollection : IEnumerable
    {
        private readonly ArrayList _shapes;

        public ShapeCollection()
        {
            _shapes = new ArrayList();
        }

        private void ShapeChoice(ref Shape shape)
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
                    shape = new Rectangle();
                    break;
                case 1:
                    shape = new Triangle();
                    break;
                default:
                    throw new Exception("Тип не выбран!");
            }
        }

        private void ScaleChoice(ref Shape shape)
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

        private void ColorChoice(ref Shape shape)
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

        private void PositionChoice(ref Shape shape)
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

            // Расчитать координаты
            shape.ComputePosition();
        }

        public void AddShape()
        {
            Console.Clear();

            // На видимой области консоли помещается 9 фигур
            if (_shapes.Count == 9)
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
            this._shapes.Add(NewShape);

            Console.Clear();

            Console.WriteLine("Фигура добавлена в коллекцию.");

            Console.ReadLine();
        }

        void PrintCollection()
        {
            Console.Clear();

            foreach (Shape shape in _shapes)
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

        IEnumerator IEnumerable.GetEnumerator() => _shapes.GetEnumerator();
    }
}
