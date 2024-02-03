namespace Task_4
{
    internal static class Extension
    {
        public static int[] Filter(this int[] array, Func<int, bool> predicate)
        {
            var tempList = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    tempList.Add(array[i]);
                }
            }

            return tempList.ToArray();
        }
    }
}