namespace Task_1
{
    internal class Pet
    {
        public delegate DialogResult TaskDelegate();
        public TaskDelegate Task { get; set; }
        protected enum State { Normal, Hungry, Bored, Tired, Sick, Playful, Final }
        protected State CurrentState { get; set; } = State.Normal;
        protected int RejectedTaskCount { get; set; } = 0;
        protected int PreviousTaskIndex { get; set; } = 0;

        protected static System.Timers.Timer RequestsTimer;

        public Pet()
        {
            this.Task += this.Feed_Task;
            this.Task += this.Walk_Task;
            this.Task += this.GoToBed_Task;
            this.Task += this.Heal_Task;
            this.Task += this.Play_Task;
        }

        // Методы-просьбы питомца.
        // Устанавливают питомцу состояния, отличные от нормального.
        // Возвращают значение, передаваемое от диалогового окна WindowsForm.
        public DialogResult Feed_Task()
        {
            this.CurrentState = State.Hungry;

            return this.GetUserAnswer("Я хочу есть. Покормишь меня?");
        }
        public DialogResult Walk_Task()
        {
            this.CurrentState = State.Bored;

            return this.GetUserAnswer("Мне скучно. Погуляешь со мной?");
        }
        public DialogResult GoToBed_Task()
        {
            this.CurrentState = State.Tired;

            return this.GetUserAnswer("Я устал. Уложишь меня спать?");
        }
        public DialogResult Heal_Task()
        {
            this.CurrentState = State.Sick;

            return this.GetUserAnswer("Я заболел. Полечишь меня?");
        }
        public DialogResult Play_Task()
        {
            this.CurrentState = State.Playful;

            return this.GetUserAnswer("Я хочу играть. Поиграешь со мной?");
        }

        // Метод завершения игры после трех отклоненных просьб и отказа полечить питомца.
        public void Finish()
        {
            this.CurrentState = State.Final;
            this.DisplayCurrentState();

            MessageBox.Show(
                "Игра окончена",
                "Сообщение от питомца",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Environment.Exit(0);
        }

        // Метод обращения к пользователю с соответствующей просьбой.
        // Получает текст вопроса. Возвращает значение, передаваемое от диалогового окна WindowsForm.
        public DialogResult GetUserAnswer(string request)
        {
            this.DisplayCurrentState();

            return MessageBox.Show(
                request,
                "Сообщение от питомца",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information);
        }    

        // Метод выбора просьбы.
        // Возвращает ссылку на выбранный метод.
        public TaskDelegate ChooseTask()
        {
            if (this.RejectedTaskCount == 3)
            {
                return this.Heal_Task;
            }

            if (this.RejectedTaskCount == 4)
            {
                this.Finish();
            }

            int chosenMethodIndex = 0;

            do
            {
                Random random = new Random();
                // Определить случайный индекс на основании длины списка вызовов делегата просьб.
                chosenMethodIndex = random.Next(this.Task.GetInvocationList().Length);
            }
            while (chosenMethodIndex == this.PreviousTaskIndex); // перезапустить, если просьба совпадает с предыдущей.

            this.PreviousTaskIndex = chosenMethodIndex;

            // Сформировать массив делегатов из списка вызовов делегата просьб.
            Delegate[] taskArray = this.Task.GetInvocationList();

            // Вернуть ссылку на метод из массива по индексу.
            return (TaskDelegate)taskArray[chosenMethodIndex];
        }

        // Метод действия персонажа.
        private void CharacterMove(Object source, System.Timers.ElapsedEventArgs e)
        {
            // Остановить таймер на время взаимодействия с пользователем.
            RequestsTimer.Stop();
            // Получить от пользователя ответ на выбранный метод.
            DialogResult dialogResult = this.ChooseTask().Invoke();

            // При положительном ответе состояние меняется на нормальное, при отрицательном - засчитываются отклоненные просьбы.
            // Третий вариант (кнопка Отмена) - приостановить игру на 20 сек.
            if (dialogResult == DialogResult.Yes)
            {
                this.CurrentState = State.Normal;
                // Если просьба выполнена, то сбросить счетчик отклоненных просьб.
                this.RejectedTaskCount = 0;
                this.DisplayCurrentState();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                this.RejectedTaskCount++;
                Thread.Sleep(20000);
            }
            else
            {
                this.RejectedTaskCount++;
            }

            // Продолжить отсчёт таймера.
            RequestsTimer.Start();
        }

        // Метод жизни персонажа.
        public void Live()
        {
            this.DisplayCurrentState();

            RequestsTimer = new System.Timers.Timer(5000);
            RequestsTimer.AutoReset = true;
            RequestsTimer.Enabled = true;
            RequestsTimer.Elapsed += CharacterMove;
        }

        public void DisplayCurrentState()
        {
            Console.Clear();

            switch (this.CurrentState)
            {
                case State.Normal:
                    DisplayNormalState();
                    break;
                case State.Hungry:
                    DisplayHungryState();
                    break;
                case State.Bored:
                    DisplayBoredState();
                    break;
                case State.Tired:
                    DisplayTiredState();
                    break;
                case State.Sick:
                    DisplaySickState();
                    break;
                case State.Playful:
                    DisplayPlayfulState();
                    break;
                case State.Final:
                    DisplayFinalState();
                    break;
                default:
                    break;
            }
        }

        void DisplayNormalState()
        {
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
        }

        void DisplayHungryState()
        {
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
        }

        void DisplayBoredState()
        {
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
        }

        void DisplayTiredState()
        {
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
        }

        void DisplaySickState()
        {
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
        }

        void DisplayPlayfulState()
        {
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
        }

        void DisplayFinalState()
        {
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
        }
    }
}
