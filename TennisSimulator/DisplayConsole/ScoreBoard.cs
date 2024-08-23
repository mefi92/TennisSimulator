using Microsoft.VisualBasic;
using System;
using System.IO;
using TennisSimulator;

class ScoreBoard
{
    public static void Main(String[] args)
    {
        TennisManager tennisManager = new TennisManager();
        tennisManager.SetBestOfThree();
        tennisManager.StartNewMatch();
        TennisMatch tennisMatch = tennisManager.GetOngoingMatch();

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
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A',
                                     'A', 'A', 'A', 'A'};

        ProcessScoreSequence(scoreSequence, tennisMatch);
        string status = tennisManager.GetMatchStatus(tennisMatch);
        Console.WriteLine(status);
    }



    private static void ProcessScoreSequence(char[] scoreSequence, TennisMatch match)
    {
        foreach (char scoreChar in scoreSequence)
        {
            switch (char.ToUpper(scoreChar))
            {
                case 'A':
                    match.ScorePointForPlayer(Players.PlayerOne);
                    break;
                case 'B':
                    match.ScorePointForPlayer(Players.PlayerTwo);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}