using System.Diagnostics;
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

    public Ship? getShipAt(Vector2 position)
    {
        foreach (var ship in Ships)
        {
            if (ship.position == position) return ship;

            foreach (Vector2 shipPosition in ship.getPositions())
                if (shipPosition == position)
                    return ship;
        }

        return null;
    }

    public bool isPositionOccupied(Vector2 position)
    {
        var ship = getShipAt(position);

        return ship != null;
    }

    public char getCharAt(Vector2 position)
    {
        var ship = getShipAt(position);

        return ship != null
            ? ship.name.First()
            : ' ';
    }

    public bool isPostionValidForShip(Vector2 position, Ship ship)
    {
        if (position.x < 0 || position.x >= width) return false;
        if (position.y < 0 || position.y >= height) return false;

        foreach (Vector2 shipPosition in ship.getPositions())
        {
            var finalPosition = new Vector2(position.x + shipPosition.x, position.y + shipPosition.y);
            
            if (finalPosition.x < 0 || finalPosition.x >= width) return false;
            if (finalPosition.y < 0 || finalPosition.y >= height) return false;
            
            if (isPositionOccupied(finalPosition)) return false;
        }
        
        return true;
    }

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
}