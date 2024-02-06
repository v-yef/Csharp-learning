namespace Task_3
{
    internal class MyCircularQueue<T>
    {
        private readonly List<T> ListContainer;

        public MyCircularQueue()
        {
            this.ListContainer = new List<T>(0);
        }

        public int Size
        {
            get => this.ListContainer.Count;
        }

        public void Push(T _Value) => this.ListContainer.Add(_Value);

        public void Pop()
        {
            if (this.Empty())
            {
                throw new InvalidOperationException(
                    "Cannot pop the first element! The queue is empty!");
            }

            this.ListContainer.RemoveAt(0);
        }

        public T Peek()
        {
            if (this.Empty())
            {
                throw new InvalidOperationException(
                    "Cannot peek the first element! The queue is empty!");
            }

            return this.ListContainer[0];
        }

        public bool Empty() => this.ListContainer.Count == 0;

        public void Clear() => this.ListContainer.Clear();

        // "Circling" the queue. The first element is moved to the end.
        public void Circle()
        {
            if (this.ListContainer.Count < 2)
            {
                throw new InvalidOperationException(
                    "The queue has too few elements to be circular!");
            }

            T Val = this.Peek();

            this.Pop();

            this.Push(Val);
        }

        public void Print()
        {
            foreach (var item in this.ListContainer)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
