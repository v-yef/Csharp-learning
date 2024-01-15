namespace Task_3
{
    public static class UserInputProcessor
    {
        public static sbyte? GetDigitFromUser()
        {
            sbyte result;
            string? userInput;
            bool isValidInput;

            do
            {
                Console.WriteLine($"Enter a digit OR press 'Q' to quit.");

                userInput = Console.ReadLine();

                if (userInput is null ||
                    string.Equals(userInput, "Q", StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }

                isValidInput = sbyte.TryParse(userInput, out result) && (result / 10 == 0);

                if (!isValidInput)
                {
                    Console.WriteLine($"\"{userInput}\" is not a digit.");
                }
            }
            while (!isValidInput);

            return result;
        }
    }
}
