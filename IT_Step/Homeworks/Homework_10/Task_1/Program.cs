/*
 ============================================================================
 Name        : Homework_10-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a Credit Card class. The class must contain:
- Card number;
- Full name of the owner;
- Card validity period;
- PIN;
- Credit limit;
- Amount of money.
Create the desired set of class methods. Implement events for the following situations:
- Refill;
- Spending funds from the account;
- Start using credit funds;
- Achieving the limit of a given amount of money;
- Change PIN.
 ============================================================================
 */

using System.Text.RegularExpressions;

namespace Task_1
{
    class Menu
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
            //Console.CursorVisible = false;

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

    class CreditCard
    {
        protected string CardNumber { get; } = "";
        protected string CardHolderName { get; } = "";
        protected string ExpiryDate { get; } = "";
        protected short PIN { get; set; } = 0;
        protected decimal CreditLimit { get; set; } = 0;
        protected decimal Balance { get; set; } = 0;

        public CreditCard(string _CardNumber, string _CardHolderName, string _ExpiryDate)
        {
            this.CardNumber = _CardNumber;
            this.CardHolderName = _CardHolderName;
            this.ExpiryDate = _ExpiryDate;
        }

        // Метод вывода информации.
        protected void PrintInfo()
        {
            Console.Clear();
            Console.WriteLine("Номер карты : " + this.CardNumber);
            Console.WriteLine("Владелец карты : " + this.CardHolderName);
            Console.WriteLine("Действительна до : " + this.ExpiryDate);
            Console.WriteLine("PIN-код : " + this.PIN);
            Console.WriteLine("Лимит на снятие средств : " + this.CreditLimit);
            Console.WriteLine("Текущий баланс : " + this.Balance);

            return;
        }

        // Метод пополнения счета.
        protected void Refill()
        {
            Console.Clear();
            Console.WriteLine("Внесите сумму для пополнения: ");
            string UserInput = Console.ReadLine();

            // (Начиная с начала строки) - цифра(любое кол-во) - ноль или одна запятая - цифра(любое кол-во).
            Regex regex = new Regex(@"^\d+\,?\d+", RegexOptions.Compiled);

            if (regex.IsMatch(UserInput) == false)
            {
                throw new Exception("Неправильный формат ввода!");
            }

            decimal RefillAmount = Convert.ToDecimal(UserInput);
            this.Balance += RefillAmount;

            // Событие "Пополнение счета".
            if (Refill_Event != null)
            {
                Refill_Event($"Карта № {this.CardNumber}. Поступление средств {RefillAmount}. Остаток на счету {this.Balance}");
            }

            return;
        }

        // Метод списания со счета.
        protected void Withdraw()
        {
            Console.Clear();
            Console.WriteLine("Введите сумму для снятия: ");
            string UserInput = Console.ReadLine();

            // (Начиная с начала строки) - цифра(любое кол-во) - ноль или одна запятая - цифра(любое кол-во).
            Regex regex = new Regex(@"^\d+\,?\d+", RegexOptions.Compiled);

            if (regex.IsMatch(UserInput) == false)
            {
                throw new Exception("Неправильный формат ввода!");
            }

            decimal WithdrawAmount = Convert.ToDecimal(UserInput);

            // Если в результате снятия суммы лимит не будет исчерпан, уменьшить баланс и остаток лимита.
            // Переход в отрицательный баланс не учитывается, т.к. это кредитная карта.
            if (this.CreditLimit - WithdrawAmount > 0)
            {
                this.CreditLimit -= WithdrawAmount;
                this.Balance -= WithdrawAmount;

                // Событие "Первое использование средств".
                if (StartUsing_Event != null)
                {
                    StartUsing_Event($"Карта № {this.CardNumber}. Начало использования карты {DateTime.Now}");
                    // Удалить событие после однократного срабатывания.
                    this.StartUsing_Event = null;
                }

                // Событие "Успешное списание со счета".
                if (Withdraw_Succeed_Event != null)
                {
                    Withdraw_Succeed_Event($"Карта № {this.CardNumber}. Списание средств {WithdrawAmount}. Остаток на счету {this.Balance}");
                }
            }
            else
            {
                // Событие "Неудачное списание со счета".
                if (Withdraw_Fail_Event != null)
                {
                    Withdraw_Fail_Event($"Карта № {this.CardNumber}. Попытка списания средств {WithdrawAmount}. Лимит снятия превышен на {Math.Abs(this.CreditLimit - WithdrawAmount)}");
                }
            }

            return;
        }

        // Метод установки (смены) PIN-кода.
        protected void SetPIN()
        {
            Console.Clear();
            // (Начиная с начала строки) - цифра(ровно 4).
            Regex regex = new Regex(@"^\d{4}", RegexOptions.Compiled);

            Console.WriteLine("Введите новый PIN (4 цифры): ");
            string UserInput_1 = Console.ReadLine();

            if (regex.IsMatch(UserInput_1) == false)
            {
                throw new Exception("Неправильный формат ввода!");
            }

            Console.WriteLine("Подтвердите новый PIN : ");
            string UserInput_2 = Console.ReadLine();

            if (regex.IsMatch(UserInput_2) == false)
            {
                throw new Exception("Неправильный формат ввода!");
            }

            if (UserInput_1 == UserInput_2)
            {
                this.PIN = Convert.ToInt16(UserInput_1);

                // Событие "Смена PIN".
                if (PINChange_Event != null)
                {
                    PINChange_Event($"Карта № {this.CardNumber}. Установлен новый PIN-код {this.PIN}.");
                }
            }
            else
            {
                throw new Exception("Введенные значения не совпадают!");
            }

            return;
        }

        // Метод установки лимита на снятие средств
        protected void SetCreditLimit()
        {
            Console.Clear();
            Console.WriteLine("Введите лимит на снятие средств:");
            string UserInput = Console.ReadLine();

            // (Начиная с начала строки) - цифра(любое кол-во) - ноль или одна запятая - цифра(любое кол-во).
            Regex regex = new Regex(@"^\d+\,?\d+", RegexOptions.Compiled);

            if (regex.IsMatch(UserInput) == false)
            {
                throw new Exception("Неправильный формат ввода!");
            }

            this.CreditLimit = Convert.ToDecimal(UserInput);

            Console.WriteLine("Лимит на снятие средств успешно установлен.");

            return;
        }

        // Меню для работы с картой. Все методы вызываются только через него.
        public void CardMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите операцию с картой :");

            int Type = Menu.VerticalMenu(new string[]
            {
                "Вывести информацию о карте",
                "Пополнить счет",
                "Списать средства",
                "Сменить PIN",
                "Установить лимит",
                "Выход"
            });

            switch (Type)
            {
                case 0:
                    this.PrintInfo();
                    break;
                case 1:
                    this.Refill();
                    break;
                case 2:
                    this.Withdraw();
                    break;
                case 3:
                    this.SetPIN();
                    break;
                case 4:
                    this.SetCreditLimit();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

            return;
        }

        // События, происходящие с картой.
        public event Action<string> StartUsing_Event;
        public event Action<string> PINChange_Event;
        public event Action<string> Refill_Event;
        public event Action<string> Withdraw_Succeed_Event;
        public event Action<string> Withdraw_Fail_Event;
    }

    class Bank
    {
        // Метод для получения уведомлений о событиям, происходящих с картой.
        public void Inform(string _Message)
        {
            Console.WriteLine(_Message);

            return;
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {

            CreditCard creditCard = new CreditCard("0000-0000-0000-0000", "Ivanov Ivan Ivanovich", "06/25");

            Bank bank = new Bank();

            creditCard.StartUsing_Event += bank.Inform;
            creditCard.Refill_Event += bank.Inform;
            creditCard.Withdraw_Succeed_Event += bank.Inform;
            creditCard.Withdraw_Fail_Event += bank.Inform;
            creditCard.PINChange_Event += bank.Inform;

            while (true)
            {
                try
                {
                    creditCard.CardMenu();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                Console.ReadLine();
            }
        }
    }
}
