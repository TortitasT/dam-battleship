using System.Text;

namespace dam_battleship.models;

internal class Board
{
    public readonly List<Ship> Ships = new();

    public Board(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public int width { get; }
    public int height { get; }

    public override string? ToString()
    {
        var sb = new StringBuilder();

        for (var y = 0; y < height; y++)
        {
            sb.Append("|");
            for (var x = 0; x < width; x++)
            {
                sb.Append(" ");
                sb.Append(getCharAt(new Vector2(x, y)));
                sb.Append(" ");
            }

            sb.Append("|\n");
        }

        return sb.ToString();
    }

    public char getCharAt(Vector2 position)
    {
        foreach (var ship in Ships)
        {
            var character = ship.name.First();

            if (ship.position == position) return character;

            for (var k = 0; k < ship.matrix.GetLength(0); k++)
                for (var l = 0; l < ship.matrix.GetLength(1); l++)
                    if (ship.matrix[k, l] == 1)
                        if (ship.position.x + l == position.x && ship.position.y + k == position.y)
                            return character;
        }

        return ' ';
    }
}