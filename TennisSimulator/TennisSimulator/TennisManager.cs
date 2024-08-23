using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TennisSimulator
{
    public class TennisManager
    {
        private List<TennisMatch> matches = [];
        private MatchType matchType;

        public void StartNewMatch()
        {
            TennisMatch tennisMatch = new TennisMatch(matchType);
            matches.Insert(0, tennisMatch);
        }

        public TennisMatch GetOngoingMatch()
        {
            return matches[0];
        }

        public void SetBestOfThree()
        {
            matchType = MatchType.BestOfThree;
        }

        public void SetBestOfFive()
        {
            matchType = MatchType.BestOfFive;
        }

        public string GetMatchStatus(TennisMatch match)
        {
            StringBuilder status = new StringBuilder();

            status.AppendLine("Match Status:");
            status.AppendLine($"Overall Score - {Players.PlayerOne}: {match.PlayerOneScore}, {Players.PlayerTwo}: {match.PlayerTwoScore}");

            for (int i = match.sets.Count - 1; i >= 0; i--)
            {
                var set = match.sets[i];
                status.AppendLine($"Set {match.sets.Count - i}: {Players.PlayerOne} {set.PlayerOneScore} - {set.PlayerTwoScore} {Players.PlayerTwo}");
            }

            if (!match.IsCompleted)
            {
                var ongoingSet = match.GetOngoingSet();
                var ongoingGame = ongoingSet.GetOngoingGame();

                status.AppendLine("Ongoing Game:");
                status.AppendLine($"{Players.PlayerOne}: {ConvertScore(ongoingGame.PlayerOneScore)}, {Players.PlayerTwo}: {ConvertScore(ongoingGame.PlayerTwoScore)}");
            }

            if (match.IsCompleted)
            {
                status.AppendLine("Match Winner: " + match.Winner);
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

        public (int player1Matches, int player2Matches) GetMatches(TennisMatch match)
        {
            return (match.PlayerOneScore, match.PlayerTwoScore);
        }

        public (int player1Sets, int player2Sets) GetSets(TennisMatch match)
        {
            TennisSet actualSet = match.sets[0];
            return (actualSet.PlayerOneScore, actualSet.PlayerTwoScore);
        }

        public (int player1Games, int player2Games) GetGames(TennisMatch match)
        {
            TennisGame actualGame = match.sets[0].games[0];
            return (actualGame.PlayerOneScore, actualGame.PlayerTwoScore);
        }
    }
}
