using dam_battleship.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils = dam_battleship.utils.Utils;

namespace dam_battleship.models.Tests
{
    [TestClass()]
    public class BoardTests
    {
        [TestMethod()]
        public void BoardTest()
        {
            var stubsDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\stubs";

            var expectedStdout = File.ReadAllText(stubsDirectory + "/seeded_board_output.txt");

            SeededRandom.SetSeed(1234);

            var teams = new List<Team>()
            {
                new Team("Test1"),
                new Team("Test2")
            };

            var board = new Board(20, 20);

            Utils.PopulateBoard(board, teams);

            Assert.IsTrue(expectedStdout.Equals(board.ToString()));
        }
    }
}