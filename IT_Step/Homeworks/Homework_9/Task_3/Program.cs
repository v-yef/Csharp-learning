/*
 ============================================================================
 Name        : Homework_9-Task_3
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a generic class "Circular Queue". Implement standard methods and properties for circular queue operation.
 ============================================================================
 */

namespace Task_3
{
    class MyCircularQueue<T>
    {
        // Список, содержащий пары "значение - приоритет".
        private List<T> ListContainer;

        public MyCircularQueue()
        {
            // Выделить память под список с 0 элементов.
            this.ListContainer = new List<T>(0);
        }

        // Поле-свойство Размер очереди.
        public int Size
        {
            get { return this.ListContainer.Count; }
        }

        // Метод вставки в очередь. 
        public void Push(T _Value)
        {
            ListContainer.Add(_Value);

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

        // Метод получения первого элемента очереди.
        public T Peek()
        {
            if (this.Empty())
                throw new Exception("Очередь пуста!");

            return this.ListContainer[0];
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

        // Метод кольцевания очереди. Первый элемент переносится в конец.
        public void Circle()
        {
            if (this.ListContainer.Count < 2)
                throw new Exception("Слишком мало элементов в очереди!");

            T Val = this.Peek();

            this.Pop();

            this.Push(Val);
        }

        // Метод вывода очереди на экран.
        public void Print()
        {
            foreach (var item in this.ListContainer)
            {
                Console.Write(item + " ");
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
                MyCircularQueue<int> circularQueue = new MyCircularQueue<int>();

                //circularQueue.Pop();
                circularQueue.Push(1);
                circularQueue.Push(2);
                circularQueue.Push(3);
                circularQueue.Push(4);
                circularQueue.Push(5);

                circularQueue.Print();

                Console.WriteLine("Размер очереди : " + circularQueue.Size);
                //circularQueue.Pop();
                //circularQueue.Pop();
                //circularQueue.Pop();
                //circularQueue.Pop();

                circularQueue.Circle();
                circularQueue.Print();

                circularQueue.Circle();
                circularQueue.Print();

                circularQueue.Clear();
                circularQueue.Print();
                Console.WriteLine("Размер очереди : " + circularQueue.Size);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }
    }
}
