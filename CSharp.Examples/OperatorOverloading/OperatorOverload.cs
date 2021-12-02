using System;

namespace CSharp.Examples.OperatorOverloading
{
    public class Score
    {
        public int Round1 { get; set; }
        public int Round2 { get; set; }

        public Score(int round1, int round2)
        {
            Round1 = round1;
            Round2 = round2;
        }

        public static Score operator +(Score teamMate1, Score teamMate2)
        {
            var round1 = teamMate1.Round1 + teamMate2.Round1;
            var round2 = teamMate1.Round2 + teamMate2.Round2;

            var result = new Score(round1, round2);

            return result;
        }

        public static Score operator -(Score score, Score penalties)
        {
            var round1 = score.Round1 - penalties.Round1;
            var round2 = score.Round2 - penalties.Round2;

            var result = new Score(round1, round2);

            return result;
        }

        public static Score operator *(Score score, Score multipliers)
        {
            var round1 = score.Round1;
            if (multipliers.Round1 > 1)
            {
                round1 = score.Round1 * multipliers.Round1;
            }

            var round2 = score.Round2;
            if (multipliers.Round2 > 1)
            {
                round2 = score.Round2 * multipliers.Round2;
            }

            var result = new Score(round1, round2);

            return result;
        }
    }

    public static class ScoreExample
    {
        public static void Run()
        {
            var blueTeammate1Score = new Score(1,3);
            var blueTeammate2Score = new Score(3, 5);
            var blueTeamPenalties = new Score(1, 1);
            var blueTeamMultipliers = new Score(2, 3);

            var redTeammate1Score = new Score(1, 3);
            var redTeammate2Score = new Score(3, 5);
            var redTeamPenalties = new Score(0, 3);
            var redTeamMultipliers = new Score(0, 0);

            var blueTeamScore = blueTeammate1Score + blueTeammate2Score;
            var redTeamScore = redTeammate1Score + redTeammate2Score;

            blueTeamScore -= blueTeamPenalties;
            redTeamScore -= redTeamPenalties;

            blueTeamScore *= blueTeamMultipliers;
            redTeamScore *= redTeamMultipliers;

            Console.WriteLine($"Round 1 Blue [{blueTeamScore.Round1}] : Red [{redTeamScore.Round1}] ");
            Console.WriteLine($"Round 2 Blue [{blueTeamScore.Round2}] : Red [{redTeamScore.Round2}] ");

            //Output:
            //Round 1 Blue[6] : Red[4]
            //Round 2 Blue[21] : Red[5]
        }
    }
}
