using System.Text;

namespace dam_battleship.models;

public class Board
{
    public readonly List<Ship> Ships = new List<Ship>();

    public Board(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Width { get; }
    public int Height { get; }

    public Ship? GetShipAt(Vector2 position)
    {
        foreach (Ship ship in Ships)
        {
            if (ship.Position == position) return ship;

            foreach (Vector2 shipPosition in ship.GetPositions())
                if (shipPosition == position)
                    return ship;
        }

        return null;
    }

    public bool IsPositionOccupied(Vector2 position)
    {
        Ship? ship = GetShipAt(position);

        return ship != null;
    }

    public char GetCharAt(Vector2 position)
    {
        Ship? ship = GetShipAt(position);

        return ship != null
            ? ship.Name.First()
            : ' ';
    }

    public bool IsPositionOutOfBounds(Vector2 position)
    {
        if (position.X < 0 || position.X >= Width) return true;
        if (position.Y < 0 || position.Y >= Height) return true;
        return false;
    }

    public bool IsPositionValidForShip(Vector2 position, Ship ship)
    {
        if (IsPositionOutOfBounds(position)) return false;

        foreach (Vector2 shipPosition in ship.GetPositions())
        {
            Vector2 finalPosition = new Vector2(position.X + shipPosition.X, position.Y + shipPosition.Y);

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
                sb.Append(GetCharAt(new Vector2(x, y)));
                sb.Append(" ");
            }

            sb.Append("|\n");
        }

        return sb.ToString();
    }
}