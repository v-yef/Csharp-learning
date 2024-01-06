/*
 ============================================================================
 Name        : Homework_3-Task_2
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : Create the "Shop" class. The following must be stored in the class fields: store name, address, store profile description,
contact phone number, email. Implement class methods for data input, data output. Implement access to individual fields via
  class methods.
 ============================================================================
 */

namespace Task_2
{
    class MyShop
    {
        public string m_sName_ { get; set; }
        public string m_sAddress_ { get; set; }
        public string m_sDescription_ { get; set; }
        public string m_sPhoneNumber_ { get; set; }
        public string m_sEmail_ { get; set; }

        public MyShop()
        {
            m_sName_ = "No name";
            m_sAddress_ = "No address";
            m_sDescription_ = "No description";
            m_sPhoneNumber_ = "000-000-000";
            m_sEmail_ = "No email";
        }

        public MyShop(string _sName, string _sAddress, string _sDescription, string _sPhoneNumber, string _sEmail)
        {
            m_sName_ = _sName;
            m_sAddress_ = _sAddress;
            m_sDescription_ = _sDescription;
            m_sPhoneNumber_ = _sPhoneNumber;
            m_sEmail_ = _sEmail;
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            MyShop shop_1 = new MyShop();

            Console.WriteLine("Магазин №1 (начальный) :");
            Console.WriteLine(shop_1.m_sName_);
            Console.WriteLine(shop_1.m_sAddress_);
            Console.WriteLine(shop_1.m_sDescription_);
            Console.WriteLine(shop_1.m_sPhoneNumber_);
            Console.WriteLine(shop_1.m_sEmail_);
            Console.WriteLine();

            shop_1.m_sName_ = "Новое имя";
            shop_1.m_sAddress_ = "Новый адрес";
            shop_1.m_sDescription_ = "Новое описание";
            shop_1.m_sPhoneNumber_ = "123-456-789";
            shop_1.m_sEmail_ = "Новый email";

            Console.WriteLine("Магазин №1 (обновленный) :");
            Console.WriteLine(shop_1.m_sName_);
            Console.WriteLine(shop_1.m_sAddress_);
            Console.WriteLine(shop_1.m_sDescription_);
            Console.WriteLine(shop_1.m_sPhoneNumber_);
            Console.WriteLine(shop_1.m_sEmail_);
            Console.WriteLine();

            MyShop shop_2 = new MyShop("Мой магазин", "Адрес магазина", "Описание магазина", "987-654-321", "Email магазина");

            Console.WriteLine("Магазин №2 (начальный) :");
            Console.WriteLine(shop_2.m_sName_);
            Console.WriteLine(shop_2.m_sAddress_);
            Console.WriteLine(shop_2.m_sDescription_);
            Console.WriteLine(shop_2.m_sPhoneNumber_);
            Console.WriteLine(shop_2.m_sEmail_);

            Console.ReadLine();
        }
    }
}
