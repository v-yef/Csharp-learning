/*
 ============================================================================
 Name        : Homework_10-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a "Credit Card" class. The class must contain:
                - Card ID;
                - Full name of the holder;
                - Card expiry period;
                - PIN;
                - Credit limit;
                - Amount of money.
               Create necessary class methods. Implement events for the 
               following situations:
                - Refill;
                - Spending funds from the account;
                - Start using credit funds;
                - Hitting the limit of a given amount of money;
                - PIN change.
 ============================================================================
 */

namespace Task_1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var creditCard = new CreditCard("0000-0000-0000-0000", "Ivanov Ivan Ivanovich", "06/25");

            var bank = new Bank();

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
