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
    public class Vector2Tests
    {
        [TestMethod()]
        public void Vector2Test()
        {
            var vector2 = new Vector2(1, 2);

            Assert.AreEqual(1, vector2.X);
            Assert.AreEqual(2, vector2.Y);
        }

        [TestMethod()]
        public void RandomTest()
        {
            var vector2 = Vector2.Random(100, 100);

            Assert.IsTrue(vector2.X >= 0 && vector2.X < 100);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var vector2One = new Vector2(1, 2);
            var vector2Two = new Vector2(1, 2);

            Assert.IsFalse(vector2One.Equals(vector2Two));
            Assert.IsTrue(vector2One.Equals(vector2One));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var vector2One = new Vector2(1, 2);
            var vector2Two = new Vector2(1, 2);

            Assert.AreNotEqual(vector2One.GetHashCode(), vector2Two.GetHashCode());
            Assert.AreEqual(vector2One.GetHashCode(), vector2One.GetHashCode());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var vector2 = new Vector2(1, 2);

            Assert.AreEqual("Vector2(1, 2)", vector2.ToString());
        }
    }
}