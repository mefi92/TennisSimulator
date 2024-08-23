using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisSimulator
{
    public abstract class TennisRules
    {
        public int PlayerOneScore { get; protected set; } = 0;
        public int PlayerTwoScore { get; protected set; } = 0;
        public bool IsCompleted { get; protected set; }
        public string? Winner { get; protected set; }
        public abstract void ScorePointForPlayer(string player);

        protected bool HasRequiredPointDifference(int score1, int score2)
        {
            return Math.Abs(score1 - score2) >= Constants.PointDifferenceThreshold;
        }

        protected void IncreaseSetScoreForPlayer(string player)
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
        }

        protected void SetWinner()
        {
            Winner = PlayerOneScore > PlayerTwoScore ? Constants.PlayerOneId : Constants.PlayerTwoId;
        }
    }
}
