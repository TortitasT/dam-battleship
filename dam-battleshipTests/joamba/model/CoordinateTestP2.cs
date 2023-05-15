using dam_battleship.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dam_battleshipTests.joamba.model
{
    [TestClass]
    public class CoordinateTestP2
    {
        static readonly int[] vcoor = { 0, 0, -70, -2, 20 };
        readonly int DIM = vcoor.Length;
        List<Coordinate> lcoor;

        /* initializing mock lists and arrays for checking test results */
        [TestInitialize]
        public void SetUp()
        {
            lcoor = new List<Coordinate>();
            // creating coordinates (0,0), (0,-70), (-70,-2), (-2,20)
            for (int i = 0; i < DIM - 1; i++)
            {
                lcoor.Add(new Coordinate(vcoor[i], vcoor[i + 1]));
            }
        }

        /* create copies of the coordinates created in SetUp() and verifying that:
         * 1. original and copy are not the same
         * 2. copy has the same values in the respective components as the copied object
         */
        [TestMethod]
        public void Coordinate_TestCopy()
        {
            Coordinate ccopy;

            foreach (Coordinate c in lcoor)
            {
                ccopy = c.Copy();
                Assert.AreNotSame(ccopy, c);
                Assert.AreEqual(c.Get(0), ccopy.Get(0));
                Assert.AreEqual(c.Get(1), ccopy.Get(1));
            }
        }

        /* A Coordinate is created and from it the adjacent Coordinates are obtained 
         * and stored in a HashSet<Coordinate>. For each of the positions adjacent to 
         * the initial Coordinate a Coordinate is created, and it is checked whether 
         * they are contained in the HashSet<Coordinate>.
         */
        [TestMethod]
        public void Coordinate_TestAdjacentCoordinates()
        {
            Coordinate c = new(-3, 5);
            HashSet<Coordinate> setcoord = c.AdjacentCoordinates();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0)
                        Assert.IsFalse(setcoord.Contains(new Coordinate(c.Get(0) + i, c.Get(1) + j)));
                    else
                        Assert.IsTrue(setcoord.Contains(new Coordinate(c.Get(0) + i, c.Get(1) + j)));
                }
            }
        }
    }

}
