using FluentAssertions;
using Xunit;

namespace BowlingGame.Test
{
    public class BowlingGameTests
    {
        private readonly BowlingGame bowlingGame;

        public BowlingGameTests()
        {
            bowlingGame = new BowlingGame();
        }

        // test: gutter game
        [Fact]
        public void Roll_ShouldReturnNumberOfRolledPins()
        {
            bowlingGame.Roll(0);

            bowlingGame.Score.Should().Be(0);
        }

        // test: all ones scores 20 - When you knock down one pin with each ball, your total score is 20.
        [Fact]
        public void Roll_20Times_ShouldReturnNumberOfRolledPins()
        {
            bowlingGame.Roll(20);

            bowlingGame.Score.Should().Be(20);
        }

        // test: a spare in the first frame, followed by three pins, followed by all misses scores 16.
        [Fact]
        public void Roll_Spare_ShouldReturnNumberOfRolledPinsForSpare()
        {
            RollSpare();
            bowlingGame.Roll(3);

            RollMany(17, 0);

            var result = bowlingGame.CalculateScore();

            result.Should().Be(16);
        }

        // test: A strike in the first frame, followed by three and then four pins, followed by all misses, scores 24.
        [Fact]
        public void Roll_Strike_ShouldReturnNumberOfRolledPinsForStrike()
        {
            RollStrike();
            bowlingGame.Roll(3);
            bowlingGame.Roll(4);

            RollMany(16, 0);

            var result = bowlingGame.CalculateScore();

            result.Should().Be(24);
        }

        // test: perfect game - 12 strikes scores 300
        [Fact]
        public void Roll_ShouldReturnNumberOfRolledPinsForPerfectGame()
        {
            RollMany(12, 10);

            var result = bowlingGame.CalculateScore();

            result.Should().Be(300);
        }

        private void RollMany(int rolls, int value)
        {
            for (int i = 0; i < rolls; i++)
            {
                bowlingGame.Roll(value);
            }
        }

        private void RollSpare()
        {
            bowlingGame.Roll(5);

            bowlingGame.Roll(5);
        }

        private void RollStrike()
        {
            bowlingGame.Roll(10);
        }
    }
}