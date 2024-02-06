namespace Task_3
{
    internal static class MyCircularQueueDriver
    {
        public static void RunTest()
        {
            try
            {
                var circularQueue = new MyCircularQueue<int>();

                circularQueue.Push(1);
                circularQueue.Push(2);
                circularQueue.Push(3);
                circularQueue.Push(4);
                circularQueue.Push(5);
                circularQueue.Print();
                Console.WriteLine("Size of the queue : " + circularQueue.Size);

                Console.WriteLine("Popping two elements from the queue...");
                circularQueue.Pop();
                circularQueue.Pop();
                circularQueue.Print();
                Console.WriteLine("Size of the queue : " + circularQueue.Size);

                Console.WriteLine("Scrolling the queue one time...");
                circularQueue.Circle();
                circularQueue.Print();

                Console.WriteLine("Scrolling the queue one more time...");
                circularQueue.Circle();
                circularQueue.Print();

                Console.WriteLine("The queue is cleared now! ");
                circularQueue.Clear();
                circularQueue.Print();
                Console.WriteLine("Size of the queue : " + circularQueue.Size);

                circularQueue.Pop();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
