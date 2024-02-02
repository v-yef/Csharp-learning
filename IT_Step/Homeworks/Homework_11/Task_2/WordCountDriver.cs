namespace Task_2
{
    internal static class WordCountDriver
    {
        public static void RunTest()
        {
            Console.WriteLine("Enter a string :");

            string? userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput))
            {
                return;
            }

            Console.WriteLine($"The number of words : {userInput.WordCount()}");
        }
    }
}
