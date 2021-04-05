using System;
using FluentAssertions;
using Xunit;

namespace StringCalculator.Test
{
    public class StringCalculatorTests
    {
        private readonly StringCalculator stringCalculator;

        public StringCalculatorTests()
        {
            stringCalculator = new StringCalculator();
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1, 2, 3, 4, 5, 6", 21)]
        [InlineData("1\n2, 3", 6)]
        public void Add_StringWithValidInputs_ShouldReturnSum(string input, int expectedResult)
        {
            var result = stringCalculator.Add(input);

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Add_StringWithCharReturnsInvalidArgumentException()
        {
            Action act = () => stringCalculator.Add("A");

            act.Should().Throw<FormatException>();
        }
    }
}