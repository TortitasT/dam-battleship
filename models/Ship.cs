namespace dam_battleship.models;

internal class Ship
{
    public static Ship[] DEFAULT_SHIPS =
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
        this.name = name;
        this.matrix = matrix;
        position = new Vector2(0, 0);
    }

    public Vector2 position { get; set; }

    public Team? team { get; set; }

    public string name { get; }

    public int[,] matrix { get; }

    public override string ToString()
    {
        return $"{name} at {position}";
    }

    public Vector2[] getPositions()
    {
        var positions = new List<Vector2>();
        for (var y = 0; y < matrix.GetLength(0); y++)
        for (var x = 0; x < matrix.GetLength(1); x++)
                if (matrix[y, x] == 1)
                positions.Add(new Vector2(position.x + x, position.y + y));
        return positions.ToArray();
    }
}