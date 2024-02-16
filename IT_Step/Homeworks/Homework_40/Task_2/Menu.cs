using System;

namespace Task_2
{
    internal static class Menu
    {
        public static int VerticalMenu(string[] elements, ConsoleColor foregroundColor, ConsoleColor backgroundColor,
                                        int upLeft_x, int upLeft_y)
        {
            int maxLen = 0;

            foreach (var item in elements)
            {
                if (item.Length > maxLen)
                {
                    maxLen = item.Length;
                }
            }

            ConsoleColor initialForegroundColor = Console.ForegroundColor;
            ConsoleColor initialBackgroundColor = Console.BackgroundColor;

            Console.BackgroundColor = foregroundColor;
            Console.ForegroundColor = backgroundColor;

            Console.SetCursorPosition(0, 0);

            int x = Console.CursorLeft;
            int y = Console.CursorTop;

            int pos = 0;

            while (true)
            {
                for (int i = 0; i < elements.Length; i++)
                {

                    Console.CursorVisible = false;
                    Console.SetCursorPosition(x + upLeft_x, y + i + upLeft_y);

                    if (i == pos)
                    {
                        Console.BackgroundColor = foregroundColor;
                        Console.ForegroundColor = backgroundColor;
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundColor;
                        Console.ForegroundColor = foregroundColor;
                    }

                    Console.Write(elements[i].PadCenter(maxLen));
                }

                Console.ForegroundColor = initialForegroundColor;
                Console.BackgroundColor = initialBackgroundColor;

                ConsoleKey consoleKey = Console.ReadKey().Key;

                switch (consoleKey)
                {

                    case ConsoleKey.Enter:
                        return pos;

                    case ConsoleKey.Escape:
                        return -1;

                    case ConsoleKey.UpArrow:
                        if (pos > 0)
                        {
                            pos--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (pos < elements.Length - 1)
                        {
                            pos++;
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }

    static class Extensions
    {
        public static string PadCenter(this string sourceString, int length)
        {

            if ((sourceString.Length >= length) || (sourceString.Length + 1 == length))
            {
                return sourceString;
            }

            int charNumberToAdd = (length - sourceString.Length) / 2;

            string result = "";

            for (int i = 0; i < charNumberToAdd; i++)
            {
                result += " ";
            }

            result += sourceString;

            for (int i = 0; i < charNumberToAdd; i++)
            {
                result += " ";
            }

            return result;
        }
    }
}
