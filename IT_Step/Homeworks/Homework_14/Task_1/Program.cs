/*
 ============================================================================
 Name        : Homework_14-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Display the list of currencies in the form "currency name" - "abbreviation" - "rate".
               Select only currencies with a rate range from 10 to 20.
               Source data in XML https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange.
 ============================================================================
 */

using System.Globalization;
using System.Text;
using System.Xml;

namespace Task_1
{
    static class Reader
    {
        public static void readXML()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange");
            // Создать списки из узлов с нужными тегами.
            XmlNodeList tag1 = xmlDocument.GetElementsByTagName("txt");
            XmlNodeList tag2 = xmlDocument.GetElementsByTagName("cc");
            XmlNodeList tag3 = xmlDocument.GetElementsByTagName("rate");
            // Списки формируются из одной базы => кол-во элементов одинаковое, индексы элементов соответствуют.
            int currencyCount = tag3.Count;
            for (int i = 0; i < currencyCount; i++)
            {
                if (Decimal.Parse(tag3[i].InnerText, CultureInfo.InvariantCulture) > 10 &&
                   (Decimal.Parse(tag3[i].InnerText, CultureInfo.InvariantCulture) < 20))
                {
                    Console.WriteLine(tag1[i].InnerText + " " + tag2[i].InnerText + " " + tag3[i].InnerText);
                }
            }
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            try
            {
                Reader.readXML();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            Console.ReadLine();
        }
    }
}
