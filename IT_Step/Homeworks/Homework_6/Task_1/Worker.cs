namespace Task_1
{
    internal abstract class Worker : IWorker
    {
        public string Name { get; }

        protected Worker(string name)
        {
            Name = name;
        }

        public virtual void DoWork(House house) { }
    }

    internal class Builder : Worker
    {
        public Builder(string name) : base(name) { }

        public override void DoWork(House house)
        {
            // Find out what part must be build next.
            // Build it and left a signature of the builder.
            for (int i = 0; i < house.Length; i++)
            {
                if (!house[i].IsBuilt)
                {
                    house[i].WhoBuilt = Name;
                    house[i].IsBuilt = true;
                    break;
                }
            }

            Console.WriteLine(
                "Something was build. Press \"Enter\" to continue...");
        }
    }

    internal class TeamLeader : Worker
    {
        public TeamLeader(string name) : base(name) { }

        public override void DoWork(House house)
        {
            int partsCount = 0;

            Console.WriteLine("Team leader's report :");

            foreach (var part in house.parts)
            {
                if (part.IsBuilt)
                {
                    part.PrintInfo();
                    partsCount++;
                }
            }

            Console.WriteLine(
                "Work is completed by : " + 
                Math.Round((float)partsCount / house.Length * 100, 2) + " %");

            Console.WriteLine("Press \"Enter\" to continue...");
        }
    }
}
