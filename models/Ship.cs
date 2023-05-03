namespace dam_battleship.models;

internal class Ship
{
    public static Ship[] DefaultShips =
    {
        new("Aircraft Carrier", new[,]
        {
            { 1, 1, 1, 1 },
            { 0, 0, 0, 1 }
        }),

        new("Battleship", new[,]
        {
            { 1, 1, 1, 1 }
        }),

        new("Submarine", new[,]
        {
            { 1, 1, 1 }
        }),

        new("Cruiser", new[,]
        {
            { 1, 1, 1 }
        }),

        new("Destroyer", new[,]
        {
            { 1, 1 }
        })
    };

    public Ship(string name, int[,] matrix)
    {
        this.Name = name;
        this.Matrix = matrix;
        Position = new Vector2(0, 0);
    }

    public Vector2 Position { get; set; }

    public Team? Team { get; set; }

    public string Name { get; }

    public int[,] Matrix { get; }

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