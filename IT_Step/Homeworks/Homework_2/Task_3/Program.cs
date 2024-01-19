/*
 ============================================================================
 Name        : Homework_2-Task_3
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : User enters an arithmetic expression of two integers with a
               keyboard. The application must calculate its result. Implement
               only two operations: + and –.
 ============================================================================
 */

namespace Task_3
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение a +/- b:");

            string sInputStr = Console.ReadLine();

            // Очистка входной строки от пробелов
            string sFilteredStr = sInputStr.Replace(" ", "");

            int iResult = 0;
            int i = 0;

            while (i < sFilteredStr.Length)
            {
                // Получение первого числа в последовательности символов
                string sNumb_1 = "";
                // Пока встречается тип Цифра, добавлять её в строку первого числа
                while (Char.IsDigit(sFilteredStr[i]))
                    sNumb_1 += sFilteredStr[i++];

                // Получение знака в последовательности символов
                char cSign = ' ';

                if (sFilteredStr[i] == '+')
                    cSign = '+';
                else if (sFilteredStr[i] == '-')
                    cSign = '-';

                i++;

                // Получение второго числа в последовательности символов
                string sNumb_2 = "";
                // Пока встречается тип Цифра, добавлять её в строку второго числа
                while (Char.IsDigit(sFilteredStr[i]))
                {
                    sNumb_2 += sFilteredStr[i++];
                    // Проверка на выход за пределы строки
                    if (i >= sFilteredStr.Length)
                        break;
                }

                // Сформированные из цифр строки-числа переводятся в числовой формат и выполняется расчет
                if (cSign == '+')
                    iResult += Convert.ToInt32(sNumb_1) + Convert.ToInt32(sNumb_2);
                else if (cSign == '-')
                    iResult += Convert.ToInt32(sNumb_1) - Convert.ToInt32(sNumb_2);
            }

            Console.WriteLine(sInputStr + " = " + iResult);

            Console.ReadLine();
        }
    }
}
