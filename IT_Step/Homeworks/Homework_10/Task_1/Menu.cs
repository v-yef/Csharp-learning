﻿namespace Task_1
{
    internal static class Menu
    {
        public static int VerticalMenu(string[] elements)
        {
            int maxLen = 0;

            foreach (var item in elements)
            {
                if (item.Length > maxLen)
                    maxLen = item.Length;
            }

            ConsoleColor bg = Console.BackgroundColor;
            ConsoleColor fg = Console.ForegroundColor;

            int x = Console.CursorLeft;
            int y = Console.CursorTop;

            int pos = 0;

            while (true)
            {

                for (int i = 0; i < elements.Length; i++)
                {
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(x, y + i);

                    if (i == pos)
                    {
                        Console.BackgroundColor = fg;
                        Console.ForegroundColor = bg;
                    }
                    else
                    {
                        Console.BackgroundColor = bg;
                        Console.ForegroundColor = fg;
                    }

                    Console.Write(elements[i].PadRight(maxLen));
                }

                ConsoleKey consoleKey = Console.ReadKey().Key;

                switch (consoleKey)
                {
                    case ConsoleKey.Enter:
                        return pos;
                    //break;

                    case ConsoleKey.Escape:
                        return elements.Length - 1;
                    //break;

                    case ConsoleKey.UpArrow:
                        if (pos > 0)
                            pos--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (pos < elements.Length - 1)
                            pos++;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
