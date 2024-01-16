namespace Task_1
{
    public static class UserInputProcessor
    {
        public static int? GetIntegerFromUserInRange(int num1, int num2)
        {
            int result;
            string? userInput;
            bool isValidInput;

            do
            {
                Console.WriteLine($"Enter an integer number between {num1} and {num2} " +
                   $"OR press 'Q' to quit.");

                userInput = Console.ReadLine();

                if (userInput is null ||
                    string.Equals(userInput, "Q", StringComparison.OrdinalIgnoreCase))
                {
                    return null;
                }

                isValidInput = int.TryParse(userInput, out result);

                if (isValidInput)
                {
                    if (result < num1 || result > num2)
                    {
                        Console.WriteLine($"Your input {result} is out of range.");
                    }
                }
                else
                {
                    Console.WriteLine($"\"{userInput}\" is not an integer number.");
                }
            }
            while (!isValidInput);

            return result;
        }

        public static string MakeMessageBasedOnIntegerInput(int? input)
        {
            string result;

            if (input % 3 == 0 && input % 5 == 0)
            {
                result = "Fizz Buzz";
            }
            else if (input % 5 == 0)
            {
                result = "Buzz";
            }
            else if (input % 3 == 0)
            {
                result = "Fizz";
            }
            else
            {
                result = input.HasValue ? input.Value.ToString() : string.Empty;
            }

            return result;
        }
    }
}
