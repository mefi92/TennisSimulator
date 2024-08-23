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
        public int PlayerOneScore { get; private set; } = 0;
        public int PlayerTwoScore { get; private set; } = 0;

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

        public override void ScorePointForPlayer(string player)
        {
            TennisGame ongoingGame = GetOngoingGame();
            ongoingGame.ScorePointForPlayer(player);
            CheckActualGameState(ongoingGame);
        }

        private void CheckActualGameState(TennisGame ongoingGame)
        {
            if (ongoingGame.IsCompleted && ongoingGame.Winner != null)
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

        private void IncreaseSetScoreForPlayer(string player)
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

        private bool HasSetWinner()
        {
            return (PlayerOneScore >= Constants.SetPointThreshold || PlayerTwoScore >= Constants.SetPointThreshold) &&
                 HasRequiredPointDifference(PlayerOneScore, PlayerTwoScore);
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