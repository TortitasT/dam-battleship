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
    public class ShipTests
    {
        private readonly int[,] _matrix = new int[,]{
            { 1, 1, 1, 1, 1 },
            { 0, 1, 0, 1, 0 }
        };
        private readonly Ship _ship = new("Yamato", new int[,] { });

        [TestInitialize]
        public void TestInitialize()
        {
            _ship.Matrix = _matrix;
        }

        [TestMethod()]
        public void ShipTest()
        {
            Assert.AreEqual("Yamato", _ship.Name);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("Yamato at Vector2(0, 0)", _ship.ToString());
        }

        [TestMethod()]
        public void GetPositionsTest()
        {
            var positions = _ship.GetPositions().ToList();

            Assert.AreEqual(7, positions.Count);

            foreach (var position in positions)
            {
                Assert.IsTrue(_matrix[position.Y, position.X] == 1);
            }
        }
    }
}