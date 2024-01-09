/*
 ============================================================================
 Name        : Homework_8-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : The user enters a logical expression in the string from the keyboard. For example, 3>2 or 7<3.
               The program should calculate the result of the entered expression and output the result: true or false.
               The line should contain only integers and operators: <, >, <=, >=, ==, != .Use the exception mechanism to handle input errors.
 ============================================================================
 */

using System.Text.RegularExpressions;

namespace Task_1
{
    class BoolCalc
    {
        public static string getExpression()
        {
            Console.WriteLine("Введите выражение :");

            string InputString = Console.ReadLine();

            // (Начиная с начала строки) - цифра(любое кол-во) - конкретный знак(любое кол-во) - цифра(любое кол-во)
            // Опции - копиляция в сборку для более быстрого выполнения
            Regex regex = new Regex(@"^\d+[<>!=]+\d+", RegexOptions.Compiled);

            if (regex.IsMatch(InputString) == false)
            {
                throw new Exception("Неправильный формат ввода!");
            }
            else
            {
                return InputString;
            }
        }

        public static bool computeExpression(string _Input)
        {
            //Выделить из входной строки подстроки по знаку - разделителю
            string[] numbers = _Input.Split("<>!=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // Очистить входную строку от чисел, проверяя каждый символ и удаляя его, если это число,
            // при этом перезаписывая строку без этого символа. В итоге в строке останется только команда
            for (int i = 0; i < _Input.Length; i++)
            {
                if (Char.IsDigit(_Input[i]))
                {
                    _Input = _Input.Remove(i, 1);
                    i--;// Следующее действие - инкремент i в цикле. С помощью этого декремента i не перейдет
                        // дальше, пока _Input[i] - символ, тем самым удаляя все символы на указанной позиции,
                        // но в обновляющейся строке.
                }
            }

            // В зависимости от оставшегося набора символов во входной строке, выполнить соответствующие
            // логические операции
            switch (_Input)
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

    internal static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(BoolCalc.computeExpression(BoolCalc.getExpression()));
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);

            }
            Console.ReadLine();
        }
    }
}
