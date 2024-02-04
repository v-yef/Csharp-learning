namespace Task_1
{
    internal static class Swapper<T>
    {
        public static void Swap(ref T val_1, ref T val_2)
        {
            T Temp = val_1;
            val_1 = val_2;
            val_2 = Temp;
        }
    }
}
