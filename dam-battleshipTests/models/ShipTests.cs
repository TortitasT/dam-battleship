using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dam_battleship.models.Tests;

[TestClass]
public class ShipTests
{
    private readonly int[,] _matrix =
    {
        { 1, 1, 1, 1, 1 },
        { 0, 1, 0, 1, 0 }
    };

    private readonly Ship _ship = new Ship("Yamato", new int[,] { });

    [TestInitialize]
    public void TestInitialize()
    {
        _ship.Matrix = _matrix;
    }

    [TestMethod]
    public void ShipTest()
    {
        Assert.AreEqual("Yamato", _ship.Name);
    }

    [TestMethod]
    public void ToStringTest()
    {
        Assert.AreEqual("Yamato at (0, 0)", _ship.ToString());
    }

    [TestMethod]
    public void GetPositionsTest()
    {
        var positions = _ship.GetPositions().ToList();

        Assert.AreEqual(7, positions.Count);

        foreach (Coordinate position in positions) Assert.IsTrue(_matrix[position.Y, position.X] == 1);
    }
}