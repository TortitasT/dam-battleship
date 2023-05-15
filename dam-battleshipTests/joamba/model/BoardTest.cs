using dam_battleship.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace dam_battleshipTests.joamba.model
{
    [TestClass]
    public class BoardTest
    {
        static readonly int MAX_BOARD_SIZE = 20;
        static readonly int MIN_BOARD_SIZE = 5;
        static readonly int DIM = 10;
        Board board;
        Ship fragata, galeon, bergantin, goleta;
        static string sboardEmpty, sboard, sboardHide1, sboardHide2,
            sboardHits1, sboardHits2, sboardHits3;

        [TestInitialize]
        public void SetUp()
        {
            string rn = "\r\n";

            sboardHide1 = $"?????{rn}?????{rn}?????{rn}?????{rn}?????";

            sboardHide2 = $"A ??•{rn}" +
                          $"A ?? {rn}" +
                          $"A  ??{rn}" +
                          $"   ?•{rn}" +
                          $"?•??•";

            sboardEmpty = $"     {rn}     {rn}     {rn}     {rn}     ";

            sboard = $"A FFF{rn}" +
                     $"A    {rn}" +
                     $"A   G{rn}" +
                     $"    G{rn}" +
                     $"BBB G";

            sboardHits1 = $"• FFF{rn}" +
                          $"•    {rn}" +
                          $"•   G{rn}" +
                          $"    G{rn}" +
                          $"BBB G";

            sboardHits2 = $"• FF•{rn}" +
                          $"•    {rn}" +
                          $"•   G{rn}" +
                          $"    •{rn}" +
                          $"BBB •";

            sboardHits3 = $"• FF•{rn}" +
                          $"•    {rn}" +
                          $"•   G{rn}" +
                          $"    •{rn}" +
                          $"B•B •";

            fragata = new Ship(Orientation.WEST, 'F', "Barbanegra");
            galeon = new Ship(Orientation.SOUTH, 'A', "Francis Drake");
            bergantin = new Ship(Orientation.EAST, 'B', "Benito Soto");
            goleta = new Ship(Orientation.NORTH, 'G', "Hook");
            board = new Board(DIM);
        }

        /* The size limits in the constructor are checked */
        [TestMethod]
        public void Board_TestGetSize()
        {
            Board board = new(MIN_BOARD_SIZE - 1);
            Assert.AreEqual(MIN_BOARD_SIZE, board.GetSize());

            board = new Board(MAX_BOARD_SIZE + 1);
            Assert.AreEqual(MIN_BOARD_SIZE, board.GetSize());

            board = new Board(MIN_BOARD_SIZE + 1);
            Assert.AreEqual(MIN_BOARD_SIZE + 1, board.GetSize());

            board = new Board(MAX_BOARD_SIZE - 1);
            Assert.AreEqual(MAX_BOARD_SIZE - 1, board.GetSize());
        }

        /* CheckCoordidnate is checked in limits of board size */
        [TestMethod]
        public void Board_TestCheckCoordinate()
        {
            int SIZE = 15;
            Board board = new(SIZE);

            Assert.IsFalse(board.CheckCoordinate(new Coordinate(0, SIZE)));
            Assert.IsFalse(board.CheckCoordinate(new Coordinate(-1, SIZE - 1)));
            Assert.IsFalse(board.CheckCoordinate(new Coordinate(-1, SIZE)));
            Assert.IsFalse(board.CheckCoordinate(new Coordinate(SIZE, 0)));
            Assert.IsFalse(board.CheckCoordinate(new Coordinate(SIZE - 1, -1)));
            Assert.IsFalse(board.CheckCoordinate(new Coordinate(SIZE, -1)));
            Assert.IsTrue(board.CheckCoordinate(new Coordinate(0, SIZE - 1)));
            Assert.IsTrue(board.CheckCoordinate(new Coordinate(SIZE - 1, 0)));
        }

        /* positioning is correct among ships. It is checked that
         * ships are positioned in the board
         */
        [TestMethod]
        public void Board_TestAddShipsOk()
        {
            Assert.IsTrue(board.AddShip(galeon, new Coordinate(0, 1)));
            for (int i = 2; i < 5; i++)
                Assert.IsNotNull(board.GetShip(new Coordinate(2, i)), $"x,y = 2,{i}");

            Assert.IsTrue(board.AddShip(fragata, new Coordinate(5, 1)));
            for (int i = 6; i < 9; i++)
                Assert.IsNotNull(board.GetShip(new Coordinate(i, 3)), $"x,y = {i},3");

            Assert.IsTrue(board.AddShip(goleta, new Coordinate(0, 5)));
            for (int i = 6; i < 9; i++)
                Assert.IsNotNull(board.GetShip(new Coordinate(2, i)), $"x,y = 2,{i}");

            Assert.IsTrue(board.AddShip(bergantin, new Coordinate(4, 3)));
            for (int i = 5; i < 8; i++)
                Assert.IsNotNull(board.GetShip(new Coordinate(i, 5)), $"x,y = {i},5");
        }

        /* positioning is correct of ships at limits of board. It is checked
         * ships are positioned in the board
         */
        [TestMethod]
        public void Board_TestAddShipsOkLimits()
        {
            Assert.IsTrue(board.AddShip(galeon, new Coordinate(-2, -1)));
            for (int i = 0; i < 3; i++)
                Assert.IsNotNull(board.GetShip(new Coordinate(0, i)), $"x,y = 0,{i}");

            Assert.IsTrue(board.AddShip(fragata, new Coordinate(-1, 7)));
            for (int i = 0; i < 3; i++)
                Assert.IsNotNull(board.GetShip(new Coordinate(i, 9)), $"x,y = {i},9");

            Assert.IsTrue(board.AddShip(goleta, new Coordinate(7, 6)));
            for (int i = 7; i < 10; i++)
                Assert.IsNotNull(board.GetShip(new Coordinate(9, i)), $"x,y = 9,{i}");

            Assert.IsTrue(board.AddShip(bergantin, new Coordinate(6, -2)));
            for (int i = 7; i < 10; i++)
                Assert.IsNotNull(board.GetShip(new Coordinate(i, 0)), $"x,y = {i},0");
        }

        /* positioning out of board. It is also checked that ship is not added */
        [TestMethod]
        public void Board_TestAddShipsOutOfBoard()
        {
            Assert.IsFalse(board.AddShip(galeon, new Coordinate(0, 7)));
            for (int i = 8; i < 11; i++)
                Assert.IsNull(board.GetShip(new Coordinate(2, i)), $"x,y = 2,{i}");

            Assert.IsFalse(board.AddShip(fragata, new Coordinate(7, 3)));
            for (int i = 8; i < 11; i++)
                Assert.IsNull(board.GetShip(new Coordinate(i, 5)), $"x,y = {i},5");

            Assert.IsFalse(board.AddShip(goleta, new Coordinate(-2, -2)));
            for (int i = -1; i < 2; i++)
                Assert.IsNull(board.GetShip(new Coordinate(0, i)), $"x,y = 0,{i}");

            Assert.IsFalse(board.AddShip(bergantin, new Coordinate(-2, 7)));
            for (int i = 8; i < 11; i++)
                Assert.IsNull(board.GetShip(new Coordinate(i, 0)), $"x,y = {i},0");
        }

        /* ship positioning not correct for proximity with other ship.
         * It is also checked that ship is not added
         */
        [TestMethod]
        public void Board_TestAddShipNextOther()
        {
            Assert.IsTrue(board.AddShip(galeon, new Coordinate(0, 1)));
            Assert.IsFalse(board.AddShip(fragata, new Coordinate(2, 0)));
            for (int i = 3; i < 6; i++)
                Assert.IsNull(board.GetShip(new Coordinate(i, 2)), $"x,y = {i},2");
        }

        /* ship positioning not correct for overlapping proximity with other ship.
         * It is also checked that ship is not added
         */
        [TestMethod]
        public void Board_TestAddShipOccupied()
        {
            Assert.IsTrue(board.AddShip(galeon, new Coordinate(0, 1)));
            Assert.IsFalse(board.AddShip(fragata, new Coordinate(1, 0)));
            for (int i = 3; i < 5; i++)
                Assert.IsNull(board.GetShip(new Coordinate(i, 2)), $"x,y = {i},2");
        }

        /* a ship is positioned in a coordinate
         * 1. checking GetShip in a coordinate that there is no ship
         * 2. checking GetShip i all positions occupied by ship
         */
        [TestMethod]
        public void Board_TestGetShip()
        {
            Assert.IsTrue(board.AddShip(fragata, new Coordinate(3, 1)));

            Coordinate c = new(2, 3);
            Assert.IsNull(board.GetShip(c));
            for (int i = 4; i < 7; i++)
            {
                c.Set(0, i);
                Assert.IsNotNull(board.GetShip(c));
            }
        }

        /* a ship is positionated in a coordinate and it is checked
         * the aggregation between Board and Ship
         */
        [TestMethod]
        public void Board_TestAggregationBoardShip()
        {
            board.AddShip(fragata, new Coordinate(3, 1));
            Coordinate c = new(0, 3);
            for (int i = 4; i < 7; i++)
            {
                c.Set(0, i);
                Assert.AreSame(fragata, board.GetShip(c));
            }
        }

        /* checking IsSeen before and after shooting to water in
         * a board without ships
         */
        [TestMethod]
        public void Board_TestIsSeen1()
        {
            for (int i = 0; i < board.GetSize(); i++)
                for (int j = 0; j < board.GetSize(); j++)
                {
                    Assert.IsFalse(board.IsSeen(new Coordinate(i, j)));
                    board.Hit(new Coordinate(i, j));
                    Assert.IsTrue(board.IsSeen(new Coordinate(i, j)));
                }
        }

        /* a ship is positioned in a board and checks IsSeen before and after shooting to the ship
         * when ship is shootdown, check that the neighbors coordinates
         * are marked as seen
         */
        [TestMethod]
        public void Board_TestIsSeen2()
        {
            board.AddShip(galeon, new Coordinate(0, 1));
            for (int i = 2; i < 5; i++)
            {
                Assert.IsFalse(board.IsSeen(new Coordinate(2, i)), $"x,y = 2,{i}");
                board.Hit(new Coordinate(2, i));
                Assert.IsTrue(board.IsSeen(new Coordinate(2, i)), $"x,y = 2,{i}");
            }

            for (int i = 1; i < 4; i++)
                for (int j = 1; j < 6; j++)
                    Assert.IsTrue(board.IsSeen(new Coordinate(i, j)), $"x,y = {i},{j}");
        }

        /* a ship is positioned in a board, then it is shooted to the each ships' part
         * coordinates are saved in a List. We obtain by reflection the private attribute
         * 'seen'. Check that coordinates stored in the List have the same addresses than 
         * the corresponding 'seen'. The composition between Board and Coordinate is checked
         */
        [TestMethod]
        public void Board_TestCompositionBoardCoordinate()
        {
            board.AddShip(galeon, new Coordinate(0, 1));
            List<Coordinate> listHits = new(); // for shoots
            Coordinate c;

            // shooting the ship
            for (int i = 2; i < 5; i++)
            {
                c = new Coordinate(2, i);
                listHits.Add(c);
                board.Hit(c);
            }

            HashSet<Coordinate> boardSet = GetBoardField(board, "seen");
            int j;
            foreach (Coordinate caux in boardSet)
            {
                j = listHits.IndexOf(caux);
                if (j != -1)
                    Assert.AreSame(caux, listHits[j], "Composition");
            }
        }

        /* auxiliar method */
        private HashSet<Coordinate> GetBoardField(Board board, string attribute)
        {
            Type typeb = typeof(Board);
            FieldInfo field = typeb.GetField(attribute, BindingFlags.NonPublic | BindingFlags.Instance);

            HashSet<Coordinate> boardset = field.GetValue(board) as HashSet<Coordinate>;

            return boardset;
        }

        /* a Ship is placed on the Board in a Coordinate. Check that:
         * 1. when firing (hit) on the positions around the Ship the result is WATER.
         * 2. when firing (hit) on the positions of the Ship, except the last one, the result is HIT.
         * 3. when firing (hit) on the last position of the Ship, the result is DESTROYED
         */
        [TestMethod]
        public void Board_TestHit()
        {
            board.AddShip(galeon, new Coordinate(5, 5));
            for (int i = 5; i < board.GetSize(); i++)
                for (int j = 5; j < board.GetSize(); j++)
                    if (i != 7 || j < 6 || j > 8)
                        Assert.AreEqual(CellStatus.WATER, board.Hit(new Coordinate(i, j)), $"x,y = {i},{j}");
                    else if (i == 7 && j == 8)
                        Assert.AreEqual(CellStatus.DESTROYED, board.Hit(new Coordinate(i, j)), $"x,y = {i},{j}");
                    else
                        Assert.AreEqual(CellStatus.HIT, board.Hit(new Coordinate(i, j)), $"x,y = {i},{j}");
        }

        /* It is checked that:
         * 1. on a Board without Ships, areAllCraftsDestroyed returns true.
         * 2. when positioning two Ships on the Board, after each positioning, areAllCraftsDestroyed 
         *    returns false.
         * 3. after each shot on the first Ship, AreAllCraftsDestroyed returns false.
         * 4. after each shot on the second Ship, AreAllCraftsDestroyed returns false, except after 
         *    the last shot which must return true.
         * 5. if we add a new Ship, then AreAllCraftsDestroyed should return false.
         */
        [TestMethod]
        public void Board_TestAreAllCraftsDestroyed()
        {
            Assert.IsTrue(board.AreAllCraftsDestroyed(), "numCrafts=destroyedCrafts=0");
            board.AddShip(galeon, new Coordinate(0, 1));
            Assert.IsFalse(board.AreAllCraftsDestroyed(), "numCrafts=1; destroyedCrafts=0");
            board.AddShip(fragata, new Coordinate(3, 1));
            Assert.IsFalse(board.AreAllCraftsDestroyed(), "numCrafts=2; destroyedCrafts=0");

            // destroying ship galeon
            for (int i = 2; i < 5; i++)
            {
                board.Hit(new Coordinate(2, i));
                Assert.IsFalse(board.AreAllCraftsDestroyed());
            }
            for (int i = 4; i < 6; i++)
            {
                board.Hit(new Coordinate(i, 3));
                Assert.IsFalse(board.AreAllCraftsDestroyed(), "numCrafts=2; destroyedCrafts=1");
            }
            board.Hit(new Coordinate(6, 3));
            Assert.IsTrue(board.AreAllCraftsDestroyed(), "numCrafts=destroyedCrafts=2");
            board.AddShip(galeon, new Coordinate(0, 5));
            Assert.IsFalse(board.AreAllCraftsDestroyed(), "numCrafts=3; destroyedCrafts=2");
        }

        /* It is checked:
         * 1. GetNeighborhood(Ship) for a Ship that has not been placed on the Board 
         *    must return an empty Set.
         * 2. GetNeighborhood(Ship, Coordinate) where the Ship goes outside the boundaries 
         *    of the Board. The set of neighbouring Coordinate only picks up those that 
         *    are inside the Board
         */
        [TestMethod]
        public void Board_TestGetNeighborhoodShipOutOfBounds()
        {
            HashSet<Coordinate> neighborhood = board.GetNeighborhood(galeon);
            // assert neighborhood is empty
            Assert.IsTrue(!neighborhood.Any());

            neighborhood = board.GetNeighborhood(galeon, new Coordinate(0, 7));
            Assert.AreEqual(7, neighborhood.Count);
            for (int i = 1; i < 4; i++)
                for (int j = 7; j < 11; j++)
                    if (j > 9 || ((j == 8 || j == 9) && i == 2))
                        Assert.IsFalse(neighborhood.Contains(new Coordinate(i, j)), $"x,y = {i},{j}");
                    else
                        Assert.IsTrue(neighborhood.Contains(new Coordinate(i, j)), $"x,y = {i},{j}");
        }

        /* GetNeighborhood(Ship) is checked where the Ship and all 
         * its neighbouring Coordinate neighbours are inside Board
         */
        [TestMethod]
        public void Board_TestGetNeighborhoodShipCompletelyIn1()
        {
            board.AddShip(fragata, new Coordinate(5, 1));
            HashSet<Coordinate> neighborhood = board.GetNeighborhood(fragata);
            Assert.AreEqual(12, neighborhood.Count);
            for (int i = 5; i < 10; i++)
                for (int j = 2; j < 4; j++)
                    if (j == 3 && i >= 6 && i <= 8)
                        Assert.IsFalse(neighborhood.Contains(new Coordinate(i, j)), $"x,y = {i},{j}");
                    else
                        Assert.IsTrue(neighborhood.Contains(new Coordinate(i, j)), $"x,y = {i},{j}");
        }

        /* a Ship is added to a board boundary. Check that getNeighborhood(Ship) 
         * picks up only those neighbouring positions that are inside the board
         */
        [TestMethod]
        public void Board_TestGetNeighborhoodShipCompletelyIn2()
        {
            board.AddShip(fragata, new Coordinate(6, -2));
            HashSet<Coordinate> neighborhood = board.GetNeighborhood(fragata);
            Assert.AreEqual(5, neighborhood.Count);
            for (int i = 6; i < 10; i++)
                for (int j = -2; j < 2; j++)
                    if ((j == 0 && i >= 7 && i <= 9) || j < 0)
                        Assert.IsFalse(neighborhood.Contains(new Coordinate(i, j)), $"x,y = {i},{j}");
                    else
                        Assert.IsTrue(neighborhood.Contains(new Coordinate(i, j)), $"x,y = {i},{j}");
        }

        /* It is verified that:
         * 1. getNeighborhood(Ship, Coordinate) returns an empty Set of Coordinates when the Ship and its neighbours 
         *    are all outside the Board.
         * 2. GetNeighborhood(Ship, Coordinate) returns only those neighbouring Coordinates that are inside the Board 
         *    for a Ship completely outside the Board. are inside the Board for a Ship completely outside the Board.
         */
        [TestMethod]
        public void Board_TestNeighborhoodShipCompletelyOutOfBounds()
        {
            HashSet<Coordinate> neighborhood = board.GetNeighborhood(galeon, new Coordinate(0, 10));
            // assert neighborhood is empty
            Assert.IsTrue(!neighborhood.Any());

            neighborhood = board.GetNeighborhood(galeon, new Coordinate(0, 9));
            for (int i = 1; i < 4; i++)
                for (int j = 9; j < 13; j++)
                    if (j > 9)
                        Assert.IsFalse(neighborhood.Contains(new Coordinate(i, j)), $"x,y = {i},{j}");
                    else
                        Assert.IsTrue(neighborhood.Contains(new Coordinate(i, j)), $"x,y = {i},{j}");
        }

        /* a board of size 5 is created without Ships. Check that what is returned 
         * by Show(true) and Show(false) is correct
         */
        [TestMethod]
        public void Board_TestShowBoardEmpty()
        {
            board = new Board(5);

            string hideShips = board.Show(false);
            Assert.AreEqual(sboardHide1, hideShips);

            string showShips = board.Show(true);
            Assert.AreEqual(sboardEmpty, showShips);
        }

        /* a board of size 5 is created. The 4 ships are added in the positions 
         * indicated in the static variable 'sboard' defined in SetUp().
         * Check that Show(false) returns the same as the static variable sboardHide1 
         * and that Show(true) returns the same as the content of the static variable 'sboard'
         */
        [TestMethod]
        public void Board_TestShowBoardWithShips()
        {
            board = new Board(5);

            board.AddShip(galeon, new Coordinate(-2, -1));
            board.AddShip(fragata, new Coordinate(1, -2));
            board.AddShip(goleta, new Coordinate(2, 1));
            board.AddShip(bergantin, new Coordinate(-1, 2));

            string hideShips = board.Show(false);
            Assert.AreEqual(sboardHide1, hideShips);

            string showShips = board.Show(true);
            Assert.AreEqual(sboard, showShips);
        }

        /* a Board of size 5 is created. The 4 Ships of the SetUp() are placed on it in the 
         * positions indicated in the static string "sboard". The positions of the 'galeon'
         * are triggered by sinking it.
         * The Show(true) method must return the same as the string 'sboardHits1'.
         * Ships 'goleta' and 'fragata' positions are fired on without sinking them and Show(true) 
         * is checked with 'sboardHits2'.
         * The 'bergantin is fired' upon and several shots are fired into the water. Show(true) is 
         * checked with 'sboardHits3'. Finally we compare Show(false) with 'sboardHide2'.
         */
        [TestMethod]
        public void Board_TestShowBoardWithShipsAndHits()
        {
            board = new Board(5);

            board.AddShip(galeon, new Coordinate(-2, -1));
            board.AddShip(fragata, new Coordinate(1, -2));
            board.AddShip(goleta, new Coordinate(2, 1));
            board.AddShip(bergantin, new Coordinate(-1, 2));

            // firing on the galeon, sinking it
            board.Hit(new Coordinate(0, 0));
            board.Hit(new Coordinate(0, 1));
            board.Hit(new Coordinate(0, 2));
            string showShips = board.Show(true);
            Assert.AreEqual(sboardHits1, showShips);

            // firing on goleta and fragata without sink them
            board.Hit(new Coordinate(4, 0));
            board.Hit(new Coordinate(4, 3));
            board.Hit(new Coordinate(4, 4));
            showShips = board.Show(true);
            Assert.AreEqual(sboardHits2, showShips);

            // firing on the bergantin
            board.Hit(new Coordinate(1, 4));

            // firing on the water
            board.Hit(new Coordinate(2, 2));
            board.Hit(new Coordinate(2, 3));
            board.Hit(new Coordinate(4, 1));

            showShips = board.Show(true);
            Assert.AreEqual(sboardHits3, showShips);

            showShips = board.Show(false);
            Assert.AreEqual(sboardHide2, showShips);
        }

        /* the 4 Ships from SetUp() are added and ToString() 
         * is checked with the correct output
         */
        [TestMethod]
        public void Board_TestToString1()
        {
            board.AddShip(galeon, new Coordinate(0, 1));
            board.AddShip(fragata, new Coordinate(5, 1));
            board.AddShip(goleta, new Coordinate(0, 5));
            board.AddShip(bergantin, new Coordinate(4, 3));
            Assert.AreEqual("Board 10; crafts: 4; destroyed: 0", board.ToString());
        }

        /* The example of the test Board_TestAreAllCraftsDestroyed() is taken and 
         * ToString() is interleaved to check that the outputs are correct
         */
        [TestMethod]
        public void Board_TestToString2()
        {
            board.AddShip(galeon, new Coordinate(0, 1));
            board.AddShip(fragata, new Coordinate(3, 1));

            // destroying ship galeon
            for (int i = 2; i < 5; i++)
            {
                board.Hit(new Coordinate(2, i));
            }
            Assert.AreEqual("Board 10; crafts: 2; destroyed: 1", board.ToString());

            for (int i = 4; i < 6; i++)
            {
                board.Hit(new Coordinate(i, 3));
                Assert.AreEqual("Board 10; crafts: 2; destroyed: 1", board.ToString());
            }

            board.Hit(new Coordinate(6, 3));
            Assert.AreEqual("Board 10; crafts: 2; destroyed: 2", board.ToString());
            board.AddShip(galeon, new Coordinate(0, 5));
            Assert.AreEqual("Board 10; crafts: 3; destroyed: 2", board.ToString());
        }

    }
}
