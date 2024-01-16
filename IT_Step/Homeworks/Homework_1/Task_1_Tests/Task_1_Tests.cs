using Task_1;

namespace Task_1_Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Task_1_Tests
    {
        [TestCase(null, ExpectedResult = "")]
        [TestCase(0, ExpectedResult = "Fizz Buzz")]
        [TestCase(15, ExpectedResult = "Fizz Buzz")]
        [TestCase(45, ExpectedResult = "Fizz Buzz")]
        [TestCase(9, ExpectedResult = "Fizz")]
        [TestCase(27, ExpectedResult = "Fizz")]
        [TestCase(33, ExpectedResult = "Fizz")]
        [TestCase(5, ExpectedResult = "Buzz")]
        [TestCase(50, ExpectedResult = "Buzz")]
        [TestCase(100, ExpectedResult = "Buzz")]
        [TestCase(2, ExpectedResult = "2")]
        [TestCase(28, ExpectedResult = "28")]
        [TestCase(97, ExpectedResult = "97")]
        public string MakeMessageBasedOnIntegerInput_ReturnsResult(int? input)
        {
            // Act
            return UserInputProcessor.MakeMessageBasedOnIntegerInput(input);
        }
    }
}
