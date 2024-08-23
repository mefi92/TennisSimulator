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
        public Players Winner { get; protected set; }
        public abstract void ScorePointForPlayer(Players player);

        protected bool HasRequiredPointDifference(int score1, int score2)
        {
            return Math.Abs(score1 - score2) >= Constants.PointDifferenceThreshold;
        }

        protected void IncreaseSetScoreForPlayer(Players player)
        {
            switch (player)
            {
                case Players.PlayerOne:
                    PlayerOneScore += 1; break;
                case Players.PlayerTwo:
                    PlayerTwoScore += 1; break;
            }
        }

        protected void SetWinner()
        {
            Winner = PlayerOneScore > PlayerTwoScore ? Players.PlayerOne : Players.PlayerTwo;
        }
    }
}
