using Microsoft.VisualStudio.TestTools.UnitTesting;
using dam_battleship.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dam_battleship.models.Tests
{
    [TestClass()]
    public class TeamTests
    {
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