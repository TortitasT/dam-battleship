namespace dam_battleship.models;

public class Ship
{
    public static Ship[] DefaultShips =
    {
        new Ship("Aircraft Carrier", new[,] { { 1, 1, 1, 1 }, { 0, 0, 0, 1 } }), new Ship("Battleship", new[,] { { 1, 1, 1, 1 } }),
        new Ship("Submarine", new[,] { { 1, 1, 1 } }), new Ship("Cruiser", new[,] { { 1, 1, 1 } }), new Ship("Destroyer", new[,] { { 1, 1 } })
    };

    public Ship(string name, int[,] matrix)
    {
        Name = name;
        Matrix = matrix;
        Position = new Vector2(0, 0);
    }

    public Vector2 Position { get; set; }

    public Team? Team { get; set; }

    public string Name { get; }

    public int[,] Matrix { get; set; }

    public override string ToString()
    {
        return $"{Name} at {Position}";
    }

    public Vector2[] GetPositions()
    {
        var positions = new List<Vector2>();
        for (var y = 0; y < Matrix.GetLength(0); y++)
        for (var x = 0; x < Matrix.GetLength(1); x++)
            if (Matrix[y, x] == 1)
                positions.Add(new Vector2(Position.X + x, Position.Y + y));
        return positions.ToArray();
    }
}