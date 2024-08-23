namespace TennisSimulator.Test
{
    [TestClass]
    public class TennisGameTest
    {
        TennisManager tennisGame;

        [TestInitialize]
        public void Init()
        {
            tennisGame = new TennisManager();
            tennisGame.SetBestOfThree();
            tennisGame.StartNewMatch();
        }

        [TestMethod]
        public void TennisGame_InitialScore_Score0_0()
        {
            char[] scoreSequence = { };

            var expectedGames = (0, 0);
            var expectedSets = (0, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P0OneScore_Score1_0()
        {
            char[] scoreSequence = { 'A' };

            var expectedGames = (1, 0);
            var expectedSets = (0, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_BothPlayersScored_Score1_1()
        {
            char[] scoreSequence = { 'A', 'B' };

            var expectedGames = (1, 1);
            var expectedSets = (0, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_ScoreTwoOne_Score2_1()
        {
            char[] scoreSequence = { 'A', 'B', 'A' };

            var expectedGames = (2, 1);
            var expectedSets = (0, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_SetForP1_Set1_0()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'A' };

            var expectedGames = (0, 0);
            var expectedSets = (1, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_SetForP2_Set0_1()
        {
            char[] scoreSequence = { 'B', 'B', 'B', 'B' };

            var expectedGames = (0, 0);
            var expectedSets = (0, 1);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P1G0Se1Sc1()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'A', 'A' };

            var expectedGames = (1, 0);
            var expectedSets = (1, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P1G0Se1Sc3()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'A',
                                     'A', 'A', 'A' };

            var expectedGames = (3, 0);
            var expectedSets = (1, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P1G0Se2Sc0()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A' };

            var expectedGames = (0, 0);
            var expectedSets = (2, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_ThreeAll()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B' };

            var expectedGames = (3, 3);
            var expectedSets = (0, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_DeuceScenario()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B' };

            var expectedGames = (4, 4);
            var expectedSets = (0, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_FiveAll()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'A', 'B' };

            var expectedGames = (5, 5);
            var expectedSets = (0, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P0Advantage_FourThree()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A' };

            var expectedGames = (4, 3);
            var expectedSets = (0, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P0Advantage_FiveFour()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'A' };

            var expectedGames = (5, 4);
            var expectedSets = (0, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P0WinAdvantage()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'A', 'A' };

            var expectedGames = (0, 0);
            var expectedSets = (1, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P0WinAdvantageAndOneMoreGame()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'A', 'A', 'A' };

            var expectedGames = (1, 0);
            var expectedSets = (1, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P1Advantage()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'B' };

            var expectedGames = (4, 5);
            var expectedSets = (0, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }



        [TestMethod]
        public void TennisGame_P1WinAdvantage()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'B', 'B' };

            var expectedGames = (0, 0);
            var expectedSets = (0, 1);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P1WinAdvantageAndOneMoreGame()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'B', 'B', 'B' };

            var expectedGames = (0, 1);
            var expectedSets = (0, 1);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P0OneSetAndThreeGames()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'A', 'A',
                                     'A', 'A', 'A' };

            var expectedGames = (3, 0);
            var expectedSets = (1, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P0TwoSets()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'A', 'A',
                                     'A', 'A', 'A', 'A' };

            var expectedGames = (0, 0);
            var expectedSets = (2, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P0ThreeSets()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A'};

            var expectedGames = (0, 0);
            var expectedSets = (3, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P0FourSets()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A'};

            var expectedGames = (0, 0);
            var expectedSets = (4, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P0FiveSets()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A'};

            var expectedGames = (0, 0);
            var expectedSets = (5, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P0WinsMatch()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A'};

            var expectedGames = (0, 0);
            var expectedSets = (0, 0);
            var expectedMatches = (1, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P1WinsMatch()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B'};

            var expectedGames = (0, 0);
            var expectedSets = (0, 0);
            var expectedMatches = (0, 1);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_Sets5_5()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'B', 'B',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A', // 5 - 1
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B'};

            var expectedGames = (0, 0);
            var expectedSets = (5, 5);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_Sets6_5()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'B', 'B',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A', // 5 - 1
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'A', 'A', 'A', 'A'};

            var expectedGames = (0, 0);
            var expectedSets = (6, 5);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_Sets7_5_P0Wins()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'B', 'B',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A', // 5 - 1
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A'};

            var expectedGames = (0, 0);
            var expectedSets = (0, 0);
            var expectedMatches = (1, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_Sets7_6()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'B', 'B',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A', // 5 - 1
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'A', 'A', 'A', 'A', // 6 - 5
                                     'B', 'B', 'B', 'B',
                                     'A', 'A', 'A', 'A'};

            var expectedGames = (0, 0);
            var expectedSets = (7, 6);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_Sets6_7()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'B', 'B',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A', // 5 - 1
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'A', 'A', 'A', 'A', // 6 - 5
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B'};

            var expectedGames = (0, 0);
            var expectedSets = (6, 7);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_Sets9_9()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'B', 'B', 'B', 'A', 'B', 'B', 'B',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A', // 5 - 1
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B',
                                     'A', 'A', 'A', 'A', // 6 - 5
                                     'B', 'B', 'B', 'B',
                                     'B', 'B', 'B', 'B', // 6 - 7
                                     'A', 'A', 'A', 'A', // 7 - 7
                                     'B', 'B', 'B', 'B', // 7 - 8
                                     'A', 'A', 'A', 'A', // 8 - 8
                                     'B', 'B', 'B', 'B', // 8 - 9
                                     'A', 'A', 'A', 'A'};

            var expectedGames = (0, 0);
            var expectedSets = (9, 9);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P0FiveInARow_OneSetAndOneGame()
        {
            char[] scoreSequence = { 'A', 'A', 'A', 'A', 'A' };

            var expectedGames = (1, 0);
            var expectedSets = (1, 0); // 1 - 1  WTF?
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P1EasyWin()
        {
            char[] scoreSequence = { 'A', 'A', 'B', 'B', 'B', 'B' };

            var expectedGames = (0, 0);
            var expectedSets = (0, 1);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P1EasyWinsWithLuck()
        {
            char[] scoreSequence = { 'A', 'A', 'B', 'B', 'B', 'A', 'A', 'B', 'A', 'B', 'B', 'B' };

            var expectedGames = (0, 0);
            var expectedSets = (0, 1);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGame_P0WinsWithHardGame_9_7()
        {
            char[] scoreSequence = { 'A', 'A', 'B', 'B', 'B', 'A', 'A', 'B', 'A', 'B', 'A', 'B', 'A', 'B', 'A', 'A' };

            var expectedGames = (0, 0);
            var expectedSets = (1, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TennisGameTest_Invalid_C_Player()
        {
            char[] scoreSequence = { 'C' };

            var expectedGames = (0, 0);
            var expectedSets = (1, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        public void TennisGameTest_LowerCaseInputs()
        {
            char[] scoreSequence = { 'a', 'b' };

            var expectedGames = (1, 1);
            var expectedSets = (0, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TennisGameTest_CharIntInputs()
        {
            char[] scoreSequence = { '1', '2' };

            var expectedGames = (1, 1);
            var expectedSets = (0, 0);
            var expectedMatches = (0, 0);

            SimulateTennisMatch(scoreSequence, expectedGames, expectedSets, expectedMatches);
        }

        private void ProcessScoreSequence(TennisMatch tennisMatch, char[] scoreSequence)
        {
            foreach (char scoreChar in scoreSequence)
            {
                switch (char.ToUpper(scoreChar))
                {
                    case 'A':
                        tennisMatch.ScorePointForPlayer(Players.PlayerOne);
                        break;
                    case 'B':
                        tennisMatch.ScorePointForPlayer(Players.PlayerTwo);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private void SimulateTennisMatch(char[] scoreSequence, (int, int) expectedGames, (int, int) expectedSets, (int, int) expectedMatches)
        {
            TennisMatch tennisMatch = tennisGame.GetOngoingMatch();

            ProcessScoreSequence(tennisMatch, scoreSequence);

            var resultGames = tennisGame.GetGames(tennisMatch);
            var resultSets = tennisGame.GetSets(tennisMatch);
            var resultMatches = tennisGame.GetMatches(tennisMatch);

            Assert.AreEqual(expectedGames, resultGames);
            Assert.AreEqual(expectedSets, resultSets);
            Assert.AreEqual(expectedMatches, resultMatches);
        }
    }
}