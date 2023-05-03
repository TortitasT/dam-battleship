namespace dam_battleship.models;

internal class Vector2
{
    public Vector2(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public int X { get; }
    public int Y { get; }

    public static Vector2 Random(int width, int height)
    {
        var random = new Random();
        return new Vector2(random.Next(width), random.Next(height));
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