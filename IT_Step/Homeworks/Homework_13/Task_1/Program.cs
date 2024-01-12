/*
 ============================================================================
 Name        : Homework_13-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Develop a class “Invoice for payment”. Provide the following fields in the class:
  -payment per day;
-amount of days;
- fine for one day of late payment;
-number of days of delay in payment;
-amount to be paid without penalty (calculated field);
-fine(calculated field);
-total amount to be paid (calculated field).

  In the class, declare a static property of type bool, the value of which affects the formatting process
  objects of this class. If the value of this property is true, then all
  fields; if false, calculated fields are not serialized.

  Develop an application in which you need to demonstrate the use of this class, the results
  must be written to and read from the file.
 ============================================================================
 */

using System.Runtime.Serialization;

namespace Task_1
{
    [Serializable]
    public class Bill : ISerializable
    {
        protected decimal DayPayment { get; } = 0;
        protected int DayCount { get; } = 0;
        protected decimal DayFee { get; } = 0;
        protected int DelayedDayCount { get; } = 0;
        protected decimal PaymentWithoutFee { get; set; } = 0;
        protected decimal Fee { get; set; } = 0;
        protected decimal PaymentTotal { get; set; } = 0;
        static public bool IsAllSerialized { get; set; } = false;

        // Конструктор принимает основные данные по оплате и производит расчет вычисляемых полей. 
        public Bill(decimal _DayPayment, int _DayCount, decimal _DayFee, int _DelayedDayCount)
        {
            this.DayPayment = _DayPayment;
            this.DayCount = _DayCount;
            this.DayFee = _DayFee;
            this.DelayedDayCount = _DelayedDayCount;

            this.ComputePaymentWithoutFee();
            this.ComputeFee();
            this.ComputePaymentTotal();
        }

        private void ComputePaymentWithoutFee() => this.PaymentWithoutFee = this.DayPayment * this.DayCount;
        private void ComputeFee() => this.Fee = this.DayFee * this.DelayedDayCount;
        private void ComputePaymentTotal() => this.PaymentTotal = this.PaymentWithoutFee + this.Fee;

        public void Print()
        {
            Console.WriteLine("Оплата за день : " + this.DayPayment);
            Console.WriteLine("Количество дней : " + this.DayCount);
            Console.WriteLine("Штраф за один день задержки оплаты : " + this.DayFee);
            Console.WriteLine("Количество дней задержи оплаты : " + this.DelayedDayCount);
            Console.WriteLine("Сумма к оплате без штрафа : " + this.PaymentWithoutFee);
            Console.WriteLine("Штраф : " + this.Fee);
            Console.WriteLine("Общая сумма к оплате : " + this.PaymentTotal);

            return;
        }

        // Метод сериализации.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("DayPayment", DayPayment);
            info.AddValue("DayCount", DayCount);
            info.AddValue("DayFee", DayFee);
            info.AddValue("DelayedDayCount", DelayedDayCount);
            info.AddValue("IsAllSerialized", IsAllSerialized);

            if (IsAllSerialized == true)
            {
                info.AddValue("PaymentWithoutFee", PaymentWithoutFee);
                info.AddValue("Fee", Fee);
                info.AddValue("PaymentTotal", PaymentTotal);
            }

            return;
        }

        // Конструктор десериализации.
        private Bill(SerializationInfo info, StreamingContext context)
        {
            DayPayment = Convert.ToDecimal(info.GetString("DayPayment"));
            DayCount = Convert.ToInt32(info.GetString("DayCount"));
            DayFee = Convert.ToDecimal(info.GetString("DayFee"));
            DelayedDayCount = Convert.ToInt32(info.GetString("DelayedDayCount"));
            IsAllSerialized = Convert.ToBoolean(info.GetString("IsAllSerialized"));

            if (IsAllSerialized == true)
            {
                PaymentWithoutFee = Convert.ToDecimal(info.GetString("PaymentWithoutFee"));
                Fee = Convert.ToDecimal(info.GetString("Fee"));
                PaymentTotal = Convert.ToDecimal(info.GetString("PaymentTotal"));
            }
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Bill bill_1 = new Bill(10, 1, 1, 1);

                SoapFormatter soap = new SoapFormatter();

                Bill.IsAllSerialized = true;
                //Bill.IsAllSerialized = false;

                Console.WriteLine("Вычисляемые поля сериализуются : ");
                Console.WriteLine("================================ ");

                using (Stream stream = File.Create("Bill.soap"))
                {
                    soap.Serialize(stream, bill_1);
                }

                Bill bill_2 = null;

                Bill.IsAllSerialized = true;
                //Bill.IsAllSerialized = false;

                using (Stream fStream = File.OpenRead("Bill.soap"))
                {
                    bill_2 = (Bill)soap.Deserialize(fStream);
                }

                bill_2.Print();
                Console.WriteLine();

                Console.WriteLine("Вычисляемые поля не сериализуются : ");
                Console.WriteLine("================================ ");

                //Bill.IsAllSerialized = true;
                Bill.IsAllSerialized = false;

                using (Stream stream = File.Create("Bill.soap"))
                {
                    soap.Serialize(stream, bill_1);
                }

                bill_2 = null;

                //Bill.IsAllSerialized = true;
                Bill.IsAllSerialized = false;

                using (Stream fStream = File.OpenRead("Bill.soap"))
                {
                    bill_2 = (Bill)soap.Deserialize(fStream);
                }

                bill_2.Print();
                Console.WriteLine();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            Console.ReadLine();

            return;
        }
    }
}
