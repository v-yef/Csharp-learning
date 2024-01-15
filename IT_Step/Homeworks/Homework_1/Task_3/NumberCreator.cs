namespace Task_3
{
    public static class NumberCreator
    {
        public static int CreateNumberOfFourDigits(sbyte num1, sbyte num2, sbyte num3, sbyte num4)
        {
            bool isSigned = num1 < 0;

            int number = Math.Abs(num1);
            number = number * 10 + Math.Abs(num2);
            number = number * 10 + Math.Abs(num3);
            number = number * 10 + Math.Abs(num4);

            return isSigned ? (-number) : number;
        }
    }
}
