using System.Text;

namespace Task_1
{
    internal static class CurrencyRateReaderDriver
    {
        public static void RunTest()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            try
            {
                CurrencyRateReader.ReadRatesFromXmlAtUrl
                    ("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
