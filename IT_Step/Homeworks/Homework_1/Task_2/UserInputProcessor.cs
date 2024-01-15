namespace Task_2
{
    public static class UserInputProcessor
    {
        public static double? GetDoubleFromUser()
        {
            double result;
            string? userInput;
            bool isValidInput;

            do
            {
                Console.WriteLine($"Enter a double number " +
                   $"OR press 'Q' to quit.");

                userInput = Console.ReadLine();

                if (userInput is null ||
                    string.Equals(userInput, "Q", StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }

                isValidInput = double.TryParse(userInput, out result);

                if (!isValidInput)
                {
                    Console.WriteLine($"\"{userInput}\" is not a double number.");
                }
            }
            while (!isValidInput);

            return result;
        }

        public static double CalculatePercentPartOfNumber(double number, double percent) =>
            Math.Abs(Math.Round(number * percent / 100, 6));
    }
}
