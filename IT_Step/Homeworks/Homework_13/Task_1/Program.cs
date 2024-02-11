/*
 ============================================================================
 Name        : Homework_13-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a class “Invoice” with following fields:
                - daily payment,
                - number of days,
                - daily fine if payment is delayed,
                - number of days of delay,
                - payment without fines (calculated field),
                - total fine (calculated field),
                - total payment (calculated field).
               Also include a static bool property, the value of which affects
               the serialization process of this class. If the value of this
               property is true, then all fields are serialized; if it is false,
               calculated fields are not serialized.
               Write a programm that demonstrates the use of this class. The
               results must be written to and read from the file.
 ============================================================================
 */

using System.Runtime.Serialization;

namespace Task_1
{
    [Serializable]
    public class Invoice : ISerializable
    {
        protected decimal DayPayment { get; } = 0;
        protected int DayCount { get; } = 0;
        protected decimal DayFee { get; } = 0;
        protected int DelayedDayCount { get; } = 0;
        protected decimal PaymentWithoutFee { get; set; } = 0;
        protected decimal Fee { get; set; } = 0;
        protected decimal PaymentTotal { get; set; } = 0;
        static public bool IsAllSerialized { get; set; } = false;

        public Invoice(decimal dayPayment, int dayCount, decimal dayFee, int delayedDayCount)
        {
            this.DayPayment = dayPayment;
            this.DayCount = dayCount;
            this.DayFee = dayFee;
            this.DelayedDayCount = delayedDayCount;

            this.ComputePaymentWithoutFee();
            this.ComputeFee();
            this.ComputePaymentTotal();
        }

        private void ComputePaymentWithoutFee() =>
            this.PaymentWithoutFee = this.DayPayment * this.DayCount;

        private void ComputeFee() =>
            this.Fee = this.DayFee * this.DelayedDayCount;

        private void ComputePaymentTotal() =>
            this.PaymentTotal = this.PaymentWithoutFee + this.Fee;

        public void Print()
        {
            Console.WriteLine("Оплата за день : " + this.DayPayment);
            Console.WriteLine("Количество дней : " + this.DayCount);
            Console.WriteLine("Штраф за один день задержки оплаты : " + this.DayFee);
            Console.WriteLine("Количество дней задержи оплаты : " + this.DelayedDayCount);
            Console.WriteLine("Сумма к оплате без штрафа : " + this.PaymentWithoutFee);
            Console.WriteLine("Штраф : " + this.Fee);
            Console.WriteLine("Общая сумма к оплате : " + this.PaymentTotal);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DayPayment", DayPayment);
            info.AddValue("DayCount", DayCount);
            info.AddValue("DayFee", DayFee);
            info.AddValue("DelayedDayCount", DelayedDayCount);
            info.AddValue("IsAllSerialized", IsAllSerialized);

            if (IsAllSerialized)
            {
                info.AddValue("PaymentWithoutFee", PaymentWithoutFee);
                info.AddValue("Fee", Fee);
                info.AddValue("PaymentTotal", PaymentTotal);
            }
        }

        private Invoice(SerializationInfo info, StreamingContext context)
        {
            DayPayment = Convert.ToDecimal(info.GetString("DayPayment"));
            DayCount = Convert.ToInt32(info.GetString("DayCount"));
            DayFee = Convert.ToDecimal(info.GetString("DayFee"));
            DelayedDayCount = Convert.ToInt32(info.GetString("DelayedDayCount"));
            IsAllSerialized = Convert.ToBoolean(info.GetString("IsAllSerialized"));

            if (IsAllSerialized)
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
                Invoice invoice_1 = new Invoice(10, 1, 1, 1);

                SoapFormatter soap = new SoapFormatter();

                Invoice.IsAllSerialized = true;
                //Invoice.IsAllSerialized = false;

                Console.WriteLine("Вычисляемые поля сериализуются : ");
                Console.WriteLine("================================ ");

                using (Stream stream = File.Create("Invoice.soap"))
                {
                    soap.Serialize(stream, invoice_1);
                }

                Invoice invoice_2;

                Invoice.IsAllSerialized = true;
                //Invoice.IsAllSerialized = false;

                using (Stream fStream = File.OpenRead("Invoice.soap"))
                {
                    invoice_2 = (Invoice)soap.Deserialize(fStream);
                }

                invoice_2.Print();
                Console.WriteLine();

                Console.WriteLine("Вычисляемые поля не сериализуются : ");
                Console.WriteLine("================================ ");

                //Invoice.IsAllSerialized = true;
                Invoice.IsAllSerialized = false;

                using (Stream stream = File.Create("Invoice.soap"))
                {
                    soap.Serialize(stream, invoice_1);
                }

                //Invoice.IsAllSerialized = true;
                Invoice.IsAllSerialized = false;

                using (Stream fStream = File.OpenRead("Invoice.soap"))
                {
                    invoice_2 = (Invoice)soap.Deserialize(fStream);
                }

                invoice_2.Print();

                Console.WriteLine();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            Console.ReadLine();
        }
    }
}
