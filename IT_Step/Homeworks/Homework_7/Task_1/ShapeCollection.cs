using System.Collections;

namespace Task_1
{
    internal class ShapeCollection : IEnumerable
    {
        private const int MaxShapesToDisplay = 9;

        private readonly ArrayList _shapes;

        public ShapeCollection()
        {
            _shapes = new ArrayList();
        }

        public void MenuStart()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Gray;

                int userChoice = Menu.VerticalMenu([
                    "Add shape",
                    "Print all shapes",
                    "Exit"]);

                switch (userChoice)
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

        private void AddShape()
        {
            Console.Clear();

            if (_shapes.Count == MaxShapesToDisplay)
            {
                Console.WriteLine("Can't add a shape. Collection is full.");
                Console.ReadLine();

                return;
            }

            Shape newShape = ShapeMaker.CreateShape();

            if(newShape is null)
            {
                return;
            }

            this._shapes.Add(newShape);

            Console.Clear();

            Console.WriteLine("Фигура добавлена в коллекцию.");

            Console.ReadLine();
        }

        private void PrintCollection()
        {
            Console.Clear();

            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }

            Console.ReadLine();
        }

        IEnumerator IEnumerable.GetEnumerator() => _shapes.GetEnumerator();
    }
}
