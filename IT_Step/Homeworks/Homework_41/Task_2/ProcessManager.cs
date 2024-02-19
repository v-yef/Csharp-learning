using System.Diagnostics;

namespace Task_2
{
    internal class ProcessManager
    {
        public void Work()
        {
            Console.WriteLine("Press any key to start process...");
            Console.ReadKey();

            try
            {
                var process = new Process();

                if (process is null)
                {
                    Console.WriteLine("Cannot create new process!");
                    return;
                }

                process.StartInfo.FileName = "notepad.exe";

                if (process.Start())
                {
                    Console.WriteLine("Process started successfully!");

                    this.maintainProcess(process);

                    Console.WriteLine($"Process was closed. Exit code: {process.ExitCode}");
                }
                else
                {
                    Console.WriteLine("Process cannot start!");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"\n\n{exc.Message}");
            }
        }

        private void maintainProcess(Process process)
        {
            Console.WriteLine("Choose action:");

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

            return;
        }
    }
}
