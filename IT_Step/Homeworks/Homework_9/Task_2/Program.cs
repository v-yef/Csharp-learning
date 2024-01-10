/*
 ============================================================================
 Name        : Homework_9-Task_2
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a generic class "Queue" with priorities. Implement standard methods and properties for queue operation
with priorities.
 ============================================================================
 */

namespace Task_2
{
    class MyPriorityQueue<T>
    {
        // Список, содержащий пары "значение - приоритет".
        private List<(T, uint)> ListContainer;

        public MyPriorityQueue()
        {
            // Выделить память под список с 0 элементов.
            this.ListContainer = new List<(T, uint)>(0);
        }

        // Поле-свойство Размер очереди.
        public int Size
        {
            get { return this.ListContainer.Count; }
        }

        // Метод вставки в очередь. Принимает значение и приоритет (в виде целочисленного ключа без знака).
        // Чем меньше ключ, тем выше приоритет значения. 
        public void Push(T _Value, uint _Priority)
        {
            if (this.Empty())
            {
                ListContainer.Add((_Value, _Priority));
            }
            else
            {
                int Index = ListContainer.FindLastIndex(i => i.Item2 <= _Priority);

                if ((Index == -1) && _Priority == 0)
                {
                    ListContainer.Insert(0, (_Value, _Priority));
                }
                else if (Index == -1)
                {
                    ListContainer.Add((_Value, _Priority));
                }
                else
                {
                    ListContainer.Insert(Index + 1, (_Value, _Priority));
                }
            }

            return;
        }

        // Метод удаления первого элемента очереди.
        public void Pop()
        {
            if (this.Empty())
                throw new Exception("Очередь пуста!");

            this.ListContainer.RemoveAt(0);

            return;
        }

        // Метод получения первого элемента очереди. Возвращается только значение (первый элемент пары).
        public T Peek()
        {
            if (this.Empty())
                throw new Exception("Очередь пуста!");

            return this.ListContainer[0].Item1;
        }

        // Метод проверки пуста ли очередь.
        public bool Empty()
        {
            return this.ListContainer.Count == 0;
        }

        // Метод очистки очереди.
        public void Clear()
        {
            this.ListContainer.Clear();

            return;
        }

        // Метод вывода очереди на экран. Выводятся только значения (первый элемент пары).
        public void Print()
        {
            foreach (var item in this.ListContainer)
            {
                Console.Write(item.Item1 + " ");
            }

            Console.WriteLine();

            return;
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyPriorityQueue<int> priorityQueue = new MyPriorityQueue<int>();

                //priorityQueue.Pop();
                priorityQueue.Push(1, 1);
                priorityQueue.Push(2, 1);
                priorityQueue.Push(2, 1);
                priorityQueue.Push(3, 2);
                priorityQueue.Push(3, 2);

                priorityQueue.Print();

                Console.WriteLine("Размер очереди : " + priorityQueue.Size);

                priorityQueue.Push(15, 1);
                priorityQueue.Print();

                priorityQueue.Push(10, 0);
                priorityQueue.Print();

                priorityQueue.Push(11, 0);
                priorityQueue.Print();

                Console.WriteLine("Размер очереди : " + priorityQueue.Size);

                priorityQueue.Clear();
                priorityQueue.Print();

                Console.WriteLine("Размер очереди : " + priorityQueue.Size);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }
    }
}
