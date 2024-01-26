/*
 ============================================================================
 Name        : Homework_6-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create classes "House", "Basement", "Walls", "Door", "Window",
               "Roof", "Worker", "TeamLeader", "Team" and interfaces "IWorker",
               "IPart". All parts of the house must implement the "IPart"
               interface. The "IWorker" interface is implemented by workers
               and the team leader. A group of workers ("Team") is building a
               house ("House"). The house consists of a foundation ("Basement"),
               walls ("Wall"), windows ("Window"), doors ("Door"), roof (Roof).
               According to the project, the house has 1 foundation, 4 walls,
               1 door, 4 windows and 1 roof. The team begins to work, and the
               workers “build” the house in logical order, starting from the
               foundation. Each worker does not know in advance the previous
               stage of construction, so he “checks” what was built and continues
               the work. When the work is complete the team leader comes - he
               does not build anything, but generates a report on what was built
               and what part of the work has been completed. All team members
               are called to work in random order and only one member can be
               busy at the moment.
 ============================================================================
 */

namespace Task_1
{
    abstract class IPart
    {
        // Флаг построена ли часть
        public bool IsBuilt { get; set; } = false;

        // Подпись "Кем построена"
        public string Signature { get; set; } = "< Пусто >";

        // Метод ввода информации о части. Для каждого наследника свой
        public virtual void Print()
        {
            Console.WriteLine("Built : " + Signature);
        }
    }

    class Basement : IPart
    {
        public override void Print()
        {
            Console.Write("Basement. ");
            base.Print();
        }
    }

    class Wall : IPart
    {
        public override void Print()
        {
            Console.Write("Wall. ");
            base.Print();
        }
    }

    class Door : IPart
    {
        public override void Print()
        {
            Console.Write("Door. ");
            base.Print();
        }
    }

    class Window : IPart
    {
        public override void Print()
        {
            Console.Write("Window. ");
            base.Print();
        }
    }

    class Roof : IPart
    {
        public override void Print()
        {
            Console.Write("Roof. ");
            base.Print();
        }
    }

    class House
    {
        public IPart[] parts;

        public int Length
        {
            get { return parts.Length; }
        }

        // Конструктор заполняет массив частей при создании экземпляра класса
        public House()
        {
            parts = new IPart[] { new Basement(), new Wall(), new Wall(), new Wall(), new Wall(),
                            new Door(), new Window(), new Window(), new Window(), new Window(), new Roof() };
        }

        // Индексатор Дома
        public IPart this[int _Index]
        {
            get
            {
                if (_Index >= 0 && _Index < parts.Length)
                {
                    return parts[_Index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (_Index >= 0 && _Index < parts.Length)
                {
                    parts[_Index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        // Метод проверки построен ли Дом
        public bool IsBuilt()
        {
            foreach (var part in parts)
            {
                // Если хотя бы одна часть не построена, то дом не построен
                if (part.IsBuilt == false)
                {
                    return false;
                }
            }

            return true;
        }
    }

    abstract class IWorker
    {
        public string Name { get; }

        public IWorker(string _Name) { Name = _Name; }

        // Метод выполнения работы по Дому. Для каждого наследника свой
        public virtual void DoWork(House _House) { }
    }

    class Worker : IWorker
    {
        public Worker(string _Name) : base(_Name) { }

        public override void DoWork(House _House)
        {
            Console.WriteLine("Работает строитель. Что-то построено.");

            for (int i = 0; i < _House.Length; i++)
            {
                // Проверка какая из следующих частей не построена
                if (_House[i].IsBuilt == false)
                {
                    // Построить часть, подписав её своим именем
                    _House[i].Signature = Name;
                    _House[i].IsBuilt = true;
                    break;
                }
            }
        }
    }

    class TeamLeader : IWorker
    {
        public TeamLeader(string _Name) : base(_Name) { }

        public override void DoWork(House _House)
        {
            // Кол-во построееных частей для вывода объема проделанной работы
            int iParts = 0;

            Console.WriteLine("Работает бригадир. Отчёт :");

            foreach (var part in _House.parts)
            {
                // Вывести информацию о всех построенных частях
                if (part.IsBuilt == true)
                {
                    iParts++;
                    part.Print();
                }
            }

            Console.WriteLine("Выполнено работы : " + (int)((float)iParts / _House.Length * 100) + "%");
        }
    }

    class Team
    {
        private IWorker[] workers;

        public int Length
        {
            get { return workers.Length; }
        }

        // Конструктор заполняет массив частей при создании экземпляра класса
        public Team()
        {
            workers = new IWorker[]{ new Worker("Работник_1"), new Worker("Работник_2"), new Worker("Работник_3"),
                                    new Worker("Работник_4"), new TeamLeader("Бригадир") };
        }

        // Индексатор Бригады
        public IWorker this[int _Index]
        {
            get
            {
                if (_Index >= 0 && _Index < workers.Length)
                {
                    return workers[_Index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (_Index >= 0 && _Index < workers.Length)
                {
                    workers[_Index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            House house = new House();
            Team team = new Team();

            Console.WriteLine("Строительство началось!");
            Console.WriteLine("========================");
            Console.WriteLine();

            // Пока Дом не построен
            while (!house.IsBuilt())
            {
                Random random = new Random();

                // Вызывать случайного работника для выполнения работы по Дому
                team[random.Next(team.Length)].DoWork(house);

                // Следующий шаг по нажатию клавиши Enter
                Console.ReadLine();
            }

            Console.WriteLine("========================");
            Console.WriteLine("Строительство завершено!");
            Console.WriteLine();

            // Вызвать бригадира для формирования отчета
            // (вызов по индексу - известно что он последний в списке)
            team[team.Length - 1].DoWork(house);

            Console.ReadLine();
        }
    }
}
