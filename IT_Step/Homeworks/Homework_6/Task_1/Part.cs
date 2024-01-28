namespace Task_1
{
    internal abstract class Part: IPart
    {
        public string Name { get; set; } = "Part";
        public bool IsBuilt { get; set; } = false;
        public string WhoBuilt { get; set; } = "Unknown";

        public void PrintInfo() =>
            Console.Write($"{Name} was built. By: < {WhoBuilt} >\n");
    }

    internal class Basement : Part
    {
        public Basement()
        {
            Name = "Basement";
        }
    }

    internal class Wall : Part
    {
        public Wall()
        {
            Name = "Wall";
        }
    }

    internal class Door : Part
    {
        public Door()
        {
            Name = "Door";
        }
    }

    internal class Window : Part
    {
        public Window()
        {
            Name = "Window";
        }
    }

    internal class Roof : Part
    {
        public Roof()
        {
            Name = "Roof";
        }
    }
}
