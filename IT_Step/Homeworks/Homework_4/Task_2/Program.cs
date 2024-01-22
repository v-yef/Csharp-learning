/*
 ============================================================================
 Name        : Homework_4-Task_2
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create an abstract base class Worker with the Print() method.
               Then create four derived classes: President, Security, Manager,
               Engineer. Override the Print() method to print the information
               of each employee type.
 ============================================================================
 */

namespace Task_2
{
    abstract class Worker
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly int salary;

        protected Worker(string firstName, string lastName, int salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.salary = salary;
        }

        public virtual void Print()
        {
            Console.WriteLine("First name : " + firstName);
            Console.WriteLine("Last name  : " + lastName);
            Console.WriteLine("Salary     : " + salary);
        }
    }

    class President : Worker
    {
        public President(string firstName, string lastName, int salary)
            : base(firstName, lastName, salary)
        { }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Role       : President");
        }
    }

    class Security : Worker
    {
        public Security(string firstName, string lastName, int salary)
            : base(firstName, lastName, salary)
        { }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Role       : Security");
        }
    }

    class Manager : Worker
    {
        public Manager(string firstName, string lastName, int salary)
            : base(firstName, lastName, salary)
        { }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Role       : Manager");
        }
    }

    class Engineer : Worker
    {
        public Engineer(string firstName, string lastName, int salary)
            : base(firstName, lastName, salary)
        { }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Role       : Engineer");
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = [
                new President("John", "Johnson", 10000),
                new Security("Kevin", "Kevinson", 3000),
                new Manager("Peter", "Peterson", 6000),
                new Engineer("Donald", "Donaldson", 5000)
                ];

            foreach (var worker in workers)
            {
                worker.Print();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
