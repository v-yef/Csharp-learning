using System.Text.RegularExpressions;

namespace Task_1
{
    internal static class BoolCalculator
    {
        public static string GetExpressionFromUser()
        {
            Console.WriteLine("Введите выражение :");

            string? InputString = Console.ReadLine();

            if(InputString is null)
            {
                return string.Empty;
            }

            // (Начиная с начала строки) - цифра(любое кол-во) - конкретный знак(любое кол-во) - цифра(любое кол-во)
            // Опции - копиляция в сборку для более быстрого выполнения
            Regex regex = new Regex(@"^\d+[<>!=]+\d+", RegexOptions.Compiled);

            if (!regex.IsMatch(InputString))
            {
                throw new Exception("Неправильный формат ввода!");
            }
            else
            {
                return InputString;
            }
        }

        public static bool EvaluateExpression(string input)
        {
            
            // Выделить из входной строки подстроки по знаку - разделителю
            string[] numbers = input.Split("<>!=".ToCharArray(),
                                    StringSplitOptions.RemoveEmptyEntries);

            // Очистить входную строку от чисел, проверяя каждый символ и удаляя его, если это число,
            // при этом перезаписывая строку без этого символа. В итоге в строке останется только команда
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    input = input.Remove(i, 1);
                    i--;// Следующее действие - инкремент i в цикле. С помощью этого декремента i не перейдет
                        // дальше, пока _Input[i] - символ, тем самым удаляя все символы на указанной позиции,
                        // но в обновляющейся строке.
                }
            }

            // В зависимости от оставшегося набора символов во входной строке,
            // выполнить соответствующие логические операции
            switch (input)
            {
                case "<":
                    return Convert.ToInt32(numbers[0]) < Convert.ToInt32(numbers[1]);
                case ">":
                    return Convert.ToInt32(numbers[0]) > Convert.ToInt32(numbers[1]);
                case ">=":
                    return Convert.ToInt32(numbers[0]) >= Convert.ToInt32(numbers[1]);
                case "<=":
                    return Convert.ToInt32(numbers[0]) <= Convert.ToInt32(numbers[1]);
                case "==":
                    return Convert.ToInt32(numbers[0]) == Convert.ToInt32(numbers[1]);
                case "!=":
                    return Convert.ToInt32(numbers[0]) != Convert.ToInt32(numbers[1]);
                default:
                    throw new Exception("Введена неизвестная команда!");
            }
        }
    }
}
