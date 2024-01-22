/*
 ============================================================================
 Name        : Homework_4-Task_2
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create an abstract Worker base class with the Print() method. Create four derived classes: President,
Security, Manager, Engineer. Override the Print() method to print the information that corresponds to each employee type.
 ============================================================================
 */

namespace Task_2
{
    abstract class Worker
    {
        string Name { get; set; }
        string Surname { get; set; }
        int Salary { get; set; }

        protected Worker(string _Name, string _Surname, int _Salary)
        {
            Name = _Name;
            Surname = _Surname;
            Salary = _Salary;
        }

        public virtual void Print()
        {
            Console.WriteLine("Имя : " + Name);
            Console.WriteLine("Фамилия : " + Surname);
            Console.WriteLine("Зарплата : " + Salary);
        }
    }

    class President : Worker
    {
        public President(string _Name, string _Surname, int _Salary) : base(_Name, _Surname, _Salary) { }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Должность : Президент");
        }
    }

    class Security : Worker
    {
        public Security(string _Name, string _Surname, int _Salary) : base(_Name, _Surname, _Salary) { }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Должность : Охранник");
        }
    }

    class Manager : Worker
    {
        public Manager(string _Name, string _Surname, int _Salary) : base(_Name, _Surname, _Salary) { }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Должность : Менеджер");
        }
    }

    class Engineer : Worker
    {
        public Engineer(string _Name, string _Surname, int _Salary) : base(_Name, _Surname, _Salary) { }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Должность : Инженер");
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = new Worker[4];

            workers[0] = new President("Имя_1", "Фамилия_1", 10000);
            workers[1] = new Security("Имя_2", "Фамилия_2", 3000);
            workers[2] = new Manager("Имя_3", "Фамилия_3", 6000);
            workers[3] = new Engineer("Имя_4", "Фамилия_4", 5000);

            foreach (var worker in workers)
            {
                worker.Print();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
