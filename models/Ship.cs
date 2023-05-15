using System.Text;

namespace dam_battleship.models;

public class Ship
{
    public Ship(Orientation orientation, char character, string name)
    {
        Orientation = orientation;

        Shape = new int[][] {
            new int[] {
            0, 0, 0, 0, 0, // NORTH .....
            0, 0, 1, 0, 0, // ..#..
            0, 0, 1, 0, 0, // ..#..
            0, 0, 1, 0, 0, // ..#..
            0, 0, 0, 0, 0 // .....
            },
            new int[] {
            0, 0, 0, 0, 0, // EAST .....
            0, 0, 0, 0, 0, // .....
            0, 1, 1, 1, 0, // .###.
            0, 0, 0, 0, 0, // .....
            0, 0, 0, 0, 0 // .....
            },
            new int[] {
            0, 0, 0, 0, 0, // SOUTH .....
            0, 0, 1, 0, 0, // ..#..
            0, 0, 1, 0, 0, // ..#..
            0, 0, 1, 0, 0, // ..#..
            0, 0, 0, 0, 0 // .....
            },
            new int[] {
            0, 0, 0, 0, 0, // WEST .....
            0, 0, 0, 0, 0, // .....
            0, 1, 1, 1, 0, // .###.
            0, 0, 0, 0, 0, // .....
            0, 0, 0, 0, 0 // .....
            }
        };

        Character = char.ToUpper(character);

        Name = name;
    }

    public Coordinate? Position { get; set; }

    public CellStatus Status { get; set; }

    public Orientation Orientation { get; set; }

    public Team? Team { get; set; }

    public string Name { get; }

    public char Character { get; }

    public int[][] Shape { get; set; }

    public int[] Matrix
    {
        get => Shape[(int)Orientation];
    }

    public List<Coordinate> HitCoordinates { get; set; } = new List<Coordinate>();

    public override string ToString()
    {
        var title = $"{Name} ({Orientation})";

        var sb = new StringBuilder();

        sb.Append(title);

        sb.Append("\r\n -----");
        for (var i = 0; i < Matrix.Length; i++)
        {
            if (i % 5 == 0)
                sb.Append("\r\n|");

            sb.Append(Matrix[i] == 1 ? Character : ' ');

            if (i % 5 == 4)
                sb.Append("|");
        }
        sb.Append("\r\n -----");

        return sb.ToString();
    }

    public char GetSymbol()
    {
        return Character;
    }

    public string GetName()
    {
        return Name;
    }

    public Orientation GetOrientation()
    {
        return Orientation;
    }

    public Coordinate GetPosition()
    {
        return Position;
    }

    public int[][] GetShape()
    {
        return Shape;
    }

    public int GetShapeIndex(Coordinate coordinate)
    {
        return coordinate.X + (coordinate.Y * 5);
    }

    public void SetPosition(Coordinate coordinate)
    {
        Position = coordinate.Copy();
    }

    public bool IsShotDown()
    {
        if (Position is null) return false;

        return HitCoordinates.Count == GetPositions().Length;
    }

    public bool IsHit(Coordinate coordinate)
    {
        return HitCoordinates.Contains(coordinate);
    }

    public bool Hit(Coordinate coordinate)
    {
        if (Position is null) return false;

        if (IsHit(coordinate)) return false;

        if (!GetPositions().Contains(coordinate)) return false;

        HitCoordinates.Add(coordinate);
        return true;
    }

    public HashSet<Coordinate> GetAbsolutePositions()
    {
        return GetPositions().ToHashSet();
    }

    public HashSet<Coordinate> GetAbsolutePositions(Coordinate coordinate)
    {
        return GetPositions(coordinate).ToHashSet();
    }

    public Coordinate[] GetPositions()
    {
        return GetPositions(Position ?? new Coordinate(0, 0));
    }

    public Coordinate[] GetPositions(Coordinate coordinate)
    {
        var positions = new List<Coordinate>();

        for (var i = 0; i < Matrix.Length; i++)
            if (Matrix[i] == 1)
                positions.Add(new Coordinate(coordinate.X + (i % 5), coordinate.Y + (i / 5)));

        return positions.ToArray();
    }
}