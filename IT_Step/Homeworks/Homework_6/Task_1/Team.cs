namespace Task_1
{
    internal class Team
    {
        private readonly Worker[] _workers;

        public int Length
        {
            get => _workers.Length;
        }

        public Team()
        {
            _workers = [new Builder("Builder_1"),
                        new Builder("Builder_2"),
                        new Builder("Builder_3"),
                        new Builder("Builder_4"),
                        new TeamLeader("Team Leader")];
        }

        // Индексатор Бригады
        public Worker this[int _Index]
        {
            get
            {
                if (_Index >= 0 && _Index < _workers.Length)
                {
                    return _workers[_Index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (_Index >= 0 && _Index < _workers.Length)
                {
                    _workers[_Index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }
}
