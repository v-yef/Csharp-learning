/*
 ============================================================================
 Name        : Homework_2-Task_4
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : The user enters some text from the keyboard. The application must change the case of the first letter of each sentence to the letter y
upper case. For example, if the user entered: today is a good day for walking. i will try to walk near the sea.
  The result of the application: Today is a good day for walking. I will try to walk near the sea.
 ============================================================================
 */
namespace Task_4
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string: ");

            string sInputStr = Console.ReadLine();

            for (int i = 0; i < sInputStr.Length; i++)
            {
                // Первую букву в строке выводить как заглавную
                if (i == 0)
                    Console.Write(char.ToUpper(sInputStr[i]));
                // Первую букву после пробела с точкой выводить как заглавную
                else if (i - 1 > 0 && sInputStr[i - 2] == '.')
                    Console.Write(char.ToUpper(sInputStr[i]));
                // в остальных случаях выводить буквы как они есть
                else
                    Console.Write(sInputStr[i]);
            }

            Console.ReadLine();
        }
    }
}
