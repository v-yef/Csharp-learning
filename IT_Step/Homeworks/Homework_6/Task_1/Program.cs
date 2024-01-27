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
