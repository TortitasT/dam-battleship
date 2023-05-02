namespace dam_battleship.models;

internal class Vector2
{
    public Vector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int x { get; }
    public int y { get; }

    public static Vector2 random(int width, int height)
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
        return base.ToString();
    }

    public static bool operator ==(Vector2 a, Vector2 b)
    {
        return a.x == b.x && a.y == b.y;
    }

    public static bool operator !=(Vector2 a, Vector2 b)
    {
        return !(a == b);
    }
}