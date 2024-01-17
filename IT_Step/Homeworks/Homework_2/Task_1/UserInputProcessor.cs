namespace Task_1
{
    public static class UserInputProcessor
    {
        public static float? GetFloatFromUser()
        {
            float result;
            string? userInput;
            bool isValidInput;

            do
            {
                Console.WriteLine($"Enter a float number OR press 'Q' to quit.");

                userInput = Console.ReadLine();

                if (userInput is null ||
                    string.Equals(userInput, "Q", StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }

                isValidInput = float.TryParse(userInput, out result);

                if (!isValidInput)
                {
                    Console.WriteLine($"\"{userInput}\" is not a float number.");
                }
            }
            while (!isValidInput);

            return result;
        }
    }
}
