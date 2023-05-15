using dam_battleship.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dam_battleshipTests.joamba.model
{
    [TestClass]
    public class CoordinateTestP1
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

        /* if 2 Coordinates are equals, their hash must be the same,
         * if the coordinares are distinct, their hash could be the same or not
         */
        [TestMethod]
        public void Coordinate_TestHashCode()
        {
            Coordinate c1 = lcoor[2];
            Coordinate c2 = new(c1);


            Assert.AreEqual(c1, c2);
            Assert.AreEqual(c1.GetHashCode(), c2.GetHashCode());
        }

        /* check if the constructor works well, analyzing if the components '0' and
         * '1' of each Coordinate created in the SetUp() method are the correct ones 
         */
        [TestMethod]
        public void Coordinate_TestCoordinateConstructor()
        {
            int j = 0;
            for (int i = 0; i < DIM - 1; i++)
            {
                Assert.AreEqual(vcoor[i], lcoor[j].Get(0), "x");
                Assert.AreEqual(vcoor[i + 1], lcoor[j].Get(1), "y");
                j++;
            }
        }

        /* check if the copy constructor creates a new Coordinate with the
         * same values as the respective components of the copied Coordinate.
         * we do it with each Coordinate created in SetUp() method 
         */
        [TestMethod]
        public void Coordinate_TestCoordinateConstructorCopy()
        {
            Coordinate ccopy;
            foreach (Coordinate c in lcoor)
            {
                ccopy = new Coordinate(c);
                Assert.AreEqual(c.Get(0), ccopy.Get(0));
                Assert.AreEqual(c.Get(1), ccopy.Get(1));
            }
        }

        /* check that the Get(int) method for each component of a Coordinate
         * works correctly. The values of the components of the previous
         * Coordinate are modified with the method Set(int, int) and it is
         * verified with Get(int) that the values of its components have 
         * changed to those values. 
         */
        [TestMethod]
        public void Coordinate_TestGetSet()
        {
            Coordinate c = lcoor[2];
            Assert.AreEqual(-70, c.Get(0), "x==-70");
            Assert.AreEqual(-2, c.Get(1), "y==-2");

            // modify method Set to public and uncomment this assertion
            c.Set(1, -11);
            c.Set(0, 33);
            Assert.AreEqual(33, c.Get(0), "x==33");
            Assert.AreEqual(-11, c.Get(1), "y==-11");
        }

        /* The Coordinates created in the setUp() are added and it is 
         * verified, as they are added, that the values of their 
         * components are taking the correct values and that the 
         * Coordinate returned is not the same as the Coordinate 
         * that invokes the method.
         */
        [TestMethod]
        public void Coordinate_TestAdd()
        {
            Coordinate c1 = lcoor[0];
            Coordinate c2;

            int sumx = c1.Get(0);
            int sumy = c1.Get(1);

            for (int i = 0; i < DIM - 2; i++)
            {
                c2 = c1;
                c1 = c1.Add(lcoor[i + 1]);
                sumx += vcoor[i + 1];
                sumy += vcoor[i + 2];

                Assert.AreEqual(sumx, c1.Get(0));
                Assert.AreEqual(sumy, c1.Get(1));
                Assert.AreNotSame(c1, c2);
            }
        }

        /* The Coordinates created in the setUp() are substracted and 
         * it is verified, as they are substracted, that the values of their 
         * components are taking the correct values and that the 
         * Coordinate returned is not the same as the Coordinate 
         * that invokes the method.
         */
        [TestMethod]
        public void Coordinate_TestSubstract()
        {
            Coordinate c1 = lcoor[0];
            Coordinate c2;

            int subx = c1.Get(0);
            int suby = c1.Get(1);

            for (int i = 0; i < DIM - 2; i++)
            {
                c2 = c1;
                c1 = c1.Substract(lcoor[i + 1]);
                subx -= vcoor[i + 1];
                suby -= vcoor[i + 2];

                Assert.AreEqual(subx, c1.Get(0));
                Assert.AreEqual(suby, c1.Get(1));
                Assert.AreNotSame(c1, c2);
            }
        }

        /* It is checked, for the toString() method, that the Coordinate 
         * created in the setUp() have the correct format.
         */
        [TestMethod]
        public void Coordinate_TestToString()
        {
            Assert.AreEqual("(0,0)", RemoveSpaces(lcoor[0].ToString()));
            Assert.AreEqual("(0,-70)", RemoveSpaces(lcoor[1].ToString()));
            Assert.AreEqual("(-70,-2)", RemoveSpaces(lcoor[2].ToString()));
            Assert.AreEqual("(-2,20)", RemoveSpaces(lcoor[3].ToString()));
        }

        /* we take a Coordinate and check all possible conditions under which 
         * our Equals() method returns true or false
         */
        [TestMethod]
        public void Coordinate_TestEqualsObject()
        {
            object obj = new string("(0, 0)");
            Coordinate c = lcoor[0];
            Assert.IsFalse(c.Equals(null));
            Assert.IsFalse(c.Equals(obj));
            Assert.IsFalse(c.Equals(lcoor[1]));
            Assert.IsFalse(c.Equals(new Coordinate(24, 0)));
            Assert.IsTrue(c.Equals(c));

            Coordinate d = new Coordinate(0, 0);
            Assert.IsTrue(c.Equals(d));
        }

        /* Auxiliar method */
        private string RemoveSpaces(string? str)
        {
            string[] exp = str.Split(" ");
            string nstr = new string("");

            foreach (string s in exp)
            {
                if (!s.Equals(" ")) nstr += s;
            }

            return nstr;
        }

        /* Test implemented in the classroom as an example */
        [TestMethod]
        public void Coordinate_TestConstructorWithTwoValidParams()
        {
            Coordinate c = new(2, 1);

            Assert.AreEqual("(2, 1)", c.ToString());
        }
    }
}