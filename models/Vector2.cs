using dam_battleship.utils;

namespace dam_battleship.models;

public class Vector2
{
    public Vector2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

    public static Vector2 Random(int width = 100, int height = 100)
    {
        return new Vector2(SeededRandom.Next(0, width), SeededRandom.Next(0, height));
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return $"Vector2({X}, {Y})";
    }

    public static bool operator ==(Vector2 a, Vector2 b)
    {
        return a.X == b.X && a.Y == b.Y;
    }

    public static bool operator !=(Vector2 a, Vector2 b)
    {
        return !(a == b);
    }
}