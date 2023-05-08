using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dam_battleship.models.Tests;

[TestClass]
public class Vector2Tests
{
    [TestMethod]
    public void Vector2Test()
    {
        Vector2 vector2 = new Vector2(1, 2);

        Assert.AreEqual(1, vector2.X);
        Assert.AreEqual(2, vector2.Y);
    }

    [TestMethod]
    public void RandomTest()
    {
        Vector2 vector2 = Vector2.Random();

        Assert.IsTrue(vector2.X >= 0 && vector2.X < 100);
    }

    [TestMethod]
    public void EqualsTest()
    {
        Vector2 vector2One = new Vector2(1, 2);
        Vector2 vector2Two = new Vector2(1, 2);

        Assert.IsFalse(vector2One.Equals(vector2Two));
        Assert.IsTrue(vector2One.Equals(vector2One));
    }

    [TestMethod]
    public void GetHashCodeTest()
    {
        Vector2 vector2One = new Vector2(1, 2);
        Vector2 vector2Two = new Vector2(1, 2);

        Assert.AreNotEqual(vector2One.GetHashCode(), vector2Two.GetHashCode());
        Assert.AreEqual(vector2One.GetHashCode(), vector2One.GetHashCode());
    }

    [TestMethod]
    public void ToStringTest()
    {
        Vector2 vector2 = new Vector2(1, 2);

        Assert.AreEqual("Vector2(1, 2)", vector2.ToString());
    }
}