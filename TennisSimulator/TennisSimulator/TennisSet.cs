using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TennisSimulator
{
    public class TennisSet : TennisRules
    {
        public List<TennisGame> games = new List<TennisGame>();

        public TennisSet()
        {
            StartNewGame();
        }

        public void StartNewGame()
        {
            if (IsCompleted) return;

            TennisGame game = new TennisGame();
            games.Insert(0, game);
        }

        public override void ScorePointForPlayer(Players player)
        {
            TennisGame ongoingGame = GetOngoingGame();
            ongoingGame.ScorePointForPlayer(player);
            CheckActualGameState(ongoingGame);
        }

        private void CheckActualGameState(TennisGame ongoingGame)
        {
            if (ongoingGame.IsCompleted)
            {
                IncreaseSetScoreForPlayer(ongoingGame.Winner);
                SetWinnerOrNewGame();
            }
        }

        private void SetWinnerOrNewGame()
        {
            if (HasSetWinner())
            {
                IsCompleted = true;
                SetWinner();
            }
            else
            {
                StartNewGame();
            }
        }

        public TennisGame GetOngoingGame()
        {
            return games[0];
        }

        private bool HasSetWinner()
        {
            return (PlayerOneScore >= Constants.SetPointThreshold || PlayerTwoScore >= Constants.SetPointThreshold) &&
                 HasRequiredPointDifference(PlayerOneScore, PlayerTwoScore);
        }
    }
}