using System.Text;

namespace Task_1
{
    internal static class CurrencyRateReaderDriver
    {
        private static string _currencyRatesURL = 
            "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange";

        public static void RunTest()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            try
            {
                CurrencyRateReader.ReadRatesFromXmlAtUrl(_currencyRatesURL);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
