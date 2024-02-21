using System.Diagnostics;

namespace Task_4
{
    internal static class ProcessManager
    {
        public static void Work()
        {
            Console.WriteLine("Enter arguments (Example: FilePath SearchWord) :");
            string? arguments = Console.ReadLine();
            if (arguments is null)
            {
                return;
            }

            Console.WriteLine("Arguments obtained. Press any key to start a process...");
            Console.ReadKey();

            try
            {
                var process = new Process();
                if (process is null)
                {
                    Console.WriteLine("\nCannot create a new process...");
                    return;
                }

                process.StartInfo.FileName = "Task_4_WordCounter.exe";
                process.StartInfo.Arguments = arguments;

                if (process.Start())
                {
                    Console.WriteLine("\nProcess started successfully...");

                    process.WaitForExit();

                    Console.WriteLine($"\nProcess was closed. Exit code: {process.ExitCode}");
                }
                else
                {
                    Console.WriteLine("\nProcess cannot start...");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"\n\n{exc.Message}");
            }
        }
    }
}
