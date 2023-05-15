using dam_battleship.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dam_battleshipTests.joamba.model
{
    [TestClass]
    public class ShipTest
    {
        readonly static int BOUNDING_SQUARE_SIZE = 5;
        static List<Coordinate> north, east, south, west;
        static string sNorth, sEast, sSouth, sWest;
        Ship bergantin, goleta, fragata, galeon;

        readonly int[][] shape = new int[][]
        {
            new int[] {
                        0, 0, 0, 0, 0,          // NORTH    .....
                        0, 0, 1, 0, 0,          //          ..#..
                        0, 0, 1, 0, 0,          //          ..#..
                        0, 0, 1, 0, 0,          //          ..#..
                        0, 0, 0, 0, 0           //          .....
                      },

            new int[] {
                        0, 0, 0, 0, 0,          // EAST     .....
                        0, 0, 0, 0, 0,          //          .....
                        0, 1, 1, 1, 0,          //          .###.
                        0, 0, 0, 0, 0,          //          .....
                        0, 0, 0, 0, 0           //          .....
                      },

            new int[] {
                        0, 0, 0, 0, 0,          // SOUTH    .....
                        0, 0, 1, 0, 0,          //          ..#..
                        0, 0, 1, 0, 0,          //          ..#..
                        0, 0, 1, 0, 0,          //          ..#..
                        0, 0, 0, 0, 0           //          .....
                      },

            new int[] {
                        0, 0, 0, 0, 0,          // WEST     .....
                        0, 0, 0, 0, 0,          //          .....
                        0, 1, 1, 1, 0,          //          .###.
                        0, 0, 0, 0, 0,          //          .....
                        0, 0, 0, 0, 0           //          .....
                      }
        };

        [TestInitialize]
        public void SetUp()
        {
            string rn = "\r\n";

            north = new List<Coordinate>();
            east = new List<Coordinate>();
            south = new List<Coordinate>();
            west = new List<Coordinate>();

            for (int i = 1; i < 4; i++)
            {
                north.Add(new Coordinate(2, i));
                east.Add(new Coordinate(i, 2));
                south.Add(new Coordinate(2, i));
                west.Add(new Coordinate(i, 2));
            }

            sNorth = $"Goleta (NORTH){rn} -----{rn}|     |{rn}|  G  |{rn}|  G  |{rn}|  G  |{rn}|     |{rn} -----";
            sSouth = $"Galeón (SOUTH){rn} -----{rn}|     |{rn}|  A  |{rn}|  A  |{rn}|  A  |{rn}|     |{rn} -----";
            sEast = $"Bergantín (EAST){rn} -----{rn}|     |{rn}|     |{rn}| BBB |{rn}|     |{rn}|     |{rn} -----";
            sWest = $"Fragata (WEST){rn} -----{rn}|     |{rn}|     |{rn}| FFF |{rn}|     |{rn}|     |{rn} -----";

            bergantin = new Ship(Orientation.EAST, 'B', "Bergantín");
            goleta = new Ship(Orientation.NORTH, 'G', "Goleta");
            fragata = new Ship(Orientation.WEST, 'F', "Fragata");
            galeon = new Ship(Orientation.SOUTH, 'A', "Galeón");
        }

        /* The composition between Ship and Coordinate is checked. To do this, 
         * we create a Coordinate object, we position a Ship to that Coordinate. 
         * We check that this Coordinate and the position of the Ship are the same. 
         * We modify the Coordinate and check that it and the position of the Ship 
         * are no longer equal
         */
        [TestMethod]
        public void Ship_TestSetPosition()
        {
            Coordinate pos = new Coordinate(7, 4);

            // check the composition between Ship and Coordinate
            bergantin.SetPosition(pos);
            Assert.AreEqual(pos, bergantin.GetPosition());

            pos.Set(0, -2);
            pos.Set(1, -24);
            Assert.AreNotEqual(pos, bergantin.GetPosition());

            // change position and check again
            pos = new Coordinate(-17, -2);
            bergantin.SetPosition(pos);
            Assert.AreEqual(pos, bergantin.GetPosition());

            pos.Set(0, 12);
            pos.Set(1, 34);
            Assert.AreNotEqual(pos, bergantin.GetPosition());
        }

        /* We check that the initial position of a Ship is null. We check that 
         * GetPosition makes a defensive copy: To do so, the Ship is positioned 
         * in a specific Coordinate. We check that the position of the Ship and 
         * the Coordinate are the same, but they do not have the same reference
         */
        [TestMethod]
        public void Ship_TestGetPosition()
        {
            Coordinate pos = bergantin.GetPosition();
            // at first, ship's position must be null
            Assert.IsNull(pos);

            // check that GetPosition make a defensive copy
            Coordinate pos1 = new Coordinate(7, 4);
            bergantin.SetPosition(pos1);
            Coordinate pos2 = bergantin.GetPosition();
            Assert.AreNotSame(pos1, pos2);
            Assert.AreEqual(pos1, pos2);
        }

        /* test GetName() */
        [TestMethod]
        public void Ship_TestGetName()
        {
            Assert.AreEqual("Bergantín", bergantin.GetName());
            Assert.AreEqual("Fragata", fragata.GetName());
        }

        /* test GetOrientation() */
        [TestMethod]
        public void Ship_TestGetOrientation()
        {
            Assert.AreEqual(Orientation.NORTH, goleta.GetOrientation());
            Assert.AreEqual(Orientation.EAST, bergantin.GetOrientation());
            Assert.AreEqual(Orientation.SOUTH, galeon.GetOrientation());
            Assert.AreEqual(Orientation.WEST, fragata.GetOrientation());
        }

        /* test GetSymbol() */
        [TestMethod]
        public void Ship_TestGetSymbol()
        {
            Assert.AreEqual('B', bergantin.GetSymbol());
            Assert.AreEqual('G', goleta.GetSymbol());
            Assert.AreEqual('A', galeon.GetSymbol());
            Assert.AreEqual('F', fragata.GetSymbol());
        }

        /* check if the ship shape's matrix is correct */
        [TestMethod]
        public void Ship_TestGetShape()
        {
            int[][] shapeAux = goleta.GetShape();

            for (int i = 0; i < shape.Length; i++)
                for (int j = 0; j < shape[i].Length; j++)
                    Assert.AreEqual(shape[i][j], shapeAux[i][j]);
        }

        /* It is checked, for all relative coordinates, that GetShapeIndex(Coordinate):
         *    1- Returns a value between 0 and 24 (both inclusive).
         *    2- The corresponding value of x inside shape[][] for the different 
         *    orientations is correct
         */
        [TestMethod]
        public void Ship_TestGetShapeIndex()
        {
            Coordinate c;
            int x;

            for (int i = 0; i < BOUNDING_SQUARE_SIZE; i++)
                for (int j = 0; j < BOUNDING_SQUARE_SIZE; j++)
                {
                    c = new Coordinate(i, j);
                    x = goleta.GetShapeIndex(c);
                    Assert.IsTrue((0 <= x) && (x <= 24), $"0<={x}<=24");
                    if ((x == 7) || (x == 12) || (x == 17))
                    {
                        Assert.IsTrue(goleta.GetShape()[(int)Orientation.NORTH][x] == 1, $"shape[NORTH][{x}]==1");
                        Assert.IsTrue(goleta.GetShape()[(int)Orientation.SOUTH][x] == 1, $"shape[SOUTH][{x}]==1");
                    }
                    else
                    {
                        Assert.IsTrue(goleta.GetShape()[(int)Orientation.NORTH][x] == 0, $"shape[NORTH][{x}]==0");
                        Assert.IsTrue(goleta.GetShape()[(int)Orientation.SOUTH][x] == 0, $"shape[SOUTH][{x}]==0");
                    }
                    if ((x > 10) && (x < 14))
                    {
                        Assert.IsTrue(goleta.GetShape()[(int)Orientation.EAST][x] == 1, $"shape[EAST][{x}]==1");
                        Assert.IsTrue(goleta.GetShape()[(int)Orientation.WEST][x] == 1, $"shape[WEST][{x}]==1");
                    }
                    else
                    {
                        Assert.IsTrue(goleta.GetShape()[(int)Orientation.EAST][x] == 0, $"shape[EAST][{x}]==0");
                        Assert.IsTrue(goleta.GetShape()[(int)Orientation.WEST][x] == 0, $"shape[WEST][{x}]==0");
                    }
                }
        }

        /* The absolute positions for the NORTH orientation from a Coordinate are 
         * checked to ensure that they are correct.
         */
        [TestMethod]
        public void Ship_TestGetAbsolutePositionsNorth()
        {
            Coordinate c1 = new Coordinate(13, 27);
            HashSet<Coordinate> positions = goleta.GetAbsolutePositions(c1);

            foreach (Coordinate c in north)
                Assert.IsTrue(positions.Contains(c.Add(c1)), $"Absolute Value for positions North {c} + {c1}");
        }

        /* The absolute positions for the EAST orientation from a Coordinate are 
         * checked to ensure that they are correct.
         */
        [TestMethod]
        public void Ship_TestGetAbsolutePositionsEast()
        {
            Coordinate c1 = new Coordinate(0, 0);
            HashSet<Coordinate> positions = bergantin.GetAbsolutePositions(c1);

            foreach (Coordinate c in east)
                Assert.IsTrue(positions.Contains(c.Add(c1)), $"Absolute Value for positions East {c} + {c1}");
        }

        /* The absolute positions for the SOUTH orientation from a Coordinate are 
         * checked to ensure that they are correct.
         */
        [TestMethod]
        public void Ship_TestGetAbsolutePositionsSouth()
        {
            Coordinate c1 = new Coordinate(300, 700);
            HashSet<Coordinate> positions = galeon.GetAbsolutePositions(c1);

            foreach (Coordinate c in south)
                Assert.IsTrue(positions.Contains(c.Add(c1)), $"Absolute Value for positions South {c} + {c1}");
        }

        /* The absolute positions for the WEST orientation from a Coordinate are 
         * checked to ensure that they are correct.
         */
        [TestMethod]
        public void Ship_TestGetAbsolutePositionsWest()
        {
            Coordinate c1 = new Coordinate(-11, -11);
            HashSet<Coordinate> positions = fragata.GetAbsolutePositions(c1);

            foreach (Coordinate c in west)
                Assert.IsTrue(positions.Contains(c.Add(c1)), $"Absolute Value for positions West {c} + {c1}");
        }

        /* Several Ships are positioned in a Coordinate 
         * Check that their absolute positions are correct
         */
        [TestMethod]
        public void Ship_TestGetAbsolutePositionsShips()
        {
            Coordinate c1 = new Coordinate(119, -123);

            GetAbsolutePositionsShip(c1, goleta, north);
            GetAbsolutePositionsShip(c1, galeon, south);
            GetAbsolutePositionsShip(c1, fragata, west);
            GetAbsolutePositionsShip(c1, bergantin, east);
        }

        /* Auxiliar method */
        private void GetAbsolutePositionsShip(Coordinate cpos, Ship ship, List<Coordinate> orient)
        {
            ship.SetPosition(cpos);
            HashSet<Coordinate> pos = ship.GetAbsolutePositions();

            foreach (Coordinate c in orient)
            {
                Assert.IsTrue(pos.Contains(c.Add(cpos)), $"Absolute Value for positions {cpos} + {c}");
            }
        }

        /* shots are fired at a Ship that has not yet been 
         * positioned. Hit is checked and returns false
         */
        [TestMethod]
        public void Ship_TestHitShipPositionNull()
        {
            Coordinate c = new Coordinate(2, 1);

            Assert.IsFalse(goleta.Hit(c));
        }

        /* a Ship is positioned in a Coordinate and shots are fired 
         * into the water. Check that Hit always returns false
         */
        [TestMethod]
        public void Ship_TestHitWater()
        {
            Coordinate c = new Coordinate(2, 1);

            goleta.SetPosition(c);
            Assert.IsFalse(goleta.Hit(c));

            for (int i = 3; i < 7; i++)
                for (int j = 1; j < 6; j++)
                    if ((i == 4) && ((j < 2) || (j > 4)))
                        Assert.IsFalse(goleta.Hit(new Coordinate(i, j)));
        }

        /* A Ship is positioned in a Coordinate, and first shots are fired 
         * at the Ship's positions and hit returns true. You return to shot 
         * to the same positions and check that hit now returns false
         */
        [TestMethod]
        public void Ship_TestHitShip()
        {
            Coordinate c = new Coordinate(2, 1);

            goleta.SetPosition(c);

            for (int j = 2; j < 5; j++)
            {
                Assert.IsTrue(goleta.Hit(new Coordinate(4, j)));
                Assert.IsFalse(goleta.Hit(new Coordinate(4, j)));
            }
        }

        /* It is checked that:
         * 1. IsShotDown() to an unpositioned Ship returns false
         * 2. IsShotDown() returns false after positioning a Ship in a Coordinate
         */
        [TestMethod]
        public void Ship_TestIsShotDown1()
        {
            Coordinate c = new Coordinate(2, 1);

            Assert.IsFalse(bergantin.IsShotDown());
            bergantin.SetPosition(c);
            Assert.IsFalse(bergantin.IsShotDown());
        }

        /* It is checked that:
         * 1. IsShotDown() returns false after shooting all Ship positions except one
         * 2. IsShotDown() returns true after shooting at the only undamaged position
         */
        [TestMethod]
        public void Ship_TestIsShotDown2()
        {
            Coordinate c = new Coordinate(2, 1);

            bergantin.SetPosition(c);

            for (int j = 3; j < 6; j++)
            {
                bergantin.Hit(new Coordinate(j, 3));
                if (j != 5)
                    Assert.IsFalse(bergantin.IsShotDown());
                else
                    Assert.IsTrue(bergantin.IsShotDown());
            }
        }

        /* It is checked that:
         * 1. IsHit on a Ship not positioned returns false
         * 2. IsHit on a Coordinate in a position outside a Ship 
         * already positioned, returns false
         */
        [TestMethod]
        public void Ship_TestIsHit1()
        {
            Coordinate c = new Coordinate(2, 1);

            // Ship not positioned
            Assert.IsFalse(bergantin.IsHit(c));
            bergantin.SetPosition(c);
            // Ship positioned. Coordinate c in water
            Assert.IsFalse(bergantin.IsHit(c));
        }

        /* It is verified that:	
         * 1. IsHit on the Coordinates of a Ship returns false
         * 2. IsHit on the Coordinates of a Ship returns true after a hit
         */
        [TestMethod]
        public void Ship_TestIsHit2()
        {
            Coordinate c = new Coordinate(2, 1);

            bergantin.SetPosition(c);

            // we ask on ship before shooting and after shooting
            for (int j = 3; j < 6; j++)
            {
                c = new Coordinate(j, 3);
                Assert.IsFalse(bergantin.IsHit(c));
                bergantin.Hit(c);
                Assert.IsTrue(bergantin.IsHit(c));
            }
        }

        /* It is verified that the outputs of the various Ships 
         * in different orientations are correct
         */
        [TestMethod]
        public void Ship_TestToString()
        {
            Assert.AreEqual(sNorth, goleta.ToString());
            Assert.AreEqual(sSouth, galeon.ToString());
            Assert.AreEqual(sEast, bergantin.ToString());
            Assert.AreEqual(sWest, fragata.ToString());
        }

    }
}
