namespace Task_2
{
    internal static class Extension
    {
        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            string[] words = str.Split(
                " ,.!?'\";:@#$%^&*()+=<>/1234567890".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);

            return words.Length;
        }
    }
}
