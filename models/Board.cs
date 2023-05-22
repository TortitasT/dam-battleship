using System.Diagnostics;
using System.Text;

namespace dam_battleship.models;

public class Board
{
    static readonly int MAX_BOARD_SIZE = 20;
    static readonly int MIN_BOARD_SIZE = 5;
    private static readonly char HIT_SYMBOL = '•';
    private static readonly char WATER_SYMBOL = ' ';
    private static readonly char NOTSEEN_SYMBOL = '?';

    public readonly List<Ship> Ships = new();

    private HashSet<Coordinate> seen = new(); // TODO: no tocar la nomenclatura aunque de aviso, hay un test que usa reflexion para leer esta propiedad.

    public Board(int size) : this(size, size) { }

    public Board(int width, int height)
    {
        var clampedWidth = ClampSizes(width, MIN_BOARD_SIZE, MAX_BOARD_SIZE);
        var clampedHeight = ClampSizes(height, MIN_BOARD_SIZE, MAX_BOARD_SIZE);

        Width = clampedWidth;
        Height = clampedHeight;
    }

    private static int ClampSizes(int size, int min, int max)
    {
        if (size < min)
            return min;

        if (size > max)
            return min; // TODO: weird

        return size;
    }

    public int Width { get; }
    public int Height { get; }

    public bool AddShip(Ship ship, Coordinate coordinate)
    {
        if (!IsPositionValidForShip(coordinate, ship)) return false;

        ship.Position = coordinate;
        ship.Status = CellStatus.WATER;
        Ships.Add(ship);

        return true;
    }

    public bool AreAllCraftsDestroyed()
    {
        if (Ships.Count == 0)
            return true;

        return Ships.All(ship => ship.Status == CellStatus.DESTROYED);
    }

    public int GetSize()
    {
        return Width;
    }

    public string Show(bool unveil)
    {
        var sb = new StringBuilder();

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                if (unveil || IsSeen(new Coordinate(x, y)))
                {
                    sb.Append(GetCharAt(new Coordinate(x, y), unveil));
                    continue;
                }

                sb.Append(NOTSEEN_SYMBOL);
            }

            if (y != Height - 1)
                sb.Append("\r\n");
        }

        return sb.ToString();
    }

    public bool IsSeen(Coordinate coordinate)
    {
        return seen.Contains(coordinate);
    }

    public bool CheckCoordinate(Coordinate coordinate)
    {
        return !IsPositionOutOfBounds(coordinate);
    }

    public Ship? GetShip(Coordinate coordinate)
    {
        return GetShipAt(coordinate);
    }

    public HashSet<Coordinate> GetNeighborhood(Ship ship)
    {
        if (!Ships.Contains(ship)) return new HashSet<Coordinate>();

        return GetNeighborhood(ship, ship.Position);
    }

    public HashSet<Coordinate> GetNeighborhood(Ship ship, Coordinate coordinate)
    {
        var copyShip = (Ship)ship.Clone();

        copyShip.Position = coordinate;

        var positions = copyShip.GetPositions();

        var neighborhood = new HashSet<Coordinate>();

        positions.ToList().ForEach(
            position =>
                position.GetNeighborhood().ToList().ForEach(
                    neighbourPosition =>
                    {
                        if (positions.Contains(neighbourPosition)) return;

                        if (IsPositionOutOfBounds(neighbourPosition)) return;

                        neighborhood.Add(neighbourPosition);
                    })
            );

        return neighborhood;
    }

    public CellStatus Hit(Coordinate coordinate)
    {
        seen.Add(coordinate);

        var ship = GetShipAt(coordinate);

        if (ship == null) return CellStatus.WATER;

        if (!ship.Hit(coordinate)) return CellStatus.WATER;

        if (!ship.IsShotDown())
            return CellStatus.HIT;

        GetNeighborhood(ship).ToList().ForEach(item => seen.Add(item));

        return CellStatus.DESTROYED;
    }

    public Ship? GetShipAt(Coordinate position)
    {
        foreach (Ship ship in Ships)
            foreach (Coordinate shipPosition in ship.GetPositions())
                if (shipPosition == position)
                    return ship;

        return null;
    }

    public bool IsPositionOccupied(Coordinate position)
    {
        Ship? ship = GetShipAt(position);

        return ship != null;
    }

    public char GetCharAt(Coordinate position, bool unveil = true)
    {
        Ship? ship = GetShipAt(position);

        if (ship == null)
            return WATER_SYMBOL;

        if (ship.IsShotDown() && !unveil)
            return ship.Character;

        if (ship.IsHit(position))
        {
            Debug.WriteLine("position");

            return HIT_SYMBOL;
        }

        return ship.Character;
    }

    public bool IsPositionOutOfBounds(Coordinate position)
    {
        if (position.X < 0 || position.X >= Width) return true;
        if (position.Y < 0 || position.Y >= Height) return true;
        return false;
    }

    public bool IsPositionValidForShip(Coordinate position, Ship ship)
    {

        foreach (Coordinate shipPosition in ship.GetPositions())
        {
            Coordinate finalPosition = new(position.X + shipPosition.X, position.Y + shipPosition.Y);

            if (IsPositionOutOfBounds(finalPosition)) return false;

            if (finalPosition.AdjacentCoordinates().Any(IsPositionOccupied))
                return false;

            if (IsPositionOutOfBounds(finalPosition)) return false;

            if (IsPositionOccupied(finalPosition)) return false;
        }

        return true;
    }

    public override string? ToString()
    {
#if false
        StringBuilder sb = new();

        for (var y = 0; y < Height; y++)
        {
            sb.Append("|");
            for (var x = 0; x < Width; x++)
            {
                sb.Append(" ");
                sb.Append(GetCharAt(new Coordinate(x, y)));
                sb.Append(" ");
            }

            sb.Append("|\n");
        }

        return sb.ToString();
#endif
        return $"Board {Width}; crafts: {Ships.Count}; destroyed: {Ships.Count(ship => ship.IsShotDown())}";
    }
}
