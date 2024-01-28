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
               1 door, 4 windows and 1 roof. The team begins working, and the
               workers “build” the house in logical order, starting from the
               foundation. Each worker does not know in advance the previous
               stage of construction, so he “checks” what was built and continues
               the work, and the part he built remain unknown until the team
               leader comes. The team leader does not build anything, but
               generates a report on what parts were built and by whom, as well
               as what part of the work has been completed. All team members
               are called to work in random order and only one member can be
               busy at the moment.
 ============================================================================
 */

namespace Task_1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var house = new House();
            var team = new Team();

            Console.WriteLine("The work has begun!");
            Console.WriteLine("========================");
            Console.WriteLine();

            Random random = new Random();

            // At every iteration the random worker is called to do the work.
            while (!house.IsBuilt())
            {
                int workerIndex = random.Next(team.Length);

                team[workerIndex].DoWork(house);

                // Next iteration is by pressing "Enter".
                Console.ReadLine();
            }

            Console.WriteLine("========================");
            Console.WriteLine("The work is completed!");
            Console.WriteLine();

            // Find the team leader to create a final report.
            foreach (var worker in team)
            {
                if (worker.Name.Equals("Team Leader"))
                {
                    worker.DoWork(house);
                }
            }

            Console.ReadLine();
        }
    }
}
