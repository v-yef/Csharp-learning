namespace Task_2
{
    internal class MyPriorityQueue<T>
    {
        // The list contains pairs "value - priority".
        private readonly List<(T, uint)> ListContainer;

        public MyPriorityQueue()
        {
            this.ListContainer = new List<(T, uint)>(0);
        }

        public int Size
        {
            get => this.ListContainer.Count;
        }

        // The Push method imlements logic "the lesser priority key is - the closer to
        // the beginning its member is inserted".
        public void Push(T value, uint priority)
        {
            if (this.IsEmpty())
            {
                ListContainer.Add((value, priority));
            }
            else
            {
                int Index = ListContainer.FindLastIndex(i => i.Item2 <= priority);

                if ((Index == -1) && priority == 0)
                {
                    ListContainer.Insert(0, (value, priority));
                }
                else if (Index == -1)
                {
                    ListContainer.Add((value, priority));
                }
                else
                {
                    ListContainer.Insert(Index + 1, (value, priority));
                }
            }
        }

        public void Pop()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException(
                    "Cannot pop the first element! The queue is empty!");
            }

            this.ListContainer.RemoveAt(0);
        }

        public T Peek()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException(
                    "Cannot peek the first element! The queue is empty!");
            }

            return this.ListContainer[0].Item1;
        }

        public bool IsEmpty() => this.ListContainer.Count == 0;

        public void Clear()
        {
            this.ListContainer.Clear();
        }

        public void Print()
        {
            foreach (var item in this.ListContainer)
            {
                Console.Write(item.Item1 + " ");
            }

            Console.WriteLine();
        }
    }
}
