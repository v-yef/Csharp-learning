/*
 ============================================================================
 Name        : Homework_12-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Develop a Tamagotchi application. The pet's lifecycle is 1-2
               minutes. The pet randomly generates wishes (but the same wish
               is not issued in a row). Wishes may be the following: Feed, Walk,
               Put to bed, Treat, Play. If wishes are ignored for three times,
               the pet “gets sick” and asks for treatment. If the user refuses,
               the pet “dies.” The pet is displayed in the console window using
               pseudo-graphics. Dialogue with the character is carried out by
               calling a Show() method of the MessageBox class from the
               System.Windows.Forms namespace. For detailed information on it
               contact your instructor or MSDN.

               To solve this problem, you will need the Timer class from the
               System.Timers namespace, which event Elapsed is of type delegate
               ElapsedEventHandler, occurs after a certain time interval, that
               is specified in the Interval property. Start() and Stop() methods
               start and stop the timer, respectively. You may also want to pause
               the application, in this case you can call the Sleep() method of
               the Thread class from the System.Threading namespace, passing the
               required number of milliseconds to it.
 ============================================================================
 */

namespace Task_1
{
    internal static class Program
    {
        static void Main()
        {
            var app = new Pet();
            app.Live();

            Console.ReadLine();
        }
    }
}
