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
        public List<TennisSet> sets = new List<TennisSet>();
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

        public override void ScorePointForPlayer(Players player)
        {
            TennisSet ongoingSet = GetOngoingSet();
            ongoingSet.ScorePointForPlayer(player);
            CheckActualSetState(ongoingSet);
        }

        public TennisSet GetOngoingSet()
        {
            return sets[0];
        }

        private void CheckActualSetState(TennisSet ongoingSet)
        {
            if (ongoingSet.IsCompleted)
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
    }
}
