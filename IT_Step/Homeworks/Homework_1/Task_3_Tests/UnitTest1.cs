using Task_3;

namespace Task_3_Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Task_3_Tests
    {
        [TestCase(-1, 2, 3, 4, ExpectedResult = -1234)]
        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(0, 5, 3, 2, ExpectedResult = 532)]
        [TestCase(1, 5, 7, 8, ExpectedResult = 1578)]
        [TestCase(1, -1, 3, 7, ExpectedResult = 1137)]
        [TestCase(5, 8, 9, 0, ExpectedResult = 5890)]
        [TestCase(7, 0, 0, 0, ExpectedResult = 7000)]
        [TestCase(9, -2, -3, -4, ExpectedResult = 9234)]
        public int CreateNumberOfFourDigits_ReturnsNumber(sbyte num1, sbyte num2, sbyte num3, sbyte num4)
        {
            // Act
            return NumberCreator.CreateNumberOfFourDigits(num1, num2, num3, num4);
        }
    }
}
