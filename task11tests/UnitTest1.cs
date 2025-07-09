using task11;
using Generated;
using Xunit;

namespace task11tests
{
    public class CalculatorTests
    {
        private readonly ICalculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Generated.Calculator();
        }

        [Fact]
        public void Add_Test()
        {
            Assert.Equal(5, _calculator.Add(2, 3));
        }

        [Fact]
        public void Minus_Test()
        {
            Assert.Equal(2, _calculator.Minus(5, 3));
        }

        [Fact]
        public void Mul_Test()
        {
            Assert.Equal(12, _calculator.Mul(4, 3));
        }

        [Fact]
        public void Div_Test()
        {
            Assert.Equal(5, _calculator.Div(10, 2));
        }
    }
}

