namespace Task_1
{
    internal abstract class Worker : IWorker
    {
        public string Name { get; }

        public Worker(string name)
        {
            Name = name;
        }

        public virtual void DoWork(House house) { }
    }

    internal class Builder : Worker
    {
        public Builder(string _Name) : base(_Name) { }

        public override void DoWork(House house)
        {
            Console.WriteLine("Работает строитель. Что-то построено.");

            for (int i = 0; i < house.Length; i++)
            {
                // Проверка какая из следующих частей не построена
                if (!house[i].IsBuilt)
                {
                    // Построить часть, подписав её своим именем
                    house[i].WhoBuilt = Name;
                    house[i].IsBuilt = true;
                    break;
                }
            }
        }
    }

    internal class TeamLeader : Worker
    {
        public TeamLeader(string name) : base(name) { }

        public override void DoWork(House house)
        {
            // Кол-во построееных частей для вывода объема проделанной работы
            int iParts = 0;

            Console.WriteLine("Работает бригадир. Отчёт :");

            foreach (var part in house.parts)
            {
                // Вывести информацию о всех построенных частях
                if (part.IsBuilt)
                {
                    iParts++;
                    part.PrintInfo();
                }
            }

            Console.WriteLine("Выполнено работы : " + (int)((float)iParts / house.Length * 100) + "%");
        }
    }
}
