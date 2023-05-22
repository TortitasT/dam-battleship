using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dam_battleship.models.Tests;

[TestClass]
public class BoardTests
{
#if false
    [TestMethod]
    public void BoardTest()
    {
        var expectedStdout = "|                                                            |\n|                                  B  B  B  B                |\n|    C  C  C                    D  D                         |\n|                                                            |\n|                                                            |\n|                                                            |\n|                                     S  S  S                |\n|                                                            |\n|                                                            |\n|                                                       D  D |\n|                                                 C  C  C    |\n|                                              S  S  S       |\n|                                                            |\n|                                           A  A  A  A       |\n|                                                    A       |\n|                                                            |\n|                                                            |\n|                      A  A  A  A                            |\n|                   B  B  B  B  A                            |\n|                                                            |\n";

        SeededRandom.SetSeed(1234);

        var teams = new List<Team>
            {
                new Team("Test1"),
                new Team("Test2")
            };

        Board board = new(20, 20);

        Utils.PopulateBoard(board, teams);

        File.WriteAllText("testboard.txt", board.ToString());
        File.WriteAllText("testExpected.txt", expectedStdout);

        Assert.AreEqual(expectedStdout, board.ToString());
    }

#endif
}