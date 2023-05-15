namespace dam_battleship.models;

public class Ship
{
    public static Ship[] DefaultShips =
    {
        new Ship("Aircraft Carrier", new[,] { { 1, 1, 1, 1 }, { 0, 0, 0, 1 } }), new Ship("Battleship", new[,] { { 1, 1, 1, 1 } }),
        new Ship("Submarine", new[,] { { 1, 1, 1 } }), new Ship("Cruiser", new[,] { { 1, 1, 1 } }), new Ship("Destroyer", new[,] { { 1, 1 } })
    };

    public Ship(Orientation orientation, char character, string name) : this(name, new int[,] { { 1, 1, 1 } })
    {
        Orientation = orientation;
    }

    public Ship(string name, int[,] matrix)
    {
        Name = name;
        Matrix = matrix;
        Position = new Coordinate(0, 0);
    }

    public Coordinate Position { get; set; }

    public CellStatus Status { get; set; }

    public Orientation Orientation { get; set; }

    public Team? Team { get; set; }

    public string Name { get; }

    public int[,] Matrix { get; set; }

    public override string ToString()
    {
        return $"{Name} at {Position}";
    }

    public string GetName()
    {
        return Name;
    }

    public Orientation GetOrientation()
    {
        return Orientation;
    }

    public Coordinate GetPosition()
    {
        return Position;
    }

    public int[,] GetShape()
    {
        return Matrix;
    }

    public HashSet<Coordinate> GetAbsolutePositions()
    {
        return GetPositions().ToHashSet();
    }

    public Coordinate[] GetPositions()
    {
        var positions = new List<Coordinate>();
        for (var y = 0; y < Matrix.GetLength(0); y++)
            for (var x = 0; x < Matrix.GetLength(1); x++)
                if (Matrix[y, x] == 1)
                    positions.Add(new Coordinate(Position.X + x, Position.Y + y));
        return positions.ToArray();
    }
}