﻿namespace dam_battleship.models;

public class Team
{
    private static int _teamIndex;

    public Team(string name)
    {
        Id = _teamIndex;
        this.Name = name;

        _teamIndex++;
    }

    public int Id { get; }
    public string Name { get; }
}