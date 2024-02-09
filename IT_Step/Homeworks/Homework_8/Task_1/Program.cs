/*
 ============================================================================
 Name        : Homework_8-Task_1
 Author      : Viacheslav Yefisko
 Version     : 0
 Copyright   : MIT License
 Description : The user enters a logical expression using a keyboard. For example,
               3>2 or 7<3. The program should evaluate this expression and output
               the result: true or false. The line should contain only integers
               and operators: <, >, <=, >=, ==, !=. Use exceptions to handle input
               errors.
 ============================================================================
 */

namespace Task_1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            string input = BoolCalculator.GetExpressionFromUser();

            try
            {
                Console.WriteLine(BoolCalculator.EvaluateExpression(input));
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            Console.ReadLine();
        }
    }
}
