/*
 ============================================================================
 Name        : Homework_14-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Display the list of currencies in the format
               "currency name" - "abbreviation" - "rate". Select only currencies
               with a rate range from 30 to 50. Source data in XML
               https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange.
 ============================================================================
 */

namespace Task_1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            CurrencyRateReaderDriver.RunTest();

            Console.ReadLine();
        }
    }
}
