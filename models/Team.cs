namespace dam_battleship.models;

internal class Team
{
    private static int teamIndex;

    public Team(string name)
    {
        id = teamIndex;
        this.name = name;

        teamIndex++;
    }

    private int id { get; }
    private string name { get; }
}