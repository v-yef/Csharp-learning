namespace Task_3
{
    internal static class Extension
    {
        public static int LastWordLength(this string str)
        {
            string[] words = str.Split(
                " ,.!?'\";:@#$%^&*()+=<>/1234567890".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);

            string lastWord = words[^1];

            return lastWord.Length;
        }
    }
}