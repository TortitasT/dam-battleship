namespace dam_battleship.models;

internal class Team
{
    private static int _teamIndex;

    public Team(string name)
    {
        Id = _teamIndex;
        this.Name = name;

        _teamIndex++;
    }

    private int Id { get; }
    private string Name { get; }
}