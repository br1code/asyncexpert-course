using Module01.Homework;
using Xunit;

namespace Dotnetos.AsyncExpert.Homework.Module01.Tests
{
    public class FibonacciCalcTests
    {
        private readonly FibonacciCalc _fibonacciCalc;

        public FibonacciCalcTests()
        {
            _fibonacciCalc = new FibonacciCalc();
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(5, 5)]
        [InlineData(10, 55)]
        public void Recursive_ReturnsCorrectValue(ulong n, ulong expected)
        {
            var result = _fibonacciCalc.Recursive(n);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(5, 5)]
        [InlineData(10, 55)]
        public void RecursiveWithMemoization_ReturnsCorrectValue(ulong n, ulong expected)
        {
            var result = _fibonacciCalc.RecursiveWithMemoization(n);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(5, 5)]
        [InlineData(10, 55)]
        public void Iterative_ReturnsCorrectValue(ulong n, ulong expected)
        {
            var result = _fibonacciCalc.Iterative(n);
            Assert.Equal(expected, result);
        }
    }
}
