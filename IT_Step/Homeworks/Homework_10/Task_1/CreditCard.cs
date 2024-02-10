using System.Text.RegularExpressions;

namespace Task_1
{
    internal class CreditCard
    {
        protected string cardID { get; }
        protected string cardHolderName { get; }
        protected string expiryDate { get; }
        protected short PIN { get; set; } = 0;
        protected decimal creditLimit { get; set; } = 0;
        protected decimal balance { get; set; } = 0;

        public event Action<string> StartUsing_Event;
        public event Action<string> PINChange_Event;
        public event Action<string> Refill_Event;
        public event Action<string> Withdraw_Succeed_Event;
        public event Action<string> Withdraw_Fail_Event;

        public CreditCard(string cardID, string cardHolderName, string expiryDate)
        {
            this.cardID = cardID;
            this.cardHolderName = cardHolderName;
            this.expiryDate = expiryDate;
        }

        protected void PrintInfo()
        {
            Console.Clear();
            Console.WriteLine("Номер карты : " + this.cardID);
            Console.WriteLine("Владелец карты : " + this.cardHolderName);
            Console.WriteLine("Действительна до : " + this.expiryDate);
            Console.WriteLine("PIN-код : " + this.PIN);
            Console.WriteLine("Лимит на снятие средств : " + this.creditLimit);
            Console.WriteLine("Текущий баланс : " + this.balance);
        }

        protected void Refill()
        {
            Console.Clear();
            Console.WriteLine("Внесите сумму для пополнения: ");
            string UserInput = Console.ReadLine();

            // (Начиная с начала строки) - цифра(любое кол-во) - ноль или одна запятая - цифра(любое кол-во).
            var regex = new Regex(@"^\d+\,?\d+", RegexOptions.Compiled);

            if (!regex.IsMatch(UserInput))
            {
                throw new Exception("Неправильный формат ввода!");
            }

            decimal RefillAmount = Convert.ToDecimal(UserInput);
            this.balance += RefillAmount;

            // Событие "Пополнение счета".
            if (Refill_Event != null)
            {
                Refill_Event($"Карта № {this.cardID}. Поступление средств {RefillAmount}. Остаток на счету {this.balance}");
            }
        }

        protected void Withdraw()
        {
            Console.Clear();
            Console.WriteLine("Введите сумму для снятия: ");
            string UserInput = Console.ReadLine();

            // (Начиная с начала строки) - цифра(любое кол-во) - ноль или одна запятая - цифра(любое кол-во).
            var regex = new Regex(@"^\d+\,?\d+", RegexOptions.Compiled);

            if (!regex.IsMatch(UserInput))
            {
                throw new Exception("Неправильный формат ввода!");
            }

            decimal WithdrawAmount = Convert.ToDecimal(UserInput);

            // Если в результате снятия суммы лимит не будет исчерпан, уменьшить баланс и остаток лимита.
            // Переход в отрицательный баланс не учитывается, т.к. это кредитная карта.
            if (this.creditLimit - WithdrawAmount > 0)
            {
                this.creditLimit -= WithdrawAmount;
                this.balance -= WithdrawAmount;

                // Событие "Первое использование средств".
                if (StartUsing_Event != null)
                {
                    StartUsing_Event($"Карта № {this.cardID}. Начало использования карты {DateTime.Now}");
                    // Удалить событие после однократного срабатывания.
                    this.StartUsing_Event = null;
                }

                // Событие "Успешное списание со счета".
                if (Withdraw_Succeed_Event != null)
                {
                    Withdraw_Succeed_Event($"Карта № {this.cardID}. Списание средств {WithdrawAmount}. Остаток на счету {this.balance}");
                }
            }
            else
            {
                // Событие "Неудачное списание со счета".
                if (Withdraw_Fail_Event != null)
                {
                    Withdraw_Fail_Event($"Карта № {this.cardID}. Попытка списания средств {WithdrawAmount}. Лимит снятия превышен на {Math.Abs(this.creditLimit - WithdrawAmount)}");
                }
            }
        }

        protected void SetPIN()
        {
            Console.Clear();
            // (Начиная с начала строки) - цифра(ровно 4).
            var regex = new Regex(@"^\d{4}", RegexOptions.Compiled);

            Console.WriteLine("Введите новый PIN (4 цифры): ");
            string UserInput_1 = Console.ReadLine();

            if (!regex.IsMatch(UserInput_1))
            {
                throw new Exception("Неправильный формат ввода!");
            }

            Console.WriteLine("Подтвердите новый PIN : ");
            string UserInput_2 = Console.ReadLine();

            if (!regex.IsMatch(UserInput_2))
            {
                throw new Exception("Неправильный формат ввода!");
            }

            if (UserInput_1 == UserInput_2)
            {
                this.PIN = Convert.ToInt16(UserInput_1);

                // Событие "Смена PIN".
                if (PINChange_Event != null)
                {
                    PINChange_Event($"Карта № {this.cardID}. Установлен новый PIN-код {this.PIN}.");
                }
            }
            else
            {
                throw new Exception("Введенные значения не совпадают!");
            }
        }

        protected void SetCreditLimit()
        {
            Console.Clear();
            Console.WriteLine("Введите лимит на снятие средств:");
            string UserInput = Console.ReadLine();

            // (Начиная с начала строки) - цифра(любое кол-во) - ноль или одна запятая - цифра(любое кол-во).
            var regex = new Regex(@"^\d+\,?\d+", RegexOptions.Compiled);

            if (!regex.IsMatch(UserInput))
            {
                throw new Exception("Неправильный формат ввода!");
            }

            this.creditLimit = Convert.ToDecimal(UserInput);

            Console.WriteLine("Лимит на снятие средств успешно установлен.");
        }

        public void CardMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите операцию с картой :");

            int Type = Menu.VerticalMenu([
                "Вывести информацию о карте",
                "Пополнить счет",
                "Списать средства",
                "Сменить PIN",
                "Установить лимит",
                "Выход"
            ]);

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
        }
    }
}
