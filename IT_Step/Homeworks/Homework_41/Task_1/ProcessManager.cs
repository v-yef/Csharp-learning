using System.Diagnostics;

namespace Task_1
{
    internal static class ProcessManager
    {
        public static void Work()
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
                    process.WaitForExit();
                    Console.WriteLine($"Process was closed. Exit code: {process.ExitCode}");
                }
                else
                {
                    Console.WriteLine("Process cannot start!");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }
        }
    }
}
