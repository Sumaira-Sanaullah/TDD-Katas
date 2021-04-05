using System.Collections.Generic;

namespace BowlingGame
{
    public class BowlingGame
    {
        private readonly List<int> rolls;
        public int Score { get; private set; }

        public BowlingGame()
        {
            rolls = new List<int>();
        }

        public void Roll(int pins)
        {
            Score += pins;
            rolls.Add(pins);
        }

        public int CalculateScore()
        {
            var score = 0;
            var roll = 0;

            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    score += StrikeBonus(roll);
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    score += 10 + SpareBonus(roll);
                    roll += 2;
                }

                else
                {
                    score += SumOfBallsInFrame(roll);
                    roll += 2;
                }
            }

            return score;
        }

        private bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }

        private bool IsStrike(int roll)
        {
            return rolls[roll] == 10;
        }

        private int StrikeBonus(int roll)
        {
            return rolls[roll] + rolls[roll + 1] + rolls[roll + 2];
        }

        private int SumOfBallsInFrame(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }

        private int SpareBonus(int roll)
        {
            return rolls[roll + 2];
        }
    }
}