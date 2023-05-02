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
}