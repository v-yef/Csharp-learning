using System.Globalization;
using System.Xml;

namespace Task_1
{
    internal static class CurrencyRateReader
    {
        public static void ReadRatesFromXmlAtUrl(string url)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(url);

            // Create lists of nodes by required tags.
            XmlNodeList tag1 = xmlDocument.GetElementsByTagName("txt");
            XmlNodeList tag2 = xmlDocument.GetElementsByTagName("cc");
            XmlNodeList tag3 = xmlDocument.GetElementsByTagName("rate");

            // Lists are created form one base, so the number of elements is the same and
            // indexes of the elements are the same, too.
            int currencyCount = tag3.Count;
            for (int i = 0; i < currencyCount; i++)
            {
                if (tag1[i] != null && tag2[i] != null && tag3[i] != null)
                {
                    if (decimal.Parse(tag3[i].InnerText, CultureInfo.InvariantCulture) >= 30 &&
                        (decimal.Parse(tag3[i].InnerText, CultureInfo.InvariantCulture) <= 50))
                    {
                        Console.WriteLine(
                            tag1[i].InnerText + " " + tag2[i].InnerText + " " + tag3[i].InnerText);
                    }
                }
            }
        }
    }
}
