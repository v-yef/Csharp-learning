namespace Task_3
{
    internal static class LastWordLengthDriver
    {
        public static void RunTest()
        {
            Console.WriteLine("Enter a string :");

            string? userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput))
            {
                return;
            }

            Console.WriteLine($"The length of the last word : " +
                $"{userInput.LastWordLength()}");
        }    
    }
}
