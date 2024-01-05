using Task_1;

namespace Task_1_Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Task_1_Tests
    {
        [TestCase(-1, ExpectedResult = "Error! The number must be in the [1..100] range!")]
        [TestCase(0, ExpectedResult = "Error! The number must be in the [1..100] range!")]
        [TestCase(101, ExpectedResult = "Error! The number must be in the [1..100] range!")]
        [TestCase(15, ExpectedResult = "Fizz Buzz")]
        [TestCase(45, ExpectedResult = "Fizz Buzz")]
        [TestCase(75, ExpectedResult = "Fizz Buzz")]
        [TestCase(9, ExpectedResult = "Fizz")]
        [TestCase(27, ExpectedResult = "Fizz")]
        [TestCase(33, ExpectedResult = "Fizz")]
        [TestCase(5, ExpectedResult = "Buzz")]
        [TestCase(50, ExpectedResult = "Buzz")]
        [TestCase(100, ExpectedResult = "Buzz")]
        [TestCase(2, ExpectedResult = "2")]
        [TestCase(28, ExpectedResult = "28")]
        [TestCase(97, ExpectedResult = "97")]

        public string CreateMessageBasedOnIntegerInput_ReturnsValidMessage(int input)
        {
            // Act
            return UserInputProcessor.CreateMessageBasedOnIntegerInput(input);
        }
    }
}
