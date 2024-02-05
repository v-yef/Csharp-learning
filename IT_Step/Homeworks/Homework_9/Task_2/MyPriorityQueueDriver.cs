namespace Task_2
{
    internal static class MyPriorityQueueDriver
    {
        public static void RunTest()
        {
            try
            {
                var priorityQueue = new MyPriorityQueue<int>();

                priorityQueue.Push(1, 1);
                priorityQueue.Push(2, 1);
                priorityQueue.Push(2, 1);
                priorityQueue.Push(3, 2);
                priorityQueue.Push(3, 2);

                priorityQueue.Print();

                Console.WriteLine("Size of the queue : " + priorityQueue.Size);

                priorityQueue.Push(15, 1);
                priorityQueue.Print();

                priorityQueue.Push(10, 0);
                priorityQueue.Print();

                priorityQueue.Push(11, 0);
                priorityQueue.Print();

                Console.WriteLine("Size of the queue : " + priorityQueue.Size);

                priorityQueue.Clear();
                priorityQueue.Print();

                Console.WriteLine("Size of the queue : " + priorityQueue.Size);

                priorityQueue.Pop();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
