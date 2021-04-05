using FluentAssertions;
using Xunit;

namespace FizzBuzz.Test
{
    public class FizzBuzzTests
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        private readonly FizzBuzz fizzBuzz;

        public FizzBuzzTests()
        {
            fizzBuzz = new FizzBuzz();
        }

        [Theory]
        [InlineData(120)]
        public void PlayFizzBuzz_ShouldReturnListWithTheRightAmountOfValues(int rounds)
        {
            var result = fizzBuzz.PlayFizzBuzz(rounds);

            result.Should().HaveCount(rounds);
        }

        [Theory]
        [InlineData(120, 2, 116, Fizz)]
        [InlineData(120, 4, 114, Buzz)]
        [InlineData(120, 14, 119, Fizz + Buzz)]
        public void PlayFizzBuzz_ShouldReturnAListWithTheRightValues(int rounds, int firstOccurance, int lastOccurance,
            string expectedValue)
        {
            var result = fizzBuzz.PlayFizzBuzz(rounds);

            result.Should().HaveElementAt(firstOccurance, expectedValue).And
                .HaveElementAt(lastOccurance, expectedValue);
        }
    }
}