namespace BattleShip.model;

public class Team
{
    private static int _teamIndex;

    public Team(string name)
    {
        Id = _teamIndex;
        Name = name;

        _teamIndex++;
    }

    public int Id { get; }
    public string Name { get; }

    public static void ResetIndex()
    {
        _teamIndex = 0;
    }
}