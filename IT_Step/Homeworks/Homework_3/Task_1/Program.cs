/*
 ============================================================================
 Name        : Homework_3-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create a "Website" class. The following must be stored in the class fields: site name, site path, site description, site ip address.
Implement class methods for data input, data output. Implement access to individual fields through class methods.
 ============================================================================
 */

namespace Task_1
{
    class MySite
    {
        public string m_sName_ { get; set; }
        public string m_sWebAddress_ { get; set; }
        public string m_sIpAddress_ { get; set; }
        public string m_sDescription_ { get; set; }

        public MySite()
        {
            m_sName_ = "No name";
            m_sWebAddress_ = "No web-address";
            m_sIpAddress_ = "No ip-address";
            m_sDescription_ = "No description";
        }

        public MySite(string _sName, string _sWebAddress, string _sIpAddress, string _sDescription)
        {
            m_sName_ = _sName;
            m_sWebAddress_ = _sWebAddress;
            m_sIpAddress_ = _sIpAddress;
            m_sDescription_ = _sDescription;
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            MySite site_1 = new MySite();

            Console.WriteLine("Сайт №1 (начальный) :");
            Console.WriteLine(site_1.m_sName_);
            Console.WriteLine(site_1.m_sWebAddress_);
            Console.WriteLine(site_1.m_sIpAddress_);
            Console.WriteLine(site_1.m_sDescription_);
            Console.WriteLine();

            site_1.m_sName_ = "Новое имя";
            site_1.m_sWebAddress_ = "Новый веб-адрес";
            site_1.m_sIpAddress_ = "Новый ip-адрес";
            site_1.m_sDescription_ = "Новое описание";

            Console.WriteLine("Сайт №1 (обновленный) :");
            Console.WriteLine(site_1.m_sName_);
            Console.WriteLine(site_1.m_sWebAddress_);
            Console.WriteLine(site_1.m_sIpAddress_);
            Console.WriteLine(site_1.m_sDescription_);
            Console.WriteLine();

            MySite site_2 = new MySite("Мой сайт", "https://mywebsite.com", "192.168.0.1", "Очень интересный сайт");

            Console.WriteLine("Сайт №2 (начальный) :");
            Console.WriteLine(site_2.m_sName_);
            Console.WriteLine(site_2.m_sWebAddress_);
            Console.WriteLine(site_2.m_sIpAddress_);
            Console.WriteLine(site_2.m_sDescription_);

            Console.ReadLine();
        }
    }
}
