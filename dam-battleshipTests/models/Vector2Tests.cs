using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dam_battleship.models.Tests;

[TestClass]
public class Vector2Tests
{
    [TestMethod]
    public void Vector2Test()
    {
        Coordinate coordinate = new(1, 2);

        Assert.AreEqual(1, coordinate.X);
        Assert.AreEqual(2, coordinate.Y);
    }

    [TestMethod]
    public void RandomTest()
    {
        Coordinate coordinate = Coordinate.Random();

        Assert.IsTrue(coordinate.X >= 0 && coordinate.X < 100);
    }

    [TestMethod]
    public void EqualsTest()
    {
        Coordinate coordinateOne = new(1, 2);
        Coordinate coordinateTwo = new(1, 2);

        Assert.IsTrue(coordinateOne.Equals(coordinateTwo));
        Assert.IsTrue(coordinateOne.Equals(coordinateOne));
        Assert.IsFalse(new Coordinate(12, 12).Equals(coordinateTwo));
    }

    [TestMethod]
    public void GetHashCodeTest()
    {
        Coordinate coordinateOne = new(1, 2);
        Coordinate coordinateTwo = new(1, 2);

        Assert.AreEqual(coordinateOne.GetHashCode(), coordinateTwo.GetHashCode());
        Assert.AreEqual(coordinateOne.GetHashCode(), coordinateOne.GetHashCode());
        Assert.AreNotEqual(new Coordinate(12, 12), coordinateTwo);
    }

    [TestMethod]
    public void ToStringTest()
    {
        Coordinate coordinate = new(1, 2);

        Assert.AreEqual("(1, 2)", coordinate.ToString());
    }
}