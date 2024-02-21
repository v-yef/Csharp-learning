using System.Diagnostics;

namespace Task_2
{
    internal static class ProcessManager
    {
        public static void Work()
        {
            Console.WriteLine("Press any key to start a process...");
            Console.ReadKey();

            try
            {
                var process = new Process();
                if (process is null)
                {
                    Console.WriteLine("\nCannot create a new process!");
                    return;
                }

                process.StartInfo.FileName = "notepad.exe";

                if (process.Start())
                {
                    Console.WriteLine("\nProcess started successfully!");

                    MaintainProcess(process);

                    Console.WriteLine($"\nProcess was closed. Exit code: {process.ExitCode}");
                }
                else
                {
                    Console.WriteLine("\nProcess cannot start!");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"\n\n{exc.Message}");
            }
        }

        private static void MaintainProcess(Process process)
        {
            Console.WriteLine("\nChoose action:");

            int choice = Menu.VerticalMenu(["Wait for process exit",
                                            "Kill process"],
                                            ConsoleColor.White, ConsoleColor.Black, 0, 4);
            switch (choice)
            {
                case 0:
                    Console.WriteLine("\n\nWaiting user to close the process...");
                    process.WaitForExit();
                    break;
                case 1:
                    Console.WriteLine("\n\nClosing process right now...");
                    process.Kill();
                    break;
                default:
                    break;
            }
        }
    }
}
