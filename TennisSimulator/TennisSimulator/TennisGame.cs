using Microsoft.VisualBasic;
using System.Reflection;

namespace TennisSimulator
{

    public class TennisGame : TennisRules
    {
        public int PlayerOneScore { get; private set; } = 0;
        public int PlayerTwoScore { get; private set; } = 0;

        public override void ScorePointForPlayer(string player)
        {
            switch (player)
            {
                case Constants.PlayerOneId:
                    PlayerOneScore += 1; break;
                case Constants.PlayerTwoId:
                    PlayerTwoScore += 1; break;
                default:
                    throw new InvalidDataException();
            }

            HasGameWinner();
        }

        private void HasGameWinner()
        {
            if ((PlayerOneScore >= Constants.GamePointThreshold || PlayerTwoScore >= Constants.GamePointThreshold) &&
                    HasRequiredPointDifference(PlayerOneScore, PlayerTwoScore))
            {
                IsCompleted = true;
                SetWinner();
            }
        }

        private bool HasRequiredPointDifference(int score1, int score2)
        {
            return Math.Abs(score1 - score2) >= Constants.PointDifferenceThreshold;
        }

        private void SetWinner()
        {
            Winner = PlayerOneScore > PlayerTwoScore ? Constants.PlayerOneId : Constants.PlayerTwoId;
        }
    }
}

