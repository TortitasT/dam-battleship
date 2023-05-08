using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dam_battleship.models.Tests
{
    [TestClass()]
    public class TeamTests
    {
        [TestInitialize()]
        public void TestInitialize()
        {
            Team.ResetIndex();
        }

        [TestMethod()]
        public void TeamTest()
        {
            var team = new Team("Team");

            Assert.AreEqual("Team", team.Name);
            Assert.AreEqual(0, team.Id);

            var team2 = new Team("Team2");

            Assert.AreEqual("Team2", team2.Name);
            Assert.AreEqual(1, team2.Id);
        }
    }
}