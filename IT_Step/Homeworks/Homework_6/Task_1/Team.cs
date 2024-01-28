using System.Collections;

namespace Task_1
{
    internal class Team : IEnumerable<Worker>
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

        public Worker this[int index]
        {
            get
            {
                if (index >= 0 && index < _workers.Length)
                {
                    return _workers[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(index), index, "The index value is outside the bounds of the \"Workers\" array.");
                }
            }

            set
            {
                if (index >= 0 && index < _workers.Length)
                {
                    _workers[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(index), index, "The index value is outside the bounds of the \"Workers\" array.");
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>
            _workers.GetEnumerator();

        public IEnumerator<Worker> GetEnumerator() =>
           ((IEnumerable<Worker>)_workers).GetEnumerator();
    }
}
