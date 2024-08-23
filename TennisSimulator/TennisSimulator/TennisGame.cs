using Microsoft.VisualBasic;
using System.Reflection;

namespace TennisSimulator
{

    public class TennisGame : TennisRules
    {
        public override void ScorePointForPlayer(Players player)
        {
            IncreaseSetScoreForPlayer(player);

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
    }
}

