using dam_battleship.utils;

namespace dam_battleship.models;

public class Coordinate
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
    public Coordinate(Coordinate coordinate) : this(coordinate.X, coordinate.Y) { }

    public int X { set; get; }
    public int Y { set; get; }

    public static Coordinate Random(int width = 100, int height = 100)
    {
        return new Coordinate(SeededRandom.Next(0, width), SeededRandom.Next(0, height));
    }

    public void Set(int index, int value)
    {
        if (index != 0 && index != 1) { return; }

        if (index == 0)
        {
            X = value;
            return;
        }

        Y = value;
    }

    public int Get(int index)
    {
        return index == 0 ? X : Y;
    }

    public Coordinate Add(Coordinate coordinate)
    {
        return new(X + coordinate.X, Y + coordinate.Y);
    }

    public Coordinate Substract(Coordinate coordinate)
    {
        return new(X - coordinate.X, Y - coordinate.Y);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        if (!(obj is Coordinate)) return false;

        var coordinate = (Coordinate)obj;

        return coordinate.X == this.X && coordinate.Y == this.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public override string? ToString()
    {
        return $"({X}, {Y})";
    }

    public Coordinate Copy()
    {
        return new Coordinate(X, Y);
    }

    public HashSet<Coordinate> AdjacentCoordinates()
    {
        return GetNeighborhood();
    }

    public HashSet<Coordinate> GetNeighborhood()
    {
        var neighborhood = new HashSet<Coordinate>();

        for (int i = 0; i < 8; i++)
        {
            neighborhood.Add(new Coordinate(X + i, Y + i));
        }

        return neighborhood;
    }

    public static bool operator ==(Coordinate a, Coordinate b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    public static bool operator !=(Coordinate a, Coordinate b)
    {
        return !(a == b);
    }
}
