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

using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1
{
    class Character
    {
        // Делегат для хранения списка всех просьб питомца.
        public delegate DialogResult TaskDelegate();
        public TaskDelegate taskDelegate { get; set; } = null;

        // Таймер, по которому выдаются просьбы.
        protected static System.Timers.Timer Timer;

        // Возможные состояния питомца.
        protected enum State { _NORMAL, _HUNGRY, _BORED, _TIRED, _ILL, _PLAYFUL, _FINAL }

        // Текущее состояние питомца.
        protected State CurrentState { get; set; } = State._NORMAL;

        // Кол-во отклоненных просьб.
        protected int RejectedTasks { get; set; } = 0;

        // Предыдущая просьба (её индекс в делегате).
        protected int PreviousTask { get; set; } = 0;

        public Character()
        {
            // Конструктор заполняет делегат с просьбами.
            this.taskDelegate += this.Feed_Task;
            this.taskDelegate += this.Walk_Task;
            this.taskDelegate += this.GoToBed_Task;
            this.taskDelegate += this.Heal_Task;
            this.taskDelegate += this.Play_Task;
        }

        // Методы-просьбы питомца.
        // Устанавливают питомцу состояния, отличные от нормального.
        // Возвращают значение, передаваемое от диалогового окна WindowsForm.
        public DialogResult Feed_Task()
        {
            this.CurrentState = State._HUNGRY;
            return this.GetUserAnswer("Я хочу есть. Покормишь меня?");
        }
        public DialogResult Walk_Task()
        {
            this.CurrentState = State._BORED;
            return this.GetUserAnswer("Мне скучно. Погуляешь со мной?");
        }
        public DialogResult GoToBed_Task()
        {
            this.CurrentState = State._TIRED;
            return this.GetUserAnswer("Я устал. Уложишь меня спать?");
        }
        public DialogResult Heal_Task()
        {
            this.CurrentState = State._ILL;
            return this.GetUserAnswer("Я заболел. Полечишь меня?");
        }
        public DialogResult Play_Task()
        {
            this.CurrentState = State._PLAYFUL;
            return this.GetUserAnswer("Я хочу играть. Поиграешь со мной?");
        }

        // Метод завершения игры после трех отклоненных просьб и отказа полечить питомца.
        public void Finish()
        {
            this.CurrentState = State._FINAL;
            this.DrawCurrentState();
            MessageBox.Show("Игра окончена", "Сообщение от питомца", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(0);
        }

        // Метод обращения к пользователю с соответствующей просьбой.
        // Получает текст вопроса. Возвращает значение, передаваемое от диалогового окна WindowsForm.
        public DialogResult GetUserAnswer(string _Question)
        {
            this.DrawCurrentState();
            return MessageBox.Show(_Question, "Сообщение от питомца",
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        }

        // Метод отображения состояний питомца.
        public void DrawCurrentState()
        {
            Console.Clear();
            switch (this.CurrentState)
            {
                case State._NORMAL:
                    Console.WriteLine("    XXXXX    ");
                    Console.WriteLine("   X     X   ");
                    Console.WriteLine("  X       X  ");
                    Console.WriteLine(" X ==  ==  X ");
                    Console.WriteLine("X           X");
                    Console.WriteLine("X    []     X");
                    Console.WriteLine("X           X");
                    Console.WriteLine(" X  =====  X ");
                    Console.WriteLine("  X       X  ");
                    Console.WriteLine("   X     X   ");
                    Console.WriteLine("    XXXXX    ");
                    break;
                case State._HUNGRY:
                    Console.WriteLine("    XXXXX    ");
                    Console.WriteLine("   X     X   ");
                    Console.WriteLine("  X       X  ");
                    Console.WriteLine(" X \\    /  X");
                    Console.WriteLine("X           X");
                    Console.WriteLine("X    []     X");
                    Console.WriteLine("X           X");
                    Console.WriteLine(" X  \\.../  X");
                    Console.WriteLine("  X       X  ");
                    Console.WriteLine("   X     X   ");
                    Console.WriteLine("    XXXXX    ");
                    break;
                case State._BORED:
                    Console.WriteLine("    XXXXX    ");
                    Console.WriteLine("   X     X   ");
                    Console.WriteLine("  X       X  ");
                    Console.WriteLine(" X /\\   /\\ X");
                    Console.WriteLine("X           X");
                    Console.WriteLine("X    []     X");
                    Console.WriteLine("X           X");
                    Console.WriteLine(" X   ____  X ");
                    Console.WriteLine("  X /    \\X ");
                    Console.WriteLine("   X     X   ");
                    Console.WriteLine("    XXXXX    ");
                    break;
                case State._TIRED:
                    Console.WriteLine("    XXXXX    ");
                    Console.WriteLine("   X     X   ");
                    Console.WriteLine("  X       X  ");
                    Console.WriteLine(" X \\/   \\/ X");
                    Console.WriteLine("X           X");
                    Console.WriteLine("X    []     X");
                    Console.WriteLine("X     __    X");
                    Console.WriteLine(" X   /  \\  X ");
                    Console.WriteLine("  X  \\__/ X ");
                    Console.WriteLine("   X     X   ");
                    Console.WriteLine("    XXXXX    ");
                    break;
                case State._ILL:
                    Console.WriteLine("    XXXXX    ");
                    Console.WriteLine("   X     X   ");
                    Console.WriteLine("  X       X  ");
                    Console.WriteLine(" X  /   \\  X");
                    Console.WriteLine("X           X");
                    Console.WriteLine("X    []     X");
                    Console.WriteLine("X           X");
                    Console.WriteLine(" X    X    X ");
                    Console.WriteLine("  X       X ");
                    Console.WriteLine("   X     X   ");
                    Console.WriteLine("    XXXXX    ");
                    break;
                case State._PLAYFUL:
                    Console.WriteLine("    XXXXX    ");
                    Console.WriteLine("   X     X   ");
                    Console.WriteLine("  X       X  ");
                    Console.WriteLine(" X /\\   /\\ X");
                    Console.WriteLine("X           X");
                    Console.WriteLine("X    []     X");
                    Console.WriteLine("X           X");
                    Console.WriteLine(" X  \\____/ X");
                    Console.WriteLine("  X       X  ");
                    Console.WriteLine("   X     X   ");
                    Console.WriteLine("    XXXXX    ");
                    break;
                case State._FINAL:
                    Console.WriteLine("    XXXXX    ");
                    Console.WriteLine("   X     X   ");
                    Console.WriteLine("  X       X  ");
                    Console.WriteLine(" X  X   X  X");
                    Console.WriteLine("X           X");
                    Console.WriteLine("X     X     X");
                    Console.WriteLine("X           X");
                    Console.WriteLine(" X   XXX   X ");
                    Console.WriteLine("  X       X ");
                    Console.WriteLine("   X     X   ");
                    Console.WriteLine("    XXXXX    ");
                    break;
                default:
                    break;
            }
            return;
        }

        // Метод выбора просьбы.
        // Возвращает ссылку на выбранный метод.
        public TaskDelegate ChooseTask()
        {

            if (this.RejectedTasks == 3)
            {
                return this.Heal_Task;
            }

            if (this.RejectedTasks == 4)
            {
                this.Finish();
            }

            int chosenMethodIndex = 0;

            do
            {
                Random random = new Random();
                // Определить случайный индекс на основании длины списка вызовов делегата просьб.
                chosenMethodIndex = random.Next(this.taskDelegate.GetInvocationList().Length);
            } while (chosenMethodIndex == this.PreviousTask); // перезапустить, если просьба совпадает с предыдущей.

            this.PreviousTask = chosenMethodIndex;

            // Сформировать массив делегатов из списка вызовов делегата просьб.
            Delegate[] taskArray = this.taskDelegate.GetInvocationList();

            // Вернуть ссылку на метод из массива по индексу.
            return (TaskDelegate)taskArray[chosenMethodIndex];
        }

        // Метод действия персонажа.
        private void CharacterMove(Object source, System.Timers.ElapsedEventArgs e)
        {

            // Остановить таймер на время взаимодействия с пользователем.
            Timer.Stop();
            // Получить от пользователя ответ на выбранный метод.
            DialogResult dialogResult = this.ChooseTask().Invoke();

            // При положительном ответе состояние меняется на нормальное, при отрицательном - засчитываются отклоненные просьбы.
            // Третий вариант (кнопка Отмена) - приостановить игру на 20 сек.
            if (dialogResult == DialogResult.Yes)
            {
                this.CurrentState = State._NORMAL;
                // Если просьба выполнена, то сбросить счетчик отклоненных просьб.
                this.RejectedTasks = 0;
                this.DrawCurrentState();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                this.RejectedTasks++;
                Thread.Sleep(20000);
            }
            else
            {
                this.RejectedTasks++;
            }

            // Продолжить отсчёт таймера.
            Timer.Start();

            return;
        }

        // Метод жизни персонажа.
        public void Live()
        {
            this.DrawCurrentState();
            Timer = new System.Timers.Timer(5000);
            Timer.AutoReset = true;
            Timer.Enabled = true;
            Timer.Elapsed += CharacterMove;

            return;
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {

            Character app = new Character();
            app.Live();

            Console.ReadLine();
        }
    }
}
