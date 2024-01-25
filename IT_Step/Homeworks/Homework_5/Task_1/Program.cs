/*
 ============================================================================
 Name        : Homework_5-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : In one of the previous tasks, you created the "Shop" class. Now add
               the information about the shop's area to this class. Overload the 
               "+" and "—" operators (to increase and reduce the area of ​​the store
               by the specified size), "==", "!=", "<" and ">" operators (to check
               the relations of the areas of two stores). Use the property mechanism
               of class fields.
 ============================================================================
 */

namespace Task_1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var Shop_0 = new MyShop();
            Console.WriteLine("Shop_0:");
            Console.WriteLine(Shop_0.ToString());

            //=================================================================

            var Shop_1 = new MyShop(
                "Shop_1",
                "Address_1",
                "Description_1",
                "000-000-001",
                "Email_1",
                10.0f);
            var Shop_2 = new MyShop(
                "Shop_2",
                "Address_2",
                "Description_2",
                "000-000-002",
                "Email_2",
                10.0f);

            Console.WriteLine("Shop_1:");
            Console.WriteLine(Shop_1.ToString());
            Console.WriteLine("Shop_2:");
            Console.WriteLine(Shop_2.ToString());

            Console.WriteLine(
                $"{Shop_1.Name} == {Shop_2.Name} : {Shop_1 == Shop_2}.");
            Console.WriteLine(
                $"{Shop_1.Name} != {Shop_2.Name} : {Shop_1 != Shop_2}.");
            Console.WriteLine(
                $"{Shop_1.Name} > {Shop_2.Name} : {Shop_1 > Shop_2}.");
            Console.WriteLine(
                $"{Shop_1.Name} < {Shop_2.Name} : {Shop_1 < Shop_2}.");
            Console.WriteLine(
                $"{Shop_1.Name} equals {Shop_2.Name} : {Shop_1.Equals(Shop_2)}.");
            Console.WriteLine();

            //=================================================================

            MyShop Shop_3 = Shop_2 + 5.0f;

            Shop_3.Name = "Shop_3";
            Shop_3.Address = "Address_3";
            Shop_3.Description = "Description_3";
            Shop_3.PhoneNumber = "000-000-003";
            Shop_3.Email = "Email_3";
            
            Console.WriteLine("Shop_3:");
            Console.WriteLine(Shop_3.ToString());

            Console.WriteLine(
                $"{Shop_3.Name} == {Shop_2.Name} : {Shop_3 == Shop_2}.");
            Console.WriteLine(
                $"{Shop_3.Name} != {Shop_2.Name} : {Shop_3 != Shop_2}.");
            Console.WriteLine(
                $"{Shop_3.Name} > {Shop_2.Name} : {Shop_3 > Shop_2}.");
            Console.WriteLine(
                $"{Shop_3.Name} < {Shop_2.Name} : {Shop_3 < Shop_2}.");
            Console.WriteLine(
                $"{Shop_3.Name} equals {Shop_2.Name} : {Shop_3.Equals(Shop_2)}.");
            Console.WriteLine();

            //=================================================================

            MyShop Shop_4 = Shop_3 - 5.0f;

            Shop_4.Name = "Shop_4";
            Shop_4.Address = "Address_4";
            Shop_4.Description = "Description_4";
            Shop_4.PhoneNumber = "000-000-004";
            Shop_4.Email = "Email_4";

            Console.WriteLine("Shop_4:");
            Console.WriteLine(Shop_4.ToString());

            Console.WriteLine(
                $"{Shop_4.Name} == {Shop_2.Name} : {Shop_4 == Shop_2}.");
            Console.WriteLine(
                $"{Shop_4.Name} != {Shop_2.Name} : {Shop_4 != Shop_2}.");
            Console.WriteLine(
                $"{Shop_4.Name} > {Shop_2.Name} : {Shop_4 > Shop_2}.");
            Console.WriteLine(
                $"{Shop_4.Name} < {Shop_2.Name} : {Shop_4 < Shop_2}.");
            Console.WriteLine(
                $"{Shop_4.Name} equals {Shop_2.Name} : {Shop_4.Equals(Shop_2)}.");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
