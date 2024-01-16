using Task_2;

namespace Task_2_Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class UnitTests
    {
        [DefaultFloatingPointTolerance(6)]
        [TestCase(-10, -10.1, ExpectedResult = 1.01)]
        [TestCase(0.01, 5.2, ExpectedResult = 0.00052)]
        [TestCase(1.5, 25, ExpectedResult = 0.375)]
        [TestCase(35, 17, ExpectedResult = 5.95)]
        [TestCase(100, 25, ExpectedResult = 25)]
        [TestCase(1000.555, 75.75, ExpectedResult = 757.920412)]
        [TestCase(999999.99999, 99.99, ExpectedResult = 999900)]

        public double CalculatePercentOfNumber_ReturnsResult(double number, double percent)
        {
            // Act
            return UserInputProcessor.CalculatePercentOfNumber(number, percent);
        }
    }
}
