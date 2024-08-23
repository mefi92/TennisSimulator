using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TennisSimulator
{
    public class TennisMatch : TennisRules
    {
        private List<TennisSet> sets = new List<TennisSet>();
        private readonly MatchType matchType;

        public TennisMatch(MatchType matchType)
        {
            this.matchType = matchType;
            StartNewSet();
        }

        public void StartNewSet()
        {
            if (IsCompleted) return;

            TennisSet set = new TennisSet();
            sets.Insert(0, set);
        }

        public override void ScorePointForPlayer(string player)
        {
            TennisSet ongoingSet = GetOngoingSet();
            ongoingSet.ScorePointForPlayer(player);
            CheckActualSetState(ongoingSet);
        }

        private TennisSet GetOngoingSet()
        {
            return sets[0];
        }

        private void CheckActualSetState(TennisSet ongoingSet)
        {
            if (ongoingSet.IsCompleted && ongoingSet.Winner != null)
            {
                IncreaseSetScoreForPlayer(ongoingSet.Winner);
                SetWinnerOrNewGame();
            }
        }

        private void SetWinnerOrNewGame()
        {
            if (HasMatchWinner())
            {
                IsCompleted = true;
                SetWinner();
            }
            else
            {
                StartNewSet();
            }
        }

        private bool HasMatchWinner()
        {
            int requiredSetsToWin = matchType == MatchType.BestOfThree ? Constants.BestOfThreeThreshold : Constants.BestOfFiveThreshold;
            return PlayerOneScore == requiredSetsToWin || PlayerTwoScore == requiredSetsToWin;
        }

        public string GetMatchStatus()
        {
            StringBuilder status = new StringBuilder();

            status.AppendLine("Match Status:");
            status.AppendLine($"Overall Score - {Constants.PlayerOneId}: {PlayerOneScore}, {Constants.PlayerTwoId}: {PlayerTwoScore}");

            for (int i = sets.Count - 1; i >= 0; i--)
            {
                var set = sets[i];
                status.AppendLine($"Set {sets.Count - i}: {Constants.PlayerOneId} {set.PlayerOneScore} - {set.PlayerTwoScore} {Constants.PlayerTwoId}");
            }

            if (!IsCompleted)
            {
                var ongoingSet = GetOngoingSet();
                var ongoingGame = ongoingSet.GetOngoingGame();

                status.AppendLine("Ongoing Game:");
                status.AppendLine($"{Constants.PlayerOneId}: {ConvertScore(ongoingGame.PlayerOneScore)}, {Constants.PlayerTwoId}: {ConvertScore(ongoingGame.PlayerTwoScore)}");
            }

            if (IsCompleted)
            {
                status.AppendLine("Match Winner: " + Winner);
            }

            return status.ToString();
        }

        private string ConvertScore(int score)
        {
            switch (score)
            {
                case 0: return "0";
                case 1: return "15";
                case 2: return "30";
                case 3: return "40";
                default: return "Advantage";
            }
        }

        public (int player1Matches, int player2Matches) GetMatches()
        {
            return (PlayerOneScore, PlayerTwoScore);
        }

        public (int player1Sets, int player2Sets) GetSets()
        {
            TennisSet actualSet = sets[0];
            return (actualSet.PlayerOneScore, actualSet.PlayerTwoScore);
        }

        public (int player1Games, int player2Games) GetGames()
        {
            TennisGame actualGame = sets[0].games[0];
            return (actualGame.PlayerOneScore, actualGame.PlayerTwoScore);
        }
    }
}
