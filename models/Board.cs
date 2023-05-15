using System.Text;

namespace dam_battleship.models;

public class Board
{
    public readonly List<Ship> Ships = new List<Ship>();

    private HashSet<Coordinate> Seen = new HashSet<Coordinate>();

    public Board(int size) : this(size, size) { }

    public Board(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Width { get; }
    public int Height { get; }

    public bool AddShip(Ship ship, Coordinate coordinate)
    {
        if (IsPositionOccupied(coordinate)) return false;

        ship.Position = coordinate;
        Ships.Add(ship);

        return true;
    }

    public bool AreAllCraftsDestroyed()
    {
        return Ships.Any(ship => ship.Status == CellStatus.DESTROYED);
    }

    public int GetSize()
    {
        return Width;
    }

    public string Show(bool unveil)
    {
        return "";
    }

    public bool IsSeen(Coordinate coordinate)
    {
        return Seen.Contains(coordinate);
    }

    public bool CheckCoordinate(Coordinate coordinate)
    {
        return IsPositionOccupied(coordinate);
    }

    public Ship? GetShip(Coordinate coordinate)
    {
        return GetShipAt(coordinate);
    }

    public HashSet<Coordinate> GetNeighborhood(Ship ship)
    {
        return GetNeighborhood(ship, ship.Position);
    }

    public HashSet<Coordinate> GetNeighborhood(Ship ship, Coordinate coordinate)
    {
        var copyShip = new Ship(ship.Name, ship.Matrix);

        copyShip.Position = coordinate;

        var positions = copyShip.GetPositions();

        var neighborhood = new HashSet<Coordinate>();

        positions.ToList().ForEach(
            position =>
                position.GetNeighborhood().ToList().ForEach(
                    neighbourPosition =>
                    {
                        if (positions.Contains(neighbourPosition)) return;

                        neighborhood.Add(neighbourPosition);
                    })
            );

        return neighborhood;
    }

    public CellStatus Hit(Coordinate coordinate)
    {
        Ship? ship = GetShipAt(coordinate);

        if (ship == null) return CellStatus.WATER;

        return ship.Status;
    }

    public Ship? GetShipAt(Coordinate position)
    {
        foreach (Ship ship in Ships)
        {
            if (ship.Position == position) return ship;

            foreach (Coordinate shipPosition in ship.GetPositions())
                if (shipPosition == position)
                    return ship;
        }

        return null;
    }

    public bool IsPositionOccupied(Coordinate position)
    {
        Ship? ship = GetShipAt(position);

        return ship != null;
    }

    public char GetCharAt(Coordinate position)
    {
        Ship? ship = GetShipAt(position);

        return ship != null
            ? ship.Name.First()
            : ' ';
    }

    public bool IsPositionOutOfBounds(Coordinate position)
    {
        if (position.X < 0 || position.X >= Width) return true;
        if (position.Y < 0 || position.Y >= Height) return true;
        return false;
    }

    public bool IsPositionValidForShip(Coordinate position, Ship ship)
    {
        if (IsPositionOutOfBounds(position)) return false;

        foreach (Coordinate shipPosition in ship.GetPositions())
        {
            Coordinate finalPosition = new Coordinate(position.X + shipPosition.X, position.Y + shipPosition.Y);

            if (IsPositionOutOfBounds(finalPosition)) return false;

            if (IsPositionOccupied(finalPosition)) return false;
        }

        return true;
    }

    public override string? ToString()
    {
        StringBuilder sb = new StringBuilder();

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
    }
}
